namespace github_activity;

public class Actor
{
    public long Id { get; set; }
    public string Login { get; set; } = string.Empty;
    public string DisplayLogin { get; set; } = string.Empty;
    public string GravatarId { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public string AvatarUrl { get; set; } = string.Empty;
}