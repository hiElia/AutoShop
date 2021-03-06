// <auto-generated />
using System;
using AutoShop.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AutoShop.Data.Migrations
{
    [DbContext(typeof(AutoShopDbContext))]
    [Migration("20220122033007_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AutoShop.Core.Carmodel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("brand");

                    b.Property<string>("model");

                    b.Property<int>("price");

                    b.HasKey("id");

                    b.ToTable("carmodels");
                });

            modelBuilder.Entity("AutoShop.Core.Carshop", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("id");

                    b.ToTable("carshops");
                });

            modelBuilder.Entity("AutoShop.Core.Employee", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name");

                    b.HasKey("id");

                    b.ToTable("employees");
                });

            modelBuilder.Entity("AutoShop.Core.Sale", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Carshopid");

                    b.Property<int>("carmodel_id");

                    b.Property<int>("employee_id");

                    b.HasKey("id");

                    b.HasIndex("Carshopid");

                    b.ToTable("sales");
                });

            modelBuilder.Entity("AutoShop.Core.Sale", b =>
                {
                    b.HasOne("AutoShop.Core.Carshop")
                        .WithMany("sales")
                        .HasForeignKey("Carshopid");
                });
#pragma warning restore 612, 618
        }
    }
}
