namespace LoanApp.Service
{
    public class CreditNumberGanareteHelper
    {
        public static int GenereteCreditNumber(HashSet<int> CreditNumbers)
        {
            int lust = 10000000;
            if (CreditNumbers!=null)
            {
                lust = CreditNumbers.Last();
                CreditNumbers.Add(lust + 1);
            }
            else
            { 
                CreditNumbers = new HashSet<int> { lust };
            }
            return lust;
        }
    }
}
