using System;
using System.Linq;
using Bogus;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TowerDefence.Tests
{
    [TestClass]
    public class GameEngineTests
    {
        private Randomizer _randomizer;

        [TestInitialize]
        public void TestIntialized()
        {
            InitializeRandom();
        }

        private void InitializeRandom()
        {
            var seed = Environment.TickCount;
            var random = new Random(seed);
            Console.WriteLine("Seed=" + seed);
            Randomizer.Seed = random;
            _randomizer = new Faker().Random;
        }

        private int GetRandomColumn()
        {
            var column = _randomizer.Int(0, GameEngine.NumberOfColumns);
            Console.WriteLine("Column=" + column);
            return column;
        }

        private int GetRandomRow()
        {
            var row = _randomizer.Int(0, GameEngine.NumberOfRows);
            Console.WriteLine("Row="+row);
            return row;
        }

        [TestMethod]
        public void WhenUserClicksOnCellHeIsAskedToSelectTowerType()
        {
            var mockUI = A.Fake<IGameUI>();
            var engine = new GameEngine(mockUI);

            engine.UserClickedOnCell(0, 0);
            A.CallTo(() => mockUI.SelectTowerType(0, 0, engine)).MustHaveHappenedOnceExactly();
        }

        [TestMethod]
        public void WhenUserSelectsATowerTheTowerIsAddedAtTheClickedLocation()
        {
            var row = GetRandomRow();
            var column = GetRandomColumn();
            var mockUI = A.Fake<IGameUI>();
            var engine = new GameEngine(mockUI);
            A.CallTo(() => mockUI.SelectTowerType(column, row, engine)).Returns(GameEngine.TowerType.SimpleTower);
                
            engine.UserClickedOnCell(column, row);
            
            Assert.AreEqual(1, engine.Towers.Count, "1 tower should be created");
            var tower = engine.Towers.Single();
            Assert.AreEqual(column, tower.Location.X, $"Tower should be created in the {column} column");
            Assert.AreEqual(row, tower.Location.Y, $"Tower should be created in the {row} row");
        }
    }
}
