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

            ArgumentParser parser = new ArgumentParser(args);

            Assert.NotNull(parser);
        }

        [Fact]
        public void ParseInput_InvalidMontantType()
        {
            string[] args = ["abc", "9", "0.01"];

            InvalidCastException exception = Assert.Throws<InvalidCastException>(() => new ArgumentParser(args));
            Assert.Equal("Le montant de l'emprunt doit être un nombre entier", exception.Message);            
        }
        [Fact]
        public void ParseInput_InvalidDureeType()
        {
            string[] args = ["50000", "abc", "0.01"];

            InvalidCastException exception = Assert.Throws<InvalidCastException>(() => new ArgumentParser(args));
            Assert.Equal("La durée de l'emprunt doit être un nombre entier", exception.Message);            
        }
        [Fact]
        public void ParseInput_InvalidTauxType()
        {
            string[] args = ["50000", "9", "abc"];

            InvalidCastException exception = Assert.Throws<InvalidCastException>(() => new ArgumentParser(args));
            Assert.Equal("Le taux de l'emprunt doit être un nombre décimal", exception.Message);            
        }

        [Fact]
        public void ParseInput_CorrectValues()
        {
            const int montant = 50000;
            const int dureeAnne = 9;
            const float taux = 0.01f;

            string[] args = [montant.ToString(), dureeAnne.ToString(), taux.ToString()];

            ArgumentParser parser = new ArgumentParser(args);

            Assert.NotNull(parser);
            Assert.Equal(montant, parser.Montant);
            Assert.Equal(dureeAnne, parser.Duree);
            Assert.Equal(taux, parser.Taux);
        }
    }
}
