namespace ConsoleApp.Configuration
{
    public class SmsSettings : ISmsSettings
    {
        public SmsSettings(IConfigurationLoader configurationLoader)
        {
            string section = "SmsSettings";
            
            ApiKey = configurationLoader.GetSetting(section, "ApiKey");
            ApiSecret = configurationLoader.GetSetting(section, "ApiSecret");
            FromNumber = configurationLoader.GetSetting(section, "FromNumber");
        }

        public string ApiKey { get; }
        public string ApiSecret { get; }
        public string FromNumber { get; }
    }
}