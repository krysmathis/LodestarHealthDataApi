using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace LodestarHealthDataApi.Migrations
{
    public partial class IndexingLatLong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Facility_Lat_Long",
                table: "Facility",
                columns: new[] { "Lat", "Long" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Facility_Lat_Long",
                table: "Facility");
        }
    }
}
