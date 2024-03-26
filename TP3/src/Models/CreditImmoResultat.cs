using System.Text;

namespace CredImmo.App.Models
{
    public sealed class CreditImmoResultat
    {
        public float Total { get; }

        public IReadOnlyList<PaiementMensuel> PaiementsMensuel { get; }

        public CreditImmoResultat(float total, List<PaiementMensuel> paiementsMensuel)
        {
            Total = total;
            PaiementsMensuel = paiementsMensuel.AsReadOnly();
        }

        public string ToCSV()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Total;{Total};");
            stringBuilder.AppendLine("Mois;Mensualite;Rembourse;Restant;");
            foreach (PaiementMensuel paiementMensuel in PaiementsMensuel)
            {
                stringBuilder.AppendLine(paiementMensuel.ToCSV());
            }
            return stringBuilder.ToString();
        }
    }
}
