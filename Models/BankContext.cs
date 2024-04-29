using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Bank_Branch.Models
{
    public class BankContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<BankBranch> BankBranches { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<BankBranch>().HasData(
                new BankBranch()
                {
                    BankId = 1,
                    LocationName = "Al-Jahra Branch",
                    LocationURL = "https://maps.app.goo.gl/mPDxWzf5bcwgNCek9",
                    BranchManager = "Mohammed Ali",
                    EmployeeCount = 20
                },

                new BankBranch()
                {
                    BankId = 2,
                    LocationName = "Kaifan Branch",
                    LocationURL = "https://maps.app.goo.gl/DnMgNCGQD1cpPJLFA",
                    BranchManager = "Saoud Faleh",
                    EmployeeCount = 18
                },

                new BankBranch()
                {
                    BankId = 3,
                    LocationName = "Al-Khaldiya Branch",
                    LocationURL = "https://maps.app.goo.gl/R559DtfAFDN3f92g8",
                    BranchManager = "Mubarak Mohammed",
                    EmployeeCount = 24
                },

                new BankBranch()
                {
                    BankId = 4,
                    LocationName = "Farwaniya Branch",
                    LocationURL = "https://maps.app.goo.gl/mmLBR5aSciF2k9q8A",
                    BranchManager = "Salem Ali",
                    EmployeeCount = 35
                });
            modelBuilder.Entity<Employee>()
               .HasIndex(e => e.CivilId)
               .IsUnique(true);

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("Data Source=asb.db");
        //}
        public BankContext(DbContextOptions<BankContext> options) : base(options) 
        { 
        
        }
    }
}
