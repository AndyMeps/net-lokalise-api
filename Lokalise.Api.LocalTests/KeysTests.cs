using Lokalise.Api.Constants;
using Lokalise.Api.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Lokalise.Api.LocalTests
{
    public class KeysTests : LocalTests
    {
        [Fact]
        public async Task ListAsync_ShouldListAllKeys()
        {
            // Arrange
            var testProject = await EnsureTestProjectAsync();

            var uploadResult = await LokaliseClient.Files.UploadAsync(
                testProject.ProjectId!,
                new FileInfo("Data/TestResourceFile.resx"),
                "Data/TestResourceFile.resx",
                "en",
                cfg =>
                {
                    cfg.TagInsertedKeys = true;
                    cfg.Tags = new List<string>
                    {
                        "test"
                    };
                });
            Thread.Sleep(TimeSpan.FromSeconds(10));

            // Act
            var result = await LokaliseClient.Keys.ListAsync(testProject.ProjectId!);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result!.ProjectId);
            Assert.Equal(1, result.Page);
            Assert.Equal(1, result.TotalCount);
            Assert.Collection(result.Keys, k =>
            {
                Assert.NotNull(k.KeyName);
                Assert.Null(k.Translations);
                Assert.Null(k.Screenshots);
                Assert.Equal(1, k.BaseWords);
                Assert.Equal(0, k.CharLimit);
                Assert.Equal("", k.Filenames!.Android);
                Assert.Equal("", k.Filenames!.iOS);
                Assert.Equal("", k.Filenames!.Web);
                Assert.Equal("Data/TestResourceFile.resx", k.Filenames!.Other);
                Assert.Equal("Key", k.KeyName!.Android);
                Assert.Equal("Key", k.KeyName!.iOS);
                Assert.Equal("Key", k.KeyName!.Web);
                Assert.Equal("Key", k.KeyName!.Other);
                Assert.Collection(k.Tags, t =>
                {
                    Assert.Equal("test", t);
                });
            });
        }

        [Fact]
        public async Task ListAsync_ShouldIncludeTranslationsWhenConfigured()
        {
            // Arrange
            var testProject = await EnsureTestProjectAsync();

            var uploadResult = await LokaliseClient.Files.UploadAsync(
                testProject.ProjectId!,
                new FileInfo("Data/TestResourceFile.resx"),
                "Data/TestResourceFile.resx",
                "en",
                cfg =>
                {
                    cfg.TagInsertedKeys = true;
                    cfg.Tags = new List<string>
                    {
                        "test"
                    };
                });
            Thread.Sleep(TimeSpan.FromSeconds(10));

            // Act
            var result = await LokaliseClient.Keys.ListAsync(testProject.ProjectId!, cfg =>
            {
                cfg.IncludeTranslations = true;
            });

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result!.ProjectId);
            Assert.Equal(1, result.Page);
            Assert.Equal(1, result.TotalCount);
            Assert.Collection(result.Keys, k =>
            {
                Assert.NotNull(k.Translations);
                Assert.Collection(k.Translations, t =>
                {
                    Assert.Equal("en", t.LanguageIso);
                    Assert.NotNull(t.TranslationId);
                    Assert.Equal("Value", t.Value);
                });
            });
        }

        [Fact]
        public async Task CreateAsync_ShouldAddToKeys()
        {
            // Arrange
            var testProject = await EnsureTestProjectAsync();

            // Act
            var result = await CreateSampleKey(testProject.ProjectId!);

            // Assert
            Assert.NotNull(result);
            Assert.Collection(result!.Keys, k =>
            {
                Assert.NotNull(k.KeyName);
                Assert.Equal("TestAddKey", k.KeyName!.Web);
                Assert.Collection(k.Translations, t =>
                {
                    Assert.Equal("TestAddValue", t.Value);
                });
                Assert.NotNull(k.Filenames);
                Assert.Equal("%LANG_ISO%.json", k.Filenames!.Web);
            });
        }

        [Fact]
        public async Task DeleteAsync_ShouldDeleteKey()
        {
            // Arrange
            var testProject = await EnsureTestProjectAsync();
            var keysResult = await CreateSampleKey(testProject.ProjectId!);

            // Act
            var result = await LokaliseClient.Keys.DeleteAsync(testProject.ProjectId!, keysResult!.Keys!.First().KeyId!.Value);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(testProject.ProjectId, result!.ProjectId);
            Assert.True(result!.KeyRemoved);
            Assert.Equal(0, result!.KeysLocked);
        }

        [Fact]
        public async Task DeleteAsync_ShouldDeleteKeys()
        {
            // Arrange
            var testProject = await EnsureTestProjectAsync();
            var keysResult = await CreateSampleKey(testProject.ProjectId!);
            var secondKeyResult = await LokaliseClient.Keys.CreateAsync(testProject.ProjectId!, new Models.NewKey("TestAddKeyTwo", new string[] { Platforms.Web }, filenames: new FileNames { Web = "%LANG_ISO%.json" }, translations: new NewTranslation[] { new NewTranslation("en", "TestAddValueTwo") }));

            // Act
            var result = await LokaliseClient.Keys.DeleteAsync(testProject.ProjectId!, new long[] { keysResult!.Keys!.First().KeyId!.Value, secondKeyResult!.Keys!.First().KeyId!.Value });

            // Assert
            Assert.NotNull(result);
            Assert.Equal(testProject.ProjectId, result!.ProjectId);
            Assert.True(result!.KeysRemoved);
            Assert.Equal(0, result!.KeysLocked);
        }

        [Fact]
        public async Task RetrieveAsync_ShouldGetKey()
        {
            // Arrange
            var testProject = await EnsureTestProjectAsync();
            var keysResult = await CreateSampleKey(testProject.ProjectId!);

            // Act
            var result = await LokaliseClient.Keys.RetrieveAsync(testProject.ProjectId!, keysResult!.Keys!.First().KeyId!.Value);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(testProject.ProjectId, result!.ProjectId);
            Assert.Equal("TestAddKey", result!.Key!.KeyName!.Web);
            Assert.Equal("%LANG_ISO%.json", result.Key!.Filenames!.Web);
            Assert.Collection(result!.Key.Translations, t =>
            {
                Assert.Equal("TestAddValue", t.Value);
            });
        }

        [Fact]
        public async Task UpdateAsync_ShouldUpdateKeyName()
        {
            // Arrange
            var testProject = await EnsureTestProjectAsync();
            var keysResult = await CreateSampleKey(testProject.ProjectId!);

            // Act
            var result = await LokaliseClient.Keys.UpdateAsync(testProject.ProjectId!, new UpdateKey(keysResult!.Keys!.First().KeyId!.Value)
            {
                KeyName = "TestUpdateKey"
            });

            // Assert
            Assert.NotNull(result);
            Assert.Equal(testProject.ProjectId, result!.ProjectId);
            Assert.Equal("TestUpdateKey", result!.Key!.KeyName!.Web);
        }

        [Fact]
        public async Task UpdateAsync_ShouldUpdateKeyTags()
        {
            // Arrange
            var testProject = await EnsureTestProjectAsync();
            var keysResult = await CreateSampleKey(testProject.ProjectId!);

            // Act
            var result = await LokaliseClient.Keys.UpdateAsync(testProject.ProjectId!, new UpdateKey(keysResult!.Keys!.First().KeyId!.Value)
            {
                Tags = new string[]
                {
                    "tagOne",
                    "tagTwo"
                }
            });

            // Assert
            Assert.NotNull(result);
            Assert.Equal(testProject.ProjectId, result!.ProjectId);
            Assert.Collection(result!.Key!.Tags, t =>
            {
                Assert.Equal("tagOne", t);
            }, t =>
            {
                Assert.Equal("tagTwo", t);
            });
        }

        [Fact]
        public async Task RetrieveAsync_ShouldHandleNotFound()
        {
            // Arrange
            var testProject = await EnsureTestProjectAsync();

            // Act
            var result = await LokaliseClient.Keys.RetrieveAsync(testProject.ProjectId!, 100);

            // Assert
            Assert.Null(result);
        }

        private async Task<KeyList?> CreateSampleKey(string projectId)
        {
            return await LokaliseClient.Keys.CreateAsync(projectId!, new Models.NewKey("TestAddKey", new string[] { Platforms.Web }, filenames: new FileNames { Web = "%LANG_ISO%.json" }, translations: new NewTranslation[] { new NewTranslation("en", "TestAddValue") }));
        }
    }
}
