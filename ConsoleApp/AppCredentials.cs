using System.Text.Json;

public class AppCredentials
{
    public static string Username { get; private set; } = null!;
    public static string Password { get; private set; } = null!;
    public static string Host { get; private set; } = null!;
    public static int Port { get; private set; }
    private static readonly string _settingsFilename = "appsettings.json";

    static AppCredentials()
    {
        Load();
    }

    private static void Load()
    {
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), _settingsFilename);
        string jsonString = File.ReadAllText(filePath);
        using (JsonDocument doc = JsonDocument.Parse(jsonString))
        {
            var root = doc.RootElement;
            var emailSettings = root.GetProperty("EmailSettings");

            Username = EncryptSetting(emailSettings.GetProperty(nameof(Username)).GetString(), "Email username");
            Password = EncryptSetting(emailSettings.GetProperty(nameof(Password)).GetString(), "Email password");
            Host = GetRequiredSetting(emailSettings.GetProperty(nameof(Host)).GetString(), "SMTP host");
            Port = GetRequiredPort(emailSettings.GetProperty(nameof(Port)).GetInt32());
        }
    }

    private static string EncryptSetting(string? settingValue, string settingName)
    {
        if (string.IsNullOrEmpty(settingValue))
            throw new ArgumentException($"{settingName} is not specified in appsettings.json.");
        return CryptoManager.Encrypt(settingValue);
    }

    private static string GetRequiredSetting(string? value, string settingName)
    {
        if (string.IsNullOrEmpty(value))
            throw new ArgumentException($"{settingName} is not specified in appsettings.json.");
        return value;
    }

    private static int GetRequiredPort(int portValue)
    {
        if (portValue <= 0)
            throw new ArgumentException("Invalid or missing SMTP port in appsettings.json.");
        return portValue;
    }

}