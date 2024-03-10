using MorpionApp;

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
            Assert.Equal(GRID_HEIGHT, _morpion.grille.GetLength(0));
            Assert.Equal(GRID_WIDTH, _morpion.grille.GetLength(1));
        }

        [Fact]
        public void GridInit_CorrectValues()
        {
            char defaultValue = '\0';
            for (int i = 0; i < GRID_WIDTH; i++)
            {
                for (int j = 0; j < GRID_HEIGHT; j++)
                {
                    Assert.Equal(defaultValue, _morpion.grille[i, j]);
                }
            }
        }
   

        [Fact]
        public void CheckWin_CorrectWin_Line()
        {           
            for(int line=0; line < GRID_HEIGHT; line++)
            {
                _morpion.grille = new char[GRID_HEIGHT, GRID_WIDTH];
                for(int column=0; column < GRID_WIDTH; column++)
                {
                    _morpion.grille[line, column] = 'X';
                }
                Assert.True(_morpion.verifVictoire('X'));
            }
        }

        [Fact]
        public void CheckWin_CorrectWin_Column()
        {
            for (int column = 0; column < GRID_WIDTH; column++)
            {
                _morpion.grille = new char[GRID_HEIGHT, GRID_WIDTH];
                for (int line = 0; line < GRID_HEIGHT; line++)
                {
                    _morpion.grille[line, column] = 'X';
                }
                Assert.True(_morpion.verifVictoire('X'));
            }
        }

        [Fact]
        public void CheckWin_CorrectWin_Diag()
        {
            _morpion.grille = new char[GRID_HEIGHT, GRID_WIDTH];
            _morpion.grille[0, 0] = 'X';
            _morpion.grille[1, 1] = 'X';
            _morpion.grille[2, 2] = 'X';

            Assert.True(_morpion.verifVictoire('X'));

            _morpion.grille = new char[GRID_HEIGHT, GRID_WIDTH];
            _morpion.grille[0, 2] = 'X';
            _morpion.grille[1, 1] = 'X';
            _morpion.grille[2, 0] = 'X';
            Assert.True(_morpion.verifVictoire('X'));
        }

        [Fact]
        public void CheckEquality()
        {
            _morpion.grille = new char[GRID_HEIGHT, GRID_WIDTH]
            {
                {'X', 'O', 'X'},
                {'X', 'O', 'X'},
                {'O', 'X', 'O'}
            };
            Assert.False(_morpion.verifVictoire('X'));
            Assert.False(_morpion.verifVictoire('O'));
            Assert.True(_morpion.verifEgalite());

            _morpion.grille = new char[GRID_HEIGHT, GRID_WIDTH]
            {
                {'X', 'O', 'X'},
                {'X', 'O', 'X'},
                {'O', ' ', 'O'}
            };
            Assert.False(_morpion.verifVictoire('X'));
            Assert.False(_morpion.verifVictoire('O'));
            Assert.True(_morpion.verifEgalite());

            _morpion.grille = new char[GRID_HEIGHT, GRID_WIDTH]
            {
                {'O', 'O', 'X'},
                {'X', 'X', 'O'},
                {' ', 'O', 'X'}
            };
            Assert.False(_morpion.verifVictoire('X'));
            Assert.False(_morpion.verifVictoire('O'));
            Assert.False(_morpion.verifEgalite());
        }
    }
}