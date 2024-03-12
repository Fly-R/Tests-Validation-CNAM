using MorpionApp.Abstractions;
using MorpionApp.Enums;
using MorpionApp.Models;

namespace MorpionApp.Controller
{
    public class GameController
    {
        public GameController(IUserInterface userInterface, IGameMode gameMode, List<Player> players)
        {
            _userInterface = userInterface;
            _gameMode = gameMode;
            _players = players;
            _grid = new Grid(_gameMode.Rows, _gameMode.Columns);
            _playerIndex = 0;
        }


        public void Play()
        {
            while (quiterJeu)
            {
                Player player = tourDuJoueur ? _players[0] : _players[1];

                tourJoueur(player);
                if (_gameMode.CheckForWin(_grid, player.Value))
                {
                    _userInterface.DisplayWinner(player);
                    quiterJeu = true;
                    break;
                }

                if (_gameMode.CheckForDraw(_grid))
                {
                    _userInterface.DisplayDraw();
                    quiterJeu = true;
                    break;
                }
                tourDuJoueur = !tourDuJoueur;
            }
        }

        private void tourJoueur(Player player)
        {
            _userInterface.DiplayPlayer(player);

            Position position;
            if(player.IsBot)
                position = AIPlay();
            else
                position = HumanPlay();

            _gameMode.ApplyGameRulesBeforePlacement(_grid, ref position);
            _grid.SetCellValue(position, player.Value);
        }

        private Position HumanPlay()
        {
            Position position;
            do
            {
                if (_userInterface.AskForPlay(_grid, out position) == UserInput.Leave)
                {
                    quiterJeu = true;
                    break;
                }
            } while (!_gameMode.IsValidInput(_grid, position));
            return position;
        }

        private Position AIPlay()
        {
            return _gameMode.AIPlay(_grid);
        }

        #region PRIVATAE

        private readonly IUserInterface _userInterface;
        private readonly IGameMode _gameMode;
        private readonly List<Player> _players;
        private readonly Grid _grid;

        private int _playerIndex;

        private bool quiterJeu = true;
        private bool tourDuJoueur = true;
        #endregion
    }
}
