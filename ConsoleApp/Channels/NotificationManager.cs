namespace ConsoleApp.Channels
{
    public class NotificationManager : INotificationManager
    {
        private readonly Dictionary<NotificationChannelType, INotificationChannel> _notificationChannels;

        public NotificationManager()
        {
            _notificationChannels = new Dictionary<NotificationChannelType, INotificationChannel>();
        }

        public void AddChannel(NotificationChannelType channelType, INotificationChannel channel)
        {
            _notificationChannels[channelType] = channel;
        }

        public void Send(string to, string subject, string message, NotificationChannelType channelType)
        {
            if (_notificationChannels.TryGetValue(channelType, out INotificationChannel? channel))
            {
                channel?.Send(to, subject, message);
            }
            else
            {
                Console.WriteLine($"Channel {channelType} is not available. Notification was not sent.");
            }
        }
    }
}