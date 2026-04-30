using DesignPatternsDay.Entities;
using Microsoft.EntityFrameworkCore;

namespace DesignPatternsDay.Context
{
    public class BankContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-UGIR0F4\\SQLEXPRESS;initial catalog=DesignPatternChainDb;integrated security=true");
        }
        public DbSet<CustomerProcess> CustomerProcesses { get; set; }
    }
}
