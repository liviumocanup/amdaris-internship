namespace ConsoleApp.Validation
{
    class PhoneNumberValidator : IInputValidator
    {
        public string ErrorMessage => "Invalid phone number format.";

        public bool IsValid(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                Console.Write("Phone number cannot be empty. ");
                return false;
            }

            if (phoneNumber.Length < 8)
            {
                Console.Write("Phone number is too short. ");
                return false;
            }

            return true;
        }
    }
}