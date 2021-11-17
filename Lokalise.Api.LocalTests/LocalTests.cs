using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

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

            var json = File.ReadAllText(APP_CONFIG_PATH);
            
            var config = JsonSerializer.Deserialize<Config>(json);

            if (config == null)
                throw new InvalidOperationException("Could not load config.");

            return config;
        }
    }

    public abstract class LocalTests
    {
        protected Config Config { get; }

        protected ILokaliseClient LokaliseClient { get; }

        public LocalTests()
        {
            Config = Config.Load();

            LokaliseClient = new LokaliseClient(Config.ApiKey);
        }
    }
}
