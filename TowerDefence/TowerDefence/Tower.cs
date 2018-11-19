using System;

namespace TowerDefence
{
     class Tower
    {
        public string ImageFilename { get; set; }
        public double FightingRadius { get; set; }
        public BoardLocation Location { get; set; }
        public int Strength { get; set; }
        public int FightsPerRound { get; set; }

        public void Initialize(string imageFilename, int strength, double fightingRadius, int fightsPerRound, BoardLocation location)
        {
            ImageFilename = imageFilename;
            Strength = strength;
            FightingRadius = fightingRadius;
            Location = location;
            FightsPerRound = fightsPerRound;
        }

        public bool IsInRange(Enemy enemy)
        {
            double x = (Location.x - enemy.Location.x) * (Location.x - enemy.Location.x);
            double y = (Location.y - enemy.Location.y) * (Location.y - enemy.Location.y);
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
