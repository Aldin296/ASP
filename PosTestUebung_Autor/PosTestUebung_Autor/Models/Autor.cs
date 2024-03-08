using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PosTestUebung_Autor.Models
{
    public class Autor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Range(18,150, ErrorMessage ="The age has to be between 18 and 150")]
        public int Age { get; set; }

        [JsonIgnore]
        public List<Buch> Buecher { get; set; } = new List<Buch>();
    }
}
