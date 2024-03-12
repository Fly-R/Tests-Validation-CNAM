using MorpionApp.Abstractions;
using MorpionApp.Controller;
using MorpionApp.Enums;
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

                new GameController(ui, gameMode).Play();

            } while (ui.AskForReplay() == UserInput.Replay);
        }
    }
}
