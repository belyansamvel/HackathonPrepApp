using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanApp.Models
{
    public class CreditApplication
    {
        public decimal CreditAmmount { get; set; }
        public int LoanRepaymentPeriodInMonth { get; set; }
        public Customer Customer { get; set; }

        public CreditApplication()
        {
            Customer = new Customer();
        }
    }
}
