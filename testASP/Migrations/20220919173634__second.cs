using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace testASP.Migrations
{
    public partial class _second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImgName",
                table: "GoodsImages",
                newName: "ImgPath");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1c3d07c1-379d-4402-9313-4b01e0761fc0",
                column: "ConcurrencyStamp",
                value: "f89c6362-bb79-49a9-ab08-ab3253aecd26");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "97088e8a-3573-479a-99a3-2541e3e7c7de",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "10feaa3f-3f45-460a-9cf6-0fa69200847c", "AQAAAAEAACcQAAAAEGe83A2hsgsEvwFvSyLeK1obbT/INUcK2iV4CcDJD4RgtqBnnjz54eziTfzVSeaB1g==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImgPath",
                table: "GoodsImages",
                newName: "ImgName");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1c3d07c1-379d-4402-9313-4b01e0761fc0",
                column: "ConcurrencyStamp",
                value: "92f5a78f-754e-41cf-be53-99c5b74fe198");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "97088e8a-3573-479a-99a3-2541e3e7c7de",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "94e8e89e-aced-401e-8c3c-1f2dbef19cfe", "AQAAAAEAACcQAAAAEEG+WUwS4+sOHuHDtW/7xLd3Qsn6qrFd076rh/DFgHuo0Y7mU5R7Y4V3Qz8UTVVJYw==" });
        }
    }
}
