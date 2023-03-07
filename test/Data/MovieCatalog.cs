using System.ComponentModel.DataAnnotations;

namespace test.Data
{
    public class MovieCatalog
    {
        public int MovieCatalogId { get; set; }

        [Display(Name = "Title")]
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        [Display(Name = "Catalog Name")]
        public int CatalogId { get; set; }
        public Catalog Catalog { get; set; }
    }
}
