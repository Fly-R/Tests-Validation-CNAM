using MorpionApp.Abstractions;
using MorpionApp.Enums;
using MorpionApp.Models;

namespace MorpionApp
{
    public class PuissanceQuatre : IGameMode
    {
        public int Rows => GRID_ROWS;
        public int Columns => GRID_COLUMNS;

        public Position AIPlay(Grid grid)
        {
            Random random = new Random();
            do
            {
                int column = random.Next(grid.Columns);
                if (grid.IsCellEmpty(0, column))
                    return new Position(0, column);

            } while (true);

        }

        public void ApplyGameRulesBeforePlacement(Grid grid, ref Position position)
        {
            while (position.Row < grid.Rows - 1)
            {
                position.Row++;
                if (!grid.IsCellEmpty(position))
                {
                    position.Row--;
                    break;
                }
            }
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
                CheckForWin_AscendingDiagonal(grid, playerSymbol) ||
                CheckForWin_DescendingDiagonal(grid, playerSymbol);
        }

        public bool IsValidInput(Grid grid, Position position)
        {
            return grid.IsCellEmpty(position);
        }     
        #region PRIVATE

        private const int GRID_ROWS = 4;
        private const int GRID_COLUMNS = 7;
        private const int WINNING_SEQUENCE = 4;


        private bool CheckForWin_Horizontal(Grid grid, GridValue symbol)
        {
            for (int row = 0; row < GRID_ROWS; row++)
            {
                if (IsSequenceValid(grid.GetRow(row), symbol))
                {
                    return true;
                }
            }
            return false;
        }

        private bool CheckForWin_Vertical(Grid grid, GridValue symbol)
        {
            for (int column = 0; column < GRID_COLUMNS; column++)
            {
                if (IsSequenceValid(grid.GetColumn(column), symbol))
                {
                    return true;
                }
            }
            return false;
        }

        private bool CheckForWin_AscendingDiagonal(Grid grid, GridValue symbol)
        {
            for (int column = 0; column <= GRID_COLUMNS - WINNING_SEQUENCE; column++)
            {
                if (IsSequenceValid(grid.GetAscendingDiagonal(new Position(GRID_ROWS - 1, column)), symbol))
                {
                    return true;
                }
            }
            return false;
        }

        private bool CheckForWin_DescendingDiagonal(Grid grid, GridValue symbol)
        {
            for (int column = 0; column <= GRID_COLUMNS - WINNING_SEQUENCE; column++)
            {
                if (IsSequenceValid(grid.GetDescendingDiagonal(new Position(0, column)), symbol))
                {
                    return true;
                }
            }
            return false;
        }


        private bool IsSequenceValid(IEnumerable<GridValue> values, GridValue value)
        {
            int count = 0;
            foreach (GridValue cell in values)
            {
                if (cell == value) count++;
                else count = 0;

                if (count >= WINNING_SEQUENCE) return true;
            }
            return false;
        }       
        #endregion
    }
}
