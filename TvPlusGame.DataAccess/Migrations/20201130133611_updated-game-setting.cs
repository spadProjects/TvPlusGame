using Microsoft.EntityFrameworkCore.Migrations;

namespace TvPlusGame.DataAccess.Migrations
{
    public partial class updatedgamesetting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "GameSettings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "ab0a587d-be2f-42f2-9eea-a6f60e703097");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f8796445-771d-4f1c-b7de-caa396587dec", "AQAAAAEAACcQAAAAEMTqnQvQeZ8fv/yHj3lF/94PoPbEedVJc1wlNYCPdDeZkS7aTfpAbkd7AvovJzctoA==", "5f95adf5-99cf-4860-b580-65d72fb3a1d8" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "GameSettings");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "d5947a4c-2196-47f8-a843-16a710dcc6d6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5aea4234-18f1-4606-829a-e4bcb08e7d63", "AQAAAAEAACcQAAAAENZGRa8GQpyWe2Uv/o1NcBsXEIA/ragHsydMKVromkkHw2gx+YmuywAHT3spGYUUaA==", "64d16ae4-66a7-49e7-898c-f81a923b6f3c" });
        }
    }
}
