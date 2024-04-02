using ConsoleApp.Decorator;
using ConsoleApp.Models;

namespace ConsoleApp.Facade
{
    public class TextFormatterFacade
    {
        private IText text;
        private List<TextDecorator> appliedDecorators;

        public TextFormatterFacade(IText text)
        {
            this.text = text;
            appliedDecorators = new List<TextDecorator>();
        }

        public TextFormatterFacade Bold() => ApplyDecorator(new BoldDecorator(text));
        public TextFormatterFacade Italic() => ApplyDecorator(new ItalicDecorator(text));
        public TextFormatterFacade Underline() => ApplyDecorator(new UnderlineDecorator(text));
        public TextFormatterFacade Color(string color) => ApplyDecorator(new ColorDecorator(text, color));
        public TextFormatterFacade BackgroundColor(string backgroundColor) => ApplyDecorator(new BackgroundColorDecorator(text, backgroundColor));

        public TextFormatterFacade RemoveBold() => RemoveDecorator(typeof(BoldDecorator));
        public TextFormatterFacade RemoveItalic() => RemoveDecorator(typeof(ItalicDecorator));
        public TextFormatterFacade RemoveUnderline() => RemoveDecorator(typeof(UnderlineDecorator));
        public TextFormatterFacade RemoveColor() => RemoveDecorator(typeof(ColorDecorator));
        public TextFormatterFacade RemoveBackgroundColor() => RemoveDecorator(typeof(BackgroundColorDecorator));

        private TextFormatterFacade ApplyDecorator(TextDecorator decorator)
        {
            appliedDecorators.Add(decorator);
            text = decorator;
            return this;
        }

        private TextFormatterFacade RemoveDecorator(Type decoratorType)
        {
            for (int i = appliedDecorators.Count - 1; i >= 0; i--)
            {
                if (appliedDecorators[i].GetType() == decoratorType)
                {
                    appliedDecorators[i].IsEnabled = false;
                    appliedDecorators.RemoveAt(i);
                    text = (i > 0) ? appliedDecorators[i - 1] : text;
                }
            }
            return this;
        }

        public IText Apply() => text;
    }
}
