using CredImmo.App.Models;

namespace CredImmo.App
{
    public sealed class CalculCreditImmo
    {
        public static CreditImmoResultat Calcul(CreditImmo creditImmo)
        {
            int mensualite = CalculMensualite(creditImmo.Montant, creditImmo.Taux, creditImmo.Duree);

            int rembourse = 0;
            int restant = mensualite * creditImmo.Duree;

            List<PaiementMensuel> mensualites = [];
            for (int mois = 1; mois <= creditImmo.Duree; mois++)
            {
                restant -= mensualite;
                rembourse += mensualite;
                mensualites.Add(new PaiementMensuel(mois, mensualite, rembourse, restant));             
            }

            int total = mensualite * creditImmo.Duree - creditImmo.Montant;
            return new CreditImmoResultat(total, mensualites);            
        }

        private static int CalculMensualite(int montant, float taux, int duree)
        {
            float tauxAnnuel = taux / 100 / 12;
            return (int)Math.Round((montant * tauxAnnuel) / (1 - (float)Math.Pow(1 + tauxAnnuel, -duree)), 2);
        }
    }
}
