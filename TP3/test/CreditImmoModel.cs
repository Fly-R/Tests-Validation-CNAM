using CredImmo.App.Models;

namespace CredImmo.Test
{
    public class CreditImmoModel
    {
        [Fact]
        public void CreditImmo_ValeursCorrectes()
        {
            const int montantEmprunt = CreditImmo.EMPRUNT_MIN_VALUE;
            const int dureeAnnee = CreditImmo.DUREE_ANNEE_MIN_VALUE;
            const float taux = 0.01f;

            CreditImmo creditImmo = new CreditImmo(montantEmprunt, dureeAnnee, taux);
            
            Assert.NotNull(creditImmo);
            Assert.Equal(montantEmprunt, creditImmo.MontantEmprunt);
            Assert.Equal(dureeAnnee, creditImmo.DureeAnnee);
            Assert.Equal(taux, creditImmo.Taux);

        }
    }
}
