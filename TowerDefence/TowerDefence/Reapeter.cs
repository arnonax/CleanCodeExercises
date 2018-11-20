namespace TowerDefence
{
    internal class Reapeter : Tower
    {
        public Reapeter(string imageFilename, int strength, double fightingRadius, int fightsPerRound, BoardLocation location)
            : base(imageFilename, strength, fightingRadius, fightsPerRound, location)
        {
        }
    }
}