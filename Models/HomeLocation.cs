using System.ComponentModel.DataAnnotations;

namespace LodestarHealthDataApi.Models
{
    public class HomeLocation
    {
        [Key]
        public int HomeLocationId { get; set; }
        [Required]
        public ApplicationUser User {get;set;}
        [Required]
        public double Lat  {get;set;}
        [Required]
        public double Lon {get; set;}

    }
}