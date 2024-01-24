using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jopp_lunch.Model.DbEntities
{
    public class User : IdentityUser
    {
        [DisplayName("Osobní číslo")]
        public int osobni_cislo { get; set; }
        [DisplayName("Jméno")]
        public string jmeno { get; set; } = string.Empty;
        [DisplayName("Příjmení")]
        public string prijmeni { get; set; } = string.Empty;
    }
}
