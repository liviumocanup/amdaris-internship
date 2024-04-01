namespace ConsoleApp.Models
{
    public class Customer(string name, string email, string number) : BaseObserver(email, number)
    {
        public string Name { get; set; } = name;
    }
}