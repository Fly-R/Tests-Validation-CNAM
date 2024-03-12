using MorpionApp.Models;

namespace Tests
{
    public class PositionTest
    {
        [Fact]
        public void PositionInit_CorrectValues()
        {
            Position position = new Position(3, 3);
            Assert.Equal(3, position.Row);
            Assert.Equal(3, position.Column);
        }

        [Fact]
        public void Position_Equals()
        {
            Position position1 = new Position(3, 3);
            Position position2 = new Position(3, 3);
            Position position3 = new Position(3, 4);
            Position position4 = new Position(4, 3);
            Position position5 = new Position(4, 4);

            Assert.True(position1.Equals(position2));
            Assert.False(position1.Equals(position3));
            Assert.False(position1.Equals(position4));
            Assert.False(position1.Equals(position5));
        }

        [Fact]
        public void Position_OperatorEquals()
        {
            Position position1 = new Position(3, 3);
            Position position2 = new Position(3, 3);
            Position position3 = new Position(3, 4);
            Position position4 = new Position(4, 3);
            Position position5 = new Position(4, 4);

            Assert.True(position1 == position2);
            Assert.False(position1 != position2);

            Assert.False(position1 == position3);
            Assert.True(position1 != position3);

            Assert.False(position1 == position4);
            Assert.True(position1 != position4);
            
            Assert.False(position1 == position5);
            Assert.True(position1 != position5);
        }

    }
}
