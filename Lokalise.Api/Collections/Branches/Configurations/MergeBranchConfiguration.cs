namespace Lokalise.Api.Collections.Branches.Configurations
{
    public class MergeBranchConfiguration
    {
        public string ForceConflictResolveUsing { get; set; }
        public long? TargetBranchId { get; set; }

        internal MergeBranchConfiguration() { }
    }
}