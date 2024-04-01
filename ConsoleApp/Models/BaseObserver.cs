using ConsoleApp.Channels;
using ConsoleApp.Observer;

namespace ConsoleApp.Models
{
    public abstract class BaseObserver : BaseEntity, IObserver
    {
        public string Email { get; set; }
        public string Number { get; set; }
        public HashSet<NotificationChannelType> PreferredChannel { get; set; } = new HashSet<NotificationChannelType>();

        protected BaseObserver(string email, string number)
        {
            Email = email;
            Number = number;
        }

        public virtual void Update(Order order, INotificationManager notificationManager)
        {
            string booksTitles = order.Books.Aggregate("", (acc, book) => acc + book?.Title + ", ");
            
            string subject = $"Order {order.Id} Update";
            string message = $"Order for books {booksTitles} is now {order.Status}.";

            foreach (var channel in PreferredChannel)
            {
                switch (channel)
                {
                    case NotificationChannelType.Email:
                        notificationManager.Send(Email, subject, message, channel);
                        break;
                    case NotificationChannelType.Sms:
                        notificationManager.Send(Number, subject, message, channel);
                        break;
                }
            }
        }
    }
}