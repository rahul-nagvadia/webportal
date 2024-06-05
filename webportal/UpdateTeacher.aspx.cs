using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YourNamespace;

namespace webportal
{
    public partial class UpdateTeacher : System.Web.UI.Page
    {

        String connectionString = ConfigurationManager.ConnectionStrings["mydb"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
               
                LoadAvailableCourses();
            }
        }

        private void LoadAvailableCourses()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT CourseId, CourseName FROM Courses";
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ListItem courseItem = new ListItem(reader["CourseName"].ToString(), reader["CourseId"].ToString());
                    cblCourses.Items.Add(courseItem);
                }

                reader.Close();
                connection.Close();
            }
        }

        protected void getTeacherBtn_Click(object sender, EventArgs e)
        {
            String id = idTextBox.Text;
            IdLabel.Text = id;
          
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Teachers WHERE TeacherId=@teacherid";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@teacherid", id);

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtTeacherName.Text = reader["TeacherName"].ToString();
                    txtUsername.Text = reader["Username"].ToString();
                  
                }
                else
                {
                    lblWarning.Text = "Teacher WITH PROVIDED ID DOES NOT EXIST";
                }

                    reader.Close();
                connection.Close();
            }
        }

        protected void btnUpdateTeacher_Click(object sender, EventArgs e)
        {
            string TeacherId = IdLabel.Text;
            string TeacherName = txtTeacherName.Text;
            string Username = txtUsername.Text;

            // Get selected courses from the checkbox list
            List<int> selectedCourses = cblCourses.Items.Cast<ListItem>()
                                          .Where(item => item.Selected)
                                          .Select(item => int.Parse(item.Value))
                                          .ToList();

            // Update teacher information
            string updateTeacherQuery = "UPDATE Teachers SET TeacherName = @TeacherName, Username = @Username WHERE TeacherId = @TeacherId";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(updateTeacherQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@TeacherId", TeacherId);
                    cmd.Parameters.AddWithValue("@TeacherName", TeacherName);
                    cmd.Parameters.AddWithValue("@Username", Username);

                    connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Update teacher-course relationships in TeacherCourses table
                        string updateTeacherCoursesQuery = "DELETE FROM TeacherCourses WHERE TeacherId = @TeacherId";
                        SqlCommand deleteCmd = new SqlCommand(updateTeacherCoursesQuery, connection);
                        deleteCmd.Parameters.AddWithValue("@TeacherId", TeacherId);
                        deleteCmd.ExecuteNonQuery();

                        foreach (int courseId in selectedCourses)
                        {
                            string insertTeacherCourseQuery = "INSERT INTO TeacherCourses (TeacherId, CourseId) VALUES (@TeacherId, @CourseId)";
                            SqlCommand insertCmd = new SqlCommand(insertTeacherCourseQuery, connection);
                            insertCmd.Parameters.AddWithValue("@TeacherId", TeacherId);
                            insertCmd.Parameters.AddWithValue("@CourseId", courseId);
                            insertCmd.ExecuteNonQuery();
                        }

                        Response.Write("Teacher and associated courses updated successfully!");
                    }
                    else
                    {
                        Response.Write("No Teacher found with the provided ID.");
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
    }
}