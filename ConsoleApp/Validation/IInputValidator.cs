namespace ConsoleApp.Validation
{
    public interface IInputValidator
    {
        bool IsValid(string input);
        string ErrorMessage { get; }
    }
}
