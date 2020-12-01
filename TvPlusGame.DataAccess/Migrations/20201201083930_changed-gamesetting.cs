using Microsoft.EntityFrameworkCore.Migrations;

namespace TvPlusGame.DataAccess.Migrations
{
    public partial class changedgamesetting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "GameSettings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "20602904-a2cf-4c80-a2bc-a5551fd91f38");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e7ae871a-23af-42c7-a7b0-1b50061ffc48", "AQAAAAEAACcQAAAAEFDQGJxqFWNpdQDSvEjkrj3SQxbrghpNnPpJ4Osb/+OgZYUhlgVPDZJqgbZiFRjtgQ==", "d1917162-40c5-465d-8824-112b7cc8297a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "GameSettings");

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
    }
}
