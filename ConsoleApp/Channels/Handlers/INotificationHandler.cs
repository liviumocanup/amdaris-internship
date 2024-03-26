using ConsoleApp.Utilities;
using ConsoleApp.Validation;

namespace ConsoleApp.Channels.Handlers
{
    public interface INotificationHandler
    {
        void AddValidator(NotificationChannelType channelType, IInputValidator validator);
        string GetTarget(NotificationChannelType channelType, IUserInteraction userInteraction);
    }
}
