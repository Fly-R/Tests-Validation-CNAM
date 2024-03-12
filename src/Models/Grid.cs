using MorpionApp.Enums;

namespace MorpionApp.Models
{
    public class Grid
    {
        public int Rows { get; }
        public int Columns { get; }

        public Grid(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            _grid = new GridValue[rows, columns];
            InitEmptyGrid();
        }

        public bool IsCellEmpty(Position position)
        {
            if (!IsPositionValid(position))
                throw new IndexOutOfRangeException();
            return _grid[position.Row, position.Column] == GridValue.Empty;
        }

        public bool IsCellEmpty(int row, int column)
        {
            return IsCellEmpty(new Position(row, column));
        }

        public GridValue GetCellValue(Position position)
        {
            if (!IsPositionValid(position))
                throw new IndexOutOfRangeException();
            return _grid[position.Row, position.Column];
        }

        public GridValue GetCellValue(int row, int column)
        {
            return GetCellValue(new Position(row, column));
        }

        public void SetCellValue(Position position, GridValue value)
        {
            if (!IsPositionValid(position))
                throw new IndexOutOfRangeException();
            _grid[position.Row, position.Column] = value;
        }

        public void SetCellValue(int row, int column, GridValue value)
        {
            SetCellValue(new Position(row, column), value);
        }

        public IEnumerable<GridValue> GetRow(int row)
        {
            if (row < 0 || row >= Rows)
                throw new IndexOutOfRangeException();

            for (int column = 0; column < Columns; column++)
            {
                yield return _grid[row, column];
            }
        }

        public IEnumerable<GridValue> GetColumn(int column)
        {
            if (column < 0 || column >= Columns)
                throw new IndexOutOfRangeException();

            for (int row = 0; row < Rows; row++)
            {
                yield return _grid[row, column];
            }
        }

        public IEnumerable<GridValue> GetAscendingDiagonal(Position startPosition)
        {
            while (IsPositionValid(startPosition))
            {
                yield return _grid[startPosition.Row, startPosition.Column];
                startPosition.Row--;
                startPosition.Column++;
            }
        }

        public IEnumerable<GridValue> GetDescendingDiagonal(Position startPosition)
        {
            while (IsPositionValid(startPosition))
            {
                yield return _grid[startPosition.Row, startPosition.Column];
                startPosition.Row++;
                startPosition.Column++;
            }
        }

        public IEnumerable<Position> GetEmptyCells()
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int column = 0; column < Columns; column++)
                {
                    if (_grid[row, column] == GridValue.Empty)
                    {
                        yield return new Position(row, column);
                    }
                }
            }
        }

        #region PRIVATE
        private readonly GridValue[,] _grid;

        private bool IsPositionValid(Position position)
        {
            return position.Row >= 0 && position.Row < Rows && position.Column >= 0 && position.Column < Columns;
        }

        private void InitEmptyGrid()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    _grid[i, j] = GridValue.Empty;
                }
            }
        }
        #endregion

    }
}
