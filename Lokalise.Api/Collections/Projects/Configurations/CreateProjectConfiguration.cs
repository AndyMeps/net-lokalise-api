using Lokalise.Api.Models;
using System.Collections.Generic;

namespace Lokalise.Api.Collections.Projects.Configurations
{
    public class CreateProjectConfiguration
    {
        public long? TeamId { get; set; }
        public string Description { get; set; }
        public List<ProjectLanguage> Languages { get; set; } = new List<ProjectLanguage>();
        public string BaseLangIso { get; set; }
        public string ProjectType { get; set; }

        internal CreateProjectConfiguration()
        {

        }
    }
}