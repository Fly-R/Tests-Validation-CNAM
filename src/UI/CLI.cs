using MorpionApp.Abstractions;
using MorpionApp.Enums;
using MorpionApp.Models;

namespace MorpionApp.UI
{
    public class CLI : IUserInterface
    {
        public UserInput AskForPlay(Grid grid, out Position position)
        {            
            Console.WriteLine("Choisir une case valide est appuyer sur [Entrer]");
            do
            {
                ClearScreen();
                DisplayGrid(grid);
                Console.SetCursorPosition(_cursorColumn * 4 + 1, _cursorRow);

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.RightArrow:
                        _cursorColumn = (_cursorColumn + 1) % grid.Columns;
                        break;
                    case ConsoleKey.LeftArrow:
                        _cursorColumn--;
                        if (_cursorColumn < 0) _cursorColumn = grid.Columns - 1;
                        break;

                    case ConsoleKey.UpArrow:
                       _cursorRow--;
                        if (_cursorRow < 0) _cursorRow = grid.Rows - 1;
                        break;

                    case ConsoleKey.DownArrow:
                        _cursorRow = (_cursorRow + 1) % grid.Rows;
                        break;
                    case ConsoleKey.Enter:
                        position = new Position(_cursorRow, _cursorColumn);
                        return UserInput.Played;
                    case ConsoleKey.Escape:
                        position = new Position(0, 0);
                        return UserInput.Leave;
                }
            } while (true);
        }

        public UserInput AskForPlayingAgainstAI()
        {
            do
            {
                Console.WriteLine("Jouer contre une IA [I] ou contre un autre joueur [J] ?");
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.I:
                        return UserInput.PlayAgainstAI;
                    case ConsoleKey.J:
                        return UserInput.PlayAgainstHuman;
                    case ConsoleKey.Escape:
                        return UserInput.Leave;
                    default:
                        Console.WriteLine("Entrée invalide.");
                        break;
                }
            } while (true);
        }

        public UserInput AskForReplay()
        {
            do
            {
                Console.WriteLine("Jouer à un autre jeu ? Taper [R] pour changer de jeu. Taper [Echap] pour quitter.");
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.R:
                        return UserInput.Replay;
                    case ConsoleKey.Escape:
                        return UserInput.Leave;
                    default:
                        Console.WriteLine("Entrée invalide.");
                        break;
                }
            } while (true);
        }

        public UserInput AskForGameMode()
        {
            do
            {
                Console.WriteLine("Jouer à quel jeu ? Taper [X] pour le morpion et [P] pour le puissance 4.");
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.X:
                        return UserInput.PlayMorpion;
                    case ConsoleKey.P:
                        return UserInput.PlayPuissance4;
                    case ConsoleKey.Escape:
                        return UserInput.Leave;
                    default:
                        Console.WriteLine("Entrée invalide.");
                        break;
                }
            } while (true);
        }

        public void DiplayPlayer(Player player)
        {
            Console.WriteLine($"C'est au tour de {player.Name} ({player.Value})");
        }

        public void DisplayDraw()
        {
            Console.WriteLine("Aucun vainqueur, la partie se termine sur une égalité.");
        }

        public void DisplayGrid(Grid grid)
        {
            for (int row = 0; row < grid.Rows; row++)
            {
                Console.WriteLine(string.Join(" | ", grid.GetRow(row).Select(item => (char)item)));
            }
        }

        public void DisplayWinner(Player player)
        {
            Console.WriteLine($"{player.Name} a gagné !");
        }

        public void ClearScreen()
        {
            Console.Clear();
        }

        #region PRIVATE
        private int _cursorRow = 0;
        private int _cursorColumn = 0;
        #endregion
    }
}
