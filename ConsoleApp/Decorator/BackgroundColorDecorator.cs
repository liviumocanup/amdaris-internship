using ConsoleApp.Models;

namespace ConsoleApp.Decorator
{
    public class BackgroundColorDecorator(IText text, string backgroundColor) : TextDecorator(text)
    {
        public string Color { get; } = backgroundColor;

        public override string GetFormattedText()
        {
            if (IsEnabled)
            {
                return $"<background={Color}>" + _textComponent.GetFormattedText() + "</background>";
            }

            return _textComponent.GetFormattedText();
        }
    }
}