using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using FoodTruckAdminTools_v2.Models;

namespace FoodTruckAdminTools_v2.Migrations
{
    [DbContext(typeof(FoodTruckCompanyContext))]
    partial class FoodTruckCompanyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FoodTruckAdminTools_v2.Models.Address", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address1")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("Address2")
                        .HasMaxLength(250);

                    b.Property<int>("AddressTypeId");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<decimal>("Latitude");

                    b.Property<decimal>("Longitude");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(2);

                    b.Property<string>("Zipcode")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.HasKey("ID");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("FoodTruckAdminTools_v2.Models.ContactInfo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<int>("ContactTypeId");

                    b.Property<int>("DisplayOrder");

                    b.Property<int?>("FoodTruckCompanyID");

                    b.Property<int?>("FoodTruckID");

                    b.Property<int?>("PersonalInfoID");

                    b.HasKey("ID");

                    b.HasIndex("FoodTruckCompanyID");

                    b.HasIndex("FoodTruckID");

                    b.HasIndex("PersonalInfoID");

                    b.ToTable("ContactInfo");
                });

            modelBuilder.Entity("FoodTruckAdminTools_v2.Models.CuisineCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoryId");

                    b.Property<string>("CategoryName");

                    b.Property<int?>("FoodTruckCompanyID");

                    b.HasKey("ID");

                    b.HasIndex("FoodTruckCompanyID");

                    b.ToTable("CuisineCategory");
                });

            modelBuilder.Entity("FoodTruckAdminTools_v2.Models.FoodTruck", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AdditionalInfoString");

                    b.Property<string>("AreaOfOperationString");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<int?>("CookInfoID");

                    b.Property<int>("CuisineCategoryId");

                    b.Property<string>("Description");

                    b.Property<int>("DriverID");

                    b.Property<int?>("FoodTruckCompanyID");

                    b.Property<string>("HealthCode")
                        .HasMaxLength(100);

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<int>("MaxCapacityPerMeal");

                    b.Property<int>("MealTypeId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("TruckMake")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("TruckModel")
                        .HasMaxLength(100);

                    b.Property<int>("Year");

                    b.HasKey("ID");

                    b.HasIndex("CookInfoID");

                    b.HasIndex("DriverID");

                    b.HasIndex("FoodTruckCompanyID");

                    b.ToTable("FoodTruck");
                });

            modelBuilder.Entity("FoodTruckAdminTools_v2.Models.FoodTruckCompany", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AdditionalInfoString");

                    b.Property<string>("AreaOfOperationString");

                    b.Property<string>("BusinessName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("CompanyTypeName")
                        .IsRequired();

                    b.Property<string>("Description");

                    b.Property<bool>("HasCatering");

                    b.Property<bool>("HasVegeterianFood");

                    b.Property<bool>("HasVigenFood");

                    b.Property<string>("HealthCode")
                        .HasMaxLength(100);

                    b.Property<int?>("OwnerInfoID");

                    b.Property<string>("PermitNumber")
                        .HasMaxLength(100);

                    b.HasKey("ID");

                    b.HasIndex("OwnerInfoID");

                    b.ToTable("FoodTruckCompany");
                });

            modelBuilder.Entity("FoodTruckAdminTools_v2.Models.MealType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("FoodTruckCompanyID");

                    b.Property<int>("MealTypeId");

                    b.Property<string>("Type");

                    b.HasKey("ID");

                    b.HasIndex("FoodTruckCompanyID");

                    b.ToTable("MealType");
                });

            modelBuilder.Entity("FoodTruckAdminTools_v2.Models.OfficeLocation", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AddressID");

                    b.Property<int?>("FoodTruckCompanyID");

                    b.HasKey("ID");

                    b.HasIndex("AddressID");

                    b.HasIndex("FoodTruckCompanyID");

                    b.ToTable("OfficeLocation");
                });

            modelBuilder.Entity("FoodTruckAdminTools_v2.Models.PersonalInfo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AddressID");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("MiddleName")
                        .HasMaxLength(200);

                    b.Property<int>("RoleId");

                    b.Property<string>("SSN");

                    b.HasKey("ID");

                    b.HasIndex("AddressID");

                    b.ToTable("PersonalInfo");
                });

            modelBuilder.Entity("FoodTruckAdminTools_v2.Models.Phone", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DisplayOrder");

                    b.Property<int?>("FoodTruckCompanyID");

                    b.Property<int?>("OfficeLocationID");

                    b.Property<int?>("PersonalInfoID");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<int>("PhoneTypeId");

                    b.HasKey("ID");

                    b.HasIndex("FoodTruckCompanyID");

                    b.HasIndex("OfficeLocationID");

                    b.HasIndex("PersonalInfoID");

                    b.ToTable("Phone");
                });

            modelBuilder.Entity("FoodTruckAdminTools_v2.Models.WorkingDayHour", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<TimeSpan>("CloseTime");

                    b.Property<int>("DayOfWeek");

                    b.Property<int?>("OfficeLocationID");

                    b.Property<TimeSpan>("OpenTime");

                    b.HasKey("ID");

                    b.HasIndex("OfficeLocationID");

                    b.ToTable("WorkingDayHour");
                });

            modelBuilder.Entity("FoodTruckAdminTools_v2.Models.ContactInfo", b =>
                {
                    b.HasOne("FoodTruckAdminTools_v2.Models.FoodTruckCompany")
                        .WithMany("Contacts")
                        .HasForeignKey("FoodTruckCompanyID");

                    b.HasOne("FoodTruckAdminTools_v2.Models.FoodTruck")
                        .WithMany("Contacts")
                        .HasForeignKey("FoodTruckID");

                    b.HasOne("FoodTruckAdminTools_v2.Models.PersonalInfo")
                        .WithMany("Contacts")
                        .HasForeignKey("PersonalInfoID");
                });

            modelBuilder.Entity("FoodTruckAdminTools_v2.Models.CuisineCategory", b =>
                {
                    b.HasOne("FoodTruckAdminTools_v2.Models.FoodTruckCompany")
                        .WithMany("CuisineCategories")
                        .HasForeignKey("FoodTruckCompanyID");
                });

            modelBuilder.Entity("FoodTruckAdminTools_v2.Models.FoodTruck", b =>
                {
                    b.HasOne("FoodTruckAdminTools_v2.Models.PersonalInfo", "CookInfo")
                        .WithMany()
                        .HasForeignKey("CookInfoID");

                    b.HasOne("FoodTruckAdminTools_v2.Models.PersonalInfo", "Driver")
                        .WithMany()
                        .HasForeignKey("DriverID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FoodTruckAdminTools_v2.Models.FoodTruckCompany")
                        .WithMany("FoodTrucks")
                        .HasForeignKey("FoodTruckCompanyID");
                });

            modelBuilder.Entity("FoodTruckAdminTools_v2.Models.FoodTruckCompany", b =>
                {
                    b.HasOne("FoodTruckAdminTools_v2.Models.PersonalInfo", "OwnerInfo")
                        .WithMany()
                        .HasForeignKey("OwnerInfoID");
                });

            modelBuilder.Entity("FoodTruckAdminTools_v2.Models.MealType", b =>
                {
                    b.HasOne("FoodTruckAdminTools_v2.Models.FoodTruckCompany")
                        .WithMany("MealTypes")
                        .HasForeignKey("FoodTruckCompanyID");
                });

            modelBuilder.Entity("FoodTruckAdminTools_v2.Models.OfficeLocation", b =>
                {
                    b.HasOne("FoodTruckAdminTools_v2.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressID");

                    b.HasOne("FoodTruckAdminTools_v2.Models.FoodTruckCompany")
                        .WithMany("OfficeLocations")
                        .HasForeignKey("FoodTruckCompanyID");
                });

            modelBuilder.Entity("FoodTruckAdminTools_v2.Models.PersonalInfo", b =>
                {
                    b.HasOne("FoodTruckAdminTools_v2.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressID");
                });

            modelBuilder.Entity("FoodTruckAdminTools_v2.Models.Phone", b =>
                {
                    b.HasOne("FoodTruckAdminTools_v2.Models.FoodTruckCompany")
                        .WithMany("PhoneNumbers")
                        .HasForeignKey("FoodTruckCompanyID");

                    b.HasOne("FoodTruckAdminTools_v2.Models.OfficeLocation")
                        .WithMany("PhoneNumbers")
                        .HasForeignKey("OfficeLocationID");

                    b.HasOne("FoodTruckAdminTools_v2.Models.PersonalInfo")
                        .WithMany("PhoneNumbers")
                        .HasForeignKey("PersonalInfoID");
                });

            modelBuilder.Entity("FoodTruckAdminTools_v2.Models.WorkingDayHour", b =>
                {
                    b.HasOne("FoodTruckAdminTools_v2.Models.OfficeLocation")
                        .WithMany("WorkingDayHours")
                        .HasForeignKey("OfficeLocationID");
                });
        }
    }
}
