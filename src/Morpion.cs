using MorpionApp.Abstractions;
using MorpionApp.Enums;
using MorpionApp.Models;

namespace MorpionApp
{
    public class Morpion : IGameMode
    {

        public int Rows => GRID_ROWS;
        public int Columns => GRID_COLUMNS;

        public bool IsValidInput(Grid grid, Position position)
        {
            return grid.IsCellEmpty(position);
        }

        public void ApplyGameRulesBeforePlacement(Grid grid, ref Position position)
        {
        }

        public bool CheckForDraw(Grid grid)
        {
            return !grid.GetEmptyCells().Any();
        }

        public bool CheckForWin(Grid grid, GridValue playerSymbol)
        {
            return
                CheckForWin_Horizontal(grid, playerSymbol) ||
                CheckForWin_Vertical(grid, playerSymbol) ||
                CheckForWin_Diagonal(grid, playerSymbol);
        }

        #region PRIVATE
        private const int GRID_ROWS = 3;
        private const int GRID_COLUMNS = 3;


        private bool CheckForWin_Horizontal(Grid grid, GridValue symbol)
        {
            for (int row = 0; row < grid.Rows; row++)
            {
                if (grid.GetRow(row).All(cell => cell == symbol))
                {
                    return true;
                }
            }
            return false;
        }

        private bool CheckForWin_Vertical(Grid grid, GridValue symbol)
        {
            for (int column = 0; column < grid.Columns; column++)
            {
                if (grid.GetColumn(column).All(cell => cell == symbol))
                {
                    return true;
                }
            }
            return false;
        }

        private bool CheckForWin_Diagonal(Grid grid, GridValue symbol)
        {
            return
                grid.GetCellValue(0, 0) == symbol &&
                grid.GetCellValue(1, 1) == symbol &&
                grid.GetCellValue(2, 2) == symbol ||
                grid.GetCellValue(2, 0) == symbol &&
                grid.GetCellValue(1, 1) == symbol &&
                grid.GetCellValue(0, 2) == symbol;
        }

        #endregion
    }
}
