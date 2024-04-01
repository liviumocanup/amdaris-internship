namespace ConsoleApp.Models
{
    public class Staff : BaseEntity, ISubscriber
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }

        public void Update(Order order)
        {
            Console.WriteLine($"Email to staff {Email}: Order {order.Id} has been updated to {order.Status}.");
        }
    }
}