using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;

namespace webportal
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { 
            HttpCookie authCookie = Request.Cookies["AuthCookie"];

            if (authCookie != null)
            {
                string username = authCookie.Values["username"];
                string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
                string query = "SELECT * FROM Student WHERE Username = @Username";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows && reader.Read())
                            {
                                lblStudentName.Text = "Student Name: " + reader["StuName"].ToString();
                                lblUsername.Text = "Username: " + reader["Username"].ToString();
                                lblDateOfBirth.Text = "Date of Birth: " + reader["DOB"].ToString();
                                lblGender.Text = "Gender: " + reader["Gender"].ToString();                        
                                lblMobileNo.Text = "Mobile No.: " + reader["MobileNumber"].ToString();
                                lblEmail.Text = "Email: " + reader["EmailId"].ToString();
                                lblAddress.Text = "Address: " + reader["Address"].ToString();
                            }
                            else
                            {
                            }
                        }
                    }
                }
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies["AuthCookie"];
            if (authCookie != null)
            {
                authCookie.Expires = DateTime.Now.AddDays(-1); 
                Response.Cookies.Add(authCookie); 
            }

            Response.Redirect("login.aspx");
        }
    }
}
