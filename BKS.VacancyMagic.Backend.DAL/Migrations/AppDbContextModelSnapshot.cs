﻿// <auto-generated />
using System;
using BKS.VacancyMagic.Backend.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BKS.VacancyMagic.Backend.DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BKS.VacancyMagic.Backend.DAL.Models.Reply", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ServiceId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("ServiceId1")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<string>("VacancyId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ServiceId1");

                    b.HasIndex("UserId");

                    b.ToTable("Replies");
                });

            modelBuilder.Entity("BKS.VacancyMagic.Backend.DAL.Models.ReplyHistory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("ReplyId")
                        .HasColumnType("bigint");

                    b.Property<long>("ReplyStatusId")
                        .HasColumnType("bigint");

                    b.Property<long>("StatusId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ReplyId");

                    b.HasIndex("ReplyStatusId");

                    b.ToTable("ReplyHistories");
                });

            modelBuilder.Entity("BKS.VacancyMagic.Backend.DAL.Models.ReplyStatus", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("ServiceId")
                        .HasColumnType("bigint");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ServiceId");

                    b.ToTable("ReplyStatuses");
                });

            modelBuilder.Entity("BKS.VacancyMagic.Backend.DAL.Models.SearchQuery", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("SearchQueries");
                });

            modelBuilder.Entity("BKS.VacancyMagic.Backend.DAL.Models.SearchTag", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("SearchQueryId")
                        .HasColumnType("bigint");

                    b.Property<long>("TagId")
                        .HasColumnType("bigint");

                    b.Property<byte>("Weight")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("SearchQueryId");

                    b.HasIndex("TagId");

                    b.ToTable("SearchTags");
                });

            modelBuilder.Entity("BKS.VacancyMagic.Backend.DAL.Models.SearchValue", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("ReplyId")
                        .HasColumnType("bigint");

                    b.Property<long>("ServiceId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<string>("VacancyId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ReplyId");

                    b.HasIndex("ServiceId");

                    b.HasIndex("UserId");

                    b.ToTable("SearchValues");
                });

            modelBuilder.Entity("BKS.VacancyMagic.Backend.DAL.Models.Service", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("BKS.VacancyMagic.Backend.DAL.Models.ServiceAuthorization", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("AccessToken")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("text");

                    b.Property<long>("ServiceId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ServiceId");

                    b.HasIndex("UserId");

                    b.ToTable("ServiceAuthorizations");
                });

            modelBuilder.Entity("BKS.VacancyMagic.Backend.DAL.Models.Tag", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ServiceId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("ServiceId1")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ServiceId1");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("BKS.VacancyMagic.Backend.DAL.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("MiddleName")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BKS.VacancyMagic.Backend.DAL.Models.Reply", b =>
                {
                    b.HasOne("BKS.VacancyMagic.Backend.DAL.Models.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BKS.VacancyMagic.Backend.DAL.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BKS.VacancyMagic.Backend.DAL.Models.ReplyHistory", b =>
                {
                    b.HasOne("BKS.VacancyMagic.Backend.DAL.Models.Reply", "Reply")
                        .WithMany()
                        .HasForeignKey("ReplyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BKS.VacancyMagic.Backend.DAL.Models.ReplyStatus", "ReplyStatus")
                        .WithMany()
                        .HasForeignKey("ReplyStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reply");

                    b.Navigation("ReplyStatus");
                });

            modelBuilder.Entity("BKS.VacancyMagic.Backend.DAL.Models.ReplyStatus", b =>
                {
                    b.HasOne("BKS.VacancyMagic.Backend.DAL.Models.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");
                });

            modelBuilder.Entity("BKS.VacancyMagic.Backend.DAL.Models.SearchQuery", b =>
                {
                    b.HasOne("BKS.VacancyMagic.Backend.DAL.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BKS.VacancyMagic.Backend.DAL.Models.SearchTag", b =>
                {
                    b.HasOne("BKS.VacancyMagic.Backend.DAL.Models.SearchQuery", "SearchQuery")
                        .WithMany()
                        .HasForeignKey("SearchQueryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BKS.VacancyMagic.Backend.DAL.Models.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SearchQuery");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("BKS.VacancyMagic.Backend.DAL.Models.SearchValue", b =>
                {
                    b.HasOne("BKS.VacancyMagic.Backend.DAL.Models.Reply", "Reply")
                        .WithMany()
                        .HasForeignKey("ReplyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BKS.VacancyMagic.Backend.DAL.Models.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BKS.VacancyMagic.Backend.DAL.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reply");

                    b.Navigation("Service");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BKS.VacancyMagic.Backend.DAL.Models.ServiceAuthorization", b =>
                {
                    b.HasOne("BKS.VacancyMagic.Backend.DAL.Models.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BKS.VacancyMagic.Backend.DAL.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BKS.VacancyMagic.Backend.DAL.Models.Tag", b =>
                {
                    b.HasOne("BKS.VacancyMagic.Backend.DAL.Models.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");
                });
#pragma warning restore 612, 618
        }
    }
}
