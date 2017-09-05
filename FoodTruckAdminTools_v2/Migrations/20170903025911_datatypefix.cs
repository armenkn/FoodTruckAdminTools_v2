using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodTruckAdminTools_v2.Migrations
{
    public partial class datatypefix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyTypeId",
                table: "FoodTruckCompany");

            migrationBuilder.AddColumn<string>(
                name: "CompanyTypeName",
                table: "FoodTruckCompany",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyTypeName",
                table: "FoodTruckCompany");

            migrationBuilder.AddColumn<int>(
                name: "CompanyTypeId",
                table: "FoodTruckCompany",
                nullable: false,
                defaultValue: 0);
        }
    }
}
