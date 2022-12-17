
using Microsoft.EntityFrameworkCore;

namespace FireHire.Server.Data
{
    public class FireHireDbContext : DbContext
    {
        public DbSet<VacancyDb> Vacancies { get; set; }
        public DbSet<ResumeDb> Resumes { get; set; }
        public DbSet<SalaryDb> Salaries { get; set; }
        public DbSet<ScoringDataDb> ScoringData { get; set; }


        public FireHireDbContext(DbContextOptions<FireHireDbContext> options) : base(options)
        {
        }
    }
}
