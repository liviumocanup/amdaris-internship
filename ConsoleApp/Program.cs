using ConsoleApp.Channels;
using ConsoleApp.Utilities;
using ConsoleApp.Configuration;
using ConsoleApp.Validation;
using ConsoleApp.Channels.Handlers;

class Program
{
    static void Main(string[] args)
    {
        string instructions = "Please type what kind of notification do you want to send:\n" +
            "0. Email\n" +
            "1. SMS\n" +
            "2. Push Notification\n" +
            "Q. Leave\n" +
            "Select multiple options by separating them with a comma (e.g. 1,2).";

        IUserInteraction userInteraction = new UserInteraction();
        NotificationManager notificationManager = SetupNotificationManager();
        INotificationHandler notificationHandler = SetupNotificationHandler();

        Console.Write("Welcome to the Notification Sender! ");

        string target = "";
        string subject = "";
        string message = "";

        do
        {
            Console.WriteLine(instructions);
            List<NotificationChannelType> selectedChannelTypes = userInteraction.SelectChannels();

            if (selectedChannelTypes.Count > 0)
            {
                subject = userInteraction.PromptForInput("Enter the subject of the notification:", s => !string.IsNullOrWhiteSpace(s) && s.Length <= 100);
                message = userInteraction.PromptForInput("Enter the message of the notification:", m => !string.IsNullOrWhiteSpace(m) && m.Length <= 500);
            }

            foreach (var channelType in selectedChannelTypes)
            {
                try
                {
                    target = notificationHandler.GetTarget(channelType, userInteraction);
                    notificationManager.Notify(target, subject, message, channelType);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }

        } while (userInteraction.AskContinue());

    }

    static NotificationManager SetupNotificationManager()
    {
        // Initialize settings for each notification channel
        IConfigurationLoader configurationLoader = new ConfigurationLoader();
        IEmailSettings emailSettings = new EmailSettings(configurationLoader);

        // Create notification channels
        INotificationChannel emailChannel = new EmailNotificationChannel(emailSettings);
        INotificationChannel smsChannel = new SmsNotificationChannel();

        // Create notification manager
        NotificationManager notificationManager = new NotificationManager();

        notificationManager.AddChannel(NotificationChannelType.Email, emailChannel);
        notificationManager.AddChannel(NotificationChannelType.Sms, smsChannel);

        return notificationManager;
    }

    static INotificationHandler SetupNotificationHandler()
    {
        // Create notification handler
        INotificationHandler notificationHandler = new NotificationHandler();

        notificationHandler.AddValidator(NotificationChannelType.Email, new EmailValidator());
        notificationHandler.AddValidator(NotificationChannelType.Sms, new PhoneNumberValidator());

        return notificationHandler;
    }
}