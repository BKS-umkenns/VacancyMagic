using BKS.VacancyMagic.Backend.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BKS.VacancyMagic.Backend.DAL;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
    {
        Database.Migrate();
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Reply> Replies { get; set; }
    public DbSet<ReplyStatus> ReplyStatuses { get; set; }
    public DbSet<ReplyHistory> ReplyHistories { get; set; }
    public DbSet<SearchQuery> SearchQueries { get; set; }
    public DbSet<SearchTag> SearchTags { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<ServiceAuthorization> ServiceAuthorizations { get; set; }
    public DbSet<SearchValue> SearchValues { get; set; }
    public DbSet<Service> Services { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        ConfigureModel(modelBuilder);
    }

    static partial void ConfigureModel(ModelBuilder builder);
}