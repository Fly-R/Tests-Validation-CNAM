using CredImmo.App.Models;

namespace CredImmo.App
{
    public static class Validator
    {
        private const string MONTANT_ERROR_MESSAGE = "Le montant de l'emprunt doit être >= 50 000€";
        private const string DUREE_INF_ERROR_MESSAGE = "La durée de l'emprunt doit être >= 9 ans";
        private const string DUREE_SUP_ERROR_MESSAGE = "La durée de l'emprunt doit être <= 25 ans";
        private const string TAUX_ERROR_MESSAGE = "Le taux de l'emprunt doit être >= 0";

        public static bool IsValid(CreditImmo creditImmo, out string outputMessage)
        {
            outputMessage = string.Empty;

            if (creditImmo.Montant < CreditImmo.EMPRUNT_MIN)
                outputMessage = MONTANT_ERROR_MESSAGE;
            if (creditImmo.Duree < CreditImmo.DUREE_MOIS_MIN)
                outputMessage = DUREE_INF_ERROR_MESSAGE;
            if (creditImmo.Duree > CreditImmo.DUREE_MOIS_MAX)
                outputMessage = DUREE_SUP_ERROR_MESSAGE;
            if (creditImmo.Taux < 0)
                outputMessage = TAUX_ERROR_MESSAGE;

            if (string.IsNullOrEmpty(outputMessage)) return true;
            return false;
        }
    }
}
