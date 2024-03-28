using ConsoleApp.Channels;

namespace ConsoleApp.Utilities
{
    public class UserInteraction : IUserInteraction
    {
        public List<NotificationChannelType> SelectChannels()
        {
            while (true)
            {
                Console.WriteLine("Enter the channels separated by commas (or 'Q' to quit):");
                var input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Please enter some input.");
                    continue;
                }

                if (input.Equals("Q", StringComparison.OrdinalIgnoreCase))
                {
                    return new List<NotificationChannelType>();
                }

                var result = ParseChannelInput(input);
                if (result.Count > 0) return result;
            }
        }

        private List<NotificationChannelType> ParseChannelInput(string input)
        {
            var selectedTypes = new List<NotificationChannelType>();
            foreach (var part in input.Split(','))
            {
                if (Enum.TryParse(part.Trim(), true, out NotificationChannelType result))
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
            return selectedTypes;
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