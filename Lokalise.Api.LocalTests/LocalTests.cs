using Lokalise.Api.Models;
using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Xunit;

namespace Lokalise.Api.LocalTests
{
    public class Config
    {
        [JsonPropertyName("apiKey")]
        public string ApiKey { get; init; } = string.Empty;

        public Config() { }

        public static Config Load()
        {
            const string APP_CONFIG_PATH = "appconfig.json";

            var json = System.IO.File.ReadAllText(APP_CONFIG_PATH);
            
            var config = JsonSerializer.Deserialize<Config>(json);

            if (config == null)
                throw new InvalidOperationException("Could not load config.");

            return config;
        }
    }

    public abstract class LocalTests
    {
        protected const string API_TEST_PROJECT_NAME = "lokalise-api-test-project";

        protected Config Config { get; }

        protected ILokaliseClient LokaliseClient { get; }

        public LocalTests()
        {
            Config = Config.Load();

            LokaliseClient = new LokaliseClient(Config.ApiKey);
        }

        protected async Task<Project> EnsureTestProjectAsync()
        {
            await DeleteProjectIfExistsAsync(API_TEST_PROJECT_NAME);

            var originalProject = await LokaliseClient.Projects.CreateAsync(
                name: API_TEST_PROJECT_NAME,
                languages: new ProjectLanguage[]
                {
                    new ProjectLanguage("en")
                },
                options: cfg =>
                {
                    cfg.Description = "Initial Description";
                });

            Assert.NotNull(originalProject);

            return originalProject!;
        }

        protected async Task DeleteProjectIfExistsAsync(string name)
        {
            var existsResult = await LokaliseClient.Projects.ListAsync(cfg =>
            {
                cfg.FilterNames = name;
            });

            var foundProject = existsResult?.Projects?.FirstOrDefault();
            if (foundProject?.ProjectId != null)
            {
                await LokaliseClient.Projects.DeleteAsync(foundProject.ProjectId);
            }
        }
    }
}
