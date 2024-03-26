using CredImmo.App.Models;

namespace CredImmo.Test
{
    public class CreditImmoResultatModel
    {
        [Fact]
        public void CreditImmoResultat_ValeursCorrectes()
        {
            const int total = 42;
            List<PaiementMensuel> paiementMensuels = new List<PaiementMensuel>()
            {
                new PaiementMensuel(1, 42, 10, 90),
                new PaiementMensuel(2, 42, 20, 80),
                new PaiementMensuel(3, 42, 30, 70),
                new PaiementMensuel(4, 42, 40, 60),
                new PaiementMensuel(5, 42, 50, 50),
                new PaiementMensuel(6, 42, 60, 40),
                new PaiementMensuel(7, 42, 70, 30),
                new PaiementMensuel(8, 42, 80, 20),
                new PaiementMensuel(9, 42, 90, 10),
                new PaiementMensuel(10, 42, 100, 0),
            };

            CreditImmoResultat creditImmoResult = new CreditImmoResultat(total, paiementMensuels);

            Assert.NotNull(creditImmoResult);
            Assert.Equal(paiementMensuels.Count, creditImmoResult.PaiementsMensuel.Count);
            Assert.Equal(total, creditImmoResult.Total);
            Assert.Equal(paiementMensuels, creditImmoResult.PaiementsMensuel);
        }

        [Fact]
        public void PaiementMensuel_ValeursCorrectes()
        {
            const int mois = 2;
            const int rembourse = 10;
            const int restant = 90;
            const int montant = 42;
            PaiementMensuel paiementMensuel = new PaiementMensuel(mois, montant, rembourse, restant);

            Assert.NotNull(paiementMensuel);
            Assert.Equal(mois, paiementMensuel.Mois);
            Assert.Equal(montant, paiementMensuel.Montant);
            Assert.Equal(rembourse, paiementMensuel.Rembourse);
            Assert.Equal(restant, paiementMensuel.Restant);
        }
    }
}
