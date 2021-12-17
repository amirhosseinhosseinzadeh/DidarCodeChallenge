using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DidarCodeChallenge.Api.Migrations
{
    public partial class Addsearchvaluecolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Value",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "Requests");
        }
    }
}
