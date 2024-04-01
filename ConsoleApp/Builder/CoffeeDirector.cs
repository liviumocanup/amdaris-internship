using ConsoleApp.Models;

namespace ConsoleApp.Builder
{
    public class CoffeeDirector
    {
        private readonly CoffeeBuilder _builder;

        public CoffeeDirector(CoffeeBuilder builder)
        {
            _builder = builder;
        }

        public Coffee MakeEspresso()
        {
            return _builder.AddBlackCoffee().Build();
        }

        public Coffee MakeCappuccino(MilkType milkType)
        {
            return _builder.AddBlackCoffee()
                            .AddMilk(milkType)
                            .Build();
        }

        public Coffee MakeFlatWhite(MilkType milkType)
        {
            return _builder.AddBlackCoffee()
                            .AddBlackCoffee()
                            .AddMilk(milkType)
                            .Build();
        }

    }
}
