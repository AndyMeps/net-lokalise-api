using System.Collections.Generic;
using Lokalise.Api.Models;

namespace Lokalise.Api.Collections.Keys.Configurations
{
    public class UpdateKeyConfiguration
    {
        /// <summary>
        /// Key identifier. For projects with enabled Per-platform key names, pass JSON encoded string with included ios, android, web and other string attributes.
        /// </summary>
        public string? KeyName { get; set; }

        /// <summary>
        /// Description of the key.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// List of platforms, enabled for this key. Possible values are ios, android, web and other.
        /// </summary>
        public IEnumerable<string>? Platforms { get; set; }

        /// <summary>
        /// An object containing key filename attribute for each platform.
        /// </summary>
        public FileNames? Filenames { get; set; }

        /// <summary>
        /// List of tags for this keys.
        /// </summary>
        public IEnumerable<string>? Tags { get; set; }

        /// <summary>
        /// Enable to merge specified tags with the current tags attached to the key.
        /// </summary>
        public bool? MergeTags { get; set; }

        /// <summary>
        /// Whether this key is plural.
        /// </summary>
        public bool? IsPlural { get; set; }

        /// <summary>
        /// Optional custom plural name (used in some formats).
        /// </summary>
        public string? PluralName { get; set; }

        /// <summary>
        /// Whether this key is hidden from non-admins (translators).
        /// </summary>
        public bool? IsHidden { get; set; }

        /// <summary>
        /// Whether this key is archived.
        /// </summary>
        public bool? IsArchived { get; set; }

        /// <summary>
        /// Optional context of the key (used with some file formats).
        /// </summary>
        public string? Context { get; set; }

        /// <summary>
        /// Maximum allowed number of characters in translations for this key.
        /// </summary>
        public long? CharLimit { get; set; }

        /// <summary>
        /// JSON encoded string containing custom attributes (if any).
        /// </summary>
        public string? CustomAttributes { get; set; }

        internal UpdateKeyConfiguration()
        {

        }
    }

}
