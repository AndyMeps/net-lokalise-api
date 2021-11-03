using Lokalise.Api.Collections.Contributors.Responses;

namespace Lokalise.Api.Models
{
    public class UserLanguage
    {
        /// <summary>
        /// Language ID.
        /// </summary>
        public long LanguageId { get; }

        /// <summary>
        /// Language code.
        /// </summary>
        public string LanguageIso { get; }

        /// <summary>
        /// Language name.
        /// </summary>
        public string LanguageName { get; }

        /// <summary>
        /// Whether the user has write access to the language.
        /// </summary>
        public bool IsWritable { get; }

        public UserLanguage(string languageIso, bool isWritable)
        {
            LanguageIso = languageIso;
            IsWritable = isWritable;
        }

        internal UserLanguage(UserLanguageResponse response)
        {
            LanguageId = response.LanguageId;
            LanguageIso = response.LanguageIso;
            LanguageName = response.LanguageName;
            IsWritable = response.IsWritable;
        }
    }
}
