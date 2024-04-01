using ConsoleApp.Models;

namespace ConsoleApp.Builder
{
    public static class CoffeeBuilderExtensions
    {
        public static CoffeeBuilder MakeEspresso(this CoffeeBuilder builder)
        {
            return builder.AddBlackCoffee();
        }

        public static CoffeeBuilder MakeCappuccino(this CoffeeBuilder builder, MilkType milkType)
        {
            return builder.AddBlackCoffee().AddMilk(milkType);
        }

        public static CoffeeBuilder MakeFlatWhite(this CoffeeBuilder builder, MilkType milkType)
        {
            return builder.AddBlackCoffee().AddBlackCoffee().AddMilk(milkType);
        }
    }
}