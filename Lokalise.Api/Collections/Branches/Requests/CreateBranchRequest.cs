namespace Lokalise.Api.Collections.Branches.Requests
{
    internal class CreateBranchRequest
    {
        public string Name { get; private set; }

        public CreateBranchRequest(string name)
        {
            Name = name;
        }
    }
}
