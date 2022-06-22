using LoanApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace LoanApp.DAL;

public class LoanContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Credit> Credits { get; set; }

    public LoanContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=EPAMYERW011B;Database=LoanDB;Trusted_Connection=True;");
    }
}
