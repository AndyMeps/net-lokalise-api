namespace Lokalise.Api
{
    public interface ILokaliseClient
    {
        public IProjectsClient Projects { get; }
        public IFilesClient Files { get; }
    }
}
