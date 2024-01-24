using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jopp_lunch.Model.DbEntities
{
    public class Choice
    {
        [Key]
        public int cislo_vyberu { get; set; }
        public User cislo_uzivatele { get; set; } = new User();
        public Lunch obedId { get; set; } = new Lunch();
        public int pocet { get; set; }
        public Canteen vydejni_misto { get; set; } = new Canteen();
    }
}
