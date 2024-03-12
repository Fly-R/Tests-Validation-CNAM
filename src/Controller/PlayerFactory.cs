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
                new Player("Player1", GridValue.X, false),
                new Player("IA", GridValue.O, true)
            ];
        }

        private static List<Player> CreatePlayersAgainstHuman()
        {
            return
           [
               new Player("Joueur 1", GridValue.X, false),
               new Player("Joueur 2", GridValue.O, false)
           ];
        }
    }
}
