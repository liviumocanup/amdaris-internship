using Microsoft.Extensions.Configuration;

public class AppCredentials
{
    public static string Username { get; private set; } = null!;
    public static string Password { get; private set; } = null!;
    public static string Host { get; private set; } = null!;
    public static int Port { get; private set; }

    static AppCredentials()
    {
        Load();
    }

    private static void Load()
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        var emailSettings = configuration.GetSection("EmailSettings");
        ValidateAndSetCredentials(emailSettings);
    }

    private static void ValidateAndSetCredentials(IConfigurationSection emailSettings)
    {
        Username = EncryptSetting(emailSettings["Username"], "Email username");
        Password = EncryptSetting(emailSettings["Password"], "Email password");
        Host = GetRequiredSetting(emailSettings["Host"], "SMTP host");
        Port = GetRequiredPort(emailSettings["Port"]);
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

    private static int GetRequiredPort(string? portValue)
    {
        if (string.IsNullOrEmpty(portValue) || !int.TryParse(portValue, out int port))
            throw new ArgumentException("Invalid or missing SMTP port in appsettings.json.");
        return port;
    }
}