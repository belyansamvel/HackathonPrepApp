using LoanApp.Models;

namespace LoanApp.Service
{
    public class CustomerService
    {
        public  static bool ValidationOfCustomer(Customer customer)
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
                    string ErrorKey = "IDNumberError";
                    string ErrorMassage = "ID Number is not valid!";
                    customer.Errors.Add(ErrorKey, ErrorMassage);
                    return false;
                }
                else if (((customer.DateOfBirth - DateTime.Now).TotalDays)/365<18 || ((customer.DateOfBirth - DateTime.Now).TotalDays) / 365>63)
                {
                    string ErrorKey = "AgeError";
                    string ErrorMassage = "Your age is not >=18 or <=63";
                    customer.Errors.Add(ErrorKey, ErrorMassage);
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

        public static bool ValidationCreditApplication (decimal CreditAmmount, int LoanRepaymentPeriodInMonth, Customer customer)
        {
            if (CreditAmmount<=200000 && CreditAmmount >5000000)
            {
                string ErrorKey = "CreditAmountError";
                string ErrorMassage = "Credit amount is less than 200000 or greater than 5000000!";
                customer.Errors.Add(ErrorKey, ErrorMassage);
                return false;
            }
            else if (LoanRepaymentPeriodInMonth<3 && LoanRepaymentPeriodInMonth>36)
            {
                string ErrorKey = "CreditRepaymentTimeError";
                string ErrorMassage = "Credit repayment time is less than 3 months or greater than 36 month!";
                customer.Errors.Add(ErrorKey, ErrorMassage);
                return false;
            }
            else
            {
                return true;
            }
        }
        

    }
}
