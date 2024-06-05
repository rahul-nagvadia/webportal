using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Principal;
using System.Web;

namespace webportal
{
    public partial class UpdateStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            String query = "SELECT DeptName FROM Department";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {

                    connection.Open();

                    using (SqlCommand newcmd = new SqlCommand(query, connection))
                    {

                        using (SqlDataReader reader1 = newcmd.ExecuteReader())
                        {
                            while (reader1.Read())
                            {
                                string deptName = reader1["DeptName"].ToString();
                                ddlDeptName.Items.Add(new ListItem(deptName));
                            }
                        }
                    }
                }
            }
           
            ddlDeptName.Items.Insert(0, new ListItem("Select Department", ""));
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
                   }

        private int GetDeptId(string deptName)
        {
            int deptId = 0;

            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            string query = "SELECT DeptId FROM Department WHERE DeptName = @DeptName";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@DeptName", deptName);
                    connection.Open();

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        deptId = Convert.ToInt32(result);
                    }
                }
            }

            return deptId;
        }

        protected void submitBtn_click(object sender, EventArgs e)
        {
            String stuId = idText.Text;
            idBox.Text = stuId;
            idBox.Enabled = false;

            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            string query = "SELECT * FROM Student WHERE StuId = @StuId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@StuId", stuId);
                    connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        txtStuName.Text = reader["StuName"].ToString();
                        txtUsername.Text = reader["Username"].ToString();
                        txtDOB.Text = reader["DOB"].ToString();
                        txtMobileNumber.Text = reader["MobileNumber"].ToString();
                        txtEmail.Text = reader["EmailId"].ToString();
                        txtAddress.Text = reader["Address"].ToString();
                        lblWarning.Text = "";
                    }
                    else
                    {
                        lblWarning.Text = "STUDENT WITH PROVIDED ID DOES NOT EXIST";

                    }
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string stuId = idText.Text;
            string stuName = txtStuName.Text;
            string username = txtUsername.Text;
            string dob = txtDOB.Text;
            string gender = ddlGender.SelectedValue;
            int deptId = GetDeptId(ddlDeptName.SelectedValue);
            string mobileNumber = txtMobileNumber.Text;
            string email = txtEmail.Text;
            string address = txtAddress.Text;
            string semester = txtSemester.Text;

            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            string query = "UPDATE Student SET StuName = @StuName, Username = @Username, DOB = @DOB, Gender = @Gender, S_DeptId = @DeptId, MobileNumber = @MobileNumber, EmailId = @Email, Address = @Address, Semester = @Semester WHERE StuId = @StuId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@StuId", stuId);
                    cmd.Parameters.AddWithValue("@StuName", stuName);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@DOB", dob);
                    cmd.Parameters.AddWithValue("@Gender", gender);
                    cmd.Parameters.AddWithValue("@DeptId", deptId);
                    cmd.Parameters.AddWithValue("@MobileNumber", mobileNumber);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@Semester", semester);

                    connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Response.Write("Student updated successfully!");
                    }
                    else
                    {
                        // Handle the case when no student is found with the provided ID
                        Response.Write("No student found with the provided ID.");
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
