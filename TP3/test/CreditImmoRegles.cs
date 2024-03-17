using CredImmo.App.Exceptions;
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

        [Fact]
        public void MontantEmprunt_InferieurLimite()
        {
            const int montantEmprunt = CreditImmo.EMPRUNT_MIN_VALUE - 1;
            const int dureeEmpruntAnnee = 1;
            const float taux = 0.01f;

            EmpruntException exception = Assert.Throws<EmpruntException>(() => new CreditImmo(montantEmprunt, dureeEmpruntAnnee, taux));
            Assert.Equal("Le montant de l'emprunt doit être >= 50 000€", exception.Message);
        }
    }
}