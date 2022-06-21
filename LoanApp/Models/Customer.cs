using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanApp.Models
{
    public class Customer
    {
        private string Name { get; set; }
        private string SurName { get; set; }
        private int IDNumber { get; set; }
        private DateTime DateOfBirth { get; set; }
        private bool IsMarried { get; set; }
        private string Workplace { get; set; }
        private decimal NetSallary { get; set; }
        private bool HaveFamilyMamber { get; set; }
        private Customer? FamilyMamber { get; set; }

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
