using ConsoleApp.Models;

namespace ConsoleApp.Decorator
{
    public abstract class TextDecorator(IText text) : IText
    {
        protected IText _textComponent = text;
        public bool IsEnabled { get; set; } = true;

        public abstract string GetFormattedText();
    }
}