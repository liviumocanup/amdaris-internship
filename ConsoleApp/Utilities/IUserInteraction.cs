using ConsoleApp.Channels;

namespace ConsoleApp.Utilities
{
    public interface IUserInteraction
    {
        List<NotificationChannelType> SelectChannels();
        string PromptForInput(string prompt, Func<string, bool> validate);
        bool AskContinue();
    }
}