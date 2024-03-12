using MorpionApp.Controllers;
using MorpionApp.Enums;
using MorpionApp.Models;

namespace Tests
{
    public class PlayerFactoryTest
    {

        [Fact]
        public void CreatePlayers_PlayAgainstAI()
        {                       
            List<Player> players = PlayerFactory.CreatePlayers(UserInput.PlayAgainstAI);

            Assert.Equal(2, players.Count);

            Assert.Equal(GridValue.Player1, players[0].Value);
            Assert.False(players[0].IsBot);

            Assert.Equal(GridValue.Player2, players[1].Value);
            Assert.True(players[1].IsBot);
        }

        [Fact]
        public void CreatePlayers_PlayAgainstHuman()
        {            
            List<Player> players = PlayerFactory.CreatePlayers(UserInput.PlayAgainstHuman);

            Assert.Equal(2, players.Count);

            Assert.Equal(GridValue.Player1, players[0].Value);
            Assert.False(players[0].IsBot);

            Assert.Equal(GridValue.Player2, players[1].Value);
            Assert.False(players[1].IsBot);
        }
    }
}
