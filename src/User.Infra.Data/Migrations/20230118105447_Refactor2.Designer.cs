﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using User.Infra.Data.Context;

namespace User.Infra.Data.Migrations
{
    [DbContext(typeof(UserContext))]
    [Migration("20230118105447_Refactor2")]
    partial class Refactor2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.10");

            modelBuilder.Entity("User.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("ID");

                    b.HasKey("Id");

                    b.ToTable("USER");
                });

            modelBuilder.Entity("User.Domain.Entities.User", b =>
                {
                    b.OwnsOne("User.Domain.VOs.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasColumnType("varchar(180)")
                                .HasColumnName("EMAIL");

                            b1.HasKey("UserId");

                            b1.ToTable("USER");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("User.Domain.VOs.Name", "Name", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasColumnType("varchar(50)")
                                .HasColumnName("FIRST_NAME");

                            b1.Property<string>("LastName")
                                .HasColumnType("varchar(50)")
                                .HasColumnName("LAST_NAME");

                            b1.HasKey("UserId");

                            b1.ToTable("USER");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("User.Domain.VOs.Password", "Password", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("PasswordHash")
                                .IsRequired()
                                .HasColumnType("varchar(200)")
                                .HasColumnName("PASSWORD");

                            b1.Property<string>("PasswordText")
                                .HasColumnType("longtext");

                            b1.HasKey("UserId");

                            b1.ToTable("USER");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("User.Domain.VOs.Role", "Role", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("UserRole")
                                .IsRequired()
                                .HasColumnType("varchar(6)")
                                .HasColumnName("ROLE");

                            b1.HasKey("UserId");

                            b1.ToTable("USER");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("Email");

                    b.Navigation("Name");

                    b.Navigation("Password");

                    b.Navigation("Role");
                });
#pragma warning restore 612, 618
        }
    }
}
