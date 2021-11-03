using Lokalise.Api.Collections.Files.Responses;

namespace Lokalise.Api.Models
{
    public class File
    {
        public string Filename { get; }

        public long KeyCount { get; }

        public override string ToString()
        {
            return Filename;
        }

        internal File(FileResponse response)
        {
            Filename = response.Filename;
            KeyCount = response.KeyCount;
        }
    }
}
