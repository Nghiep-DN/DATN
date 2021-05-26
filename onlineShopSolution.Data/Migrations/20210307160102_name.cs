using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace onlineShopSolution.Data.Migrations
{
    public partial class name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ProductTranslations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldUnicode: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 7, 23, 1, 0, 11, DateTimeKind.Local).AddTicks(2590),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 3, 7, 1, 20, 6, 959, DateTimeKind.Local).AddTicks(7482));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "c7bd6af1-dbde-4efe-ade9-2c9a13c1e7ec");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1ff95212-048b-49dd-8386-84b9225e28a6", "AQAAAAEAACcQAAAAEBgXmwO4QwJ3MSfBD4I0WHHWICcYU45EKSzjOn042FqSLKbAJpKvSCOiLSAfRGx6nA==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 3, 7, 23, 1, 0, 63, DateTimeKind.Local).AddTicks(8154));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ProductTranslations",
                type: "varchar(max)",
                unicode: false,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 7, 1, 20, 6, 959, DateTimeKind.Local).AddTicks(7482),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 3, 7, 23, 1, 0, 11, DateTimeKind.Local).AddTicks(2590));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "52a64646-31f0-4534-86d5-7e4b97306460");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "37fd9013-cf48-4438-913b-e8ecb6cd710f", "AQAAAAEAACcQAAAAEITqE1hWpmTQuK+rjpKPm1zg/wiGLOord5uB0BcDeyyqkaKsmjqeK2J8S8U++jYrkQ==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 3, 7, 1, 20, 7, 58, DateTimeKind.Local).AddTicks(6145));
        }
    }
}
