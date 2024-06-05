using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webportal
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnLogout.Visible = false;
            HttpCookie authCookie = Request.Cookies["AuthCookie"];

            if (authCookie != null)
            {
                btnLogout.Visible = true;
                Response.Redirect("welcome.aspx");
            }

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string enteredUsername = txtUsername.Text;
            string enteredPassword = txtPassword.Text;

            // Initialize a variable to track if the login is valid
            bool isValidLogin = false;

            // Define the database connection string
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Perform database query to validate the credentials
                    if (IsValidUser(connection, enteredUsername, enteredPassword))
                    {
                        // Set the flag to indicate a valid login
                        isValidLogin = true;

                        // Create an authentication cookie
                        HttpCookie authCookie = new HttpCookie("AuthCookie");
                        authCookie.Values["username"] = enteredUsername;
                        Response.Cookies.Add(authCookie);

                        // Redirect to a welcome page upon successful login
                        Response.Redirect("welcome.aspx");
                    }
                    else
                    {
                        // Display an error message to the user
                        Response.Write("Invalid username or password. Please try again.");
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions here, if needed
                    Response.Write("An error occurred: " + ex.Message);
                }
                finally
                {
                    // Close the database connection in the finally block to ensure it's always closed
                    if (connection.State != System.Data.ConnectionState.Closed)
                    {
                        connection.Close();
                    }
                }
            }

            // If the login is not valid, you can handle it here
            if (!isValidLogin)
            {
                // Handle the case where the login is not valid
            }
        }

        private bool IsValidUser(SqlConnection connection, string username, string password)
        {
            // Replace this with your actual database query and validation logic
            // It's recommended to use hashed passwords and prepared statements for security.

            string query = "SELECT * FROM Student WHERE Username = @Username AND DOB = @DOB";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@DOB", password);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    // Check if a matching record was found in the database
                    return reader.HasRows;
                }
            }
        }

        private bool IsAdminValidUser(SqlConnection connection, string username, string password)
        {

            string query = "SELECT * FROM Admin WHERE Username = @Username AND Password = @Password";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    return reader.HasRows;
                }
            }
        }

        protected void btnAdminLogin_Click(object sender, EventArgs e)
        {
            string enteredUsername = txtUsername.Text;
            string enteredPassword = txtPassword.Text;

            // Initialize a variable to track if the login is valid
            bool isValidLogin = false;

            // Define the database connection string
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Perform database query to validate the credentials
                    if (IsAdminValidUser(connection, enteredUsername, enteredPassword))
                    {
                        isValidLogin = true;

                     
                        HttpCookie authCookie = new HttpCookie("AuthCookie");
                        authCookie.Values["username"] = enteredUsername;
                        authCookie.Values["isAdmin"] = "yes";
                        Response.Cookies.Add(authCookie);

                        Response.Redirect("AdminPage.aspx");
                    }
                    else
                    {
                        // Display an error message to the user
                        Response.Write("Invalid username or password. Please try again.");
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions here, if needed
                    Response.Write("An error occurred: " + ex.Message);
                }
                finally
                {
                    // Close the database connection in the finally block to ensure it's always closed
                    if (connection.State != System.Data.ConnectionState.Closed)
                    {
                        connection.Close();
                    }
                }
            }

            // If the login is not valid, you can handle it here
            if (!isValidLogin)
            {
                // Handle the case where the login is not valid
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
