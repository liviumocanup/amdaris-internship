using ConsoleApp.Models;

namespace ConsoleApp.Validators
{
    public class SpeakerValidator : IValidator
    { 
        public bool IsValid(Speaker speaker)
        {
            CheckNullOrWhitespace(speaker.FirstName, "First Name");
            CheckNullOrWhitespace(speaker.LastName, "Last Name");
            CheckNullOrWhitespace(speaker.Email, "Email");
            
            return true;
        }

        private void CheckNullOrWhitespace(string value, string paramName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(paramName + " is required.");
            }
        }
    }
}