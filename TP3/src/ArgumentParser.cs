namespace CredImmo.App
{
    public sealed class ArgumentParser
    {        
        public int Montant { get; }
        public int Duree { get; }
        public float Taux { get; }

        public ArgumentParser(string[] args)
        {
            if(args.Length < 3)
                throw new ArgumentException("Le nombre d'arguments doit être égal à 3");

            if (!int.TryParse(args[0], out int montant))
                throw new InvalidCastException("Le montant de l'emprunt doit être un nombre entier");
            if (!int.TryParse(args[1], out int duree))
                throw new InvalidCastException("La durée de l'emprunt doit être un nombre entier");
            if (!float.TryParse(args[2].Replace('.', ','), out float taux))
                throw new InvalidCastException("Le taux de l'emprunt doit être un nombre décimal");     
            
            Montant = montant;
            Duree = duree;
            Taux = taux;
        }
    }
}
