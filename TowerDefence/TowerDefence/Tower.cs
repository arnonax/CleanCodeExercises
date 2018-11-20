using System;

namespace TowerDefence
{
    public class Tower
     {
         protected Tower(string imageFilename, int strength, double fightingRadius, int fightsPerRound, BoardLocation location)
         {
            ImageFilename = imageFilename;
            Strength = strength;
            FightingRadius = fightingRadius;
            Location = location;
            FightsPerRound = fightsPerRound;
         }

        public string ImageFilename { get; }
        public double FightingRadius { get; }
        public BoardLocation Location { get; }
        public int Strength { get; }
        public int FightsPerRound { get; }

        public bool IsInRange(Enemy enemy)
        {
            double x = (Location.X - enemy.Location.X) * (Location.X - enemy.Location.X);
            double y = (Location.Y - enemy.Location.Y) * (Location.Y - enemy.Location.Y);
            double distance = Math.Sqrt(x + y);
            if (distance > FightingRadius)
            {
                return false;
            }
            return true;
        }

        public void Fight(Enemy enemy)
        {
            if (IsInRange(enemy))
            {
                enemy.Power = enemy.Power - Strength;
            }
        }
    }
}
