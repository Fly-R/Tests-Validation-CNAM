using MorpionApp;
using MorpionApp.Enums;
using MorpionApp.Models;

namespace Tests
{
    public class MorpionTest
    {
        private const int GRID_WIDTH = 3;
        private const int GRID_HEIGHT = 3;

        private readonly Morpion _morpion;

        public MorpionTest()
        {
            _morpion = new Morpion();
        }


        [Fact]
        public void GridInit_CorrectDimensions()
        {
            Assert.Equal(GRID_HEIGHT, _morpion.Rows);
            Assert.Equal(GRID_WIDTH, _morpion.Columns);
        }   

        [Fact]
        public void CheckWin_CorrectWin_Line()
        {
            for (int row = 0; row < _morpion.Rows; row++)
            {
                Grid grid = new Grid(_morpion.Rows, _morpion.Columns);                
                for (int column = 0; column < _morpion.Columns; column++)
                {
                    grid.SetCellValue(row, column, GridValue.Player1);
                }
                Assert.True(_morpion.CheckForWin(grid, GridValue.Player1));
            }
        }

        [Fact]
        public void CheckWin_CorrectWin_Column()
        {
            for (int column = 0; column < _morpion.Columns; column++)
            {
                Grid grid = new Grid(_morpion.Rows, _morpion.Columns);
                for (int row = 0; row < _morpion.Rows; row++)
                {                    
                    grid.SetCellValue(row, column, GridValue.Player1);
                }
                Assert.True(_morpion.CheckForWin(grid, GridValue.Player1));
            }
        }

        [Fact]
        public void CheckWin_CorrectWin_Diag()
        {
            Grid grid = new Grid(_morpion.Rows, _morpion.Columns);
            grid.SetCellValue(0, 0, GridValue.Player1);
            grid.SetCellValue(1, 1, GridValue.Player1);
            grid.SetCellValue(2, 2, GridValue.Player1);      
            Assert.True(_morpion.CheckForWin(grid, GridValue.Player1));

            grid = new Grid(_morpion.Rows, _morpion.Columns);
            grid.SetCellValue(0, 2, GridValue.Player1);
            grid.SetCellValue(1, 1, GridValue.Player1);
            grid.SetCellValue(2, 0, GridValue.Player1);       
            Assert.True(_morpion.CheckForWin(grid, GridValue.Player1));
        }

        [Fact]
        public void CheckEquality()
        {
            //_morpion.grille = new char[GRID_HEIGHT, GRID_WIDTH]
            //{
            //    {'X', 'O', 'X'},
            //    {'X', 'O', 'X'},
            //    {'O', 'X', 'O'}
            //};
            //Assert.False(_morpion.verifVictoire('X'));
            //Assert.False(_morpion.verifVictoire('O'));
            //Assert.True(_morpion.verifEgalite());

            //_morpion.grille = new char[GRID_HEIGHT, GRID_WIDTH]
            //{
            //    {'X', 'O', 'X'},
            //    {'X', 'O', 'X'},
            //    {'O', ' ', 'O'}
            //};
            //Assert.False(_morpion.verifVictoire('X'));
            //Assert.False(_morpion.verifVictoire('O'));
            //Assert.True(_morpion.verifEgalite());

            //_morpion.grille = new char[GRID_HEIGHT, GRID_WIDTH]
            //{
            //    {'O', 'O', 'X'},
            //    {'X', 'X', 'O'},
            //    {' ', 'O', 'X'}
            //};
            //Assert.False(_morpion.verifVictoire('X'));
            //Assert.False(_morpion.verifVictoire('O'));
            //Assert.False(_morpion.verifEgalite());
            Assert.True(false);
        }
    }
}