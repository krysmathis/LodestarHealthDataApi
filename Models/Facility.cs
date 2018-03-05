using System.ComponentModel.DataAnnotations;

namespace LodestarHealthDataApi.Models
{
    public class Facility
    {
        [Key]
        public int FacilityId {get; set;}
        public string System_Affiliation_Name {get; set;}
        public string Facility_Name {get;set;}
        public double Current_Year_Market_Share {get; set;}
        public double Current_Year_Commercial_Market_Share {get; set;}
        public double Lat {get;set;}
        public double Long {get; set;}
        public string Quality_Complications_Deaths {get; set;}
        public int Likelihood_To_Recommend {get; set;}
        public int Overall_Hospital_Linear_Mean_Score {get; set;}
        public string Quality_Hosp_Acq_Infections {get;set;}
        public string Quality_Readmissions {get; set;}
        public double Total_2017_22_Pop_Growth {get;set;}
        public double Household_Income {get; set;}
        public long CY_Discharges {get; set;}
        public long Estimated_NR {get ;set;}
        public long Estimated_CM {get;set;}
        public long Estimated_EBITDA {get;set;}
        public long Current_Liabilities {get;set;}
        public long Current_Assets {get; set;}
        public long Total_Liabilities {get; set;}
        public long Fund_Balance {get ;set;}
        public long EBITDAR {get; set;}
    }
}