using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.Migrations
{
    public partial class AddDefaultRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "116d2f7b-fd18-44c7-aec9-f76595bb859b", "1cd53495-a578-4710-9f1f-0b7955b7d425", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b115d853-2ee9-4872-bdd8-e439a10ff140", "a8c3cd0f-beec-4a0e-9456-58367b169662", "User", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "98168f1a-59ba-417c-a519-868ac0730f60", "265d7a6b-9118-4a8a-a1d2-182a1ab86b0f", "Reporter", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "116d2f7b-fd18-44c7-aec9-f76595bb859b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "98168f1a-59ba-417c-a519-868ac0730f60");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b115d853-2ee9-4872-bdd8-e439a10ff140");
        }
    }
}
