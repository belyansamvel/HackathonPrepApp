using LoanApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanApp.Models
{
    public class Credit
    {
        private int CreditNumber { get; set; }    //ToDo- add initialising rools
        private decimal CreditAmmount { get; set; }
        private DateTime DisbursementDate { get; set; }
        private DateTime RepaymentDate { get; set; }
        private bool IsActive { get; set; }
        private int? RepaymentQuality { get; set; }

        public Credit(decimal CreditAmmount, DateTime DisbursementDate, DateTime RepaymentDate, bool IsActive, int RepaymentQuality)
        {
            CreditNumber = CreditNumberGanareteHelper.GenereteCreditNumber(new HashSet<int> { 10000000});//change with DAL functins
            this.CreditAmmount = CreditAmmount;
            this.DisbursementDate = DisbursementDate;
            this.RepaymentDate = RepaymentDate;
            this.IsActive = IsActive;
            this.RepaymentQuality = RepaymentQuality;            
        }



    }
}
