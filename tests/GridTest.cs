using MorpionApp.Enums;
using MorpionApp.Models;

namespace Tests
{
    public class GridTest
    {

        [Fact]
        public void GridInit_CorrectDimensions()
        {
            Grid grid = new Grid(3, 3);
            Assert.Equal(3, grid.Rows);
            Assert.Equal(3, grid.Columns);
        }


        [Fact]
        public void GridInit_DefaultValues()
        {
            Grid grid = new Grid(3, 3);
            for(int row= 0; row < grid.Rows; row++)
            {
                for(int column = 0; column < grid.Columns; column++)
                {
                    Assert.Equal(GridValue.Empty, grid.GetCellValue(row, column));
                }
            }
        }

        [Fact]
        public void Grid_IsCellEmpty()
        {
            Grid grid = new Grid(3, 3);
            
            Assert.True(grid.IsCellEmpty(new Position(0,0)));
            grid.SetCellValue(new Position(0,0), GridValue.X);
            Assert.False(grid.IsCellEmpty(new Position(0,0)));

            Assert.True(grid.IsCellEmpty(1,1));
            grid.SetCellValue(1,1, GridValue.O);
            Assert.False(grid.IsCellEmpty(1,1));

            Assert.Throws<IndexOutOfRangeException>(() => grid.IsCellEmpty(new Position(3,3)));
            Assert.Throws<IndexOutOfRangeException>(() => grid.IsCellEmpty(3,3));
            Assert.Throws<IndexOutOfRangeException>(() => grid.IsCellEmpty(-1,0));
        }

        [Theory]
        [InlineData(0, 0, GridValue.X)]
        [InlineData(0, 1, GridValue.O)]
        [InlineData(1, 0, GridValue.X)]
        [InlineData(1, 1, GridValue.O)]
        [InlineData(2, 2, GridValue.X)]
        public void Grid_GetAnsSetCellValue(int row, int colunm, GridValue gridValue)
        {
            Grid grid = new Grid(3, 3);
            grid.SetCellValue(new Position(row,colunm), gridValue);
            Assert.Equal(gridValue, grid.GetCellValue(row, colunm));

            Assert.Throws<IndexOutOfRangeException>(() => grid.GetCellValue(3,3));
        }

        [Fact]
        public void Grid_GetRowValues()
        {
            Grid grid = new Grid(3, 3);
            grid.SetCellValue(0, 0, GridValue.X);
            grid.SetCellValue(0, 1, GridValue.O);
            grid.SetCellValue(0, 2, GridValue.X);
            
            grid.SetCellValue(1, 0, GridValue.O);
            grid.SetCellValue(1, 1, GridValue.X);            
            grid.SetCellValue(1, 2, GridValue.O);
            
            grid.SetCellValue(2, 0, GridValue.X);
            grid.SetCellValue(2, 1, GridValue.O);
            grid.SetCellValue(2, 2, GridValue.X);

            Assert.Equal(new List<GridValue> { GridValue.X, GridValue.O, GridValue.X}, grid.GetRow(0));
            Assert.Equal(new List<GridValue> { GridValue.O, GridValue.X, GridValue.O}, grid.GetRow(1));
            Assert.Equal(new List<GridValue> { GridValue.X, GridValue.O, GridValue.X}, grid.GetRow(2));
        }

        [Fact]
        public void Grid_GetColumnValues()
        {
            Grid grid = new Grid(3, 3);
            grid.SetCellValue(0, 0, GridValue.X);
            grid.SetCellValue(1, 0, GridValue.O);
            grid.SetCellValue(2, 0, GridValue.X);

            grid.SetCellValue(0, 1, GridValue.O);
            grid.SetCellValue(1, 1, GridValue.X);
            grid.SetCellValue(2, 1, GridValue.O);

            grid.SetCellValue(0, 2, GridValue.X);
            grid.SetCellValue(1, 2, GridValue.O);
            grid.SetCellValue(2, 2, GridValue.X);

            Assert.Equal(new List<GridValue> { GridValue.X, GridValue.O, GridValue.X }, grid.GetRow(0));
            Assert.Equal(new List<GridValue> { GridValue.O, GridValue.X, GridValue.O }, grid.GetRow(1));
            Assert.Equal(new List<GridValue> { GridValue.X, GridValue.O, GridValue.X }, grid.GetRow(2));
        }
     

        [Fact]
        public void Grid_GetEmpyCells()
        {
            List<Position> emptyPosition = new List<Position>() { new Position(0, 1), new Position(0, 2) };
            Grid grid = new Grid(3, 3);
            for(int row = 0; row < grid.Rows; row++)
            {
                for(int column = 0; column < grid.Columns; column++)
                {
                    if(!emptyPosition.Contains(new Position(row, column)))
                    {
                        grid.SetCellValue(row, column, GridValue.X);
                    }
                }
            }

            Assert.Equal(emptyPosition, grid.GetEmptyCells());
        }
        
        [Fact]
        public void Grid_GetAscendingDiagonalValues()
        {
            Grid grid = new Grid(3, 3);
            grid.SetCellValue(0, 2, GridValue.X);
            grid.SetCellValue(1, 1, GridValue.O);
            grid.SetCellValue(2, 0, GridValue.X);

            Assert.Equal(new List<GridValue> { GridValue.X, GridValue.O, GridValue.X }, grid.GetAscendingDiagonal(new Position(2, 0)));
        }

        [Fact]
        public void Grid_GetDescendingDiagonalValues()
        {
            Grid grid = new Grid(3, 3);
            grid.SetCellValue(0, 0, GridValue.X);
            grid.SetCellValue(1, 1, GridValue.O);
            grid.SetCellValue(2, 2, GridValue.X);

            Assert.Equal(new List<GridValue> { GridValue.X, GridValue.O, GridValue.X }, grid.GetDescendingDiagonal(new Position(0, 0)));
        }
    }
}
