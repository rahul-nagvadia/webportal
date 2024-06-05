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
    public partial class DeleteStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadStudents();
            }
        }

        protected void LoadStudents()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Student";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string StuName = reader["StuName"].ToString();
                            chkStudents.Items.Add(new ListItem(StuName));
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

        protected int getStudentId(string studentName)
        {
            int studentId = 0;
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            string selectQuery = "SELECT StuId from STUDENT WHERE StuName=@StuName";

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();
            using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
            {
                cmd.Parameters.AddWithValue("@StuName", studentName);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                   
                    if (rdr.HasRows)
                    { 
                        rdr.Read();
                        studentId = rdr.GetInt32(rdr.GetOrdinal("StuId"));
                    }
                }
            }

            return studentId;


        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                for (int i = 0; i < chkStudents.Items.Count; i++)
                {
                    if (chkStudents.Items[i].Selected)
                    {
                        string studentName = chkStudents.Items[i].Text;

                        int stuId = getStudentId(studentName);
                        string deleteQuery = "DELETE FROM Student WHERE StuId = @StuId";

                        using (SqlCommand cmd = new SqlCommand(deleteQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@StuId", stuId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }

            Response.Redirect("AdminPage.aspx");
        }


    }

   
}