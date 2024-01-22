using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace Jopp_lunch.Pages.Users
{
    public class CreateModel : PageModel
    {
        public Uzivatel Uzivatel = new Uzivatel();
        public String errorMessage = "";
        public String successMessage = "";
        public void OnGet()
        {
        }

        public void OnPost() 
        {
            if (string.IsNullOrEmpty(Request.Form["jmeno"]) || string.IsNullOrEmpty(Request.Form["prijmeni"]))
            {
                errorMessage = "Jméno a Pøijmení jsou povinná pole!";
                return;
            }
            Uzivatel.jmeno = Request.Form["jmeno"];
            Uzivatel.prijmeni = Request.Form["prijmeni"];
            
            try
            {
                String connectionstring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=JoppLunchDB;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    connection.Open();
                    String query = "Insert into uzivatele(jmeno,prijmeni) " +
                        "values (@jmeno,@prijmeni);";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@jmeno", Uzivatel.jmeno);
                        command.Parameters.AddWithValue("@prijmeni", Uzivatel.prijmeni);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            Uzivatel = new Uzivatel();
            successMessage = "Nový uživatel byl pøidán";
            Response.Redirect("/Users/Index");
        }
    }
}
