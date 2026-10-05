using Microsoft.Identity.Client.NativeInterop;
using Mono.TextTemplating;

namespace MapOfTheProblematique.Models
{

    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<City> Cities { get; set; }

    }
   

}

