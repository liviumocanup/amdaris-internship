using ConsoleApp.Models;

namespace ConsoleApp.Decorator
{
    public class ColorDecorator(IText text, string color) : TextDecorator(text)
    {
        private readonly string _color = color;

        public override string GetFormattedText()
        {
            if (IsEnabled)
            {
                return $"<color={_color}>" + _textComponent.GetFormattedText() + "</color>";
            }

            return _textComponent.GetFormattedText();
        }
    }
}