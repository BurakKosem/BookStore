using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName", "CreatedDate", "Status" },
                values: new object[] { 1, "Felsefe", new DateTime(2023, 8, 2, 15, 53, 35, 249, DateTimeKind.Local).AddTicks(5935), true });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CategoryId", "CreatedDate", "Description", "Name", "Page", "Status" },
                values: new object[] { 1, "Epictetos", 1, new DateTime(2023, 8, 2, 15, 53, 35, 249, DateTimeKind.Local).AddTicks(5784), "Filozof", "Epictetos", 96, true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
