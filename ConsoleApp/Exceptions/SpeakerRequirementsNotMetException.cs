namespace ConsoleApp.Exceptions
{
    public class SpeakerRequirementsNotMetException : Exception
    {
        public SpeakerRequirementsNotMetException(string message)
            : base(message)
        {
        }

        public SpeakerRequirementsNotMetException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}