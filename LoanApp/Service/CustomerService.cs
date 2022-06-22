using LoanApp.Models;

namespace LoanApp.Service
{
    public class CustomerService
    {
        public static bool ValidationOfCustomer(Customer customer)
        {
            if (customer != null)
            {
                int i = 0;
                double n;
                n = Convert.ToInt32(customer.IDNumber);
                do
                {
                    n = n / 10;
                    i++;
                }
                while (Math.Abs(n) > 1);
                if (i<8)
                {
                    return false;
                }
                else if (((customer.DateOfBirth - DateTime.Now).TotalDays)/365<18 || ((customer.DateOfBirth - DateTime.Now).TotalDays) / 365>63)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public static bool CheckIsBankCustomer(Customer customer)
        {
            if (true/* finde in DB customer, if return not null*/)
            {
                return true;
            }
            else
            { 
                //call the function to registrate customer in DB
                return false;
            } 
        }

        public static bool ValidationCreditApplication (decimal CreditAmmount, int LoanRepaymentPeriodInMonth)
        {
            if (CreditAmmount<=200000 && CreditAmmount >5000000)
            {
                return false;
            }
            else if (LoanRepaymentPeriodInMonth<3 && LoanRepaymentPeriodInMonth>36)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        

    }
}
