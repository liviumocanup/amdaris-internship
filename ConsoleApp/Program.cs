using ConsoleApp.Decorator;
using ConsoleApp.Models;


IText text = new PlainText("Hello, World!");

var boldDecorator = new BoldDecorator(text);
var italicDecorator = new ItalicDecorator(boldDecorator);
var underlineDecorator = new UnderlineDecorator(italicDecorator);
var whiteTextDecorator = new ColorDecorator(underlineDecorator, "white");
var blackBackgroundDecorator = new BackgroundColorDecorator(whiteTextDecorator, "black");

Console.WriteLine(blackBackgroundDecorator.GetFormattedText());
Console.WriteLine();

whiteTextDecorator.IsEnabled = false;
blackBackgroundDecorator.IsEnabled = false;
italicDecorator.IsEnabled = false;

Console.WriteLine(blackBackgroundDecorator.GetFormattedText());