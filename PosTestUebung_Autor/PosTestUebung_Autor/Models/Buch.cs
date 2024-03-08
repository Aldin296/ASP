using System.ComponentModel.DataAnnotations;

namespace PosTestUebung_Autor.Models
{
    public class Buch
    {
        public int Id { get; set; }
        [MaxLength(100), MinLength(5, ErrorMessage = "Minimum Title Length is 5 and Maximum Length is 100") ]
        public string Title { get; set; }
        public List<string> Genres { get; set; }
        public int Pagecount { get; set; }
        [Range(1,5, ErrorMessage ="Minimum of 1 star and a maximum of 5")]
        public int Stars {  get; set; }
        public Autor? Autor { get; set; }
        public int? AutorId { get; set; }

        public override string ToString()
        {
            return $"{Title} {Autor?.Name} {Pagecount} {Stars}";
        }

    }
}
