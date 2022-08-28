using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kitchen.DataAccess.Migrations
{
    public partial class IntegrationEventOutbox : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("6a950478-6e6c-4c37-a0ce-ed576a3c1ca9"));

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: new Guid("587b88ea-d396-4b6e-ac27-dea0f8e64d70"));

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: new Guid("7c1a9309-ce3e-459e-82bf-c139317590fb"));

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: new Guid("bf9e0b39-34c3-46e5-936c-192db744859b"));

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: new Guid("ee635106-2f82-428e-a735-1200d3658bee"));

            migrationBuilder.CreateTable(
                name: "IntegrationEventsOutbox",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EventId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntegrationEventsOutbox", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IntegrationEventsOutbox_StoredEvents_EventId",
                        column: x => x.EventId,
                        principalTable: "StoredEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("b5534d23-f3b5-4907-bfc4-671b9caf0d4a"), "Soup" });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "CurrentAggregateId", "Number" },
                values: new object[,]
                {
                    { new Guid("15dc2b56-f324-463f-ab9a-e954f81df75a"), new Guid("00000000-0000-0000-0000-000000000000"), 4 },
                    { new Guid("80572e94-a8f8-42b7-9ab0-91634353bd5a"), new Guid("00000000-0000-0000-0000-000000000000"), 2 },
                    { new Guid("a8ba66b6-8374-4c3d-9371-08133067c3c1"), new Guid("00000000-0000-0000-0000-000000000000"), 3 },
                    { new Guid("e9639253-f3dc-4b02-a4aa-29e3eae9645f"), new Guid("00000000-0000-0000-0000-000000000000"), 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_IntegrationEventsOutbox_EventId",
                table: "IntegrationEventsOutbox",
                column: "EventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IntegrationEventsOutbox");

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("b5534d23-f3b5-4907-bfc4-671b9caf0d4a"));

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: new Guid("15dc2b56-f324-463f-ab9a-e954f81df75a"));

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: new Guid("80572e94-a8f8-42b7-9ab0-91634353bd5a"));

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: new Guid("a8ba66b6-8374-4c3d-9371-08133067c3c1"));

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: new Guid("e9639253-f3dc-4b02-a4aa-29e3eae9645f"));

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("6a950478-6e6c-4c37-a0ce-ed576a3c1ca9"), "Soup" });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "CurrentAggregateId", "Number" },
                values: new object[,]
                {
                    { new Guid("587b88ea-d396-4b6e-ac27-dea0f8e64d70"), new Guid("00000000-0000-0000-0000-000000000000"), 2 },
                    { new Guid("7c1a9309-ce3e-459e-82bf-c139317590fb"), new Guid("00000000-0000-0000-0000-000000000000"), 3 },
                    { new Guid("bf9e0b39-34c3-46e5-936c-192db744859b"), new Guid("00000000-0000-0000-0000-000000000000"), 4 },
                    { new Guid("ee635106-2f82-428e-a735-1200d3658bee"), new Guid("00000000-0000-0000-0000-000000000000"), 1 }
                });
        }
    }
}
