using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fix_Tune.Repository.Migrations
{
    /// <inheritdoc />
    public partial class PlateNumberAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 1);

            migrationBuilder.AddColumn<string>(
                name: "PlateNumber",
                table: "Cars",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ba38b216-7e8c-4df8-9d68-99d55a15e16c", "AQAAAAIAAYagAAAAEKA4SkJ6o3QePlZFhGcqnIkM5/FRoaqxRVL2SRXddbC3Pb0ENGwxZkyE7LhjosrQWg==", "b763f350-aeae-454d-b5e4-af9ccd96dc05" });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarId", "Brand", "PlateNumber", "Type", "UserId", "Year" },
                values: new object[] { 2, "VW", "ABB-222", "Golf 4", "admin", 2002 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "PlateNumber",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Cars");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ff91ced7-2c7c-4ef4-bb00-f7018e832dd6", "AQAAAAIAAYagAAAAEAn/+u+3IUjAH0gaspzhPm2dmJgVpZij8p8S1P5H1ONnyDg/cVKCb7VCtiqAZF/+jg==", "2f6437fa-10a6-4401-9253-3e7f8657d7c3" });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarId", "Brand", "Type", "UserId" },
                values: new object[] { 1, "VW", "Golf 4", "admin" });
        }
    }
}
