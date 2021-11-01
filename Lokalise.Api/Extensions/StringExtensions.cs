namespace Lokalise.Api.Extensions
{
    internal static class StringExtensions
    {
        internal static string IncludeBranchName(this string projectId, string branchName)
        {
            if (string.IsNullOrWhiteSpace(branchName) || projectId.Contains(":"))
                return projectId;

            return $"{projectId}:{branchName}";
        }
    }
}
