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

        private static Facility FacilityFactory(string data) 
        {
            var commaSeperated = data.Split(',');
            
            Facility facility = new Facility(); 
            
            facility.System_Affiliation_Name = commaSeperated[0];
            facility.Facility_Name = commaSeperated[1];
            facility.Current_Year_Market_Share = Convert.ToDouble(commaSeperated[2]);
            facility.Current_Year_Commercial_Market_Share = Convert.ToDouble(commaSeperated[3]);
            facility.Lat = Convert.ToDouble(commaSeperated[4]);
            facility.Long = Convert.ToDouble(commaSeperated[5]);
            facility.Quality_Complications_Deaths = commaSeperated[6];
            facility.Likelihood_To_Recommend = Convert.ToInt32(commaSeperated[7]);
            facility.Overall_Hospital_Linear_Mean_Score = Convert.ToInt32(commaSeperated[8]);
            facility.Quality_Hosp_Acq_Infections = commaSeperated[9];
            facility.Quality_Readmissions = commaSeperated[10];
            facility.Total_2017_22_Pop_Growth = Convert.ToDouble(commaSeperated[11]);
            facility.Household_Income = Convert.ToDouble(commaSeperated[12]);
            facility.CY_Discharges =Convert.ToInt64(commaSeperated[13]);
            facility.Estimated_NR = Convert.ToInt64(commaSeperated[14]);
            facility.Estimated_CM = Convert.ToInt64(commaSeperated[15]);
            facility.Estimated_EBITDA = Convert.ToInt64(commaSeperated[16]);
            facility.Current_Liabilities = Convert.ToInt64(commaSeperated[17]);
            facility.Current_Assets = Convert.ToInt64(commaSeperated[18]);
            facility.Total_Liabilities = Convert.ToInt64(commaSeperated[19]);
            facility.Fund_Balance = Convert.ToInt64(commaSeperated[20]);
            facility.EBITDAR = Convert.ToInt64(commaSeperated[21]);
            
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