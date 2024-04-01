using ConsoleApp.Builder;
using ConsoleApp.Models;

CoffeeBuilder builder = new CoffeeBuilder();
CoffeeDirector director = new CoffeeDirector(builder);

var espresso = builder.MakeEspresso().Build();
var cappuccino = builder.MakeCappuccino(MilkType.Regular).Build();
var flatWhite = builder.MakeFlatWhite(MilkType.Oat).Build();

var customEspresso = builder.MakeEspresso().AddExtraMilk(MilkType.Soy).AddSugar(1).Build();
var customCappuccino = builder.MakeCappuccino(MilkType.Regular).AddSugar(2).Build();
var customFlatWhite = builder.MakeFlatWhite(MilkType.Oat).AddSugar(1).Build();

Console.WriteLine(espresso);
Console.WriteLine(cappuccino);
Console.WriteLine(flatWhite);
Console.WriteLine();

Console.WriteLine(customEspresso);
Console.WriteLine(customCappuccino);
Console.WriteLine(customFlatWhite);
Console.WriteLine();

espresso = director.MakeEspresso();
cappuccino = director.MakeCappuccino(MilkType.Regular);
flatWhite = director.MakeFlatWhite(MilkType.Oat);

Console.WriteLine(espresso);
Console.WriteLine(cappuccino);
Console.WriteLine(flatWhite);