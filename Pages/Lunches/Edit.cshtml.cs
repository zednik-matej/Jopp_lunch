using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace Jopp_lunch.Pages.Lunches
{
    public class EditModel : PageModel
    {
        public Obed obed = new Obed();
        public String errorMessage = "";
        public String successMessage = "";

        public void OnGet()
        {
            String ID = Request.Query["cislo_obeda"];
            if (!String.IsNullOrEmpty(ID))
            {
                try
                {
                    String connectionstring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=JoppLunchDB;Integrated Security=True";
                    using (SqlConnection connection = new SqlConnection(connectionstring))
                    {
                        connection.Open();
                        String query = "Select cislo_obeda,cislo_polevky,forma_obeda,popis_obeda,datum_vydeje from obedy where cislo_obeda=@id";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("id", ID);
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    obed.cislo_obeda = reader.GetOrdinal("cislo_obeda");
                                    if (!reader.IsDBNull(reader.GetOrdinal("cislo_polevky")))
                                    {
                                        obed.cislo_polevky = reader.GetOrdinal("cislo_polevky");
                                    }
                                    obed.forma_obeda = reader.GetString(2);
                                    obed.popis_obeda = reader.GetString(3);
                                    obed.datum_vydeje = DateOnly.FromDateTime(reader.GetDateTime(4));
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    errorMessage = ex.Message;
                }
            }
        }

        public void OnPost() 
        {
            if (string.IsNullOrEmpty(Request.Form["forma"]) || string.IsNullOrEmpty(Request.Form["popis"]) || string.IsNullOrEmpty(Request.Form["datum_vydeje"]) || string.IsNullOrEmpty(Request.Form["polevka"]))
            {
                errorMessage = "forma, popis, datum výdeje jsou povinná pole!";
                return;
            }
            obed.cislo_obeda = Int32.Parse(Request.Form["cislo_obeda"]);
            obed.popis_obeda = Request.Form["popis"];
            obed.forma_obeda = Request.Form["forma"];
            obed.cislo_polevky = Int32.Parse(Request.Form["polevka"]);
            obed.datum_vydeje = DateOnly.Parse(Request.Form["datum_vydeje"]);
            try
            {
                String connectionstring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=JoppLunchDB;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    connection.Open();
                    String query = "UPDATE obedy " +
                        "SET forma_obeda=@forma, datum_vydeje=@vydej, datum_editace= GETDATE(), popis_obeda=@popis, cislo_polevky=@polevka WHERE cislo_obeda=@id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@forma", obed.forma_obeda);
                        command.Parameters.AddWithValue("@vydej", obed.datum_vydeje.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@popis", obed.popis_obeda);
                        command.Parameters.AddWithValue("@polevka", obed.cislo_polevky);
                        command.Parameters.AddWithValue("@id", obed.cislo_obeda);
                        int cnt = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            obed = new Obed();
            successMessage = "Nový uživatel byl pøidán";
            Response.Redirect("/Lunches/Index");
        }    
    }
}
