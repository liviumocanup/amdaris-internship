namespace ConsoleApp.Models
{
    public class Customer : BaseEntity, ISubscriber
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }

        public void Update(Order order)
        {
            Console.WriteLine($"Email to {Email}: Your order {order.Id} is now {order.Status}.");
        }
    }
}