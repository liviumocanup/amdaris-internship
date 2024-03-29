namespace ConsoleApp.Services
{
    public class FeeService : IFeeService
    {
        public int CalculateFee(int? experienceYears)
        {
            int fee = 0;

            if (experienceYears == null)
            {
                return fee;
            }

            if (experienceYears <= 1) fee = 500;
            else if (experienceYears <= 3) fee = 250;
            else if (experienceYears <= 5) fee = 100;
            else if (experienceYears <= 9) fee = 50;

            return fee;
        }
    }
}