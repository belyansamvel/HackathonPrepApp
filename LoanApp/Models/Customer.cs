using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanApp.Models
{
    public class Customer
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public int IDNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsMarried { get; set; }
        public string Workplace { get; set; }
        public decimal NetSallary { get; set; }
        public bool HaveFamilyMamber { get; set; }
        public List<Customer> FamilyMamber { get; set; }
        public Dictionary<string, string> Errors { get; set; }

        public Customer()
        {
            FamilyMamber = new List<Customer>();
            Errors = new Dictionary<string, string>();
        }
    }
}
