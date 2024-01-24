using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jopp_lunch.Model.DbEntities
{
    public class Soup
    {
        [Key]
        public int polevkaId { get; set; }
        public string forma_obeda { get; set; } = string.Empty;
        public string popis_obeda { get; set; } = string.Empty;
        public DateTime datum_vydeje { get; set; }
        public DateTime datum_pridani { get; set; }
        public DateTime datum_editace { get; set; }
    }
}
