using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Lokalise.Api.Clients.Options;
using Lokalise.Api.Clients.Requests;
using Lokalise.Api.Models;

namespace Lokalise.Api.Clients
{
    public class FilesClient
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        internal FilesClient(HttpClient httpClient, JsonSerializerOptions jsonSerializerOptions)
        {
            _httpClient = httpClient;
            _jsonSerializerOptions = jsonSerializerOptions;
        }

        /// <summary>
        /// <para>Lists project files and associated key count. If there are some keys in the project that do not have a file association, they will be returned with filename __unassigned__.</para>
        /// <para>Requires read_files OAuth access scope.</para>
        /// </summary>
        public async Task<FileList> ListAsync(string projectId, Action<ListFilesOptions> options = null)
        {
            var cfg = new ListFilesOptions();
            options?.Invoke(cfg);
                
            var requestUri = $"projects/{ResolveProjectIdentifier(projectId, cfg?.Branch)}/files{cfg?.ToQueryString()}";
            var request = new HttpRequestMessage(HttpMethod.Get, requestUri);
            var result = await _httpClient.SendAsync(request);

            result.EnsureSuccessStatusCode();

            var json = await result.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<FileList>(json);
        }

        /// <summary>
        /// <para>Queues a localization file for import and returns a 202 or 302 response along with a Queued process object. Learn more. Requires Upload files admin right. Supported file types.</para>
        /// <para>Please note that the 302 response code is not currently used, but in the future it will be returned if the same file is already in the upload queue.</para>
        /// <para>Requires write_files OAuth access scope.</para>
        /// </summary>
        public Task<UploadedFile> UploadAsync(string projectId, FileInfo fileInfo, string filename, string langIso, Action<UploadFileOptions> options = null)
        {
            string base64 = ToBase64(fileInfo);

            return UploadAsync(projectId, base64, filename, langIso, options);
        }

        /// <summary>
        /// <para>Queues a localization file for import and returns a 202 or 302 response along with a Queued process object. Learn more. Requires Upload files admin right. Supported file types.</para>
        /// <para>Please note that the 302 response code is not currently used, but in the future it will be returned if the same file is already in the upload queue.</para>
        /// <para>Requires write_files OAuth access scope.</para>
        /// </summary>
        public async Task<UploadedFile> UploadAsync(string projectId, string data, string filename, string langIso, Action<UploadFileOptions> options = null)
        {
            var cfg = new UploadFileOptions();
            options?.Invoke(cfg);

            var request = new HttpRequestMessage(HttpMethod.Post, $"projects/{ResolveProjectIdentifier(projectId, cfg?.Branch)}/files/upload")
            {
                Content = new StringContent(
                    content: JsonSerializer.Serialize(new UploadFileRequest(data, filename, langIso, cfg), _jsonSerializerOptions),
                    encoding: Encoding.UTF8,
                    mediaType: "application/json")
            };

            var result = await _httpClient.SendAsync(request);

            result.EnsureSuccessStatusCode();

            var json = await result.Content.ReadAsStringAsync();

            var body = JsonSerializer.Deserialize<UploadedFile>(json);
            body.Location = result.Headers.Contains("Location")
                ? result.Headers.GetValues("Location").Single()
                : null;

            return body;
        }

        /// <summary>
        /// <para>Exports project files as a .zip bundle. Generated bundle will be uploaded to an Amazon S3 bucket, which will be stored there for 12 months available to download. As the bundle is generated and uploaded you would get a response with the URL to the file. Requires Download files admin right.</para>
        /// <para>There are two ways to group keys by filenames when you are exporting - either all keys to a single file per language or use the previously assigned filenames.</para>
        /// <para>Requires read_files OAuth access scope.</para>
        /// </summary>
        public async Task<DownloadedFiles> DownloadAsync(string projectId, string format, Action<DownloadFileOptions> options = null)
        {
            var cfg = new DownloadFileOptions();
            options?.Invoke(cfg);

            var request = new HttpRequestMessage(HttpMethod.Post, $"projects/{ResolveProjectIdentifier(projectId, cfg?.Branch)}/files/download")
            {
                Content = new StringContent(
                    content: JsonSerializer.Serialize(new DownloadFileRequest(format, cfg), _jsonSerializerOptions),
                    encoding: Encoding.UTF8,
                    mediaType: "application/json")
            };

            var result = await _httpClient.SendAsync(request);

            result.EnsureSuccessStatusCode();

            var json = await result.Content.ReadAsStringAsync();
            var body = JsonSerializer.Deserialize<DownloadedFiles>(json);

            return body;
        }

        private static string ToBase64(FileInfo fileInfo)
        {
            using var fileStream = fileInfo.OpenRead();
            using var memoryStream = new MemoryStream();

            fileStream.CopyTo(memoryStream);

            var bytes = memoryStream.ToArray();

            return Convert.ToBase64String(bytes);
        }

        private static string ResolveProjectIdentifier(string projectId, string branch)
        {
            if (string.IsNullOrWhiteSpace(branch))
                return projectId;

            return $"{projectId}:{branch}";
        }
    }
}
