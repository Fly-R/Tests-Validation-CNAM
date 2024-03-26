using CredImmo.App.Models;

namespace CredImmo.App
{
    public static class CSVWriter
    {
        public static string Write(CreditImmoResultat creditImmo)
        {
            string fileName = $"creditImmo_{DateTime.Now:yyyyMMddHHmmss}.csv";
            File.WriteAllText(fileName, creditImmo.ToCSV());
            return fileName;
        }
    }
}
