namespace ConsoleApp.Models
{
    public class Order : BaseEntity
    {
        public List<Book> Books { get; set; } = new List<Book>();
        public Guid CustomerId { get; set; }
        public Guid? StaffId { get; set; }
        public OrderStatus Status { get; set; }
    }
}
