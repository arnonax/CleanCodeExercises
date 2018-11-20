namespace TowerDefence
{
    internal class SimpleTower : Tower
    {
        public SimpleTower(string imageFilename, int strength, double fightingRadius, int fightsPerRound, BoardLocation location)
            : base(imageFilename, strength, fightingRadius, fightsPerRound, location)
        {
        }
    }
}