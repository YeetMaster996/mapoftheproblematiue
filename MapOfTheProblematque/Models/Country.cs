using Microsoft.Identity.Client.NativeInterop;
using Mono.TextTemplating;
using System.ComponentModel.DataAnnotations;

namespace MapOfTheProblematique.Models
{

    public class Country
    {
        public int Id { get; set; }
        [Display(Name = "Country Name")]
        public string Name { get; set; }
        public List<City> Cities { get; set; }

    }
   

}

