using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.Migrations
{
    public partial class UpdateAuditLogTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Message",
                table: "AuditLogs",
                newName: "EmailAddress");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "AuditLogs",
                newName: "DateTime");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AuditLogs",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "AuditLogs");

            migrationBuilder.RenameColumn(
                name: "EmailAddress",
                table: "AuditLogs",
                newName: "Message");

            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "AuditLogs",
                newName: "CreatedDate");
        }
    }
}
