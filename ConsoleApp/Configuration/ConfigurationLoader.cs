using System.Text.Json;

namespace ConsoleApp.Configuration
{
    public class ConfigurationLoader : IConfigurationLoader
    {
        private readonly JsonDocument _config;

        public ConfigurationLoader() : this("appsettings.json") { }

        public ConfigurationLoader(string settingsFilename)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), settingsFilename);
            string jsonString = File.ReadAllText(filePath);
            _config = JsonDocument.Parse(jsonString);
        }


        public string GetSetting(string section, string key)
        {
            var settingsSection = _config.RootElement.GetProperty(section);
            return settingsSection.GetProperty(key).GetString()!;
        }

        public int GetSettingInt(string section, string key)
        {
            var settingsSection = _config.RootElement.GetProperty(section);
            return settingsSection.GetProperty(key).GetInt32();
        }
    }
}
