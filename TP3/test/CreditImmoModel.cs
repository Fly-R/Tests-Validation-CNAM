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

        [Theory]    
        [InlineData(9, 108)]
        [InlineData(25, 300)]
        public void CreditImmo_ConversionAnneeMois(int annee, int mois)
        {
            const int montantEmprunt = CreditImmo.EMPRUNT_MIN_VALUE;            
            const float taux = 0.01f;

            CreditImmo creditImmo = new CreditImmo(montantEmprunt, annee, taux);
                        
            Assert.Equal(mois, creditImmo.DureeMois);
        }
    }
}
