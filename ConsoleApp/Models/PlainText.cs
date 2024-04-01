namespace ConsoleApp.Models
{
    public class PlainText(string text) : IText
    {
        private readonly string _text = text;

        public string GetFormattedText()
        {
            return _text;
        }
    }
}