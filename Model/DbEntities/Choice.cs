using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jopp_lunch.Model.DbEntities
{
    public class Choice
    {
        [Key]
        [DisplayName("Číslo")]
        public int cislo_vyberu { get; set; }
        [DisplayName("Uživatel")]
        public User cislo_uzivatele { get; set; } = new User();
        [DisplayName("Oběd")]
        public Lunch obedId { get; set; } = new Lunch();
        [DisplayName("Počet")]
        public int pocet { get; set; }
        [DisplayName("Výdejní místo")]
        public Canteen vydejni_misto { get; set; } = new Canteen();
    }
}
