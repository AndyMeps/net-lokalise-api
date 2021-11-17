using System;
using System.Collections.Generic;

namespace Lokalise.Api.Models
{
    public class Screenshot
    {
        /// <summary>
        /// A unique identifier of the screenshot.
        /// </summary>
        public long ScreenshotId { get; }

        /// <summary>
        /// List of key identifiers, the screenshot is attached to.
        /// </summary>
        public IEnumerable<long> KeyIds { get; }

        /// <summary>
        /// Link to the screenshot.
        /// </summary>
        public string Url { get; }

        /// <summary>
        /// Screenshot title.
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// Description of the screenshot.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// List of screenshot tags.
        /// </summary>
        public IEnumerable<string> Tags { get; }

        /// <summary>
        /// Width of the screenshot, in pixels.
        /// </summary>
        public long Width { get; }

        /// <summary>
        /// Height of the screenshot, in pixels.
        /// </summary>
        public long Height { get; }

        /// <summary>
        /// Creation date of the screenshot.
        /// </summary>
        public DateTime CreatedAt { get; }
    }
}
