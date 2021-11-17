using Lokalise.Api.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Lokalise.Api.LocalTests
{
    public class ProjectsTests : LocalTests
    {
        [Fact]
        public async Task ListAsync_ShouldIncludeBasicDetails()
        {
            var result = await LokaliseClient.Projects.ListAsync();

            Assert.NotNull(result);
            Assert.All(result?.Projects, r => {
                Assert.NotNull(r.ProjectId);
                Assert.NotNull(r.Name);
                Assert.NotNull(r.CreatedByEmail);
            });
        }

        [Fact]
        public async Task ListAsync_ShouldNotIncludeSettings_WhenConfigIsFalse()
        {
            var result = await LokaliseClient.Projects.ListAsync(cfg =>
            {
                cfg.IncludeSettings = false;
            });

            Assert.All(result?.Projects, r =>
            {
                Assert.Null(r.Settings);
            });
        }

        [Fact]
        public async Task ListAsync_ShouldIncludeSettings_WhenConfigIsTrue()
        {
            var result = await LokaliseClient.Projects.ListAsync(cfg =>
            {
                cfg.IncludeSettings = true;
            });

            Assert.All(result?.Projects, r =>
            {
                Assert.NotNull(r.Settings);
            });
        }

        [Fact]
        public async Task ListAsync_ShouldNotIncludeStatistics_WhenConfigIsFalse()
        {
            var result = await LokaliseClient.Projects.ListAsync(cfg =>
            {
                cfg.IncludeStatistics = false;
            });

            Assert.All(result?.Projects, r =>
            {
                Assert.Null(r.Statistics);
            });
        }

        [Fact]
        public async Task ListAsync_ShouldOnlyReturnMatchingProject_WhenFilterNames()
        {
            var result = await LokaliseClient.Projects.ListAsync(cfg =>
            {
                cfg.FilterNames = "VT-Identity";
            });

            Assert.Single(result?.Projects);
        }

        [Fact]
        public async Task RetrieveAsync_ShouldReturn()
        {
            var result = await LokaliseClient.Projects.ListAsync();
            var firstProject = result?.Projects?.FirstOrDefault();

            Assert.NotNull(firstProject);

            if (firstProject?.ProjectId == null)
                return;

            var retrieveResult = await LokaliseClient.Projects.RetrieveAsync(firstProject.ProjectId);
            Assert.NotNull(retrieveResult);
            if (retrieveResult == null)
                return;

            Assert.Equal(firstProject.ProjectId, retrieveResult.ProjectId);
        }

        [Fact]
        public async Task CreateAsync_ShouldCreate()
        {
            await DeleteProjectIfExistsAsync("lokalise-api-test-project");
            
            var newProject = await LokaliseClient.Projects.CreateAsync("lokalise-api-test-project", new ProjectLanguage[]
            {
                new ProjectLanguage("en"),
                new ProjectLanguage("fr")
            });

            Assert.NotNull(newProject);
            Assert.NotNull(newProject?.ProjectId);
            Assert.Equal("lokalise-api-test-project", newProject?.Name);
            Assert.Equal("en", newProject?.BaseLanguageIso);
            Assert.Collection(newProject?.Statistics?.Languages,
                lang => Assert.Equal("en", lang.LanguageIso),
                lang => Assert.Equal("fr", lang.LanguageIso));
        }

        private async Task DeleteProjectIfExistsAsync(string name)
        {
            var existsResult = await LokaliseClient.Projects.ListAsync(cfg =>
            {
                cfg.FilterNames = name;
            });

            var foundProject = existsResult?.Projects?.First();
            if (foundProject?.ProjectId != null)
            {
                await LokaliseClient.Projects.DeleteAsync(foundProject.ProjectId);
            }
        }
    }
}