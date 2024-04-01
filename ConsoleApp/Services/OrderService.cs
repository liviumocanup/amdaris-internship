using ConsoleApp.Models;
using ConsoleApp.Repositories;

namespace ConsoleApp.Services
{
    public class OrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Book> _bookRepository;
        private readonly SubscriptionService _subscriptionService;

        public OrderService(IRepository<Order> orderRepository, IRepository<Book> bookRepository, SubscriptionService subscriptionService)
        {
            _orderRepository = orderRepository;
            _bookRepository = bookRepository;
            _subscriptionService = subscriptionService;
        }

        public Guid? PlaceOrder(Customer customer, List<Guid> bookIds)
        {
            var books = bookIds.Select(_bookRepository.GetById).ToList();

            if (books.Any(book => book == null))
            {
                Console.WriteLine("One or more books not found. Please verify the order.");
                return null;
            }

            var order = new Order
            {
                CustomerId = customer.Id,
                Books = books!,
                Status = OrderStatus.Placed
            };

            _orderRepository.Add(order);
            _subscriptionService.Subscribe(order.Id, customer);
            _subscriptionService.Notify(order);

            return order.Id;
        }

        private void UpdateOrderStatus(Guid orderId, OrderStatus newStatus, Guid? staffId = null)
        {
            var order = _orderRepository.GetById(orderId);
            if (order != null)
            {
                if (order.Status == OrderStatus.Cancelled || order.Status == OrderStatus.Completed)
                {
                    Console.WriteLine($"Order {orderId} is already {order.Status}.");
                    return;
                }

                order.Status = newStatus;
                if (staffId.HasValue)
                {
                    order.StaffId = staffId.Value;
                }
                _orderRepository.Update(order);

                _subscriptionService.Notify(order);
                if (newStatus == OrderStatus.Cancelled || newStatus == OrderStatus.Completed)
                {
                    _subscriptionService.RemoveOrder(order.Id);
                }
            }
            else
            {
                Console.WriteLine($"Order {orderId} not found.");
            }
        }

        public void ProcessOrder(Guid orderId, Guid staffId) => UpdateOrderStatus(orderId, OrderStatus.Processing, staffId);
        public void ReadyOrder(Guid orderId) => UpdateOrderStatus(orderId, OrderStatus.ReadyForShipping);
        public void ShipOrder(Guid orderId, Guid staffId) => UpdateOrderStatus(orderId, OrderStatus.Shipped, staffId);
        public void DeliveredOrder(Guid orderId) => UpdateOrderStatus(orderId, OrderStatus.Delivered);
        public void CompleteOrder(Guid orderId) => UpdateOrderStatus(orderId, OrderStatus.Completed);
        public void CancelOrder(Guid orderId) => UpdateOrderStatus(orderId, OrderStatus.Cancelled);

        public void CheckOrderStatus(Guid orderId)
        {
            var order = _orderRepository.GetById(orderId);
            if (order != null)
            {
                Console.WriteLine($"Order {orderId} status: {order.Status}.");
            }
            else
            {
                Console.WriteLine($"Order {orderId} not found.");
            }
        }
    }
}
