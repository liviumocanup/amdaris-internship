using ConsoleApp.Models;
using ConsoleApp.Repositories;

namespace ConsoleApp.Services
{
    public class OrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Book> _bookRepository;

        public OrderService(IRepository<Order> orderRepository, IRepository<Book> bookRepository)
        {
            _orderRepository = orderRepository;
            _bookRepository = bookRepository;
        }

        public Guid PlaceOrder(Guid customerId, List<Guid> bookIds)
        {
            var books = bookIds.Select(id => _bookRepository.GetById(id)).ToList();
            var order = new Order
            {
                CustomerId = customerId,
                Books = books,
                Status = OrderStatus.Placed
            };
            _orderRepository.Add(order);
            Console.WriteLine($"Order {order.Id} placed with {books.Count} books for customer {customerId}.");
            return order.Id;
        }

        public void CancelOrder(Guid orderId)
        {
            var order = _orderRepository.GetById(orderId);
            if (order != null)
            {
                order.Status = OrderStatus.Cancelled;
                Console.WriteLine($"Order {orderId} has been cancelled.");
            }
            else
            {
                Console.WriteLine($"Order {orderId} not found.");
            }
        }

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

        public void ProcessOrder(Guid orderId)
        {
            var order = _orderRepository.GetById(orderId);
            if (order != null)
            {
                order.Status = OrderStatus.Processing;
                Console.WriteLine($"Order {orderId} is now being processed.");
            }
            else
            {
                Console.WriteLine($"Order {orderId} not found.");
            }
        }

        public void UpdateOrderStatus(Guid orderId, OrderStatus status)
        {
            var order = _orderRepository.GetById(orderId);
            if (order != null)
            {
                order.Status = status;
                Console.WriteLine($"Order {orderId} status updated to {status}.");
            }
            else
            {
                Console.WriteLine($"Order {orderId} not found.");
            }
        }
    }
}
