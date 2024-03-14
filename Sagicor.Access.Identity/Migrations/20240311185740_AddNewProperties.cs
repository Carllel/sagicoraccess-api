using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sagicor.Access.Identity.Migrations
{
    /// <inheritdoc />
    public partial class AddNewProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiry",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "RefreshTokenExpiry", "SecurityStamp" },
                values: new object[] { "c01d3cd9-c7b7-4f8a-b060-3a3950714dff", "AQAAAAIAAYagAAAAEKG/y6XVJvHcZNYdIkmB782feNAKF3lgykBBmTIKLu4gUjdxjRzaHsC+5GqTAVqoEA==", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "86b63075-a9d0-470f-9683-9bf1d23df9d7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "RefreshTokenExpiry", "SecurityStamp" },
                values: new object[] { "5f84bedf-75cb-4e0e-bb63-277052211f3d", "AQAAAAIAAYagAAAAEOFa5Iujzuw2wBIHmW+c3DSR0mgrWfHLSouDM7hcPKFGiAQRXUOMJVxrpIe43+xy/w==", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "be700eaa-e02f-4070-869b-260ff13cf825" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiry",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "38391637-c4e5-4827-8f55-6dcdca72240f", "AQAAAAIAAYagAAAAEB0rL3GHVLLa6tSweweXPifMVbLfk7CcXIx8CRKi19WyhWL5TmWJ42xEqPZxB5GXEA==", "ced17b35-0a2d-4874-a6d5-7f95a7bfe95e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "60a9c5e9-f0ee-4dec-abc2-9189ad750967", "AQAAAAIAAYagAAAAEHyNrOYoz4wnkC1ikcnc6CicCjRO0g2ub890uPoZJC1sE2iyTYSjdBf3Mlwbn5zwQQ==", "81e8e72d-adf9-4b3d-97cc-936ce1e20728" });
        }
    }
}
