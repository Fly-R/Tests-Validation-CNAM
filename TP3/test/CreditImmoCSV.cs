using CredImmo.App.Models;

namespace CredImmo.Test
{
    public class CreditImmoCSV
    {
        [Fact]
        public void CSVWriter_PaiementMensuel()
        {
            const int mois = 2;
            const int value = 10;
            const int rembourse = 10;
            const int restant = 20;
            string expected = $"{mois};{value};{rembourse};{restant};";

            PaiementMensuel paiementMensuel = new PaiementMensuel(mois, value, rembourse, restant);

            Assert.Equal(expected, paiementMensuel.ToCSV());
        }
    }
}
