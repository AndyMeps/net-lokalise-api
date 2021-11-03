namespace Lokalise.Api.Collections.Branches.Requests
{
    internal class CreateBranchRequest
    {
        public string Name { get; private set; }

        internal CreateBranchRequest(string name)
        {
            Name = name;
        }
    }
}
