using MorpionApp.Abstractions;
using MorpionApp.Controller;
using MorpionApp.Controllers;
using MorpionApp.Enums;
using MorpionApp.Models;
using MorpionApp.UI;

namespace MorpionApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            IUserInterface ui = new CLI();
            do
            {
                IGameMode gameMode;
                gameMode = ui.AskForGameMode() switch
                {
                    UserInput.PlayMorpion => new Morpion(),
                    UserInput.PlayPuissance4 => new PuissanceQuatre(),
                    _ => throw new NotImplementedException()
                };

                List<Player> players = PlayerFactory.CreatePlayers(ui.AskForPlayingAgainstAI());

                new GameController(ui, gameMode, players).Play();

            } while (ui.AskForReplay() == UserInput.Replay);
        }
    }
}
