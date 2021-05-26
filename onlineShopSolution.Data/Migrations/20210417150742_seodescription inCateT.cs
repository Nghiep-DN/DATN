using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace onlineShopSolution.Data.Migrations
{
    public partial class seodescriptioninCateT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SeoDesciption",
                table: "CategoryTranslations",
                newName: "SeoDescription");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 17, 22, 7, 40, 297, DateTimeKind.Local).AddTicks(2984),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 3, 7, 23, 1, 0, 11, DateTimeKind.Local).AddTicks(2590));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "f7f177cf-f70b-4952-bb8f-932b6c72e14d");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "60bc604b-11bf-4f4e-84dc-4ecaf233e146", "AQAAAAEAACcQAAAAEMQoBVbVPvQs9M1iPRRj6lFGqBNE2amapPZZlza9MnzH6M8FWBIAUkpYNNngCGGVEg==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 4, 17, 22, 7, 40, 337, DateTimeKind.Local).AddTicks(8540));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SeoDescription",
                table: "CategoryTranslations",
                newName: "SeoDesciption");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 7, 23, 1, 0, 11, DateTimeKind.Local).AddTicks(2590),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 17, 22, 7, 40, 297, DateTimeKind.Local).AddTicks(2984));

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
    }
}
