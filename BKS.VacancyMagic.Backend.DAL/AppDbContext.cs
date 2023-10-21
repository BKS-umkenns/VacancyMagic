using BKS.VacancyMagic.Backend.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BKS.VacancyMagic.Backend.DAL;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        ConfigureModel(modelBuilder);
    }

    static partial void ConfigureModel(ModelBuilder builder);
}