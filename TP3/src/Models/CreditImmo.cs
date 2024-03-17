using CredImmo.App.Exceptions;

namespace CredImmo.App.Models
{
    public sealed class CreditImmo
    {
        public const int EMPRUNT_MIN_VALUE = 50000;
        public const int DUREE_ANNEE_MIN_VALUE = 9;

        public int MontantEmprunt { get; }        

        public CreditImmo(int montantEmprunt, int dureeEmpruntAnnee, float taux)
        {
            if(montantEmprunt < EMPRUNT_MIN_VALUE)            
                throw new EmpruntException();       
            if(dureeEmpruntAnnee < DUREE_ANNEE_MIN_VALUE)
                throw new DureeInfException();
        }

    }
}
