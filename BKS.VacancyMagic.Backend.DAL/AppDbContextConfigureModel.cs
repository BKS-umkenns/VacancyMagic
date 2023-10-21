using BKS.VacancyMagic.Backend.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BKS.VacancyMagic.Backend.DAL;

public sealed partial class AppDbContext
{
    static partial void ConfigureModel(ModelBuilder builder)
    {
        builder.Entity<Reply>(entity =>
        {
            entity.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId);
            entity.HasOne(x => x.Service).WithMany().HasForeignKey(x => x.ServiceId);
        });

        builder.Entity<SearchQuery>(entity =>
        {
            entity.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId);
        });

        builder.Entity<SearchValue>(entity =>
        {
            entity.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId);
            entity.HasOne(x => x.Service).WithMany().HasForeignKey(x => x.ServiceId);
        });

        builder.Entity<ServiceAuthorization>(entity =>
        {
            entity.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId);
            entity.HasOne(x => x.Service).WithMany().HasForeignKey(x => x.ServiceId);
        });

        builder.Entity<ReplyStatus>(entity =>
        {
            entity.HasOne(x => x.Service).WithMany().HasForeignKey(x => x.ServiceId);
        });

        builder.Entity<Tag>(entity =>
        {
            entity.HasOne(x => x.Service).WithMany().HasForeignKey(x => x.ServiceId);
        });

        builder.Entity<SearchTag>(entity =>
        {
            entity.HasOne(x => x.Tag).WithMany().HasForeignKey(x => x.TagId);
            entity.HasOne(x => x.SearchQuery).WithMany().HasForeignKey(x => x.SearchQueryId);
        });

        builder.Entity<ReplyHistory>(entity =>
        {
            entity.HasOne(x => x.Reply).WithMany().HasForeignKey(x => x.ReplyId);
            entity.HasOne(x => x.ReplyStatus).WithMany().HasForeignKey(x => x.StatusId);
        });

        builder.Entity<Service>(entity =>
        {
            entity.HasData(
                new Service { Id = 1, Name = "SuperJob" }
             );
        });
    }
}
