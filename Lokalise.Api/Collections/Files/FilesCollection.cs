using Lokalise.Api.Collections.Files.Configurations;
using Lokalise.Api.Collections.Files.Requests;
using Lokalise.Api.Collections.Files.Responses;
using Lokalise.Api.Extensions;
using Lokalise.Api.Models;
using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lokalise.Api.Collections.Files
{
    internal class FilesCollection : BaseCollection, IFilesCollection
    {
        internal FilesCollection(
            HttpClient httpClient,
            JsonSerializerOptions jsonSerializerOptions)
            : base(httpClient, jsonSerializerOptions)
        {
        }

        /// <inheritdoc/>
        public async Task<FileList> ListAsync(string projectId, Action<ListFilesConfiguration> options = null)
        {
            var cfg = new ListFilesConfiguration();
            options?.Invoke(cfg);

            var result = await GetListAsync<FileListResponse>(
                requestUri: $"{FilesUri(projectId, cfg.Branch)}{cfg?.ToQueryString()}");

            return new FileList(result);
        }

        /// <inheritdoc />
        public Task<UploadedFile> UploadAsync(string projectId, FileInfo fileInfo, string filename, string langIso, Action<UploadFileConfiguration> options = null)
        {
            return UploadInternalAsync(projectId, fileInfo.ToBase64(), filename, langIso, options);
        }

        /// <inheritdoc/>
        public Task<UploadedFile> UploadAsync(string projectId, string data, string filename, string langIso, Action<UploadFileConfiguration> options)
        {
            return UploadInternalAsync(projectId, data, filename, data, options);
        }

        /// <inheritdoc />
        public async Task<DownloadedFiles> DownloadAsync(string projectId, string format, Action<DownloadFileConfiguration> options = null)
        {
            var cfg = new DownloadFileConfiguration();
            options?.Invoke(cfg);

            var result = await PostAsync<DownloadFileRequest, DownloadedFilesResponse>(
                requestUri: $"{FilesUri(projectId, cfg.Branch)}/download",
                request: new DownloadFileRequest(format, cfg));

            return new DownloadedFiles(result);
        }

        private async Task<UploadedFile> UploadInternalAsync(string projectId, string data, string filename, string langIso, Action<UploadFileConfiguration> options = null)
        {
            var cfg = new UploadFileConfiguration();
            options?.Invoke(cfg);


            var result = await PostAsync<UploadFileRequest, UploadedFileResponse>(
                requestUri: $"{FilesUri(projectId, cfg.Branch)}/upload",
                request: new UploadFileRequest(data, filename, langIso, cfg));

            return new UploadedFile(result);
        }

        private string FilesUri(string projectId, string branchName = null) => $"projects/{projectId.IncludeBranchName(branchName)}/files";
    }
}
