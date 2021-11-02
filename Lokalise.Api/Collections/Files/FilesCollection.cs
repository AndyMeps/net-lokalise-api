using Lokalise.Api.Collections.Files.Configurations;
using Lokalise.Api.Collections.Files.Requests;
using Lokalise.Api.Extensions;
using Lokalise.Api.Models;
using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lokalise.Api.Collections.Files
{
    public class FilesCollection : BaseCollection, IFilesCollection
    {
        internal FilesCollection(
            HttpClient httpClient,
            JsonSerializerOptions jsonSerializerOptions)
            : base(httpClient, jsonSerializerOptions)
        {
        }

        /// <inheritdoc/>
        public Task<FileList> ListAsync(string projectId, Action<ListFilesConfiguration> options = null)
        {
            if (projectId is null)
                throw new ArgumentNullException(nameof(projectId));

            if (string.IsNullOrWhiteSpace(projectId))
                throw new ArgumentException("Project identifier is required to call ListAsync", nameof(projectId));

            var cfg = new ListFilesConfiguration();
            options?.Invoke(cfg);

            return GetListAsync<FileList>(
                requestUri: $"projects/{projectId.IncludeBranchName(cfg.Branch)}/files{cfg?.ToQueryString()}");
        }

        /// <inheritdoc />
        public Task<UploadedFile> UploadAsync(string projectId, FileInfo fileInfo, string filename, string langIso, Action<UploadFileConfiguration> options = null)
        {
            if (projectId is null)
                throw new ArgumentNullException(nameof(projectId));

            if (fileInfo is null)
                throw new ArgumentNullException(nameof(fileInfo));

            if (filename is null)
                throw new ArgumentNullException(nameof(filename));

            if (langIso is null)
                throw new ArgumentNullException(nameof(langIso));

            if (string.IsNullOrWhiteSpace(projectId))
                throw new ArgumentException("Project identifier is required to call UploadAsync", nameof(projectId));

            if (string.IsNullOrWhiteSpace(filename))
                throw new ArgumentException("Filename is required to call UploadAsync", nameof(filename));

            if (string.IsNullOrWhiteSpace(langIso))
                throw new ArgumentException("Language ISO is required to call UploadAsync", nameof(langIso));

            if (!fileInfo.Exists)
                throw new ArgumentException("File must exist to call UploadAsync", nameof(fileInfo));

            return UploadInternalAsync(projectId, fileInfo.ToBase64(), filename, langIso, options);
        }

        /// <inheritdoc/>
        public Task<UploadedFile> UploadAsync(string projectId, string data, string filename, string langIso, Action<UploadFileConfiguration> options)
        {
            if (projectId is null)
                throw new ArgumentNullException(nameof(projectId));

            if (data is null)
                throw new ArgumentNullException(nameof(data));

            if (filename is null)
                throw new ArgumentNullException(nameof(filename));

            if (langIso is null)
                throw new ArgumentNullException(nameof(langIso));

            if (string.IsNullOrWhiteSpace(projectId))
                throw new ArgumentException("Project identifier is required to call UploadAsync", nameof(projectId));

            if (string.IsNullOrWhiteSpace(filename))
                throw new ArgumentException("Filename is required to call UploadAsync", nameof(filename));

            if (string.IsNullOrWhiteSpace(langIso))
                throw new ArgumentException("Language ISO is required to call UploadAsync", nameof(langIso));

            if (string.IsNullOrWhiteSpace(data))
                throw new ArgumentException("Data is required to call UploadAsync", nameof(data));

            if (!Convert.TryFromBase64String(data, new Span<byte>(new byte[data.Length]), out var _))
                throw new ArgumentException("Data is not valid base64 content.", nameof(data));

            return UploadInternalAsync(projectId, data, filename, data, options);
        }

        /// <inheritdoc />
        public Task<DownloadedFiles> DownloadAsync(string projectId, string format, Action<DownloadFileConfiguration> options = null)
        {
            if (projectId is null)
                throw new ArgumentNullException(nameof(projectId));

            if (format is null)
                throw new ArgumentNullException(nameof(format));

            if (string.IsNullOrWhiteSpace(projectId))
                throw new ArgumentException("Project identifier is required to call DownloadAsync", nameof(projectId));

            if (string.IsNullOrWhiteSpace(format))
                throw new ArgumentException("Format is required to call DownloadAsync", nameof(projectId));

            var cfg = new DownloadFileConfiguration();
            options?.Invoke(cfg);

            return PostAsync<DownloadFileRequest, DownloadedFiles>(
                requestUri: $"projects/{projectId.IncludeBranchName(cfg.Branch)}/files/download",
                request: new DownloadFileRequest(format, cfg));
        }

        private Task<UploadedFile> UploadInternalAsync(string projectId, string data, string filename, string langIso, Action<UploadFileConfiguration> options = null)
        {
            var cfg = new UploadFileConfiguration();
            options?.Invoke(cfg);


            return PostAsync<UploadFileRequest, UploadedFile>(
                requestUri: $"projects/{projectId.IncludeBranchName(cfg.Branch)}/files/upload",
                request: new UploadFileRequest(data, filename, langIso, cfg));
        }
    }
}
