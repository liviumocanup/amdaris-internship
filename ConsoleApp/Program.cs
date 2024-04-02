using ConsoleApp.Decorator;
using ConsoleApp.Facade;
using ConsoleApp.Models;

// Formatting without Facade
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


// Formatting with Facade
TextFormatterFacade textFormatterFacade = new TextFormatterFacade(new PlainText("Hello, World!"));

IText text_with_facade = textFormatterFacade.Bold()
                                            .Italic()
                                            .Underline()
                                            .Color("white")
                                            .BackgroundColor("black")
                                            .Apply();

Console.WriteLine(text_with_facade.GetFormattedText());

text_with_facade = textFormatterFacade.RemoveItalic()
                                    .RemoveColor()
                                    .RemoveBackgroundColor()
                                    .Apply();

Console.WriteLine(text_with_facade.GetFormattedText());