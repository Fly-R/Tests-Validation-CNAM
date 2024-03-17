namespace CredImmo.App.Models
{
    public sealed class CreditImmo
    {
        public const int EMPRUNT_MIN_VALUE = 50000;       
        
        public int MontantEmprunt { get; }

        public CreditImmo(int montantEmprunt, int dureeEmpruntMois, float taux)
        {
            
        }

    }
}
