

using Microsoft.EntityFrameworkCore;
using AcceptorsClub.Core.Models;

namespace AcceptorsClub.Infrastructure;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
    {
        
    }
    public DbSet<CustomerScore> CustomerScore { get; set; }

     protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerScoreReportEntity>(entity =>
        {
            entity.HasNoKey();
        });
        modelBuilder.Entity<SumCustomerScoreReportEntity>(entity =>
        {
            entity.HasNoKey();
        });

        base.OnModelCreating(modelBuilder);
    }
}
