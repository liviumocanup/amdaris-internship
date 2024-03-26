namespace ConsoleApp.Configuration
{
    public interface ISmsSettings
    {
        string ApiKey { get; }
        string ApiSecret { get; }
        string FromNumber { get; }
    }
}