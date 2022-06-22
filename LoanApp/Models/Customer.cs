using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanApp.Models
{
    public class Customer
    {
        internal string Name { get; set; }
        internal string SurName { get; set; }
        internal int IDNumber { get; set; }
        internal DateTime DateOfBirth { get; set; }
        internal bool IsMarried { get; set; }
        internal string Workplace { get; set; }
        internal decimal NetSallary { get; set; }
        internal bool HaveFamilyMamber { get; set; }
        internal List <Customer>? FamilyMamber { get; set; }  
        internal Dictionary <string, string> Errors { get; set; }
        public Customer()
        {
        }
        public Customer(string Name, string SurName, int ID, DateTime DateOfBirth, bool IsMarried, string Workplace, decimal NetSallary, bool HaveFamilyMamber, List<Customer> FamilyMambers)
        {
            this.Name = Name;
            this.SurName = SurName;
            IDNumber = ID;
            this.DateOfBirth = DateOfBirth;
            this.IsMarried = IsMarried;
            this.Workplace = Workplace;
            this.NetSallary = NetSallary;
            this.HaveFamilyMamber = HaveFamilyMamber;
            if (HaveFamilyMamber==false || FamilyMamber==null)
            {
                this.FamilyMamber = null;                
            }
            else
            {
                this.FamilyMamber = FamilyMambers;
                for (int i = 0; i < FamilyMamber.Count; i++)
                {
                    FamilyMamber[i].HaveFamilyMamber = true;
                }                
            }            
        }
        public Customer(string Name, string SurName, int ID, string Workplace, decimal NetSallary)
        {
            this.Name = Name;
            this.SurName = SurName;
            IDNumber = ID;
            this.Workplace = Workplace;
            this.NetSallary = NetSallary;
        }
    }
}
