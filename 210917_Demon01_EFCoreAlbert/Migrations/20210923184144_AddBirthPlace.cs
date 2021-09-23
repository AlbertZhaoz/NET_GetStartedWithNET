using Microsoft.EntityFrameworkCore.Migrations;

namespace _210917_Demon01_EFCoreAlbert.Migrations
{
    public partial class AddBirthPlace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BirthPlace",
                table: "T_Person",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthPlace",
                table: "T_Person");
        }
    }
}
