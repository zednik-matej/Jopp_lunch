using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jopp_lunch.Model.DbEntities
{
    public class Soup
    {
        [Key]
        [DisplayName("Číslo")]
        public int polevkaId { get; set; }
        [DisplayName("Popis")]
        public string popis_obeda { get; set; } = string.Empty;
        [DisplayName("Datum výdeje")]
        public DateTime datum_vydeje { get; set; }
        [DisplayName("Datum přidání")]
        public DateTime datum_pridani { get; set; }
        [DisplayName("Datum editace")]
        public DateTime datum_editace { get; set; }
        [DisplayName("Forma výdeje")]
        public int? forma { get; set; } = 0;
    }
}
