using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FoodTruckAdminTools_v2.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address1 = table.Column<string>(maxLength: 250, nullable: false),
                    Address2 = table.Column<string>(maxLength: 250, nullable: true),
                    AddressTypeId = table.Column<int>(nullable: false),
                    City = table.Column<string>(maxLength: 250, nullable: false),
                    Latitude = table.Column<decimal>(nullable: false),
                    Longitude = table.Column<decimal>(nullable: false),
                    State = table.Column<string>(maxLength: 2, nullable: false),
                    Zipcode = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PersonalInfo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressID = table.Column<int>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 200, nullable: false),
                    LastName = table.Column<string>(maxLength: 200, nullable: false),
                    MiddleName = table.Column<string>(maxLength: 200, nullable: true),
                    RoleId = table.Column<int>(nullable: false),
                    SSN = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalInfo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PersonalInfo_Address_AddressID",
                        column: x => x.AddressID,
                        principalTable: "Address",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FoodTruckCompany",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdditionalInfoString = table.Column<string>(nullable: true),
                    AreaOfOperationString = table.Column<string>(nullable: true),
                    BusinessName = table.Column<string>(maxLength: 100, nullable: false),
                    CompanyTypeId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    HasCatering = table.Column<bool>(nullable: false),
                    HasVegeterianFood = table.Column<bool>(nullable: false),
                    HasVigenFood = table.Column<bool>(nullable: false),
                    HealthCode = table.Column<string>(maxLength: 100, nullable: true),
                    OwnerInfoID = table.Column<int>(nullable: true),
                    PermitNumber = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodTruckCompany", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FoodTruckCompany_PersonalInfo_OwnerInfoID",
                        column: x => x.OwnerInfoID,
                        principalTable: "PersonalInfo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CuisineCategory",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryId = table.Column<int>(nullable: false),
                    CategoryName = table.Column<string>(nullable: true),
                    FoodTruckCompanyID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuisineCategory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CuisineCategory_FoodTruckCompany_FoodTruckCompanyID",
                        column: x => x.FoodTruckCompanyID,
                        principalTable: "FoodTruckCompany",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FoodTruck",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdditionalInfoString = table.Column<string>(nullable: true),
                    AreaOfOperationString = table.Column<string>(nullable: true),
                    Color = table.Column<string>(maxLength: 40, nullable: false),
                    CookInfoID = table.Column<int>(nullable: true),
                    CuisineCategoryId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DriverID = table.Column<int>(nullable: false),
                    FoodTruckCompanyID = table.Column<int>(nullable: true),
                    HealthCode = table.Column<string>(maxLength: 100, nullable: true),
                    LicensePlate = table.Column<string>(maxLength: 10, nullable: false),
                    MaxCapacityPerMeal = table.Column<int>(nullable: false),
                    MealTypeId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    TruckMake = table.Column<string>(maxLength: 50, nullable: false),
                    TruckModel = table.Column<string>(maxLength: 100, nullable: true),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodTruck", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FoodTruck_PersonalInfo_CookInfoID",
                        column: x => x.CookInfoID,
                        principalTable: "PersonalInfo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FoodTruck_PersonalInfo_DriverID",
                        column: x => x.DriverID,
                        principalTable: "PersonalInfo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodTruck_FoodTruckCompany_FoodTruckCompanyID",
                        column: x => x.FoodTruckCompanyID,
                        principalTable: "FoodTruckCompany",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MealType",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FoodTruckCompanyID = table.Column<int>(nullable: true),
                    MealTypeId = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealType", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MealType_FoodTruckCompany_FoodTruckCompanyID",
                        column: x => x.FoodTruckCompanyID,
                        principalTable: "FoodTruckCompany",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OfficeLocation",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressID = table.Column<int>(nullable: true),
                    FoodTruckCompanyID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficeLocation", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OfficeLocation_Address_AddressID",
                        column: x => x.AddressID,
                        principalTable: "Address",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OfficeLocation_FoodTruckCompany_FoodTruckCompanyID",
                        column: x => x.FoodTruckCompanyID,
                        principalTable: "FoodTruckCompany",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContactInfo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Contact = table.Column<string>(maxLength: 500, nullable: false),
                    ContactTypeId = table.Column<int>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false),
                    FoodTruckCompanyID = table.Column<int>(nullable: true),
                    FoodTruckID = table.Column<int>(nullable: true),
                    PersonalInfoID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInfo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ContactInfo_FoodTruckCompany_FoodTruckCompanyID",
                        column: x => x.FoodTruckCompanyID,
                        principalTable: "FoodTruckCompany",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContactInfo_FoodTruck_FoodTruckID",
                        column: x => x.FoodTruckID,
                        principalTable: "FoodTruck",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContactInfo_PersonalInfo_PersonalInfoID",
                        column: x => x.PersonalInfoID,
                        principalTable: "PersonalInfo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Phone",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DisplayOrder = table.Column<int>(nullable: false),
                    FoodTruckCompanyID = table.Column<int>(nullable: true),
                    OfficeLocationID = table.Column<int>(nullable: true),
                    PersonalInfoID = table.Column<int>(nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 10, nullable: false),
                    PhoneTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phone", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Phone_FoodTruckCompany_FoodTruckCompanyID",
                        column: x => x.FoodTruckCompanyID,
                        principalTable: "FoodTruckCompany",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Phone_OfficeLocation_OfficeLocationID",
                        column: x => x.OfficeLocationID,
                        principalTable: "OfficeLocation",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Phone_PersonalInfo_PersonalInfoID",
                        column: x => x.PersonalInfoID,
                        principalTable: "PersonalInfo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkingDayHour",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CloseTime = table.Column<TimeSpan>(nullable: false),
                    DayOfWeek = table.Column<int>(nullable: false),
                    OfficeLocationID = table.Column<int>(nullable: true),
                    OpenTime = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingDayHour", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WorkingDayHour_OfficeLocation_OfficeLocationID",
                        column: x => x.OfficeLocationID,
                        principalTable: "OfficeLocation",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactInfo_FoodTruckCompanyID",
                table: "ContactInfo",
                column: "FoodTruckCompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_ContactInfo_FoodTruckID",
                table: "ContactInfo",
                column: "FoodTruckID");

            migrationBuilder.CreateIndex(
                name: "IX_ContactInfo_PersonalInfoID",
                table: "ContactInfo",
                column: "PersonalInfoID");

            migrationBuilder.CreateIndex(
                name: "IX_CuisineCategory_FoodTruckCompanyID",
                table: "CuisineCategory",
                column: "FoodTruckCompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_FoodTruck_CookInfoID",
                table: "FoodTruck",
                column: "CookInfoID");

            migrationBuilder.CreateIndex(
                name: "IX_FoodTruck_DriverID",
                table: "FoodTruck",
                column: "DriverID");

            migrationBuilder.CreateIndex(
                name: "IX_FoodTruck_FoodTruckCompanyID",
                table: "FoodTruck",
                column: "FoodTruckCompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_FoodTruckCompany_OwnerInfoID",
                table: "FoodTruckCompany",
                column: "OwnerInfoID");

            migrationBuilder.CreateIndex(
                name: "IX_MealType_FoodTruckCompanyID",
                table: "MealType",
                column: "FoodTruckCompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_OfficeLocation_AddressID",
                table: "OfficeLocation",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_OfficeLocation_FoodTruckCompanyID",
                table: "OfficeLocation",
                column: "FoodTruckCompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInfo_AddressID",
                table: "PersonalInfo",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_Phone_FoodTruckCompanyID",
                table: "Phone",
                column: "FoodTruckCompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Phone_OfficeLocationID",
                table: "Phone",
                column: "OfficeLocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Phone_PersonalInfoID",
                table: "Phone",
                column: "PersonalInfoID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingDayHour_OfficeLocationID",
                table: "WorkingDayHour",
                column: "OfficeLocationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactInfo");

            migrationBuilder.DropTable(
                name: "CuisineCategory");

            migrationBuilder.DropTable(
                name: "MealType");

            migrationBuilder.DropTable(
                name: "Phone");

            migrationBuilder.DropTable(
                name: "WorkingDayHour");

            migrationBuilder.DropTable(
                name: "FoodTruck");

            migrationBuilder.DropTable(
                name: "OfficeLocation");

            migrationBuilder.DropTable(
                name: "FoodTruckCompany");

            migrationBuilder.DropTable(
                name: "PersonalInfo");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
