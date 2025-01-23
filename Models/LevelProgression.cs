namespace JDR.Models
{
    public class LevelProgression(int baseExperience = 100, double factor = 1.2, int maxLevel = 20)
    {
        private readonly int BaseExperience = baseExperience;
        private readonly double Factor = factor;
        private readonly int MaxLevel = maxLevel;

        // Calculates the amount of experience needed to level up
        public int ExperienceToLevelUp(int level)
        {
            return (int)Math.Round(BaseExperience * Math.Pow(Factor, level - 1));
        }

        // Checks if the character has not reached the maximum level
        public bool CanLevelUp(int currentLevel, int currentExperience)
        {
            if (currentLevel >= MaxLevel) return false;

            int requiredExperience = ExperienceToLevelUp(currentLevel);
            return currentExperience >= requiredExperience;
        }
    }
}