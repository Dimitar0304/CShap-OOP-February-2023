using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace test.Data
{
    public class Movie
    {
        public Movie()
        {
            this.Catalogs = new List<MovieCatalog>();
        }
        public int MovieId { get; set; }
        [Required]
        [Display(Name = "Titile")]
        [MaxLength(64)]
        public string MovieName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Release Name")]
        public DateTime ReleaseDate { get; set; }

        [MaxLength(255)]
        [Display(Name = "Discription")]
        public string Discription { get; set; }

        [Display(Name = "Photo")]
        [MaxLength(150)]
        public string Phone { get; set; }
        public ICollection<MovieCatalog> Catalogs {get;set;}

    }
}
