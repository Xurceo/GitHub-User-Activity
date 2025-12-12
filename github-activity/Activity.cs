using System.Text.Json;

namespace github_activity;

public class Activity
{
    public string Id { get; set; } = string.Empty;
    public GithubEvent Type { get; set; }
    public Actor Actor { get; set; } = new Actor();
    public Repo Repo { get; set; } = new Repo();
    public JsonElement Payload { get; set; }
    public bool Public { get; set; }
    public DateTime CreateAt { get; set; }
    public JsonElement? Org { get; set; }
}