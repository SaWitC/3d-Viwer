using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resource3dModelsApi.Infrastructure.Migrations
{
    public partial class updated3m : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFileUploaded",
                table: "_3DModels",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFileUploaded",
                table: "_3DModels");
        }
    }
}
