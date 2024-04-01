using ConsoleApp.Models;

namespace ConsoleApp.Decorator
{
    public class UnderlineDecorator(IText text) : TextDecorator(text)
    {
        public override string GetFormattedText()
        {
            if (IsEnabled)
            {
                return "<u>" + _textComponent.GetFormattedText() + "</u>";
            }

            return _textComponent.GetFormattedText();
        }
    }
}