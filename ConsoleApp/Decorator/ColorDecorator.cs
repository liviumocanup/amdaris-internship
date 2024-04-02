using ConsoleApp.Models;

namespace ConsoleApp.Decorator
{
    public class ColorDecorator(IText text, string color) : TextDecorator(text)
    {
        public string Color { get; } = color;

        public override string GetFormattedText()
        {
            if (IsEnabled)
            {
                return $"<color={Color}>" + _textComponent.GetFormattedText() + "</color>";
            }

            return _textComponent.GetFormattedText();
        }
    }
}