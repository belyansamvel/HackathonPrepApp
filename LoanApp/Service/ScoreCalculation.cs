using LoanApp.Models;
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
        public decimal LoanRepaymentRatio(decimal NetSallary, decimal monthlyrepayment)
        {
            decimal repaymentRatio = NetSallary/monthlyrepayment;
            return repaymentRatio;
        }
        
        /*3․Մեթոդ հաճախորդի տարիքի հաշվարկ
        Ստանում է ծննդյան տարեթիվը, վերադարձնում է հաճախորդի տարիքը տարիներով*/
        public double CustomerAgeCalculation(Customer customer)
        {
            double age = ((customer.DateOfBirth - DateTime.Now).TotalDays) / 365;
            return age; 
        }
        /*4․Մեթոդ սքորի հաշվարկի համար նախապայմաններ/բուլյան 
        Ստանում է վարկի մարման գործակից,  
        Ստանում է հաճախորդի տարիքը 
        1․ եթե վարկի մարման գործակիցը եթե <1,7 վերադարձնում է ֆոլս 
        2․եթե հաճախորդի տարիքը <18 կամ  >63 վերադարձնում է ֆոլս */
        public bool SqoreCalculationValidation(Customer customer, CreditApplication creditApplication)
        {
            decimal repaymentRatio = LoanRepaymentRatio(customer.NetSallary, CalculateMonthlyRepayment(creditApplication.CreditAmmount, creditApplication.LoanRepaymentPeriodInMonth));
            double age = CustomerAgeCalculation(customer);
            if ((double)repaymentRatio<1.7)
            {
                return false;
            }
            else if (age<18 ||age >63)
            {
                return false;
            }
            else
            {
                return true;    
            }
        }
        /*Մեթոդ վարկի սքորի հաշվարկ 
        Ստանում է վարկի մարման գործակից, 
        Ստանում է հաճախորդի տարիքը 
        Ստանում է Ընտանեկան կարգավիճակ 
        Վերագրում է սքորեր հետևյալ տրամաբանությամբ 
        վարկի մարման գործակից Սքորի միավոր 
        1,7-3 10 
        3-6         20 
        >6         30 
         
        Հաճախորդի տարիք Սքորի միավոր 
        18-30 3 
        30-50 5 
        50-63 1 
         
        Ընտանեկան կարգավիճակ Սքորի միավոր 
        ամուսնացած 5 
        չամուսնացած 0 
          
        Վերադարձնում է սքորերի գումարը */
        public int SqorCalculation(Customer customer, CreditApplication creditApplication)
        {
            int scor = 0;
            if (SqoreCalculationValidation(customer, creditApplication))
            {               
                decimal repaymentRatio = LoanRepaymentRatio(customer.NetSallary, CalculateMonthlyRepayment(creditApplication.CreditAmmount, creditApplication.LoanRepaymentPeriodInMonth));
                double age = CustomerAgeCalculation(customer);
                bool isMarried = customer.IsMarried;
                if ((double)repaymentRatio>1.7 && (double)repaymentRatio <= 3)
                {
                    scor += 10;
                }
                else if ((double)repaymentRatio > 3 && (double)repaymentRatio <= 6)
                {
                    scor += 20;
                }
                else if ((double)repaymentRatio > 6)
                {
                    scor += 30;
                }
                else if (age>=18 && age<=30)
                {
                    scor += 3;
                }
                else if (age > 30 && age <= 50)
                {
                    scor += 5;
                }
                else if (age > 50 && age <= 63)
                {
                    scor += 1;
                }
                else if (isMarried)
                {
                    scor += 5;
                }                
            }
            return scor;
        }
        /*6․Մեթոդ վարկային պատմության հարցում  
        Ստանում է հաճախորդի ID տվյալները 
        Կատարում է բազային հարցում, եթե հաճախորդը առկա է բազայում, 
        գտնում է հաճախորդի ունեցած վարկերը և վարկի մարման գնահատական սյունակից 
        (1-3 թվեր են) հաշվում է թվաբանական միջինը ու վերադարձնում ստացված գործակիցը */
        public double CheckForCreditHistory(Customer customer)
        {
            double k = 0;
            if (CustomerService.CheckIsBankCustomer(customer))
            {
                //call the function from DB which returns int Array
                int[] credithistory = new int[] {1,3,2,4};
                
                for (int i = 0; i < credithistory.Length; i++)
                {
                    k += credithistory[i];
                }
                k = k / credithistory.Length;
            }
            return k;            
        }
        /*7․Մեթոդ վերջնական սքորի հաշվարկ 
        Ստանում է նախնական սքոր հաշվարկը/11-40/ 
        Ստանում է վարկային պատմության հարցման արդյունքները /1-3/ 
         
        վարկային պատմության հարցման արդյունքները Սքորի միավոր 
        1          -10 
        1-1,5  -5 
        1,5-2  +5 
        2-3         +10 
        Վերադարձնում է նախնական սքորին գումարած վարկային պատմության համար տրամադրված սքորի գումարը */
        public int FinalScoreCalculation(Customer customer, CreditApplication creditApplication)
        {
            double k = CheckForCreditHistory( customer);
            int score = SqorCalculation(customer, creditApplication);
            if (k==1)
            {
                score -= 10;
            }
            else if (k>1 && k<=1.5)
            {
                score -= 5;
            }
            else if (k >1.5 && k <= 2)
            {
                score += 5;
            }
            else if (k > 2)
            {
                score += 10;
            }
            return score;
        }
        /*8․Մեթոդ վարկի տրամադրման արդյունք/բուլյան 
        Ստանում է վերջնական սքորը /11-50/ 
        Եթե արդյունքը փոքր է 30-ից վերադարձնում է ֆոլս, հակառակ դեպքում թրու*/
        public bool CreditAApprovalResult(double k)
        {
            if (k<30)
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
