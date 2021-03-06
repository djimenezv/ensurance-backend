﻿// <auto-generated />
using System;
using Ensurance.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Ensurance.Migrations
{
    [DbContext(typeof(EnsuranceContext))]
    partial class EnsuranceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Ensurance.Models.Client", b =>
                {
                    b.Property<int>("Identification")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Identification");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            Identification = 123,
                            Name = "Diego Jimenez"
                        },
                        new
                        {
                            Identification = 21213,
                            Name = "Juan Manuel"
                        },
                        new
                        {
                            Identification = 3324324,
                            Name = "Leidy Jhoana"
                        });
                });

            modelBuilder.Entity("Ensurance.Models.ClientPolicy", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Identification");

                    b.Property<int?>("PolicyId");

                    b.HasKey("ID");

                    b.HasIndex("Identification");

                    b.HasIndex("PolicyId");

                    b.ToTable("ClientPolicies");
                });

            modelBuilder.Entity("Ensurance.Models.Covering", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.HasKey("ID");

                    b.ToTable("Coverings");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Description = "Terremoto"
                        },
                        new
                        {
                            ID = 2,
                            Description = "Incendio"
                        },
                        new
                        {
                            ID = 3,
                            Description = "Robo"
                        });
                });

            modelBuilder.Entity("Ensurance.Models.Policy", b =>
                {
                    b.Property<int>("PolicyNumber")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CoveragePeriod");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<long>("Price");

                    b.Property<string>("RiskType");

                    b.Property<DateTime>("StartingDate");

                    b.HasKey("PolicyNumber");

                    b.ToTable("Policies");
                });

            modelBuilder.Entity("Ensurance.Models.PolicyCovering", b =>
                {
                    b.Property<int>("PolicyNumber");

                    b.Property<int>("CoveringID");

                    b.Property<double>("CoveragePercentage");

                    b.HasKey("PolicyNumber", "CoveringID");

                    b.HasIndex("CoveringID");

                    b.ToTable("PolicyCoverings");
                });

            modelBuilder.Entity("Ensurance.Models.ClientPolicy", b =>
                {
                    b.HasOne("Ensurance.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("Identification");

                    b.HasOne("Ensurance.Models.Policy", "Policy")
                        .WithMany()
                        .HasForeignKey("PolicyId");
                });

            modelBuilder.Entity("Ensurance.Models.PolicyCovering", b =>
                {
                    b.HasOne("Ensurance.Models.Covering", "Cover")
                        .WithMany("CoveringPolicy")
                        .HasForeignKey("CoveringID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Ensurance.Models.Policy", "Policy")
                        .WithMany("CoveringPolicy")
                        .HasForeignKey("PolicyNumber")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
