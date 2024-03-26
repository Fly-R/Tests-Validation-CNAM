using CredImmo.App;
using CredImmo.App.Models;

namespace CredImmo.Test
{
    public class CreditImmoRegles
    {
        [Fact]        
        public void MontantEmprunt_Correct()
        {
            const int montantEmprunt = CreditImmo.EMPRUNT_MIN;
            const int dureeEmpruntAnnee = CreditImmo.DUREE_MOIS_MIN;
            const float taux = 0.01f;

            Assert.True(Validator.IsValid(new CreditImmo(montantEmprunt, dureeEmpruntAnnee, taux), out string outputMessage));
            Assert.Equal(string.Empty, outputMessage);
        }

        [Fact]
        public void MontantEmprunt_InferieurLimite()
        {
            const int montantEmprunt = CreditImmo.EMPRUNT_MIN - 1;
            const int dureeEmpruntAnnee = CreditImmo.DUREE_MOIS_MIN;
            const float taux = 0.01f;

            Assert.False(Validator.IsValid(new CreditImmo(montantEmprunt, dureeEmpruntAnnee, taux), out string outputMessage));
            Assert.Equal("Le montant de l'emprunt doit être >= 50 000€", outputMessage);
        }

        [Fact]
        public void DureeEmprunt_Correct()
        {
            const int montantEmprunt = CreditImmo.EMPRUNT_MIN;
            const int dureeEmpruntAnnee = CreditImmo.DUREE_MOIS_MIN;
            const float taux = 0.01f;

            Assert.True(Validator.IsValid(new CreditImmo(montantEmprunt, dureeEmpruntAnnee, taux), out string outputMessage));
            Assert.Equal(string.Empty, outputMessage);
        }

        [Fact]
        public void DureeEmprunt_InferieurLimite()
        {
            const int montantEmprunt = CreditImmo.EMPRUNT_MIN;
            const int dureeEmpruntAnnee = CreditImmo.DUREE_MOIS_MIN - 1;
            const float taux = 0.01f;

            Assert.False(Validator.IsValid(new CreditImmo(montantEmprunt, dureeEmpruntAnnee, taux), out string outputMessage));
            Assert.Equal("La durée de l'emprunt doit être >= 9 ans", outputMessage);
        }
        
        [Fact]
        public void DureeEmprun_SuperieurLimite()
        {
            const int montantEmprunt = CreditImmo.EMPRUNT_MIN;
            const int dureeEmpruntAnnee = CreditImmo.DUREE_MOIS_MAX + 1;
            const float taux = 0.01f;

            Assert.False(Validator.IsValid(new CreditImmo(montantEmprunt, dureeEmpruntAnnee, taux), out string outputMessage));
            Assert.Equal("La durée de l'emprunt doit être <= 25 ans", outputMessage);
        }

        [Fact]
        public void CreditImmoRegles_Taux_Correct()
        {
            const int montantEmprunt = CreditImmo.EMPRUNT_MIN;
            const int dureeEmpruntAnnee = CreditImmo.DUREE_MOIS_MAX;
            const float taux = 0.00f;

            Assert.True(Validator.IsValid(new CreditImmo(montantEmprunt, dureeEmpruntAnnee, taux), out string outputMessage));
            Assert.Equal(string.Empty, outputMessage);
        }

        [Fact]
        public void CreditImmoRegles_Taux_InferieurLimite()
        {
            const int montantEmprunt = CreditImmo.EMPRUNT_MIN;
            const int dureeEmpruntAnnee = CreditImmo.DUREE_MOIS_MAX;
            const float taux = -0.01f;

            Assert.False(Validator.IsValid(new CreditImmo(montantEmprunt, dureeEmpruntAnnee, taux), out string outputMessage));
            Assert.Equal("Le taux de l'emprunt doit être >= 0", outputMessage);
        }
    }
}