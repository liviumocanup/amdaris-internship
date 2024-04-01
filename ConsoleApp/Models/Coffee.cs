namespace ConsoleApp.Models
{
    public class Coffee
    {
        public int BlackCoffeeShots { get; set; }
        public MilkType? Milk { get; set; }
        public List<MilkType> ExtraMilk { get; set; } = new List<MilkType>();
        public int Sugar { get; set; }

        public override string ToString()
        {
            var descriptionParts = new List<string>();

            if (BlackCoffeeShots > 0)
            {
                descriptionParts.Add($"{BlackCoffeeShots} shots of black coffee");
            }
            if (Milk.HasValue)
            {
                descriptionParts.Add($"{Milk.Value} milk");
            }
            if (ExtraMilk.Count > 0)
            {
                descriptionParts.Add($"{string.Join(", ", ExtraMilk)} extra milk");
            }
            if (Sugar > 0)
            {
                descriptionParts.Add($"{Sugar} sugar");
            }

            return "Coffee with " + string.Join(", ", descriptionParts);
        }
    }
}