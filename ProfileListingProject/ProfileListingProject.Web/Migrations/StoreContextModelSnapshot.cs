﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProfileListingProject.Core.Contexts;

namespace ProfileListingProject.Web.Migrations
{
    [DbContext(typeof(StoreContext))]
    partial class StoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProfileListingProject.Core.Entities.AreaOfOperation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CompanyId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("AreaOfOperations");
                });

            modelBuilder.Entity("ProfileListingProject.Core.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ProfileListingProject.Core.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("LogoImageUrl");

                    b.Property<string>("Name");

                    b.Property<string>("OfficePhotoUrl");

                    b.Property<string>("Phone");

                    b.Property<string>("ShortDescription");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("ProfileListingProject.Core.Entities.CompanyService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId");

                    b.Property<string>("Description");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("Name");

                    b.Property<int>("PricingRate");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("CompanyServices");
                });

            modelBuilder.Entity("ProfileListingProject.Core.Entities.DemoAccountUrl", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password");

                    b.Property<int>("ProjectId");

                    b.Property<string>("Url");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("DemoAccountUrl");
                });

            modelBuilder.Entity("ProfileListingProject.Core.Entities.PricingModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount");

                    b.Property<int>("PricingType");

                    b.Property<int?>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("PricingModels");
                });

            modelBuilder.Entity("ProfileListingProject.Core.Entities.PricingRate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount");

                    b.Property<int?>("CompanyServiceId");

                    b.Property<int>("RateType");

                    b.HasKey("Id");

                    b.HasIndex("CompanyServiceId");

                    b.ToTable("PricingRates");
                });

            modelBuilder.Entity("ProfileListingProject.Core.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId");

                    b.Property<string>("Description");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ProfileListingProject.Core.Entities.ProductCategory", b =>
                {
                    b.Property<int>("ProductId");

                    b.Property<int>("CategoryId");

                    b.HasKey("ProductId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("ProfileListingProject.Core.Entities.ProductFeature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int?>("PricingModelId");

                    b.Property<int?>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("PricingModelId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductFeatures");
                });

            modelBuilder.Entity("ProfileListingProject.Core.Entities.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId");

                    b.Property<string>("Description");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("ProfileListingProject.Core.Entities.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CompanyId");

                    b.Property<int>("Count");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("ProfileListingProject.Core.Entities.TechnologyInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CompanyId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("TechnologyInfos");
                });

            modelBuilder.Entity("ProfileListingProject.Core.Entities.AreaOfOperation", b =>
                {
                    b.HasOne("ProfileListingProject.Core.Entities.Company", "Company")
                        .WithMany("AreaOfOperations")
                        .HasForeignKey("CompanyId");
                });

            modelBuilder.Entity("ProfileListingProject.Core.Entities.CompanyService", b =>
                {
                    b.HasOne("ProfileListingProject.Core.Entities.Company", "Company")
                        .WithMany("Services")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProfileListingProject.Core.Entities.DemoAccountUrl", b =>
                {
                    b.HasOne("ProfileListingProject.Core.Entities.Project", "Project")
                        .WithMany("DemoAccount")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProfileListingProject.Core.Entities.PricingModel", b =>
                {
                    b.HasOne("ProfileListingProject.Core.Entities.Product")
                        .WithMany("PricingModels")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("ProfileListingProject.Core.Entities.PricingRate", b =>
                {
                    b.HasOne("ProfileListingProject.Core.Entities.CompanyService", "CompanyService")
                        .WithMany()
                        .HasForeignKey("CompanyServiceId");
                });

            modelBuilder.Entity("ProfileListingProject.Core.Entities.Product", b =>
                {
                    b.HasOne("ProfileListingProject.Core.Entities.Company", "Company")
                        .WithMany("Products")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProfileListingProject.Core.Entities.ProductCategory", b =>
                {
                    b.HasOne("ProfileListingProject.Core.Entities.Category", "Category")
                        .WithMany("Categories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProfileListingProject.Core.Entities.Product", "Product")
                        .WithMany("Categories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProfileListingProject.Core.Entities.ProductFeature", b =>
                {
                    b.HasOne("ProfileListingProject.Core.Entities.PricingModel")
                        .WithMany("ProductFeature")
                        .HasForeignKey("PricingModelId");

                    b.HasOne("ProfileListingProject.Core.Entities.Product", "Product")
                        .WithMany("ProductFeatures")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("ProfileListingProject.Core.Entities.Project", b =>
                {
                    b.HasOne("ProfileListingProject.Core.Entities.Company", "Company")
                        .WithMany("Projects")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProfileListingProject.Core.Entities.Team", b =>
                {
                    b.HasOne("ProfileListingProject.Core.Entities.Company", "Company")
                        .WithMany("Teams")
                        .HasForeignKey("CompanyId");
                });

            modelBuilder.Entity("ProfileListingProject.Core.Entities.TechnologyInfo", b =>
                {
                    b.HasOne("ProfileListingProject.Core.Entities.Company", "Company")
                        .WithMany("TechnologyInfos")
                        .HasForeignKey("CompanyId");
                });
#pragma warning restore 612, 618
        }
    }
}
