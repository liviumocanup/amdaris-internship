namespace ConsoleApp.Channels
{
    public interface INotificationChannel
    {
        void Send(string to, string subject, string message);
    }
}