using CredImmo.App;
using CredImmo.App.Models;

namespace CredImmo.Test
{
    public class CreditImmoCalculs
    {
        [Theory]
        [InlineData(9 * 12)]
        [InlineData(10 * 12 + 8)]
        [InlineData(25 * 12)]
        public void CalculCredit_NombreMensualite(int month)
        {
            CreditImmo input = new CreditImmo(50000, month, 1.2f);

            CreditImmoResultat result = CalculCreditImmo.Calcul(input);

            Assert.Equal(month, result.PaiementsMensuel.Count);
        }

        [Theory]
        [InlineData(500_000, 4 * 12, 1.2f, 10_673)]
        [InlineData(50_000, 2 * 12, 2, 2_127)]
        [InlineData(1_000_000, 10 * 12, 0.5f, 8_545)]
        [InlineData(2_500_000, 25 * 12, 7, 17_669)]
        public void CalculCredit_ValeurMensualiteCorrect(int emprunt, int mois, float taux, int mensualite)
        {
            CreditImmo input = new CreditImmo(emprunt, mois, taux);

            CreditImmoResultat result = CalculCreditImmo.Calcul(input);

            PaiementMensuel paiement = result.PaiementsMensuel[0];

            Assert.Equal(mensualite, paiement.Montant);
            Assert.Equal(mensualite * mois - mensualite, paiement.Restant);

            Assert.Equal(0, result.PaiementsMensuel.Last().Restant);

        }

        [Theory]
        [InlineData(500_000, 4 * 12, 1.2f, 12_304)]
        [InlineData(50_000, 2 * 12, 2, 1_048)]
        [InlineData(1_000_000, 10 * 12, 0.5f, 25_400)]
        [InlineData(2_500_000, 25 * 12, 7, 2_800_700)]
        public void CalculCredit_ValeurTotalCorrect(int emprunt, int mois, float taux, int total)
        {
            CreditImmo input = new CreditImmo(emprunt, mois, taux);

            CreditImmoResultat result = CalculCreditImmo.Calcul(input);

            Assert.Equal(total, result.Total);

        }
    }
}
