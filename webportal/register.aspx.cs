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
    public partial class register : System.Web.UI.Page
    {
        
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string query = "SELECT DeptName FROM Department"; // Adjust the query as per your database schema

                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            connection.Open();
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string deptName = reader["DeptName"].ToString();
                                    ddlDeptName.Items.Add(new ListItem(deptName));
                                }
                            }
                        }
                    }

                    // Add a default item for selection
                    ddlDeptName.Items.Insert(0, new ListItem("Select Department", ""));
                }
            }
        

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            // Retrieve values from form fields
            string studentName = txtStudentName.Text;
            string username = txtUsername.Text;
            string dob = txtDOB.Text;
            string gender = ddlGender.SelectedValue;
            string mobile = txtMobile.Text;
            string email = txtEmail.Text;
            string address = txtAddress.Text;
            string deptName = ddlDeptName.SelectedValue;

            // Database connection string (replace with your database connection details)
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;

            try
            {
                // Create a connection
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Create a SQL command to insert data
                    string deptIdQuery = "SELECT DeptId FROM Department WHERE DeptName = @DeptName";
                    using (SqlCommand deptIdCmd = new SqlCommand(deptIdQuery, connection))
                    {
                        deptIdCmd.Parameters.AddWithValue("@DeptName", deptName);
                        int deptId = Convert.ToInt32(deptIdCmd.ExecuteScalar());
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO Student (StuName, Username, DOB, Gender, S_DeptId,  MobileNumber, EmailId, Address) VALUES (@StuName, @Username, @DOB, @Gender, @S_deptId,  @MobileNumber, @EmailId, @Address)", connection))
                    {
                        // Set parameter values from form fields
                        cmd.Parameters.AddWithValue("@StuName", studentName);
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@DOB", dob);
                        cmd.Parameters.AddWithValue("@Gender", gender);
                        cmd.Parameters.AddWithValue("@MobileNumber", mobile);
                        cmd.Parameters.AddWithValue("@EmailId", email);
                        cmd.Parameters.AddWithValue("@Address", address);
                        cmd.Parameters.AddWithValue("@S_DeptId", deptId);

                            // Execute the SQL command
                            cmd.ExecuteNonQuery();

                        // Redirect to a success page or display a confirmation message
                        Response.Redirect("AdminPage.aspx");
                    }
                }
                }
            }
            catch (Exception ex)
            {
                // Handle any database-related exceptions here
                // You can log the error, display a user-friendly message, etc.
                Response.Write("An error occurred: " + ex.Message);
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
    }
}