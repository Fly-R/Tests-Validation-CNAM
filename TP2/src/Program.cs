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
        private static readonly IUserInterface ui = new CLI();
        static void Main(string[] args)
        {
            do
            {
                if (ui.AskForLoadSave() == UserInput.LoadSave)
                {
                    LoadGame();
                }
                else
                {
                    StartNewGame();
                }

            } while (ui.AskForReplay() == UserInput.Replay);
        }

        private static void LoadGame()
        {
            try
            {
                Save save = SaveController.LoadGame(GameController.DEFAULT_SAVE_PATH);
                new GameController(ui, save).Play();
            }
            catch (Exception _)
            {
                ui.NoSave();
                StartNewGame();
            }
        }

        private static void StartNewGame()
        {
            IGameMode gameMode = ui.AskForGameMode() switch
            {
                UserInput.PlayMorpion => new Morpion(),
                UserInput.PlayPuissance4 => new PuissanceQuatre(),
                _ => throw new NotImplementedException()
            };

            UserInput playerMode = ui.AskForPlayingAgainstAI();
            List<Player> players = PlayerFactory.CreatePlayers(playerMode);

            new GameController(ui, gameMode, players).Play();
        }
    }
}
