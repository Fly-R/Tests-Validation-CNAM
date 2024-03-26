namespace CredImmo.App.Models
{
    public sealed class PaiementMensuel
    {
        public int Mois { get; }
        public int Montant { get; }
        public int Rembourse { get; }
        public int Restant { get; }

        public PaiementMensuel(int mois, int montant, int rembourse, int restant)
        {
            Mois = mois;
            Montant = montant;
            Rembourse = rembourse;
            Restant = restant;
        }

        public string ToCSV()
        {
            return $"{Mois};{Montant};{Rembourse};{Restant};";
        }
    }
}
