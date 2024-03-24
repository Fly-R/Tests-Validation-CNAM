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
                new PaiementMensuel(1, 10, 90),
                new PaiementMensuel(2, 20, 80),
                new PaiementMensuel(3, 30, 70),
                new PaiementMensuel(4, 40, 60),
                new PaiementMensuel(5, 50, 50),
                new PaiementMensuel(6, 60, 40),
                new PaiementMensuel(7, 70, 30),
                new PaiementMensuel(8, 80, 20),
                new PaiementMensuel(9, 90, 10),
                new PaiementMensuel(10, 100, 0),
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
            PaiementMensuel paiementMensuel = new PaiementMensuel(mois, rembourse, restant);

            Assert.NotNull(paiementMensuel);
            Assert.Equal(mois, paiementMensuel.Mois);
            Assert.Equal(rembourse, paiementMensuel.Rembourse);
            Assert.Equal(restant, paiementMensuel.Restant);
        }
    }
}
