namespace Lokalise.Api.Models
{
    public class CustomTranslationStatus
    {
        /// <summary>
        /// A unique custom translation status identifier.
        /// </summary>
        public long StatusId { get; }

        /// <summary>
        /// Status title.
        /// </summary>
        public string? Title { get; }

        /// <summary>
        /// Hex color of the status.
        /// </summary>
        public string? Color { get; }
        
    }
}
