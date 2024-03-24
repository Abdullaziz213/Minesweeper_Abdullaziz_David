using System.Xml.Schema;

namespace Minesweeper.Test
{
    [TestClass]
    public class MinesweeperTests 
    {
        [TestMethod]
        public void UncoverCell_UncoveringMine_EndsGame()
        {
            // Arrange
            Board game = new Board();
            game.InitializeGrid(5, 5, 5);
            int mineX = 0;
            int mineY = 0;

            // Act
            game.UncoverCell(mineX, mineY);

            // Assert
            Assert.IsTrue(game.IsGameOver());
        }

        [TestMethod]
        public void UncoverCell_UncoveringNonMine_ContinuesGame()
        {
            // Arrange
            Board game = new Board();
            game.InitializeGrid(5, 5, 5);
            int nonMineX = 2;
            int nonMineY = 2;

            // Act
            game.UncoverCell(nonMineX, nonMineY);

            // Assert
            Assert.IsFalse(game.IsGameOver());
        }

        [TestMethod]
        public void ResetGame_AfterGameOver_StartsNewGame()
        {
            // Arrange
            Board game = new Board();
            game.InitializeGrid(5, 5, 5);
            game.UncoverCell(0, 0); // Game over

            // Act
            game.ResetGame();

            // Assert
            Assert.IsFalse(game.IsGameOver());
        }
    }
}