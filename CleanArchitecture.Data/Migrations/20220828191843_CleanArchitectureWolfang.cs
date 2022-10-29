using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Litethinking.NetInventory.Backend.Data.Migrations
{
    public partial class CleanArchitectureWolfang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Inventories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Inventories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Inventories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Inventories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "InventoryProduct",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "InventoryProduct",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "InventoryProduct",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "InventoryProduct",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "InventoryProduct",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Companies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Companies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Director",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Director",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Director",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Director",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "InventoryProduct");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "InventoryProduct");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "InventoryProduct");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "InventoryProduct");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "InventoryProduct");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Director");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Director");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Director");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Director");
        }
    }
}
