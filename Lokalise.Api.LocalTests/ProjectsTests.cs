using Lokalise.Api.Exceptions;
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
            await DeleteProjectIfExistsAsync(API_TEST_PROJECT_NAME);
            
            var newProject = await LokaliseClient.Projects.CreateAsync(API_TEST_PROJECT_NAME, new ProjectLanguage[]
            {
                new ProjectLanguage("en"),
                new ProjectLanguage("fr")
            });

            Assert.NotNull(newProject);
            Assert.NotNull(newProject?.ProjectId);
            Assert.Equal(API_TEST_PROJECT_NAME, newProject?.Name);
            Assert.Equal("en", newProject?.BaseLanguageIso);
            Assert.Collection(newProject?.Statistics?.Languages,
                lang => Assert.Equal("en", lang.LanguageIso),
                lang => Assert.Equal("fr", lang.LanguageIso));
        }

        [Fact]
        public async Task CreateAsync_ShouldThrowIfNoLanguages()
        {
            var projectName = API_TEST_PROJECT_NAME;
            await DeleteProjectIfExistsAsync(projectName);

            var ex = await Assert.ThrowsAsync<LokaliseApiException>(async () =>
            {
                var sameProject = await LokaliseClient.Projects.CreateAsync(projectName, Array.Empty<ProjectLanguage>());
            });

            Assert.Equal("`languages` parameter cannot be an empty array", ex.Message);
            Assert.NotNull(ex.Error);
            Assert.Equal(400, ex.Error.Code);
        }

        [Fact]
        public async Task EmptyAsync_ShouldReturnWhenEmpty()
        {
            var projectName = API_TEST_PROJECT_NAME;
            await DeleteProjectIfExistsAsync(projectName);

            var project = await LokaliseClient.Projects.CreateAsync(projectName, new ProjectLanguage[]
                {
                    new ProjectLanguage("en"),
                    new ProjectLanguage("fr")
                });

            Assert.NotNull(project);
            if (project?.ProjectId == null)
                return;

            var result = await LokaliseClient.Projects.EmptyAsync(project.ProjectId);

            Assert.NotNull(result);
            Assert.Equal(project.ProjectId, result?.ProjectId);
            Assert.True(result?.KeysDeleted);
        }

        [Fact]
        public async Task EmptyAsync_ShouldEmpty()
        {
            var projectName = API_TEST_PROJECT_NAME;
            await DeleteProjectIfExistsAsync(projectName);

            var project = await LokaliseClient.Projects.CreateAsync(projectName, new ProjectLanguage[]
                {
                    new ProjectLanguage("en"),
                    new ProjectLanguage("fr")
                });

            Assert.NotNull(project);
            if (project?.ProjectId == null)
                return;

            await LokaliseClient.Keys.CreateAsync(project.ProjectId, new NewKey("test-key", new string[] { "web" }));

            project = await LokaliseClient.Projects.RetrieveAsync(project.ProjectId);

            Assert.NotNull(project?.Statistics?.KeysTotal);
            Assert.NotEqual(0, project?.Statistics?.KeysTotal);

            if (project?.ProjectId == null)
                return;

            var result = await LokaliseClient.Projects.EmptyAsync(project.ProjectId);

            Assert.NotNull(result);
            Assert.Equal(project.ProjectId, result?.ProjectId);
            Assert.True(result?.KeysDeleted);

            project = await LokaliseClient.Projects.RetrieveAsync(project.ProjectId);
            Assert.Equal(0, project?.Statistics?.KeysTotal);
        }

        [Fact]
        public async Task UpdateAsync_ShouldUpdateName()
        {
            var originalProjectName = "bad-name-lokalise-api-test-project";
            var newProjectName = API_TEST_PROJECT_NAME;
            await DeleteProjectIfExistsAsync(originalProjectName);
            await DeleteProjectIfExistsAsync(newProjectName);

            var originalProject = await LokaliseClient.Projects.CreateAsync(originalProjectName, new ProjectLanguage[]
                {
                    new ProjectLanguage("en")
                });

            Assert.NotNull(originalProject?.ProjectId);
            if (originalProject?.ProjectId == null)
                return;

            var updateProject = await LokaliseClient.Projects.UpdateAsync(originalProject.ProjectId, newProjectName);

            Assert.NotNull(updateProject?.ProjectId);
            Assert.Equal(newProjectName, updateProject?.Name);
        }

        [Fact]
        public async Task UpdateAsync_ShouldUpdateDescription()
        {
            var projectName = API_TEST_PROJECT_NAME;
            await DeleteProjectIfExistsAsync(projectName);

            var originalProject = await LokaliseClient.Projects.CreateAsync(projectName, new ProjectLanguage[]
                {
                    new ProjectLanguage("en")
                }, cfg =>
                {
                    cfg.Description = "Initial Description";
                });

            Assert.NotNull(originalProject?.ProjectId);
            Assert.Equal("Initial Description", originalProject?.Description);
            if (originalProject?.ProjectId == null || originalProject?.Name == null)
                return;

            var updateProject = await LokaliseClient.Projects.UpdateAsync(originalProject.ProjectId, originalProject.Name, cfg =>
            {
                cfg.Description = "Update Description";
            });

            Assert.NotNull(updateProject?.ProjectId);
            Assert.Equal("Update Description", updateProject?.Description);
        }

        
    }
}