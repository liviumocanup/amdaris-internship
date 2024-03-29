using ConsoleApp.Models;

namespace ConsoleApp.Validators
{
    public interface IValidator
    {
        bool IsValid(Speaker speaker);   
    }
}