using Lokalise.Api.Configurations;

namespace Lokalise.Api.Collections.Comments.Configurations
{
    public class ListCommentsConfiguration : PagedConfiguration
    {
        public string? Branch { get; set; }

        internal ListCommentsConfiguration() { }
    }
}
