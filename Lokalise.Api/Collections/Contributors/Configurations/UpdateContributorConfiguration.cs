using Lokalise.Api.Models;
using System.Collections.Generic;

namespace Lokalise.Api.Collections.Contributors.Configurations
{
    public class UpdateContributorConfiguration
    {
        public string? Branch { get; set; }
        public bool? IsAdmin { get; set; }
        public bool? IsReviewer { get; set; }
        public List<ContributorLanguage>? Languages { get; set; }
        public IEnumerable<string>? AdminRights { get; set; }

        internal UpdateContributorConfiguration() { }
    }
}
