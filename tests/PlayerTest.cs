using MorpionApp.Enums;
using MorpionApp.Models;

namespace Tests
{
    public class PlayerTest
    {
        [Fact]
        public void PlayerInit_CorrectValues()
        {
            Player player = new Player("Player1", GridValue.X, false);
            Assert.Equal("Player1", player.Name);
            Assert.Equal(GridValue.X, player.Value);
            Assert.False(player.IsBot);

            player = new Player("Player2", GridValue.O, true);
            Assert.Equal("Player2", player.Name);
            Assert.Equal(GridValue.O, player.Value);
            Assert.True(player.IsBot);
        }

    }
}
