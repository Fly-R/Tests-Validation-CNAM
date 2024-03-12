namespace MorpionApp.Enums
{
    public enum GridValue
    {
        Empty,
        Player1,
        Player2
    }

    public static class GridValueExtensions
    {
        public static string ToSymbol(this GridValue value)
        {
            return value switch
            {
                GridValue.Empty => " ",
                GridValue.Player1 => "X",
                GridValue.Player2 => "O",
                _ => string.Empty,
            };
        }
    }
}
