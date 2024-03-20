using System.Net;
using System.Net.Mail;

public class EmailSender : IDisposable
{
    private readonly SmtpClient _smtpClient;
    private readonly string _username;
    private readonly string _password;
    private readonly string _host;
    private readonly int _port;


    public EmailSender()
    {
        _username = CryptoManager.Decrypt(AppCredentials.Username);
        _password = CryptoManager.Decrypt(AppCredentials.Password);
        _host = AppCredentials.Host;
        _port = AppCredentials.Port;

        _smtpClient = new SmtpClient(_host)
        {
            Port = _port,
            Credentials = new NetworkCredential(_username, _password),
            EnableSsl = true,
        };
    }

    public void SendEmail(string to, string subject, string body)
    {
        using MailMessage mail = new MailMessage(_username, to, subject, body);
        _smtpClient.Send(mail);
    }

    public void Dispose() => _smtpClient?.Dispose();
}
