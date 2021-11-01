namespace Lokalise.Api.Clients
{
    public class ProjectLanguage
    {
        public string LangIso { get; private set; }
        public string CustomIso { get; private set; }

        public ProjectLanguage(string langIso, string customIso = null)
        {
            LangIso = langIso;
            CustomIso = customIso;
        }
    }
}