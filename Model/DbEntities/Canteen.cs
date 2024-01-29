using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jopp_lunch.Model.DbEntities
{
    public class Canteen
    {
        [Key]
        [DisplayName("Číslo")]
        public int cislo_VM { get; set; }
        [DisplayName("Název")]
        public string nazev { get; set; } = string.Empty;
    }
}
