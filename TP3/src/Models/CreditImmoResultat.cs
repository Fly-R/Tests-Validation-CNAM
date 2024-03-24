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
    }
}
