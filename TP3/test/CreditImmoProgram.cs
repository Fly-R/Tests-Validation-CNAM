using CredImmo.App;

namespace CredImmo.Test
{
    public class CreditImmoProgram
    {

        [Fact]
        public void CreditImmoProgram_NombreArgumentIncorrect()
        {
            string[] args = ["100000", "240"];            

            string userMessage = Main.Execute(args);

            Assert.Equal("Le nombre d'arguments doit être égal à 3", userMessage);
        }

        [Fact]
        public void CreditImmoProgram_MontantEmpruntIncorrect()
        {
            string[] args = ["0", "108", "1.2"];

            string userMessage = Main.Execute(args);

            Assert.Equal("Le montant de l'emprunt doit être >= 50 000€", userMessage);
        }

        [Fact]
        public void CreditImmoProgram_DureeEmpruntInferieure()
        {
            string[] args = ["50000", "107", "1.2"];

            string userMessage = Main.Execute(args);

            Assert.Equal("La durée de l'emprunt doit être >= 9 ans", userMessage);
        }

        [Fact]
        public void CreditImmoProgram_DureeEmpruntSuperieure()
        {
            string[] args = ["50000", "301", "1.2"];

            string userMessage = Main.Execute(args);

            Assert.Equal("La durée de l'emprunt doit être <= 25 ans", userMessage);
        }

        [Fact]
        public void CreditImmoProgram_TauxIncorrect()
        {
            string[] args = ["50000", "108", "-0.1"];

            string userMessage = Main.Execute(args);

            Assert.Equal("Le taux de l'emprunt doit être >= 0", userMessage);
        }

        [Fact]
        public void CreditImmoProgram_ValeursCorrectes()
        {
            string[] args = ["50000", "108", "1.2"];

            string userMessage = Main.Execute(args);

            Assert.Contains("creditImmo_", userMessage);
            Assert.Contains(".csv", userMessage);

            File.Delete(userMessage);
        }
    }
}
