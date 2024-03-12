namespace MorpionApp.Models
{
    public class Save
    {
        public List<Player> Players { get; set; }
        public int CurrentPlayerIndex { get; set; }
        public char[,] Grid { get; set; }
        public string GameMode { get; set; }

    }
}
