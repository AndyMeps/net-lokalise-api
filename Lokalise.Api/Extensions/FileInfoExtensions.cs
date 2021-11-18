using System;
using System.IO;

namespace Lokalise.Api.Extensions
{
    internal static class FileInfoExtensions
    {
        internal static string ToBase64(this FileInfo fileInfo)
        {
            using var fileStream = fileInfo.OpenRead();
            using var memoryStream = new MemoryStream();

            fileStream.CopyTo(memoryStream);

            var bytes = memoryStream.ToArray();

            return Convert.ToBase64String(bytes);
        }
    }
}
