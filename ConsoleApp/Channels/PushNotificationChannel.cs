namespace ConsoleApp.Channels
{
    public class PushNotificationChannel : INotificationChannel
    {
        public void Send(string to, string subject, string message)
        {
            Console.WriteLine($"Sending PUSH notification to {to} with subject: {subject} and message: {message}");
        }
    }
}