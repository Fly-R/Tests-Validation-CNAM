using MorpionApp.Enums;
using MorpionApp.Models;

namespace Tests
{
    public class PlayerTest
    {
        [Fact]
        public void PlayerInit_CorrectValues()
        {
            Player player = new Player("Player1", GridValue.Player1, false);
            Assert.Equal("Player1", player.Name);
            Assert.Equal(GridValue.Player1, player.Value);
            Assert.False(player.IsBot);

            player = new Player("Player2", GridValue.Player2, true);
            Assert.Equal("Player2", player.Name);
            Assert.Equal(GridValue.Player2, player.Value);
            Assert.True(player.IsBot);
        }

    }
}
