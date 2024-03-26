namespace ConsoleApp.Configuration
{
    public class EmailSettings : IEmailSettings
    {
        public EmailSettings(IConfigurationLoader configurationLoader)
        {
            string section = "EmailSettings";
            
            Username = configurationLoader.GetSetting(section, "Username");
            Password = configurationLoader.GetSetting(section, "Password");
            Host = configurationLoader.GetSetting(section, "Host");
            Port = configurationLoader.GetSettingInt(section, "Port");
        }

        public string Username { get; }
        public string Password { get; }
        public string Host { get; }
        public int Port { get; }
    }
}