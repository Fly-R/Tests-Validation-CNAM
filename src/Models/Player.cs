using MorpionApp.Enums;

namespace MorpionApp.Models
{
    public class Player
    {
        public string Name { get; }
        public GridValue Value { get; }

        public Player(string name, GridValue value)
        {
            Name = name;
            Value = value;
        }
    }
}
