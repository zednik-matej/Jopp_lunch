using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jopp_lunch.Model.DbEntities
{
    public class Lunch
    {
        [Key]
        [DisplayName("Číslo")]
        public int cislo_obeda { get; set; }
        [DisplayName("Popis")]
        public string popis_obeda { get; set; } = string.Empty;
        [DisplayName("Polévka")]
        public Soup cislo_polevky { get; set; } = new Soup();
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
