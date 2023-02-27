using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationNet6.Migrations
{
    /// <inheritdoc />
    public partial class Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "UserName" },
                values: new object[] { new Guid("5491a8f3-1e36-4ac8-a9f7-91f7f4431636"), "Test" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Content", "PostTime", "Read", "Title", "UserId" },
                values: new object[] { 1, "TestContent", new DateTime(2023, 2, 23, 14, 57, 17, 499, DateTimeKind.Local).AddTicks(2162), 0, "TestTitle", new Guid("5491a8f3-1e36-4ac8-a9f7-91f7f4431636") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5491a8f3-1e36-4ac8-a9f7-91f7f4431636"));
        }
    }
}
