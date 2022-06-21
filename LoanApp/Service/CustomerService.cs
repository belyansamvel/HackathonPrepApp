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
            if (ValidationOfCustomer(customer))
            {
                //finde in DB customer, if exist, return true
                //
                return true;
            }
            else return false;
        }

        

    }
}
