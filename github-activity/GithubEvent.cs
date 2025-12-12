using System.Runtime.Serialization;

namespace github_activity;

public enum GithubEvent
{
    [EnumMember(Value = "PushEvent")]
    PushEvent,

    [EnumMember(Value = "CreateEvent")]
    CreateEvent,

    [EnumMember(Value = "WatchEvent")]
    WatchEvent,

    [EnumMember(Value = "CommitCommentEvent")]
    CommitCommentEvent,

    [EnumMember(Value = "DeleteEvent")]
    DeleteEvent,

    [EnumMember(Value = "DiscussionEvent")]
    DiscussionEvent,

    [EnumMember(Value = "ForkEvent")]
    ForkEvent,

    [EnumMember(Value = "GollumEvent")]
    GollumEvent,

    [EnumMember(Value = "IssueCommentEvent")]
    IssueCommentEvent,

    [EnumMember(Value = "IssuesEvent")]
    IssuesEvent,

    [EnumMember(Value = "MemberEvent")]
    MemberEvent,

    [EnumMember(Value = "PublicEvent")]
    PublicEvent,

    [EnumMember(Value = "PullRequestEvent")]
    PullRequestEvent,

    [EnumMember(Value = "PullRequestReviewEvent")]
    PullRequestReviewEvent,

    [EnumMember(Value = "PullRequestReviewCommentEvent")]
    PullRequestReviewCommentEvent,

    [EnumMember(Value = "ReleaseEvent")]
    ReleaseEvent
}