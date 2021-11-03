using Lokalise.Api.Models;

namespace Lokalise.Api.Collections.Projects.Requests
{
    internal class ProjectLanguageDto
    {
        public string LangIso { get; }
        public string CustomIso { get; }

        internal ProjectLanguageDto(ProjectLanguage projectLanguage) : this(projectLanguage.LangIso, projectLanguage.CustomIso)
        {
            
        }

        internal ProjectLanguageDto(string langIso, string customIso)
        {
            LangIso = langIso;
            CustomIso = customIso;
        }
    }
}
