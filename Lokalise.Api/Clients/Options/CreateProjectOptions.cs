using System.Collections.Generic;

namespace Lokalise.Api.Clients
{
    public class CreateProjectOptions
    {
        public long? TeamId { get; set; }
        public string Description { get; set; }
        public List<ProjectLanguage> Languages { get; set; } = new List<ProjectLanguage>();
        public string BaseLangIso { get; set; }
        public string ProjectType { get; set; }
    }

    public class UpdateProjectOptions
    {
        public string Description { get; set; }
    }
}