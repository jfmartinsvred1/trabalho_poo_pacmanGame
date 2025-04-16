using PacManGame.Models;

namespace PacManGame.Tests
{
    public class PlayerTest
    {
        [Fact]
        public void Move_QuandoMovimentarComD_DeveAlterarAPosicaoCorreta()
        {
            #region Arrange
            var player = new Player(1,1);
            int positionXExpected = 2;
            #endregion Arrange
            #region Act
            player.Move(ConsoleKey.D);
            #endregion Act
            #region Assert
            Assert.Equal(positionXExpected, player.Position.X);
            #endregion Assert
        }
        [Fact]
        public void Move_QuandoMovimentarComOutraTecla_NaoDeveAlterarAPosicaoCorreta()
        {
            #region Arrange
            var player = new Player(1, 1);
            int positionXExpected = 1;
            #endregion Arrange
            #region Act
            player.Move(ConsoleKey.J);
            #endregion Act
            #region Assert
            Assert.Equal(positionXExpected, player.Position.X);
            #endregion Assert
        }
        [Fact]
        public void Eat_QuandoComer_DeveAumentarOScore()
        {

            #region Arrange
            var player = new Player(1, 1);
            int scoreExpected = 1;
            #endregion Arrange
            #region Act
            player.Eat();
            #endregion Act
            #region Assert
            Assert.Equal(scoreExpected, player.Score);
            #endregion Assert
        }
    }
}