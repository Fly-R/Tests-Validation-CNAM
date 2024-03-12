using MorpionApp;
using MorpionApp.Controller;
using MorpionApp.Controllers;
using MorpionApp.Enums;
using MorpionApp.Models;

namespace Tests
{
    public class SaveTest
    {
        [Fact]
        public void SaveGame_CorrectSave()
        {
            List<Player> players = PlayerFactory.CreatePlayers(UserInput.PlayAgainstAI);
            char[,] charGrid = new char[2, 2] { { 'X', 'O' }, { 'O', 'X' } };            
            int playerIndex = 42;
            string gameMode = nameof(Morpion);

            Save save = new Save()
            {
                Players = players,
                CurrentPlayerIndex = playerIndex,
                Grid = charGrid,
                GameMode = gameMode
            };

            string filePath = "save.json";
            SaveController.SaveGame(save, filePath);

            Save loadedSave = SaveController.LoadGame(filePath);
            
            Assert.Equal(save.Grid, loadedSave.Grid);
            Assert.Equal(save.CurrentPlayerIndex, loadedSave.CurrentPlayerIndex);
            Assert.Equal(save.GameMode, loadedSave.GameMode);

            for(int i = 0; i < save.Players.Count; i++)
            {
                Assert.Equal(save.Players[i].Name, loadedSave.Players[i].Name);
                Assert.Equal(save.Players[i].Value, loadedSave.Players[i].Value);
                Assert.Equal(save.Players[i].IsBot, loadedSave.Players[i].IsBot);
            }
        }

        [Fact]
        public void SaveGame_ThrowExceptionOnLoad()
        {
            Assert.Throws<FileNotFoundException>(() => SaveController.LoadGame("nonexistent.json"));
        }
    }
}
