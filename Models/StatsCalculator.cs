namespace JDR.Models
{
    public class StatsCalculator
    {
        public static int CalculateStat(int baseValue, double factor, int level, int bonusInterval = 4, int bonusAmount = 12)
        {
            // Exponential value progression
            double statValue = baseValue * Math.Pow(factor, level - 1);

            // Adds fix bonus at interval
            int bonus = (level / bonusInterval) * bonusAmount;

            // Diminishing returns to avoid excessive value growth
            double diminishingFactor = 1 - (level / 100.0);

            // Applies diminishing factor
            statValue *= diminishingFactor;

            // Adds fix bonus to stat value
            return (int)Math.Round(statValue + bonus);
        }
    }
}