using MorpionApp.Enums;

namespace MorpionApp.Models
{
    public class Player
    {
        public string Name { get; }
        public GridValue Value { get; }
        public bool IsBot { get; }

        public Player(string name, GridValue value, bool isBot)
        {
            Name = name;
            Value = value;
            IsBot = isBot;
        }
    }
}
