using MorpionApp;
using MorpionApp.Enums;
using MorpionApp.Models;

using System.Security.Cryptography;

namespace Tests
{
    public class PuissanceQuatreTest
    {
        private const int GRID_WIDTH = 7;
        private const int GRID_HEIGHT = 4;

        private readonly PuissanceQuatre _puissance4;

        public PuissanceQuatreTest()
        {
            _puissance4 = new PuissanceQuatre();
        }

        [Fact]
        public void GridInit_CorrectDimensions()
        {
            Assert.Equal(GRID_HEIGHT, _puissance4.Rows);
            Assert.Equal(GRID_WIDTH, _puissance4.Columns);
        }    

        [Fact]
        public void CheckWin_CorrectWin_Line()
        {
            for (int line = 0; line < GRID_HEIGHT; line++)
            {
                for (int linePosibility = 0; linePosibility < GRID_WIDTH - (4 - 1); linePosibility++)
                {
                    Grid grid = new Grid(_puissance4.Rows, _puissance4.Columns);
                    for (int column = 0; column < 4; column++)
                    {
                        grid.SetCellValue(line, column + linePosibility, GridValue.Player1);                        
                    }
                    Assert.True(_puissance4.CheckForWin(grid, GridValue.Player1));
                }
            }
        }

        [Fact]
        public void CheckWin_CorrectWin_Column()
        {
            for (int column = 0; column < GRID_WIDTH; column++)
            {
                Grid grid = new Grid(_puissance4.Rows, _puissance4.Columns);
                for (int line = 0; line < GRID_HEIGHT; line++)
                {                    
                    grid.SetCellValue(line, column, GridValue.Player1);
                }
                Assert.True(_puissance4.CheckForWin(grid, GridValue.Player1));
            }
        }

        [Fact]
        public void CheckWin_CorrectWin_Diag_Desc()
        {
            for (int posibility = 0; posibility < GRID_WIDTH - (4 - 1); posibility++)
            {                
                Grid grid = new Grid(_puissance4.Rows, _puissance4.Columns);
                for (int line = 0; line < GRID_HEIGHT; line++)
                {                    
                    grid.SetCellValue(line, posibility + line, GridValue.Player1);
                }
                Assert.True(_puissance4.CheckForWin(grid, GridValue.Player1));
            }
        }

        [Fact]
        public void CheckWin_CorrectWin_Diag_Asc()
        {
            for (int posibility = 0; posibility < GRID_WIDTH - (4 - 1); posibility++)
            {                
                Grid grid = new Grid(_puissance4.Rows, _puissance4.Columns);
                int column = 0;
                for (int line = GRID_HEIGHT - 1; line >= 0; line--)
                {                    
                    grid.SetCellValue(line, posibility + column, GridValue.Player1);
                    column++;
                }
                Assert.True(_puissance4.CheckForWin(grid, GridValue.Player1));
            }
        }

        [Fact]
        public void CheckEquality()
        {
            //_puissance4.grille = new char[GRID_HEIGHT, GRID_WIDTH]
            //{
            //{'O', 'X', 'X', 'X', 'O', 'O', 'O'},
            //{'X', 'X', 'O', 'X', 'O', 'X', 'X'},
            //{'O', 'O', 'X', 'O', 'X', 'O', 'X'},
            //{'O', 'X', 'O', 'X', 'O', 'O', 'O'}
            //};
            //Assert.False(_puissance4.verifVictoire('X'));
            //Assert.False(_puissance4.verifVictoire('O'));
            //Assert.True(_puissance4.verifEgalite());

            //_puissance4.grille = new char[GRID_HEIGHT, GRID_WIDTH]
            //{
            //{'O', ' ', 'X', 'X', 'O', 'O', 'O'},
            //{'X', 'X', 'O', 'X', 'O', 'X', 'X'},
            //{'O', 'X', 'X', 'O', 'X', 'O', 'X'},
            //{'O', 'X', 'O', 'X', 'O', 'O', 'O'}
            //};
            //Assert.False(_puissance4.verifVictoire('X'));
            //Assert.False(_puissance4.verifVictoire('O'));
            //Assert.False(_puissance4.verifEgalite());           
        }

        [Fact]
        public void AIPlay()
        {
            Grid grid = new Grid(3, 3);

            grid.SetCellValue(2, 0, GridValue.Player1);
            grid.SetCellValue(2, 1, GridValue.Player1);
            grid.SetCellValue(2, 2, GridValue.Player1);

            grid.SetCellValue(1, 0, GridValue.Player1);
            grid.SetCellValue(1, 1, GridValue.Player1);
            grid.SetCellValue(1, 2, GridValue.Player1);
            
            grid.SetCellValue(0, 1, GridValue.Player1);
            grid.SetCellValue(0, 2, GridValue.Player1);

            Position position = _puissance4.AIPlay(grid);

            Assert.Equal(new Position(0, 0), position);

        }

    }
}
