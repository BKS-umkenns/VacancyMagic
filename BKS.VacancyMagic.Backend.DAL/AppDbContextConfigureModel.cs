using BKS.VacancyMagic.Backend.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BKS.VacancyMagic.Backend.DAL;

public sealed partial class AppDbContext
{
    static partial void ConfigureModel(ModelBuilder builder)
    {
        builder.Entity<SearchQuery>(entity =>
        {
            entity.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId);
        });
    }
}
