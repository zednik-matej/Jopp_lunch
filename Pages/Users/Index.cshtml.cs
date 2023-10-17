using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace Jopp_lunch.Pages.Users
{
    public class IndexModel : PageModel
    {
        public List<Uzivatel> listUzivatels = new List<Uzivatel>();
        public void OnGet()
        {
            try
            {
                String connectionstring = "Data Source=(localdb)\\LocalTestDB;Initial Catalog=JoppLunchDB;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionstring)) 
                {
                    connection.Open();
                    String query = "Select * from uzivatele";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Uzivatel uzivatel = new Uzivatel();
                                uzivatel.osobni_cislo = reader.GetInt32(0);
                                uzivatel.jmeno = reader.GetString(1);
                                uzivatel.prijmeni = reader.GetString(2);
                                uzivatel.vychozi_VM = reader.GetInt32(3);
                                uzivatel.vychozi_forma = reader.GetString(4);

                                listUzivatels.Add(uzivatel);
                            }
                        }
                    }
                }
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public class Uzivatel
    {
        public int osobni_cislo;
        public string jmeno = string.Empty;
        public string prijmeni = string.Empty;
        public int vychozi_VM;
        public string vychozi_forma = string.Empty;
    }
}
