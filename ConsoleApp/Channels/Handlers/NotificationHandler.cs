using ConsoleApp.Utilities;
using ConsoleApp.Validation;

namespace ConsoleApp.Channels.Handlers
{
    public class NotificationHandler : INotificationHandler
    {
        private readonly Dictionary<NotificationChannelType, IInputValidator> _validators;

        public NotificationHandler()
        {
            _validators = new Dictionary<NotificationChannelType, IInputValidator>();
        }

        public void AddValidator(NotificationChannelType channelType, IInputValidator validator)
        {
            _validators[channelType] = validator;
        }

        public string GetTarget(NotificationChannelType channelType, IUserInteraction userInteraction)
        {
            if (_validators.TryGetValue(channelType, out IInputValidator? validator))
            {
                return userInteraction.PromptForInput($"Enter the target's {channelType}:", validator.IsValid);
            }
            else
            {
                throw new InvalidOperationException($"Validator for {channelType} is not registered. Notification was not sent.");
            }
        }
    }
}
