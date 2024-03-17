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
            const int dureeEmpruntAnnee = CreditImmo.DUREE_ANNEE_MIN_VALUE;
            const float taux = 0.01f;

            Exception exception = Record.Exception(() => new CreditImmo(montantEmprunt, dureeEmpruntAnnee, taux));

            Assert.Null(exception);
        }

        [Fact]
        public void MontantEmprunt_InferieurLimite()
        {
            const int montantEmprunt = CreditImmo.EMPRUNT_MIN_VALUE - 1;
            const int dureeEmpruntAnnee = CreditImmo.DUREE_ANNEE_MIN_VALUE;
            const float taux = 0.01f;

            EmpruntException exception = Assert.Throws<EmpruntException>(() => new CreditImmo(montantEmprunt, dureeEmpruntAnnee, taux));
            Assert.Equal("Le montant de l'emprunt doit être >= 50 000€", exception.Message);
        }

        [Fact]
        public void DureeEmprunt_Correct()
        {
            const int montantEmprunt = CreditImmo.EMPRUNT_MIN_VALUE;
            const int dureeEmpruntAnnee = CreditImmo.DUREE_ANNEE_MIN_VALUE;
            const float taux = 0.01f;

            Exception exception = Record.Exception(() => new CreditImmo(montantEmprunt, dureeEmpruntAnnee, taux));

            Assert.Null(exception);
        }

        [Fact]
        public void DureeEmprunt_InferieurLimite()
        {
            const int montantEmprunt = CreditImmo.EMPRUNT_MIN_VALUE;
            const int dureeEmpruntAnnee = CreditImmo.DUREE_ANNEE_MIN_VALUE - 1;
            const float taux = 0.01f;

            DureeInfException exception = Assert.Throws<DureeInfException>(() => new CreditImmo(montantEmprunt, dureeEmpruntAnnee, taux));
            Assert.Equal("La durée de l'emprunt doit être >= 9 ans", exception.Message);
        }
        
        [Fact]
        public void DureeEmprun_SuperieurLimite()
        {
            const int montantEmprunt = CreditImmo.EMPRUNT_MIN_VALUE;
            const int dureeEmpruntAnnee = CreditImmo.DUREE_ANNEE_MAX_VALUE + 1;
            const float taux = 0.01f;

            DureeSupException exception = Assert.Throws<DureeSupException>(() => new CreditImmo(montantEmprunt, dureeEmpruntAnnee, taux));
            Assert.Equal("La durée de l'emprunt doit être <= 25 ans", exception.Message);
        }
    }
}