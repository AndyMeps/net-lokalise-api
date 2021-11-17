using System.Collections.Generic;

namespace Lokalise.Api.Models
{
    public class NewScreenshot
    {
        /// <summary>
        /// Title of the screenshot.
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// Description of the screenshot.
        /// </summary>
        public string? Description { get; }

        /// <summary>
        /// List of screenshot tags.
        /// </summary>
        public IEnumerable<string>? Tags { get; }

        /// <summary>
        /// Base64 encoded screenshot (with leading image type 'data:image/jpeg;base64,').
        /// </summary>
        public string Data { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title">Title of the screenshot.</param>
        /// <param name="data">Base64 encoded screenshot (with leading image type 'data:image/jpeg;base64,').</param>
        /// <param name="description">Description of the screenshot.</param>
        /// <param name="tags">List of screenshot tags.</param>
        public NewScreenshot(string title, string data, string? description = null, IEnumerable<string>? tags = null)
        {
            Title = title;
            Description = description;
            Data = data;
            Tags = tags;
        }
    }
}
