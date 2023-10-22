using BKS.VacancyMagic.Backend.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BKS.VacancyMagic.Backend.DAL;

public sealed partial class AppDbContext
{
    static partial void ConfigureModel(ModelBuilder builder)
    {
        builder.Entity<User>(entity =>
        {
            entity.HasData(
                new User
                {
                    Id = 1,
                    Email = "test@mail.test",
                    Name = "test123",
                    PasswordHash = "test123",
                    FirstName = "admin",
                    LastName = "admin",
                    MiddleName = "admin"
                }
             );
        });

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

        builder.Entity<Service>(entity =>
        {
            entity.HasData(
                new Service { Id = 1, Name = "SuperJob" }
             );
        });

        builder.Entity<ServiceAuthorization>(entity =>
        {
            entity.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId);
            entity.HasOne(x => x.Service).WithMany().HasForeignKey(x => x.ServiceId);

            entity.HasData(
                new ServiceAuthorization { 
                    Id = 1,
                    AccessToken = "v3.r.137902953.5a4ad294828a9de685646546c324d48fe6da0aaa.187cad61ee9bc617932d8ecc5a936804c1a0b43a",
                    RefreshToken = "v3.r.137902953.5a4ad294828a9de685646546c324d48fe6da0aaa.187cad61ee9bc617932d8ecc5a936804c1a0b43a",
                    SecretKey = "v3.r.137902953.2438a9ca6677da093e5068ff8b52c65119ccbd0e.db749930ceec732297cc24f351ef405d053c4466",
                    ServiceId = 1,
                    UserId = 1
                }
             );
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
    }
}
