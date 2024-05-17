using Candidates.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Candidates.EF.Data
{
    public class ApplicationDbContext : DbContext
    {
        #region DbSets
        public DbSet<Candidate> Candidates { get; set; }

        #endregion

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidate>()
                .HasKey(c => c.Email);
        }
    }
}
