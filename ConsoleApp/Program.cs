class Program
{
    static void Main(string[] args)
    {
        string emailAddress = InputEmail();

        using (EmailSender sender = new EmailSender())
        {
            sender.SendEmail(emailAddress, "Thank you for subscribing!", "Thank you for subscribing to our newsletter.");

            Console.WriteLine("Email sent successfully.");
        }

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }

    static string InputEmail()
    {
        string? emailAddress;
        do
        {
            Console.WriteLine("Enter your email address:");
            emailAddress = Console.ReadLine();
        } while (!EmailChecker.IsValid(emailAddress));

        return emailAddress!;
    }
}