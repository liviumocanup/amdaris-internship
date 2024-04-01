namespace ConsoleApp.Channels.Manager
{
    public interface INotificationManager
    {
        void AddChannel(NotificationChannelType channelType, INotificationChannel channel);
        void Send(string to, string subject, string message, NotificationChannelType channelType);
    }
}