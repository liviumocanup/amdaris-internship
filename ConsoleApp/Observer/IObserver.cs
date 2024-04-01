using ConsoleApp.Channels;
using ConsoleApp.Models;

namespace ConsoleApp.Observer
{
    public interface IObserver
    {
        void Update(Order order, INotificationManager notificationManager);
    }
}