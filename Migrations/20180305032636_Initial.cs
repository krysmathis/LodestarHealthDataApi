using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace LodestarHealthDataApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Facility",
                columns: table => new
                {
                    FacilityId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CY_Discharges = table.Column<long>(nullable: false),
                    Current_Assets = table.Column<long>(nullable: false),
                    Current_Liabilities = table.Column<long>(nullable: false),
                    Current_Year_Commercial_Market_Share = table.Column<double>(nullable: false),
                    Current_Year_Market_Share = table.Column<double>(nullable: false),
                    EBITDAR = table.Column<long>(nullable: false),
                    Estimated_CM = table.Column<long>(nullable: false),
                    Estimated_EBITDA = table.Column<long>(nullable: false),
                    Estimated_NR = table.Column<long>(nullable: false),
                    Facility_Name = table.Column<string>(nullable: true),
                    Fund_Balance = table.Column<long>(nullable: false),
                    Household_Income = table.Column<double>(nullable: false),
                    Lat = table.Column<double>(nullable: false),
                    Likelihood_To_Recommend = table.Column<int>(nullable: false),
                    Long = table.Column<double>(nullable: false),
                    Overall_Hospital_Linear_Mean_Score = table.Column<int>(nullable: false),
                    Quality_Complications_Deaths = table.Column<string>(nullable: true),
                    Quality_Hosp_Acq_Infections = table.Column<string>(nullable: true),
                    Quality_Readmissions = table.Column<string>(nullable: true),
                    System_Affiliation_Name = table.Column<string>(nullable: true),
                    Total_2017_22_Pop_Growth = table.Column<double>(nullable: false),
                    Total_Liabilities = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facility", x => x.FacilityId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Facility");
        }
    }
}
