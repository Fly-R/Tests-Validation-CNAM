namespace CredImmo.App.Exceptions
{
    public sealed class EmpruntException : Exception
    {
        public EmpruntException() : base("Le montant de l'emprunt doit être >= 50 000€")
        {
        }
    }
}
