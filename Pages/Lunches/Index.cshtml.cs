using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System;

namespace Jopp_lunch.Pages.Lunches
{
    public class IndexModel : PageModel
    {
        public List<Obed> LunchList = new List<Obed>();
        public void OnGet()
        {
            try
            {
                String connectionstring = "Data Source=(localdb)\\LocalTestDB;Initial Catalog=JoppLunchDB;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    connection.Open();
                    String query = "Select * from obedy/* where datum_vydeje > GETDATE()*/";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Obed obed = new Obed();
                                obed.cislo_obeda = reader.GetInt32(0);
                                obed.forma_obeda = reader.GetString(1);
                                obed.datum_vydeje = DateOnly.FromDateTime(reader.GetDateTime(2));
                                obed.datum_pridani = reader.GetDateTime(3);
                                obed.datum_editace = reader.GetDateTime(4);
                                obed.popis_obeda = reader.GetString(5);
                                if (reader["cislo_polevky"] != DBNull.Value)
                                {
                                    obed.cislo_polevky = reader.GetInt32(6);
                                }
                                else obed.cislo_polevky = 0;
                                LunchList.Add(obed);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public class Obed
    {
        public int cislo_obeda;
        public string forma_obeda = string.Empty;
        public DateOnly datum_vydeje;
        public DateTime datum_pridani;
        public DateTime datum_editace;
        public string popis_obeda = string.Empty;
        public int cislo_polevky;
    }
}
