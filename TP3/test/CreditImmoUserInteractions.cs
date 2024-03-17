using CredImmo.App;

namespace CredImmo.Test
{
    public class CreditImmoUserInteractions
    {
        [Fact]
        public void ParseInput_InvalidCount()
        {
            string[] args = ["50000", "9"];

            ArgumentException exception = Assert.Throws<ArgumentException>( () =>  new ArgumentParser(args));

            Assert.Equal("Le nombre d'arguments doit être égal à 3", exception.Message);
        }

        [Fact]
        public void ParseInput_ValidCount()
        {
            string[] args = ["50000", "9", "0.01"];

            ArgumentParser argumentParser = new ArgumentParser(args);

            Assert.NotNull(argumentParser);
        }
    }
}
