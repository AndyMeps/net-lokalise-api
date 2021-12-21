using Lokalise.Api.Exceptions;
using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Lokalise.Api.LocalTests
{
    public class FilesTests : LocalTests
    {
        [Fact]
        public async Task ListAsync_ShouldListAllFiles()
        {
            var result = await LokaliseClient.Files.ListAsync("43805703618a5ac464aaa7.81101140");
        }

        [Fact]
        public async Task ListAsync_ShouldFilter()
        {
            // Arrange, Act
            var result = await LokaliseClient.Files.ListAsync("43805703618a5ac464aaa7.81101140", cfg =>
            {
                cfg.FilterFilename = "_unassigned_";
            });

            // Assert
            Assert.NotNull(result);
            Assert.Collection(result!.Files, f => Assert.Equal("__unassigned__", f.Filename));
        }

        [Fact]
        public async Task UploadAsync_JsonStringShouldUpload()
        {
            // Arrange
            var testProject = await EnsureTestProjectAsync();

            Assert.NotNull(testProject.ProjectId);

            // Act
            var uploadResult = await LokaliseClient.Files.UploadAsync(testProject.ProjectId!, Convert.ToBase64String(Encoding.UTF8.GetBytes("{ \"key\": \"value\" }")), "test-file.json", "en");

            // Assert
            Assert.NotNull(uploadResult);
            Assert.Equal(uploadResult!.ProjectId, testProject.ProjectId);
            Assert.NotNull(uploadResult!.Location);
            Assert.NotNull(uploadResult!.Process);
        }

        [Fact]
        public async Task UploadAsync_ResxFileShouldUpload()
        {
            // Arrange
            var testProject = await EnsureTestProjectAsync();

            Assert.NotNull(testProject.ProjectId);

            // Act
            var uploadResult = await LokaliseClient.Files.UploadAsync(testProject.ProjectId!, new FileInfo("Data/TestResourceFile.resx"), "Data/TestResourceFile.resx", "en");

            // Assert
            Assert.NotNull(uploadResult);
            Assert.Equal(uploadResult!.ProjectId, testProject.ProjectId);
            Assert.NotNull(uploadResult!.Location);
            Assert.NotNull(uploadResult!.Process);
        }

        [Fact]
        public async Task DownloadAsync_JsonStringShouldDownload()
        {
            // Arrange
            var testProject = await EnsureTestProjectAsync();

            Assert.NotNull(testProject.ProjectId);

            var uploadResult = await LokaliseClient.Files.UploadAsync(testProject.ProjectId!, Convert.ToBase64String(Encoding.UTF8.GetBytes("{ \"key\": \"value\" }")), "test-file.json", "en");

            Assert.NotNull(uploadResult);
            Assert.Equal(uploadResult!.ProjectId, testProject.ProjectId);
            Assert.NotNull(uploadResult!.Location);
            Assert.NotNull(uploadResult!.Process);

            Thread.Sleep(TimeSpan.FromSeconds(5));

            // Act
            var downloadResult = await LokaliseClient.Files.DownloadAsync(testProject.ProjectId!, "json");

            // Assert
            Assert.NotNull(downloadResult);
            Assert.NotNull(downloadResult!.BundleUrl);
            Assert.Equal(testProject.ProjectId, downloadResult.ProjectId);
        }

        [Fact]
        public async Task UploadAsync_ResxFileJsonDownloadShouldThrow()
        {
            // Arrange
            var testProject = await EnsureTestProjectAsync();

            Assert.NotNull(testProject.ProjectId);

            var uploadResult = await LokaliseClient.Files.UploadAsync(testProject.ProjectId!, new FileInfo("Data/TestResourceFile.resx"), "Data/TestResourceFile.resx", "en");

            Assert.NotNull(uploadResult);
            Assert.Equal(uploadResult!.ProjectId, testProject.ProjectId);
            Assert.NotNull(uploadResult!.Location);
            Assert.NotNull(uploadResult!.Process);

            Thread.Sleep(TimeSpan.FromSeconds(5));

            // Act, Assert
            await Assert.ThrowsAsync<LokaliseDownloadException>(async () =>
            {
                await LokaliseClient.Files.DownloadAsync(testProject.ProjectId!, "json");
            });
        }
    }
}
