using CredImmo.App;
using CredImmo.App.Models;

using System.Formats.Asn1;
using System.Text;

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

        [Fact]
        public void CSVWriter_CreditImmoResultat()
        {
            const int total = 42;
            List<PaiementMensuel> paiementMensuels = new List<PaiementMensuel>()
            {
                new PaiementMensuel(1,10,10,20),
                new PaiementMensuel(2,10,20,10),
                new PaiementMensuel(3,10,30,0),
            };

            CreditImmoResultat resultat = new CreditImmoResultat(total, paiementMensuels);

            StringBuilder expected = new StringBuilder();
            expected.AppendLine($"Total;{total};");
            expected.AppendLine("Mois;Mensualite;Rembourse;Restant;");
            expected.AppendLine("1;10;10;20;");
            expected.AppendLine("2;10;20;10;");
            expected.AppendLine("3;10;30;0;");

            Assert.Equal(expected.ToString(), resultat.ToCSV());
        }

        [Fact]
        public void CSVWriter_CreditImmoResultat_ContenuFichier()
        {
            const int total = 42;
            List<PaiementMensuel> paiementMensuels = new List<PaiementMensuel>()
            {
                new PaiementMensuel(1,10,10,20),
                new PaiementMensuel(2,10,20,10),
                new PaiementMensuel(3,10,30,0),
            };

            CreditImmoResultat resultat = new CreditImmoResultat(total, paiementMensuels);

            StringBuilder expected = new StringBuilder();
            expected.AppendLine($"Total;{total};");
            expected.AppendLine("Mois;Mensualite;Rembourse;Restant;");
            expected.AppendLine("1;10;10;20;");
            expected.AppendLine("2;10;20;10;");
            expected.AppendLine("3;10;30;0;");

            string path = CSVWriter.Write(resultat);

            string fileContent = File.ReadAllText(path);

            Assert.Equal(expected.ToString(), fileContent);

            File.Delete(path);
        }
    }
}
