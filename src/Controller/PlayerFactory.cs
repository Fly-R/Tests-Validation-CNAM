using MorpionApp.Enums;
using MorpionApp.Models;

namespace MorpionApp.Controllers
{
    public static class PlayerFactory
    {
        public static List<Player> CreatePlayers(UserInput userInput)
        {
            return userInput switch
            {
                UserInput.PlayAgainstAI => CreatePlayersAgainstAI(),
                UserInput.PlayAgainstHuman => CreatePlayersAgainstHuman(),
                _ => throw new NotImplementedException()
            };
        }

        private static List<Player> CreatePlayersAgainstAI()
        {
            return
            [
                new Player("Player1", GridValue.Player1, false),
                new Player("IA", GridValue.Player2, true)
            ];
        }

        private static List<Player> CreatePlayersAgainstHuman()
        {
            return
           [
               new Player("Joueur 1", GridValue.Player1, false),
               new Player("Joueur 2", GridValue.Player2, false)
           ];
        }
    }
}
