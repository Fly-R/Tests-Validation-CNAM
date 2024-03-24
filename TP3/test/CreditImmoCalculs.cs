using CredImmo.App;
using CredImmo.App.Models;

namespace CredImmo.Test
{
    public class CreditImmoCalculs
    {
        [Theory]
        [InlineData(9*12)]
        [InlineData(10*12+8)]
        [InlineData(25*12)]
        public void CalculCredit_NombreMensualite(int month)
        {
            CreditImmo input = new CreditImmo(50000, month, 1.2f);

            CalculCreditImmo calcul = new CalculCreditImmo(input);
            CreditImmoResultat result = calcul.Calcul();           

            Assert.Equal(month, result.PaiementsMensuel.Count);

        }     
    }
}
