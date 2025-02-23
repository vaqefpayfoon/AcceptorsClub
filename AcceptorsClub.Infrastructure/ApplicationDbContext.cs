

using Microsoft.EntityFrameworkCore;
using AcceptorsClub.Core.Models;

namespace AcceptorsClub.Infrastructure;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
    {
        
    }
    public DbSet<CustomerScore> CustomerScore { get; set; }
    public DbSet<ScorePlan> ScorePlan { get; set; }
    public DbSet<Lottery> Lottery { get; set; }
    public DbSet<Survey> Survey { get; set; }
    // public DbSet<Customer> Customer { get; set; }
    // public DbSet<CustomerWinnerLottery> CustomerWinnerLottery { get; set; }

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

        // modelBuilder.Entity<Lottery>()
        //     .HasMany(c => c.LotteryWinners)
        //     .WithOne(o => o.Lottery)
        //     .HasForeignKey(o => o.LotteryId);

        // modelBuilder.Entity<CustomerWinnerLottery>().HasOne(o => o.Customer).WithMany(o => o.LotteryWinners).HasForeignKey(x => x.CustomerId);

        base.OnModelCreating(modelBuilder);
    }
}
