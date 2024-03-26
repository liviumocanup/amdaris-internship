namespace ConsoleApp.Configuration
{
    public interface IConfigurationLoader
    {
        string GetSetting(string section, string key);
        int GetSettingInt(string section, string key);
    }
}