using CredImmo.App.Models;

namespace CredImmo.Test
{
    public class CreditImmoRegles
    {
        [Fact]        
        public void MontantEmprunt_Correct()
        {
            const int montantEmprunt = CreditImmo.EMPRUNT_MIN_VALUE;
            const int dureeEmpruntAnnee = 1;
            const float taux = 0.01f;

            Exception exception = Record.Exception(() => new CreditImmo(montantEmprunt, dureeEmpruntAnnee, taux));

            Assert.Null(exception);
        }      
    }
}