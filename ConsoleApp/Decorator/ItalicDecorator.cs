using ConsoleApp.Models;

namespace ConsoleApp.Decorator
{
    public class ItalicDecorator(IText text) : TextDecorator(text)
    {
        public override string GetFormattedText()
        {
            if (IsEnabled)
            {
                return "<i>" + _textComponent.GetFormattedText() + "</i>";
            }

            return _textComponent.GetFormattedText();
        }
    }
}