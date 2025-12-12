using System.Net.Http;
using System.Threading.Tasks;
using System.CommandLine;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace github_activity;

class Program
{
    public static readonly Dictionary<GithubEvent, Func<string, int, string, string>> Templates =
        new()
        {
            { GithubEvent.PushEvent, (name, count, repo) => $"{name} pushed {count} commit{(count > 1 ? "s" : "")} to {repo}" },
            { GithubEvent.CreateEvent, (name, count, repo) => $"{name} created {count} new branch{(count > 1 ? "es" : "")} in {repo}" },
            { GithubEvent.WatchEvent, (name, count, repo) => $"{name} starred {repo}" },
            { GithubEvent.CommitCommentEvent, (name, count, repo) => $"{name} commented {count} time{(count > 1 ? "s" : "")} on commits in {repo}" },
            { GithubEvent.DeleteEvent, (name, count, repo) => $"{name} deleted {count} item{(count > 1 ? "s" : "")} in {repo}" },
            { GithubEvent.DiscussionEvent, (name, count, repo) => $"{name} started or updated {count} discussion{(count > 1 ? "s" : "")} in {repo}" },
            { GithubEvent.ForkEvent, (name, count, repo) => $"{name} forked {count} repository{(count > 1 ? "ies" : "")} from {repo}" },
            { GithubEvent.GollumEvent, (name, count, repo) => $"{name} updated {count} wiki page{(count > 1 ? "s" : "")} in {repo}" },
            { GithubEvent.IssueCommentEvent, (name, count, repo) => $"{name} commented {count} time{(count > 1 ? "s" : "")} on issues in {repo}" },
            { GithubEvent.IssuesEvent, (name, count, repo) => $"{name} created or updated {count} issue{(count > 1 ? "s" : "")} in {repo}" },
            { GithubEvent.MemberEvent, (name, count, repo) => $"{name} added or removed {count} member{(count > 1 ? "s" : "")} in {repo}" },
            { GithubEvent.PublicEvent, (name, count, repo) => $"{name} made {repo} public" },
            { GithubEvent.PullRequestEvent, (name, count, repo) => $"{name} opened or updated {count} pull request{(count > 1 ? "s" : "")} in {repo}" },
            { GithubEvent.PullRequestReviewEvent, (name, count, repo) => $"{name} reviewed {count} pull request{(count > 1 ? "s" : "")} in {repo}" },
            { GithubEvent.PullRequestReviewCommentEvent, (name, count, repo) => $"{name} commented {count} time{(count > 1 ? "s" : "")} on PRs in {repo}" },
            { GithubEvent.ReleaseEvent, (name, count, repo) => $"{name} published {count} release{(count > 1 ? "s" : "")} in {repo}" },
            
        };

    static async Task<int> Main(string[] args)
    {
        using var http = new HttpClient();

        http.DefaultRequestHeaders.UserAgent.ParseAdd("CSharpApp/1.0");

        var root = new RootCommand("Github user activity");

        var usernameArg = new Argument<string>("username")
        {
            Description = "Get activity of the user"
        };

        root.Arguments.Add(usernameArg);

        root.SetAction(async pr =>
        {
            var activities = new Dictionary<long, List<GithubEvent>>();
            var stringUsername = pr.GetValue(usernameArg);
            if (string.IsNullOrEmpty(stringUsername))
            {
                Console.WriteLine("Argument 'username' is empty");
            }
            else
            {
                try
                {
                    var url = $"https://api.github.com/users/{stringUsername}/events";
                    var json = await http.GetStringAsync(url);

                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                        ReadCommentHandling = JsonCommentHandling.Skip,
                        AllowTrailingCommas = true,
                        WriteIndented = false,
                        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                        Converters = { new JsonStringEnumConverter() },
                    };

                    var events = JsonSerializer.Deserialize<List<Activity>>(json, options);

                    if (events != null)
                    {
                        foreach (var ev in events)
                        {
                            var repoId = ev.Repo.Id;

                            if (!activities.TryGetValue(repoId, out var list))
                            {
                                list = [];
                                activities[repoId] = list;
                            }

                            activities[repoId].Add(ev.Type);
                        }

                        foreach (var key in activities.Keys)
                        {
                            var groups = activities[key]
                                .GroupBy(e => e)
                                .ToDictionary(g => g.Key, g => g.Count());

                            var repo = events.Find(ev => ev.Repo.Id == key)!.Repo.Name;
                            var username = events.First().Actor.Login;

                            foreach (var kv in groups)
                            {

                                if (Templates.TryGetValue(kv.Key, out var template))
                                {
                                    string message = template(username, kv.Value, repo);
                                    Console.WriteLine(message);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        });

        ParseResult parseResult = root.Parse(args);
        return await parseResult.InvokeAsync();
    }
}
