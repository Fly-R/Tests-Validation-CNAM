namespace CredImmo.App.Models
{
    public sealed class CreditImmo
    {
        private const int MONTHS_PER_YEAR = 12;

        public const int EMPRUNT_MIN = 50000;
        public const int DUREE_MOIS_MIN = 9*MONTHS_PER_YEAR;
        public const int DUREE_MOIS_MAX = 25*MONTHS_PER_YEAR;

        public int Montant { get; }        
        public int Duree { get; }
        public float Taux { get; }


        public CreditImmo(int montantEmprunt, int dureeEmprunt, float taux)
        {
            Montant = montantEmprunt;
            Duree = dureeEmprunt;
            Taux = taux;
        }

    }
}
