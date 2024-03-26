using CredImmo.App.Models;

namespace CredImmo.App
{
    public sealed class CalculCreditImmo
    {
        public static CreditImmoResultat Calcul(CreditImmo creditImmo)
        {
            List<PaiementMensuel> mensualites = [];
            for (int mois = 1; mois <= creditImmo.Duree; mois++)
            {
                mensualites.Add(new PaiementMensuel(mois,0, 0, 0));             
            }

            return new CreditImmoResultat(0, mensualites);            
        }
    }
}
