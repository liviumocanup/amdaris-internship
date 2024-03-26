namespace ConsoleApp.Configuration
{
    public interface IEmailSettings
    {
        string Username { get; }
        string Password { get; }
        string Host { get; }
        int Port { get; }
    }
}
