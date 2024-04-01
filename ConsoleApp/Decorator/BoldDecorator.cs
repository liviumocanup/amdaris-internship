using ConsoleApp.Models;

namespace ConsoleApp.Decorator
{
    public class BoldDecorator(IText text) : TextDecorator(text)
    {
        public override string GetFormattedText()
        {
            if (IsEnabled)
            {
                return "<b>" + _textComponent.GetFormattedText() + "</b>";
            }

            return _textComponent.GetFormattedText();
        }

    }
}