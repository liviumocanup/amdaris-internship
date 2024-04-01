using ConsoleApp.Models;

namespace ConsoleApp.Builder
{
    public class CoffeeBuilder
    {
        private Coffee _coffee = default!;

        public CoffeeBuilder()
        {
            Reset();
        }

        public void Reset()
        {
            _coffee =  new Coffee();
        }

        public CoffeeBuilder AddBlackCoffee()
        {
            _coffee.BlackCoffeeShots++;
            return this;
        }

        public CoffeeBuilder AddMilk(MilkType milkType)
        {
            _coffee.Milk = milkType;
            return this;
        }

        public CoffeeBuilder AddExtraMilk(MilkType milkType)
        {
            _coffee.ExtraMilk.Add(milkType);
            return this;
        }

        public CoffeeBuilder AddSugar(int quantity)
        {
            _coffee.Sugar = quantity;
            return this;
        }

        public Coffee Build()
        {
            Coffee coffee = _coffee;
            Reset();
            return coffee;
        }
    }
}