using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jopp_lunch.Model.DbEntities
{
    public class Lunch
    {
        [Key]
        public int cislo_obeda { get; set; }
        public string forma_obeda { get; set; } = string.Empty;
        public string popis_obeda { get; set; } = string.Empty;
        public Soup cislo_polevky { get; set; } = new Soup();
        public DateTime datum_vydeje { get; set; }
        public DateTime datum_pridani { get; set; }
        public DateTime datum_editace { get; set; }
    }
}
