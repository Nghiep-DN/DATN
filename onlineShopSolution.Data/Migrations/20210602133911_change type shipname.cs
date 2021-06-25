using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace onlineShopSolution.Data.Migrations
{
    public partial class changetypeshipname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ShipName",
                table: "Orders",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldUnicode: false,
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 2, 20, 39, 10, 173, DateTimeKind.Local).AddTicks(8802),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 17, 22, 7, 40, 297, DateTimeKind.Local).AddTicks(2984));

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "42948367-6cb7-4003-b226-061c1b8b5a43");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8835e64c-db4d-49b1-b30e-e3e0f0bbc2c7", "AQAAAAEAACcQAAAAEGSX2z7eyN2/X4DCqEylT71Hzywv5UWFL5ciPwwRtAO9CSKA+cT7E3cgK2RSQbORcQ==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 6, 2, 20, 39, 10, 204, DateTimeKind.Local).AddTicks(9804));

            migrationBuilder.UpdateData(
                table: "Slides",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Slides",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Slides",
                keyColumn: "Id",
                keyValue: 3,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Slides",
                keyColumn: "Id",
                keyValue: 4,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Slides",
                keyColumn: "Id",
                keyValue: 5,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Slides",
                keyColumn: "Id",
                keyValue: 6,
                column: "Status",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ShipName",
                table: "Orders",
                type: "varchar(200)",
                unicode: false,
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 17, 22, 7, 40, 297, DateTimeKind.Local).AddTicks(2984),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 2, 20, 39, 10, 173, DateTimeKind.Local).AddTicks(8802));

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);

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
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 4, 17, 22, 7, 40, 337, DateTimeKind.Local).AddTicks(8540));

            migrationBuilder.UpdateData(
                table: "Slides",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Slides",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Slides",
                keyColumn: "Id",
                keyValue: 3,
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Slides",
                keyColumn: "Id",
                keyValue: 4,
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Slides",
                keyColumn: "Id",
                keyValue: 5,
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Slides",
                keyColumn: "Id",
                keyValue: 6,
                column: "Status",
                value: 0);
        }
    }
}
