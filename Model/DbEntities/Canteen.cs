using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jopp_lunch.Model.DbEntities
{
    public class Canteen
    {
        [Key]
        public int cislo_VM { get; set; }
        public string nazev { get; set; } = string.Empty;
    }
}
