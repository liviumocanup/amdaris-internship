using ConsoleApp.Models;

namespace ConsoleApp.Decorator
{
    public class BackgroundColorDecorator(IText text, string backgroundColor) : TextDecorator(text)
    {
        private readonly string _backgroundColor = backgroundColor;

        public override string GetFormattedText()
        {
            if (IsEnabled)
            {
                return $"<background={_backgroundColor}>" + _textComponent.GetFormattedText() + "</background>";
            }

            return _textComponent.GetFormattedText();
        }
    }
}