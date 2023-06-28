using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pokeSharp.Migrations
{
    /// <inheritdoc />
    public partial class pokeCustom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Pokemon",
                columns: new[] { "id", "DateTime", "LastName", "name" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "pikachuCustom" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pokemon",
                keyColumn: "id",
                keyValue: 1);
        }
    }
}
