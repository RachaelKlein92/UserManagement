using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.Migrations
{
    public partial class UpdateRoleData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f0b6c6c0-e746-4c98-9d50-d80e6f3509de", "9d5d5ea8-ec35-4450-bb03-a65b371c39d6", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9e248231-e213-4138-86ab-0e496be64b36", "36bb6a2b-f598-4936-9d35-139c8795e7e3", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "95a355f4-c022-41f6-a905-6e7975073ea7", "4a27c6e3-05c0-43ca-913d-221ef547686b", "Reporter", "REPORTER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95a355f4-c022-41f6-a905-6e7975073ea7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e248231-e213-4138-86ab-0e496be64b36");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f0b6c6c0-e746-4c98-9d50-d80e6f3509de");

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
    }
}
