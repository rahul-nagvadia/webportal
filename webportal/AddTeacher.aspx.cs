using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YourNamespace
{
    public partial class Teachers : Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Load available courses into the CheckBoxList (cblCourses)
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
            }
        }

        protected void btnAddTeacher_Click(object sender, EventArgs e)
        {
            // Add a new teacher to the database and associate selected courses
            string teacherName = txtTeacherName.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Insert teacher details into the Teachers table
                string insertTeacherQuery = "INSERT INTO Teachers (TeacherName, Username, Password) VALUES (@TeacherName, @Username, @Password); SELECT SCOPE_IDENTITY();";
                SqlCommand insertTeacherCmd = new SqlCommand(insertTeacherQuery, connection);
                insertTeacherCmd.Parameters.AddWithValue("@TeacherName", teacherName);
                insertTeacherCmd.Parameters.AddWithValue("@Username", username);
                insertTeacherCmd.Parameters.AddWithValue("@Password", password);

                int teacherId = Convert.ToInt32(insertTeacherCmd.ExecuteScalar());

                // Associate selected courses with the teacher in the TeacherCourses table
                foreach (ListItem item in cblCourses.Items)
                {
                    if (item.Selected)
                    {
                        int courseId = Convert.ToInt32(item.Value);

                        string insertTeacherCourseQuery = "INSERT INTO TeacherCourses (TeacherId, CourseId) VALUES (@TeacherId, @CourseId)";
                        SqlCommand insertTeacherCourseCmd = new SqlCommand(insertTeacherCourseQuery, connection);
                        insertTeacherCourseCmd.Parameters.AddWithValue("@TeacherId", teacherId);
                        insertTeacherCourseCmd.Parameters.AddWithValue("@CourseId", courseId);
                        insertTeacherCourseCmd.ExecuteNonQuery();
                    }
                }

                connection.Close();

                // Clear input fields and selected courses
                txtTeacherName.Text = string.Empty;
                txtUsername.Text = string.Empty;
                txtPassword.Text = string.Empty;
                ClearCheckBoxListSelection(cblCourses);
            }
        }

        private void ClearCheckBoxListSelection(CheckBoxList checkBoxList)
        {
            foreach (ListItem item in checkBoxList.Items)
            {
                item.Selected = false;
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