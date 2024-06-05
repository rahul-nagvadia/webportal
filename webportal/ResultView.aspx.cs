using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;

namespace webportal
{
    public partial class ResultView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies["AuthCookie"];

            if (authCookie != null)
            {
                string username = authCookie.Values["username"];
                string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
                string studentQuery = "SELECT s.*, d.DeptName " +
                                      "FROM Student s " +
                                      "LEFT JOIN Department d ON s.S_DeptId = d.DeptId " +
                                      "WHERE s.Username = @Username";
                string examQuery = "SELECT * FROM EXAMS WHERE SId = (SELECT StuId FROM Student WHERE Username = @Username)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Retrieve student information along with department name
                    using (SqlCommand studentCmd = new SqlCommand(studentQuery, connection))
                    {
                        studentCmd.Parameters.AddWithValue("@Username", username);

                        using (SqlDataReader studentReader = studentCmd.ExecuteReader())
                        {
                            if (studentReader.HasRows && studentReader.Read())
                            {
                                string studentName = studentReader["StuName"].ToString();
                                string studentId = studentReader["StuId"].ToString();
                                string departmentName = studentReader["DeptName"].ToString(); // Department name

                                // Display student details
                                lblStudentDetails.Text = $"<p>Student Name: {studentName}</p>" +
                                                         $"<p>Student ID: {studentId}</p>" +
                                                         $"<p>Department Name: {departmentName}</p>";
                            }
                            else
                            {
                                lblStudentDetails.Text = "Student details not found.";
                            }
                        }
                    }

                    // Retrieve exam results and create the table
                    using (SqlCommand cmd = new SqlCommand(examQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                lblResult.Text = "<table border='1'>";

                                lblResult.Text += "<tr><th>Course Name</th><th>Exam ID</th><th>Student ID</th><th>Sessional 1</th><th>Sessional 2</th><th>Sessional 3</th></tr>";

                                while (reader.Read())
                                {
                                    string courseName = reader["CourseName"].ToString();
                                    int examId = (int)reader["ExamId"];
                                    int sId = (int)reader["SId"];
                                    int sessional1 = (int)reader["Sessional1"];
                                    int sessional2 = (int)reader["Sessional2"];
                                    int sessional3 = (int)reader["Sessional3"];

                                    lblResult.Text += $"<tr><td>{courseName}</td><td>{examId}</td><td>{sId}</td><td>{sessional1}</td><td>{sessional2}</td><td>{sessional3}</td></tr>";
                                }

                                lblResult.Text += "</table>";
                            }
                            else
                            {
                                lblResult.Text = "No exam results found for this student.";
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
