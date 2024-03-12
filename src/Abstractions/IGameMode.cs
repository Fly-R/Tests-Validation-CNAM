using MorpionApp.Enums;
using MorpionApp.Models;

namespace MorpionApp.Abstractions
{
    public interface IGameMode
    {
        int Rows { get; }
        int Columns { get; }

        bool IsValidInput(Grid grid, Position position);
        void ApplyGameRulesBeforePlacement(Grid grid, ref Position position);
        bool CheckForWin(Grid grid, GridValue playerSymbol);
        bool CheckForDraw(Grid grid);

    }
}
