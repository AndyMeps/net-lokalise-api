namespace Lokalise.Api.Models
{
    public class ContributorLanguage
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

        public ContributorLanguage(string languageIso, bool isWritable)
        {
            LanguageIso = languageIso;
            IsWritable = isWritable;
        }

        internal ContributorLanguage(UserLanguage response)
        {
            LanguageId = response.LanguageId;
            LanguageIso = response.LanguageIso;
            LanguageName = response.LanguageName;
            IsWritable = response.IsWritable;
        }
    }
}
