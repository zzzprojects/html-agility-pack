using Nuke.Common.CI.GitHubActions;
using Nuke.Components;

[GitHubActions(
    "pr",
    GitHubActionsImage.WindowsLatest,
    OnPullRequestBranches = ["main", "master"],
    PublishArtifacts = false,
    InvokedTargets = [nameof(ICompile.Compile), nameof(ITest.Test)],
    CacheKeyFiles = []
)]
[GitHubActions(
    "build",
    GitHubActionsImage.WindowsLatest,
    OnPushBranches = ["master", "main"],
    OnPushTags = ["v*.*.*"],
    InvokedTargets = [nameof(ICompile.Compile), nameof(ITest.Test)],
    ImportSecrets = ["NUGET_API_KEY"],
    CacheKeyFiles = []
)]
public partial class Build;