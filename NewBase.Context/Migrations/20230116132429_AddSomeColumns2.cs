using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewBase.Context.Migrations
{
    public partial class AddSomeColumns2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "location",
                table: "AspNetUsers",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "lng",
                table: "AspNetUsers",
                newName: "Lng");

            migrationBuilder.RenameColumn(
                name: "lat",
                table: "AspNetUsers",
                newName: "Lat");

            migrationBuilder.AddColumn<bool>(
                name: "ActiveCode",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ImgProfile",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActiveCode",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ImgProfile",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "AspNetUsers",
                newName: "location");

            migrationBuilder.RenameColumn(
                name: "Lng",
                table: "AspNetUsers",
                newName: "lng");

            migrationBuilder.RenameColumn(
                name: "Lat",
                table: "AspNetUsers",
                newName: "lat");
        }
    }
}
