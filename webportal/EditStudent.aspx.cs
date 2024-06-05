using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webportal
{
    public partial class EditStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check if the StuId query parameter is provided
                if (Request.QueryString["StuId"] != null)
                {
                    int studentId = int.Parse(Request.QueryString["StuId"]);

                    // Retrieve student details from the database using the studentId
                    // Populate the textboxes with the retrieved values
                    LoadStudentDetails(studentId);
                }
                else
                {
                    // Handle the case where StuId is not provided in the query string
                    Response.Redirect("YourPage.aspx"); // Redirect to the student list page
                }
            }
        }

        private void LoadStudentDetails(int studentId)
        {
            // Retrieve student details from the database using studentId
            using (SqlConnection conn = new SqlConnection("mydb"))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT [StuName], [Username], [DOB], [Gender], [MobileNumber], [EmailId], [Address] FROM [Student] WHERE [StuId] = @StudentId", conn))
                {
                    cmd.Parameters.AddWithValue("@StudentId", studentId);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        hfStudentId.Value = studentId.ToString();
                        txtStuName.Text = reader["StuName"].ToString();
                        txtUsername.Text = reader["Username"].ToString();
                        // Populate other fields as needed
                    }
                    else
                    {
                        // Handle the case where the student with the given ID is not found
                        Response.Redirect("YourPage.aspx"); // Redirect to the student list page
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // Update student details in the database based on user input
            int studentId = int.Parse(hfStudentId.Value);
            string stuName = txtStuName.Text;
            string username = txtUsername.Text;
            // Get other field values as needed

            using (SqlConnection conn = new SqlConnection("mydb"))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE [Student] SET [StuName] = @StuName, [Username] = @Username WHERE [StuId] = @StudentId", conn))
                {
                    cmd.Parameters.AddWithValue("@StudentId", studentId);
                    cmd.Parameters.AddWithValue("@StuName", stuName);
                    cmd.Parameters.AddWithValue("@Username", username);
                    // Add parameters for other fields and their values

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Successfully updated the student's information
                        Response.Redirect("YourPage.aspx"); // Redirect to the student list page
                    }
                    else
                    {
                        // Handle the case where the update was not successful
                        // You can display an error message or take appropriate action
                    }
                }
            }
        }
    }
}