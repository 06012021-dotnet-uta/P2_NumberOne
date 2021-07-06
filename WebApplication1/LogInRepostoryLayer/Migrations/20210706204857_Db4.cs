using Microsoft.EntityFrameworkCore.Migrations;

namespace LogInRepostoryLayer.Migrations
{
    public partial class Db4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "customer");

            migrationBuilder.DropColumn(
                name: "State",
                table: "customer");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "customer");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "customer",
                newName: "Email");

            migrationBuilder.AlterColumn<string>(
                name: "ZipCode",
                table: "customer",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<string>(
                name: "Home_Coordinate",
                table: "customer",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "customer",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Wandering_Radius",
                table: "customer",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Home_Coordinate",
                table: "customer");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "customer");

            migrationBuilder.DropColumn(
                name: "Wandering_Radius",
                table: "customer");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "customer",
                newName: "email");

            migrationBuilder.AlterColumn<string>(
                name: "ZipCode",
                table: "customer",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "customer",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "customer",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "customer",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }
    }
}
