﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Programm_L.Data;

#nullable disable

namespace Programm_L.Migrations
{
    [DbContext(typeof(Programm_LContext))]
    [Migration("20230318101251_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Programm_L.Models.Books", b =>
                {
                    b.Property<int>("Book_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Book_ID"));

                    b.Property<string>("Janr_book")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Kol_vo")
                        .HasColumnType("int");

                    b.Property<string>("Name_author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name_book")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Book_ID");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Programm_L.Models.Extradition", b =>
                {
                    b.Property<int>("Extra_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Extra_ID"));

                    b.Property<int>("Book_ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data_extra")
                        .HasColumnType("datetime2");

                    b.Property<int>("Personal_ID")
                        .HasColumnType("int");

                    b.HasKey("Extra_ID");

                    b.HasIndex("Book_ID");

                    b.HasIndex("Personal_ID");

                    b.ToTable("Extradition");
                });

            modelBuilder.Entity("Programm_L.Models.Library_l", b =>
                {
                    b.Property<int>("Lib_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Lib_ID"));

                    b.Property<int>("Code_lib")
                        .HasColumnType("int");

                    b.Property<string>("Name_lib")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Lib_ID");

                    b.ToTable("Library_l");
                });

            modelBuilder.Entity("Programm_L.Models.Personal", b =>
                {
                    b.Property<int>("Personal_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Personal_ID"));

                    b.Property<string>("Name_pers")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Staj_pers")
                        .HasColumnType("int");

                    b.HasKey("Personal_ID");

                    b.ToTable("Personal");
                });

            modelBuilder.Entity("Programm_L.Models.Extradition", b =>
                {
                    b.HasOne("Programm_L.Models.Books", "Books")
                        .WithMany()
                        .HasForeignKey("Book_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Programm_L.Models.Personal", "personal")
                        .WithMany()
                        .HasForeignKey("Personal_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Books");

                    b.Navigation("personal");
                });
#pragma warning restore 612, 618
        }
    }
}