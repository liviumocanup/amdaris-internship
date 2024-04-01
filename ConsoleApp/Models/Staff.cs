using ConsoleApp.Models.Observer;

namespace ConsoleApp.Models
{
    public class Staff(string name, string email, string number) : BaseObserver(email, number)
    {
        public string Name { get; set; } = name;
    }
}