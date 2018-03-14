using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace LodestarHealthDataApi.Models
{
    public class Hospital
    {   
        [Key]
        public int HospitalId {get;set;}
        
        [Required]
        public int ProviderId {get; set;}   
        public string Hospital_Name {get; set;}
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int  ZipCode {get; set;}
        public int CountyName {get; set;}
        public double Lat {get; set;}  = 0.0;
        public double Lon {get; set;} = 0.0;
    }
}