using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace test.Data
{
    public class Catalog
    {
        public Catalog()
        {
            this.Movies = new List<MovieCatalog>();
        }
        public int CatalogId { get; set; }
        [Required]
        [Display(Name="Catalog Name")]
        [MaxLength(64)]
        public string CatalogName { get; set; }
        [Display(Name="Description")]
        public string Description { get; set; }
        [Display(Name="User")]
        public int UserId { get; set; }
        public User User { get; set; }
        public  ICollection<MovieCatalog> Movies { get; set; }
    }
}
