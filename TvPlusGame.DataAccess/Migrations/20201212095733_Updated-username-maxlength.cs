using Microsoft.EntityFrameworkCore.Migrations;

namespace TvPlusGame.DataAccess.Migrations
{
    public partial class Updatedusernamemaxlength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "bb37f9a8-4a55-4340-be60-b11907c5f886");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8c5cfd4d-0a23-4723-bfea-13712fa44a4b", "AQAAAAEAACcQAAAAEOuXHCr7+BP0yBxugcJNyA29Rohh+V5Opx/ncmqpnQ9MUqkhgv/7fFSSx7XmchYD4A==", "3332c078-180b-4132-a432-c7fb240a1178" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
