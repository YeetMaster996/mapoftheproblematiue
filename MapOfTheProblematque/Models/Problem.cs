    using MapOfTheProblematique.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    namespace MapOfTheProblematque.Models
    {
        public class Problem
        {
            [Display(Name = "Problem ID")]
            public int Id { get; set; }
            [Display(Name = "Problem Name")]
            [Required]
            [Column(TypeName = "nvarchar(250)")]
            [Remote (action: "IsProblemAvailable",controller:"Problem",AdditionalFields ="Id",ErrorMessage ="A Problem with the same Name aleady exists.")]
            public string Name { get; set; }

            [Display(Name = "Description")]
            [Column(TypeName = "nvarchar(max)")]
            public string Description { get; set; }

            [Display(Name = "Type")]
            [Column(TypeName = "nvarchar(100)")]
            public string Category { get; set; }

            [Display(Name = "Priority")]

            public int? Priority { get; set; }

            public int CityId { get; set; }

            public City? City { get; set; }

        }
    }
