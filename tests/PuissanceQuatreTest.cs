using MorpionApp;

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
            Assert.Equal(GRID_HEIGHT, _puissance4.grille.GetLength(0));
            Assert.Equal(GRID_WIDTH, _puissance4.grille.GetLength(1));
        }

        [Fact]
        public void GridInit_CorrectValues()
        {
            char defaultValue = '\0';
            for (int i = 0; i < GRID_HEIGHT; i++)
            {
                for (int j = 0; j < GRID_WIDTH; j++)
                {
                    Assert.Equal(defaultValue, _puissance4.grille[i, j]);
                }
            }
        }

        [Fact]
        public void CheckWin_CorrectWin_Line()
        {
            for (int line = 0; line < GRID_HEIGHT; line++)
            {
                for (int linePosibility = 0; linePosibility < GRID_WIDTH - (4 - 1); linePosibility++)
                {
                    _puissance4.grille = new char[GRID_HEIGHT, GRID_WIDTH];
                    for (int column = 0; column < 4; column++)
                    {
                        _puissance4.grille[line, column + linePosibility] = 'X';
                    }
                    Assert.True(_puissance4.verifVictoire('X'));
                }
            }
        }

        [Fact]
        public void CheckWin_CorrectWin_Column()
        {
            for (int column = 0; column < GRID_WIDTH; column++)
            {
                _puissance4.grille = new char[GRID_HEIGHT, GRID_WIDTH];
                for (int line = 0; line < GRID_HEIGHT; line++)
                {
                    _puissance4.grille[line, column] = 'X';
                }
                Assert.True(_puissance4.verifVictoire('X'));
            }
        }

        [Fact]
        public void CheckWin_CorrectWin_Diag_Desc()
        {
            for (int posibility = 0; posibility < GRID_WIDTH - (4 - 1); posibility++)
            {
                _puissance4.grille = new char[GRID_HEIGHT, GRID_WIDTH];
                for (int line = 0; line < GRID_HEIGHT; line++)
                {
                    _puissance4.grille[line, posibility + line] = 'X';
                }
                Assert.True(_puissance4.verifVictoire('X'));
            }
        }

        [Fact]
        public void CheckWin_CorrectWin_Diag_Asc()
        {
            for (int posibility = 0; posibility < GRID_WIDTH - (4 - 1); posibility++)
            {
                _puissance4.grille = new char[GRID_HEIGHT, GRID_WIDTH];
                int column = 0;
                for (int line = GRID_HEIGHT - 1; line >= 0; line--)
                {
                    _puissance4.grille[line, posibility + column] = 'X';
                    column++;
                }
                Assert.True(_puissance4.verifVictoire('X'));
            }
        }

        [Fact]
        public void CheckEquality()
        {
            _puissance4.grille = new char[GRID_HEIGHT, GRID_WIDTH]
            {
                {'O', 'X', 'X', 'X', 'O', 'O', 'O'},
                {'X', 'X', 'O', 'X', 'O', 'X', 'X'},
                {'O', 'O', 'X', 'O', 'X', 'O', 'X'},
                {'O', 'X', 'O', 'X', 'O', 'O', 'O'}
            };
            Assert.False(_puissance4.verifVictoire('X'));
            Assert.False(_puissance4.verifVictoire('O'));
            Assert.True(_puissance4.verifEgalite());

            _puissance4.grille = new char[GRID_HEIGHT, GRID_WIDTH]
            {
                {'O', ' ', 'X', 'X', 'O', 'O', 'O'},
                {'X', 'X', 'O', 'X', 'O', 'X', 'X'},
                {'O', 'X', 'X', 'O', 'X', 'O', 'X'},
                {'O', 'X', 'O', 'X', 'O', 'O', 'O'}
            };
            Assert.False(_puissance4.verifVictoire('X'));
            Assert.False(_puissance4.verifVictoire('O'));
            Assert.False(_puissance4.verifEgalite());           
        }

    }
}
