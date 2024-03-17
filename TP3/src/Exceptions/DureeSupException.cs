namespace CredImmo.App.Exceptions
{
    public sealed class DureeSupException : Exception
    {
        public DureeSupException() : base("La durée de l'emprunt doit être <= 25 ans")
        {
        }
    }
}
