using System.Net;
using System.Net.Mail;
using ConsoleApp.Configuration;

namespace ConsoleApp.Channels
{
    public class EmailNotificationChannel : INotificationChannel, IDisposable
    {
        private readonly SmtpClient _smtpClient;
        private readonly string _username;

        public EmailNotificationChannel(IEmailSettings settings)
        {
            _username = settings.Username;
            string password = settings.Password;
            string host = settings.Host;
            int port = settings.Port;

            _smtpClient = new SmtpClient(host)
            {
                Port = port,
                Credentials = new NetworkCredential(_username, password),
                EnableSsl = true,
            };
        }

        public void Send(string to, string subject, string message)
        {
            using MailMessage mail = new MailMessage(_username, to, subject, message);
            _smtpClient.Send(mail);
        }

        public void Dispose() => _smtpClient?.Dispose();
    }
}