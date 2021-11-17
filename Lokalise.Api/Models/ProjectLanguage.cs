namespace Lokalise.Api.Models
{
    public class ProjectLanguage
    {
        public string LangIso { get; }
        public string? CustomIso { get; }

        public ProjectLanguage(string langIso, string? customIso = null)
        {
            LangIso = langIso;
            CustomIso = customIso;
        }
    }
}