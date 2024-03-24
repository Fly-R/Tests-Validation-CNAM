namespace CredImmo.App.Models
{
    public sealed class PaiementMensuel
    {
        public int Mois { get; }
        public float Rembourse { get; }
        public float Restant { get; }

        public PaiementMensuel(int mois, float rembourse, float restant)
        {
            Mois = mois;
            Rembourse = rembourse;
            Restant = restant;
        }
    }
}
