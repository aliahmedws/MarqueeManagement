using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarqueeManagement.Migrations
{
    /// <inheritdoc />
    public partial class added_bookingsAndMenuCatergories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppBookings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventType = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GuestCount = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppBookings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppMenuCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppMenuCategories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppBookings_EventDate",
                table: "AppBookings",
                column: "EventDate");

            migrationBuilder.CreateIndex(
                name: "IX_AppBookings_EventType",
                table: "AppBookings",
                column: "EventType");

            migrationBuilder.CreateIndex(
                name: "IX_AppBookings_GuestCount",
                table: "AppBookings",
                column: "GuestCount");

            migrationBuilder.CreateIndex(
                name: "IX_AppBookings_Status",
                table: "AppBookings",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_AppBookings_TotalAmount",
                table: "AppBookings",
                column: "TotalAmount");

            migrationBuilder.CreateIndex(
                name: "IX_AppMenuCategories_Description",
                table: "AppMenuCategories",
                column: "Description");

            migrationBuilder.CreateIndex(
                name: "IX_AppMenuCategories_Name",
                table: "AppMenuCategories",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppBookings");

            migrationBuilder.DropTable(
                name: "AppMenuCategories");
        }
    }
}
