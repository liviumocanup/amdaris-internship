namespace ConsoleApp.Models
{
    public class Book(string title, string author, string isbn, decimal price) : BaseEntity
    {
        public string Title { get; set; } = title;
        public string Author { get; set; } = author;
        public string ISBN { get; set; } = isbn;
        public decimal Price { get; set; } = price;
    }
}