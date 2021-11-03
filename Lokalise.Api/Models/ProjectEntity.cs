namespace Lokalise.Api.Models
{
    public class ProjectEntity<T> where T : class
    {
        public string ProjectId { get; }
        protected T Entity { get; }

        internal ProjectEntity(string projectId, T entity)
        {
            ProjectId = projectId;
            Entity = entity;
        }
    }
}
