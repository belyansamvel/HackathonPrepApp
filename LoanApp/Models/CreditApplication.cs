using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanApp.Models
{
    public class CreditApplication
    {
        internal decimal CreditAmmount { get; set; }
        internal int LoanRepaymentPeriodInMonth { get; set; }
        internal Customer Customer { get; set; }
        public CreditApplication(decimal CreditAmmount, int LoanRepaymentPeriodInMonth, Customer Customer)
        {
            this.CreditAmmount = CreditAmmount;
            this.LoanRepaymentPeriodInMonth = LoanRepaymentPeriodInMonth;
            this.Customer = Customer;
        }
    }
}
