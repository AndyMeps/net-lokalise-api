using Lokalise.Api.Configurations;

namespace Lokalise.Api.Collections.Contributors.Configurations
{
    public class ListContributorsConfiguration : PagedConfiguration
    {
        public string Branch { get; }

        internal ListContributorsConfiguration() { }
    }
}
