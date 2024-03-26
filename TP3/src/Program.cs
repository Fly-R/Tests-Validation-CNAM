using CredImmo.App.Models;

namespace CredImmo.App
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Execute(args));
        }

        public static string Execute(string[] args)
        {
            try
            {
                ArgumentParser parser = new ArgumentParser(args);
                CreditImmo creditImmo = new CreditImmo(parser.Montant, parser.Duree, parser.Taux);

                if (Validator.IsValid(creditImmo, out string outputMessage))
                {
                    CreditImmoResultat resultat = CalculCreditImmo.Calcul(creditImmo);
                    return CSVWriter.Write(resultat);
                }
                else
                {
                    return outputMessage;
                }
            }
            catch (Exception exc)
            {
                return exc.Message;
            }
        }
    }
}
