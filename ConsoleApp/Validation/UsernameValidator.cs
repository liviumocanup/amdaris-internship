namespace ConsoleApp.Validation
{
    class UsernameValidator : IInputValidator
    {
        public string ErrorMessage => "Invalid username format.";

        public bool IsValid(string? username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                Console.Write("Username cannot be empty. ");
                return false;
            }

            if (username.Length < 3 || username.Length > 20)
            {
                Console.Write("Username must be between 3 and 20 characters. ");
                return false;
            }

            return true;
        }
    }
}