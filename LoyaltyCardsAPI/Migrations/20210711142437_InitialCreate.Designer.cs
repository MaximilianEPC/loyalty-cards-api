// <auto-generated />
using System;
using LoyaltyCardsAPI.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LoyaltyCardsAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210711142437_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LoyaltyCardsAPI.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("LoyaltyCardsAPI.Entities.LoyaltyCard", b =>
                {
                    b.Property<int>("Number")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("IssuingDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ValidUntil")
                        .HasColumnType("datetime2");

                    b.HasKey("Number");

                    b.HasIndex("ClientId");

                    b.ToTable("LoyaltyCards");
                });

            modelBuilder.Entity("LoyaltyCardsAPI.Entities.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LoyaltyCardNumber")
                        .HasColumnType("int");

                    b.Property<int>("LoyaltyPointsEarned")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeOfTransaction")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("LoyaltyCardNumber");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("LoyaltyCardsAPI.Entities.LoyaltyCard", b =>
                {
                    b.HasOne("LoyaltyCardsAPI.Entities.Client", "Client")
                        .WithMany("LoyaltyCards")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("LoyaltyCardsAPI.Entities.Transaction", b =>
                {
                    b.HasOne("LoyaltyCardsAPI.Entities.LoyaltyCard", "LoyaltyCard")
                        .WithMany("Transactions")
                        .HasForeignKey("LoyaltyCardNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LoyaltyCard");
                });

            modelBuilder.Entity("LoyaltyCardsAPI.Entities.Client", b =>
                {
                    b.Navigation("LoyaltyCards");
                });

            modelBuilder.Entity("LoyaltyCardsAPI.Entities.LoyaltyCard", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
