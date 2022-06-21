using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanApp.Models
{
    public class Customer
    {
        public string Name { get; set; }
        internal string SurName { get; set; }
        internal int IDNumber { get; set; }
        internal DateTime DateOfBirth { get; set; }
        internal bool IsMarried { get; set; }
        internal string Workplace { get; set; }
        internal decimal NetSallary { get; set; }
        internal bool HaveFamilyMamber { get; set; }
        internal Customer? FamilyMamber { get; set; }

        public Customer(string Name, string SurName, int ID, DateTime DateOfBirth, bool IsMarried, string Workplace, decimal NetSallary, bool HaveFamilyMamber)
        {
            this.Name = Name;
            this.SurName = SurName;
            IDNumber = ID;
            this.DateOfBirth = DateOfBirth;
            this.IsMarried = IsMarried;
            this.Workplace = Workplace;
            this.NetSallary = NetSallary;
            this.HaveFamilyMamber = HaveFamilyMamber;
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
