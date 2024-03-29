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
    [Migration("20221219180206_UpdateInputPassword")]
    partial class UpdateInputPassword
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
                        .HasColumnType("char(36)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(180)")
                        .HasColumnName("EMAIL");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("NAME");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasColumnName("PASSWORD");

                    b.HasKey("Id");

                    b.ToTable("USER");
                });
#pragma warning restore 612, 618
        }
    }
}
