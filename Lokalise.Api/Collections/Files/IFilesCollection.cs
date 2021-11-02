﻿using Lokalise.Api.Collections.Files.Configurations;
using Lokalise.Api.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Lokalise.Api.Collections.Files
{
    public interface IFilesCollection
    {
        /// <summary>
        /// <para>Lists project files and associated key count. If there are some keys in the project that do not have a file association, they will be returned with filename __unassigned__.</para>
        /// <para>Requires read_files OAuth access scope.</para>
        /// </summary>
        public Task<FileList> ListAsync(string projectId, Action<ListFilesConfiguration> options = null);

        /// <summary>
        /// <para>Queues a localization file for import and returns a 202 or 302 response along with a Queued process object. Learn more. Requires Upload files admin right. Supported file types.</para>
        /// <para>Please note that the 302 response code is not currently used, but in the future it will be returned if the same file is already in the upload queue.</para>
        /// <para>Requires write_files OAuth access scope.</para>
        /// </summary>
        public Task<UploadedFile> UploadAsync(string projectId, FileInfo fileInfo, string filename, string langIso, Action<UploadFileConfiguration> options = null);

        /// <summary>
        /// <para>Queues a localization file for import and returns a 202 or 302 response along with a Queued process object. Learn more. Requires Upload files admin right. Supported file types.</para>
        /// <para>Please note that the 302 response code is not currently used, but in the future it will be returned if the same file is already in the upload queue.</para>
        /// <para>Requires write_files OAuth access scope.</para>
        /// </summary>
        public Task<UploadedFile> UploadAsync(string projectId, string data, string filename, string langIso, Action<UploadFileConfiguration> options = null);

        /// <summary>
        /// <para>Exports project files as a .zip bundle. Generated bundle will be uploaded to an Amazon S3 bucket, which will be stored there for 12 months available to download. As the bundle is generated and uploaded you would get a response with the URL to the file. Requires Download files admin right.</para>
        /// <para>There are two ways to group keys by filenames when you are exporting - either all keys to a single file per language or use the previously assigned filenames.</para>
        /// <para>Requires read_files OAuth access scope.</para>
        /// </summary>
        public Task<DownloadedFiles> DownloadAsync(string projectId, string format, Action<DownloadFileConfiguration> options = null);
    }
}