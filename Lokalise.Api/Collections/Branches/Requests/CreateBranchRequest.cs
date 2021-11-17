namespace Lokalise.Api.Collections.Branches.Requests
{
    internal class CreateBranchRequest
    {
        public string Name { get; }

        internal CreateBranchRequest(string name)
        {
            Name = name;
        }
    }
}
