using ConsoleApp.Models;
using ConsoleApp.Observer;
using ConsoleApp.Channels;

namespace ConsoleApp.Services
{
    public class SubscriptionService
    {
        private readonly INotificationManager _notificationManager;
        private readonly List<IObserver> _staffObservers = new List<IObserver>();
        private readonly Dictionary<Guid, List<IObserver>> _orderObservers = new Dictionary<Guid, List<IObserver>>();

        public SubscriptionService(INotificationManager notificationManager)
        {
            _notificationManager = notificationManager;
        }

        public void Subscribe(Guid orderId, IObserver observer)
        {
            if (!_orderObservers.ContainsKey(orderId))
            {
                _orderObservers[orderId] = new List<IObserver>();
            }
            _orderObservers[orderId].Add(observer);
        }

        public void Unsubscribe(Guid orderId, IObserver observer)
        {
            if (_orderObservers.ContainsKey(orderId))
            {
                _orderObservers[orderId].Remove(observer);
            }
        }

        public void SubscribeStaff(IObserver observer)
        {
            _staffObservers.Add(observer);
        }

        public void UnsubscribeStaff(IObserver observer)
        {
            _staffObservers.Remove(observer);
        }

        public void Notify(Order order)
        {
            if (_orderObservers.TryGetValue(order.Id, out List<IObserver>? value))
            {
                foreach (var observer in value)
                {
                    observer.Update(order, _notificationManager);
                }
            }

            if (order.Status == OrderStatus.Placed || order.Status == OrderStatus.ReadyForShipping)
            {
                foreach (var staff in _staffObservers)
                {
                    staff.Update(order, _notificationManager);
                }
            }
        }

        public void RemoveOrder(Guid orderId)
        {
            _orderObservers.Remove(orderId);
        }
    }
}
