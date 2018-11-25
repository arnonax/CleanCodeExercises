using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TowerDefence.Tests
{
    [TestClass]
    public class GameEngineTests
    {
        [TestMethod]
        public void WhenUserClicksOnCellHeIsAskedToSelectTowerType()
        {
            var mockUI = A.Fake<IGameUI>();
            var engine = new GameEngine(mockUI);

            engine.UserClickedOnCell(0, 0);
            A.CallTo(() => mockUI.SelectTowerType(0, 0, engine)).MustHaveHappenedOnceExactly();
        }
    }
}
