using CredImmo.App.Models;

namespace CredImmo.Test
{
    public class CreditImmoModel
    {
        [Fact]
        public void CreditImmo_ValeursCorrectes()
        {
            const int montantEmprunt = CreditImmo.EMPRUNT_MIN;
            const int duree = CreditImmo.DUREE_MOIS_MIN;
            const float taux = 0.01f;

            CreditImmo creditImmo = new CreditImmo(montantEmprunt, duree, taux);
            
            Assert.NotNull(creditImmo);
            Assert.Equal(montantEmprunt, creditImmo.Montant);
            Assert.Equal(duree, creditImmo.Duree);
            Assert.Equal(taux, creditImmo.Taux);
        }       
    }
}
