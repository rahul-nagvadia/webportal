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
    public partial class AddMarks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT DeptName FROM Department"; 

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

                
                ddlDeptName.Items.Insert(0, new ListItem("Select Department", ""));
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            
            string selectedDepartment = ddlDeptName.SelectedValue;
            int selectedSemester = int.Parse(ddlSemester.SelectedValue);


            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT CourseName FROM Courses WHERE C_DeptId = (SELECT DeptId FROM Department WHERE DeptName = @DeptName) AND Semester = @Semester";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@DeptName", selectedDepartment);
                    cmd.Parameters.AddWithValue("@Semester", selectedSemester);

                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        rptCourses.DataSource = reader;
                        rptCourses.DataBind();
                    }
                }
            }
        }


        protected void btnSubmitMarks_Click(object sender, EventArgs e)
        {
            foreach(RepeaterItem item in rptCourses.Items)
    {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                  
                    Label lblCourseName = (Label)item.FindControl("lblCourseName");
                    TextBox txtSessional1 = (TextBox)item.FindControl("txtSessional1");
                    TextBox txtSessional2 = (TextBox)item.FindControl("txtSessional2");
                    TextBox txtSessional3 = (TextBox)item.FindControl("txtSessional3");

                  
                    string courseName = lblCourseName.Text;
                    int sessional1 = int.Parse(txtSessional1.Text);
                    int sessional2 = int.Parse(txtSessional2.Text);
                    int sessional3 = int.Parse(txtSessional3.Text);


                    string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string query = "INSERT INTO Exams (SId, CourseName, Sessional1, Sessional2, Sessional3) VALUES (@SId, @CourseName, @Sessional1, @Sessional2, @Sessional3)";

                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            int studentId;
                            if (int.TryParse(txtStudentID.Text, out studentId))
                            {
                  
                            }

                            cmd.Parameters.AddWithValue("@SId", studentId);
                            cmd.Parameters.AddWithValue("@CourseName", courseName);
                            cmd.Parameters.AddWithValue("@Sessional1", sessional1);
                            cmd.Parameters.AddWithValue("@Sessional2", sessional2);
                            cmd.Parameters.AddWithValue("@Sessional3", sessional3);

                            connection.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            Response.Redirect("welcome.aspx");
        }
    }
}