using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanApp.Models
{
    public class CreditApplication
    {
        private decimal CreditAmmount { get; set; }
        private int LoanRepaymentPeriodInMonth { get; set; }
        private Customer Customer { get; set; }
        public CreditApplication(decimal CreditAmmount, int LoanRepaymentPeriodInMonth, Customer Customer)
        {
            this.CreditAmmount = CreditAmmount;
            this.LoanRepaymentPeriodInMonth = LoanRepaymentPeriodInMonth;
            this.Customer = Customer;
        }
    }
}
