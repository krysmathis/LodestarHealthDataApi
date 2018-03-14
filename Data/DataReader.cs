using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using LodestarHealthDataApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace LodestarHealthDataApi.Data
{
    public class DataReader
    { 
        public static async void Init(LodestarAPIContext context) {

      
                var roleStore = new RoleStore<IdentityRole>(context);
                var userstore = new UserStore<ApplicationUser>(context);

                if (!context.Roles.Any(r => r.Name == "Administrator"))
                {
                    var role = new IdentityRole { Name = "Administrator", NormalizedName = "Administrator" };
                    await roleStore.CreateAsync(role);
                }

                if (!context.ApplicationUser.Any(u => u.UserName == "admin@admin.com"))
                {
                    //  This method will be called after migrating to the latest version.
                    ApplicationUser user = new ApplicationUser {
                        UserName = "admin@admin.com",
                        NormalizedUserName = "ADMIN@ADMIN.COM",
                        Email = "admin@admin.com",
                        NormalizedEmail = "ADMIN@ADMIN.COM",
                        EmailConfirmed = true,
                        LockoutEnabled = false,
                        SecurityStamp = Guid.NewGuid().ToString("D")
                    };
                    var passwordHash = new PasswordHasher<ApplicationUser>();
                    user.PasswordHash = passwordHash.HashPassword(user, "Admin8*");
                    await userstore.CreateAsync(user);
                    await userstore.AddToRoleAsync(user, "Administrator");
                }

            Hospital[] hospitals = new Hospital[] {
                new Hospital() {
                    ProviderId = 1,
                    Address = "one",
                    

                },
            };

             // check if data exists in the database
            if (!context.Facility.Any()){
                // if not ReadFacilityData from the file
                Facility[] facilities = ReadFacilityData("./Data/data.csv");
                // add it to the database
                Console.WriteLine($"There are how many: {facilities.Length}");
                
                facilities.ToList().ForEach(f => 
                    context.Facility.Add(f)
                 );
                 context.SaveChanges();
                
            } 
        }

        // A valid entry is one that is not null, not blank and not a dash
        // includes special handling if 'Not Available'
        private static bool isValid(string val) {
            return (val == "" || 
                    val == null || 
                    val == "Not Available" ||
                    val == "-") ? false : true;
        }

        private static Facility FacilityFactory(string data) 
        {
            data = data.Replace("\"", "");
            var commaSeperated = data.Split(',');
            
            
            Facility facility = new Facility(); 
            
            facility.System_Affiliation_Name = commaSeperated[0];
            facility.Facility_Name = commaSeperated[1];
            facility.Current_Year_Market_Share = isValid(commaSeperated[2]) ? Convert.ToDouble(commaSeperated[2]) : default(double);
            facility.Current_Year_Commercial_Market_Share = isValid(commaSeperated[3])  ? Convert.ToDouble(commaSeperated[3]) : default(double);
            facility.Lat = isValid(commaSeperated[4]) ? Convert.ToDouble(commaSeperated[4]) : default(double);
            facility.Long = isValid(commaSeperated[5]) ? Convert.ToDouble(commaSeperated[5]) : default(double);
            facility.Quality_Complications_Deaths = commaSeperated[6];
            facility.Likelihood_To_Recommend = isValid(commaSeperated[7])  ? Convert.ToInt32(commaSeperated[7]) : default(int);
            facility.Overall_Hospital_Linear_Mean_Score = isValid(commaSeperated[8]) ? Convert.ToInt32(commaSeperated[8]) : default(int);
            facility.Quality_Hosp_Acq_Infections = commaSeperated[9];
            facility.Quality_Readmissions = commaSeperated[10];
            facility.Total_2017_22_Pop_Growth = isValid(commaSeperated[11]) ? Convert.ToDouble(commaSeperated[11]) : default(double);
            facility.Household_Income = isValid(commaSeperated[12]) ? Convert.ToDouble(commaSeperated[12]) : default(double);
            facility.CY_Discharges = isValid(commaSeperated[13]) ? Convert.ToInt64(commaSeperated[13]) : default(long);
            facility.Estimated_NR = isValid(commaSeperated[14])  ? Convert.ToInt64(commaSeperated[14]) : default(long);
            facility.Estimated_CM = isValid(commaSeperated[15])  ? Convert.ToInt64(commaSeperated[15]) : default(long);
            facility.Estimated_EBITDA = isValid(commaSeperated[16])  ? Convert.ToInt64(commaSeperated[16]) : default(long);
            facility.Current_Liabilities = isValid(commaSeperated[17])  ? Convert.ToInt64(commaSeperated[17]) : default(long);
            facility.Current_Assets = isValid(commaSeperated[18])  ? Convert.ToInt64(commaSeperated[18]) : default(long);
            facility.Total_Liabilities = isValid(commaSeperated[19])  ? Convert.ToInt64(commaSeperated[19]) : default(long);
            facility.Fund_Balance = isValid(commaSeperated[20])  ? Convert.ToInt64(commaSeperated[20]) : default(long);
            facility.EBITDAR = isValid(commaSeperated[21])  ? Convert.ToInt64(commaSeperated[21]) : default(long);
            
            // ... all the logic to turn one row of csv data into a facility
            return facility;
        }

        public static Facility[] ReadFacilityData(string dataPath)
        {
            
           var data = 
                File.ReadAllLines(dataPath)
                .Skip(1) // skip header
                .Select(FacilityFactory)
                .ToArray();
            
            return data;
        }
    }
}