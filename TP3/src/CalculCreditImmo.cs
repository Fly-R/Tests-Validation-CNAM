using CredImmo.App.Models;

namespace CredImmo.App
{
    public sealed class CalculCreditImmo(CreditImmo creditImmo)
    {
        private readonly CreditImmo _creditImmo = creditImmo;

        public CreditImmoResultat Calcul()
        {
            List<PaiementMensuel> mensualites = [];
            for (int mois = 1; mois <= _creditImmo.Duree; mois++)
            {
                mensualites.Add(new PaiementMensuel(mois, 0, 0));             
            }

            return new CreditImmoResultat(0, mensualites);            
        }
    }
}
