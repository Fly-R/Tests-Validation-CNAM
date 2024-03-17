namespace CredImmo.App.Exceptions
{
    public sealed class DureeInfException : Exception
    {
        public DureeInfException() : base("La durée de l'emprunt doit être >= 9 ans")
        {
        }
    }
}
