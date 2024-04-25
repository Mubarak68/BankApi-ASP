﻿// <auto-generated />
using Bank_Branch.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(BankContext))]
    [Migration("20240425061323_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("Bank_Branch.Models.BankBranch", b =>
                {
                    b.Property<int>("BankId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BranchManager")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("EmployeeCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LocationName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LocationURL")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("BankId");

                    b.ToTable("bankBranchTable");

                    b.HasData(
                        new
                        {
                            BankId = 1,
                            BranchManager = "Mohammed Ali",
                            EmployeeCount = 20,
                            LocationName = "Al-Jahra Branch",
                            LocationURL = "https://maps.app.goo.gl/mPDxWzf5bcwgNCek9"
                        },
                        new
                        {
                            BankId = 2,
                            BranchManager = "Saoud Faleh",
                            EmployeeCount = 18,
                            LocationName = "Kaifan Branch",
                            LocationURL = "https://maps.app.goo.gl/DnMgNCGQD1cpPJLFA"
                        },
                        new
                        {
                            BankId = 3,
                            BranchManager = "Mubarak Mohammed",
                            EmployeeCount = 24,
                            LocationName = "Al-Khaldiya Branch",
                            LocationURL = "https://maps.app.goo.gl/R559DtfAFDN3f92g8"
                        },
                        new
                        {
                            BankId = 4,
                            BranchManager = "Salem Ali",
                            EmployeeCount = 35,
                            LocationName = "Farwaniya Branch",
                            LocationURL = "https://maps.app.goo.gl/mmLBR5aSciF2k9q8A"
                        });
                });

            modelBuilder.Entity("Bank_Branch.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BankBranchBankId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CivilId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BankBranchBankId");

                    b.HasIndex("CivilId")
                        .IsUnique();

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Bank_Branch.Models.Employee", b =>
                {
                    b.HasOne("Bank_Branch.Models.BankBranch", "BankBranch")
                        .WithMany("Employees")
                        .HasForeignKey("BankBranchBankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BankBranch");
                });

            modelBuilder.Entity("Bank_Branch.Models.BankBranch", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
