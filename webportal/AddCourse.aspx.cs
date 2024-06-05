using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Net;
using System.Reflection;
using System.Configuration;

namespace webportal
{
    public partial class AddCourse : System.Web.UI.Page
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

        protected void btnAddCourse_Click(object sender, EventArgs e)
        {
            string courseName = txtCourseName.Text;
            string deptName = ddlDeptName.SelectedValue;
            string semesterValue = ddlSemester.SelectedValue;
            string credit = txtCredit.Text;

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;

                // Create a connection
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Create a SQL command to retrieve the DeptId based on DeptName
                    string deptIdQuery = "SELECT DeptId FROM Department WHERE DeptName = @DeptName";
                    using (SqlCommand deptIdCmd = new SqlCommand(deptIdQuery, connection))
                    {
                        deptIdCmd.Parameters.AddWithValue("@DeptName", deptName);
                        int deptId = Convert.ToInt32(deptIdCmd.ExecuteScalar());

                        // Convert semesterValue to an integer using int.Parse or int.TryParse
                        int semester;
                        if (int.TryParse(semesterValue, out semester))
                        {
                            // Create a SQL command to insert data into the Courses table
                            using (SqlCommand cmd = new SqlCommand("INSERT INTO Courses (CourseName, C_DeptId, Semester, Credit) VALUES (@CourseName, @DeptId, @Semester, @Credit)", connection))
                            {
                                // Set parameter values from form fields
                                cmd.Parameters.AddWithValue("@CourseName", courseName);
                                cmd.Parameters.AddWithValue("@DeptId", deptId);
                                cmd.Parameters.AddWithValue("@Semester", semester);
                                cmd.Parameters.AddWithValue("@Credit", credit);

                                // Execute the SQL command
                                cmd.ExecuteNonQuery();

                                // Redirect to a success page or display a confirmation message
                                Response.Redirect("AdminPage.aspx");
                            }
                        }
                        else
                        {
                            // Handle the case where semesterValue cannot be parsed as an integer
                            lblMessage.Text = "Invalid semester value selected.";
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

            lblMessage.Text = "Course added successfully.";
        }
    }
}
