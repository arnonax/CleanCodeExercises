namespace TowerDefence
{
    internal class Sniper : Tower
    {
        public Sniper(string imageFilename, int strength, double fightingRadius, int fightsPerRound, BoardLocation location) 
            : base(imageFilename, strength, fightingRadius, fightsPerRound, location)
        {
        }
    }
}