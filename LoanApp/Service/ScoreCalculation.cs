using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanApp.Service
{
    public class ScoreCalculation
    {  
        public decimal CalculateMonthlyRepayment(decimal CreditAmmount,int LoanRepaymentPeriodInMonth)
        {
            decimal annualpersentage = 0;            
            decimal futurValue = 0M;
            if (CreditAmmount>=200000 && CreditAmmount <=1000000 && LoanRepaymentPeriodInMonth>=3 && LoanRepaymentPeriodInMonth<=6)
            {
                annualpersentage = 22M;
            }
            else if (CreditAmmount >= 200000 && CreditAmmount <= 1000000 && LoanRepaymentPeriodInMonth > 6 && LoanRepaymentPeriodInMonth <= 12)
            {
                annualpersentage = 23M;
            }
            else if (CreditAmmount >= 200000 && CreditAmmount <= 1000000 && LoanRepaymentPeriodInMonth > 12 && LoanRepaymentPeriodInMonth <= 24)
            {
                annualpersentage = 23.5M;
            }
            else if (CreditAmmount >= 200000 && CreditAmmount <= 1000000 && LoanRepaymentPeriodInMonth > 24 && LoanRepaymentPeriodInMonth <= 36)
            {
                annualpersentage = 24M;
            }
            else if (CreditAmmount>1000000 && CreditAmmount <=2000000 && LoanRepaymentPeriodInMonth>=3 && LoanRepaymentPeriodInMonth<=6)
	        {
                annualpersentage = 20M;
	        }
            else if (CreditAmmount>1000000 && CreditAmmount <=2000000 && LoanRepaymentPeriodInMonth > 6 && LoanRepaymentPeriodInMonth <= 12)
	        {
                annualpersentage = 21M;
	        }
            else if (CreditAmmount>1000000 && CreditAmmount <=2000000 && LoanRepaymentPeriodInMonth > 12 && LoanRepaymentPeriodInMonth <= 24)
	        {
                annualpersentage = 21.5M;
	        }
            else if (CreditAmmount>1000000 && CreditAmmount <=2000000 && LoanRepaymentPeriodInMonth > 24 && LoanRepaymentPeriodInMonth <= 36)
	        {
                annualpersentage = 22;
            } 

            decimal value = (CreditAmmount*(1+annualpersentage));
            for (int i = 0; i < LoanRepaymentPeriodInMonth; i++)
			{
                futurValue*= value;
			} 
            decimal monthlyrepayment = futurValue/LoanRepaymentPeriodInMonth;

            return monthlyrepayment;
        }
        public decimal LoanRepaymentRatio(int NetSallary, decimal monthlyrepayment)
        {
            decimal repaymentRatio = NetSallary/monthlyrepayment;
            return repaymentRatio;
        }


    }
}
