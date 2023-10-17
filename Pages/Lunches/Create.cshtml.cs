using Jopp_lunch.Pages.Lunches;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace Jopp_lunch.Pages.Lunches
{
    public class CreateModel : PageModel
    {
        public Obed obed = new Obed();
        public String errorMessage = "";
        public String successMessage = "";
        public void OnGet()
        {
        }

        public void OnPost() 
        {
            if (string.IsNullOrEmpty(Request.Form["forma"]) || string.IsNullOrEmpty(Request.Form["popis"]) || string.IsNullOrEmpty(Request.Form["datum_vydeje"]) || string.IsNullOrEmpty(Request.Form["polevka"]))
            {
                errorMessage = "forma, popis, datum výdeje jsou povinná pole!";
                return;
            }
            obed.forma_obeda = Request.Form["forma"];
            obed.popis_obeda = Request.Form["popis"];
            obed.datum_vydeje = DateOnly.Parse(Request.Form["datum_vydeje"]);
            obed.cislo_polevky = Int32.Parse(Request.Form["polevka"]);

            try
            {
                String connectionstring = "Data Source=(localdb)\\LocalTestDB;Initial Catalog=JoppLunchDB;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    connection.Open();
                    String query = "Insert into obedy(forma_obeda,popis_obeda,datum_vydeje,datum_pridani,datum_editace,cislo_polevky) " +
                        "values (@forma,@popis,@vydej,GETUTCDATE(),GETUTCDATE(),@polivka);";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@forma", obed.forma_obeda);
                        command.Parameters.AddWithValue("@popis", obed.popis_obeda);
                        command.Parameters.AddWithValue("@vydej", obed.datum_vydeje.ToString("MM.dd.yyyy"));
                        command.Parameters.AddWithValue("@polivka", obed.cislo_polevky);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
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
