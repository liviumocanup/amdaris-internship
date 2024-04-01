namespace ConsoleApp.Channels
{
    public class EmailNotificationChannel : INotificationChannel
    {
        public void Send(string to, string subject, string message)
        {
            Console.WriteLine($"Email to {to} with subject: {subject} and message: {message}");
        }
    }
}