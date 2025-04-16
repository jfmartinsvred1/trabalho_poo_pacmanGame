using PacManGame.Models;

namespace PacManGame.Tests
{
    public class ScoringHistoryTest
    {
        [Fact]
        public void AddPlayer_QuandoAcabarOJogoEAdicionarPlayer_DeveSerAdicionadoAListaComScoreCorreto()
        {
            #region Arrange
            var scoreHistory = new ScoringHistory();
            var player = new Player(1, 1);
            int score = 2;
            #endregion Arrange
            #region Act
            player.Eat();
            player.Eat();
            scoreHistory.AddPlayer(player);
            #endregion Act
            #region Assert
            Assert.Equal(score, scoreHistory.Players.FirstOrDefault().Score);
            #endregion Assert
        }
    }
}
