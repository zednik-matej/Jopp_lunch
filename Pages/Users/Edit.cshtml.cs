using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace Jopp_lunch.Pages.Users
{
    public class EditModel : PageModel
    {
        public Uzivatel Uzivatel = new Uzivatel();
        public String errorMessage = "";
        public String successMessage = "";

        public void OnGet()
        {
            String ID = Request.Query["osobni_cislo"];
            if (!String.IsNullOrEmpty(ID))
            {
                try
                {
                    String connectionstring = "Data Source=(localdb)\\LocalTestDB;Initial Catalog=JoppLunchDB;Integrated Security=True";
                    using (SqlConnection connection = new SqlConnection(connectionstring))
                    {
                        connection.Open();
                        String query = "Select * from uzivatele where osobni_cislo=@id";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("id", ID);
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    Uzivatel.osobni_cislo = reader.GetInt32(0);
                                    Uzivatel.jmeno = reader.GetString(1);
                                    Uzivatel.prijmeni = reader.GetString(2);
                                    Uzivatel.vychozi_VM = reader.GetInt32(3);
                                    Uzivatel.vychozi_forma = reader.GetString(4);
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
            if (string.IsNullOrEmpty(Request.Form["jmeno"]) || string.IsNullOrEmpty(Request.Form["prijmeni"]))
            {
                errorMessage = "Jméno a Pøijmení jsou povinná pole!";
                return;
            }
            Uzivatel.osobni_cislo = Int32.Parse(Request.Form["osobni_cislo"]);
            Uzivatel.jmeno = Request.Form["jmeno"];
            Uzivatel.prijmeni = Request.Form["prijmeni"];
            Uzivatel.vychozi_forma = Request.Form["vychozi_forma"];
            Uzivatel.vychozi_VM = Int32.Parse(Request.Form["vychozi_VM"]);
            try
            {
                String connectionstring = "Data Source=(localdb)\\LocalTestDB;Initial Catalog=JoppLunchDB;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    connection.Open();
                    String query = "UPDATE uzivatele " +
                        "SET jmeno=@jmeno, prijmeni=@prijmeni, vychozi_VM=@VM, vychozi_forma=@forma WHERE osobni_cislo=@id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@jmeno", Uzivatel.jmeno);
                        command.Parameters.AddWithValue("@prijmeni", Uzivatel.prijmeni);
                        command.Parameters.AddWithValue("@VM", Uzivatel.vychozi_VM);
                        command.Parameters.AddWithValue("@forma", Uzivatel.vychozi_forma);
                        command.Parameters.AddWithValue("@id", Uzivatel.osobni_cislo);
                        int cnt = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
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
