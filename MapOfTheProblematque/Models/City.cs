using System.ComponentModel.DataAnnotations;

namespace MapOfTheProblematique.Models
{
    public class City
    {
        public int CityId { get; set; }
        [Display(Name = "City Name")]
        public string CityName { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }
    }

}
