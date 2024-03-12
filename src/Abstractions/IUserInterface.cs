using MorpionApp.Enums;
using MorpionApp.Models;

namespace MorpionApp.Abstractions
{
    public interface IUserInterface
    {
        void DisplayGrid(Grid grid);
        void DiplayPlayer(Player player);
        void DisplayWinner(Player player);
        void DisplayDraw();
        void ClearScreen();

        UserInput AskForGameMode();
        UserInput AskForReplay();
        UserInput AskForPlay(Grid grid, out Position position);

    }
}
