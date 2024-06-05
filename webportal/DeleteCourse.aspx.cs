using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webportal
{
    public partial class DeleteCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Courses";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string CourseName = reader["CourseName"].ToString();
                            chkCourses.Items.Add(new ListItem(CourseName));
                        }
                    }
                }
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

        protected void btnHome_click(object sender, EventArgs e)
        {
            Response.Redirect("AdminPage.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                for (int i = 0; i < chkCourses.Items.Count; i++)
                {
                    if (chkCourses.Items[i].Selected)
                    {
                        string CourseName = chkCourses.Items[i].Text;
                        string deleteQuery = "DELETE FROM Courses WHERE CourseName = @CourseName";

                        using (SqlCommand cmd = new SqlCommand(deleteQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@CourseName", CourseName);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }

            Response.Redirect("AdminPage.aspx");
        }
    }
}