namespace ConsoleApp.Channels
{
    public class SmsNotificationChannel : INotificationChannel
    {
        public void Send(string to, string subject, string message)
        {
            Console.WriteLine($"SMS to {to} with subject: {subject} and message: {message}");
        }
    }
}