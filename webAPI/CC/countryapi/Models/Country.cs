using System.ComponentModel.DataAnnotations;

namespace CountryAPI.Models
{
    public class Country
    {
        public int ID { get; set; }

        [Required]
        public string CountryName { get; set; }

        [Required]
        public string Capital { get; set; }
    }
}
