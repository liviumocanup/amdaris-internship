using ConsoleApp.Channels;

namespace ConsoleApp.Utilities
{
    public class UserInteraction : IUserInteraction
    {
        public List<NotificationChannelType> SelectChannels()
        {
            while (true)
            {
                string? input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Please enter some input.");
                    continue;
                }

                if (input.Equals("Q", StringComparison.CurrentCultureIgnoreCase))
                {
                    return new List<NotificationChannelType>();
                }

                List<NotificationChannelType> selectedTypes = new List<NotificationChannelType>();
                foreach (string part in input.Split(','))
                {
                    if (Enum.TryParse<NotificationChannelType>(part.Trim(), true, out var result))
                    {
                        selectedTypes.Add(result);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input, try again.");
                        selectedTypes.Clear();
                        break;
                    }
                }

                if (selectedTypes.Count > 0) return selectedTypes;
            }
        }

        public string PromptForInput(string prompt, Func<string, bool> validate)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                string? input = Console.ReadLine();
                if (validate(input ?? "")) return input!;
                Console.WriteLine("Invalid input, try again.");
            }
        }

        public bool AskContinue()
        {
            Console.WriteLine("Do you want to send more notifications? (y/n):");
            string? response = Console.ReadLine();
            return response?.ToLower() == "y";
        }
    }
}