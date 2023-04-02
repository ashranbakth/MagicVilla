using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicVilla_VillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedVillaTableWithCreatedDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenity", "CreatedDate", "Details", "ImageUrl", "Name", "Occupancy", "Rate", "Sqft", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "", new DateTime(2023, 4, 2, 1, 40, 51, 736, DateTimeKind.Local).AddTicks(2560), "Ashran lives here.", "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa1.jpg", "Bali Villa", 5, 200.0, 500, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "", new DateTime(2023, 4, 2, 1, 40, 51, 736, DateTimeKind.Local).AddTicks(2620), "George Bush lives here", "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa2.jpg", "White House Villa", 5, 200.0, 500, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "", new DateTime(2023, 4, 2, 1, 40, 51, 736, DateTimeKind.Local).AddTicks(2630), "Naruto lives here", "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa3.jpg", "Konoha Villa", 5, 200.0, 500, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "", new DateTime(2023, 4, 2, 1, 40, 51, 736, DateTimeKind.Local).AddTicks(2630), "Agumon lives here", "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa4.jpg", "Digimon Villa", 5, 200.0, 500, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "", new DateTime(2023, 4, 2, 1, 40, 51, 736, DateTimeKind.Local).AddTicks(2630), "Pikachu lives here", "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa5.jpg", "Pokemon Villa", 5, 200.0, 500, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
