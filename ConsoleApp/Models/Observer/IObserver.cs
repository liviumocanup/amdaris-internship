using ConsoleApp.Channels.Manager;

namespace ConsoleApp.Models.Observer
{
    public interface IObserver
    {
        void Update(Order order, INotificationManager notificationManager);
    }
}