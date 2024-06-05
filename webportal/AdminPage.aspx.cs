using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webportal
{
    public partial class AdminPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddStudent_Click(object sender, EventArgs e)
        {
            Response.Redirect("register.aspx");
        }

        protected void btnCreateStudent_Click(object sender, EventArgs e)
        {

        }

        protected void btnUpdateStudent_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateStudent.aspx");
        }

        protected void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            Response.Redirect("DeleteStudent.aspx");
        }

        protected void btnAddTeacher_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddTeacher.aspx");
        }

        protected void btnCreateTeacher_Click(object sender, EventArgs e)
        {

        }

        protected void btnUpdateTeacher_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateTeacher.aspx");
        }

        protected void btnDeleteTeacher_Click(object sender, EventArgs e)
        {

        }

        protected void btnAddCourse_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddCourse.aspx");
        }

        protected void btnCreateCourse_Click(object sender, EventArgs e)
        {

        }

        protected void btnUpdateCourse_Click(object sender, EventArgs e)
        {

        }

        protected void btnDeleteCourse_Click(object sender, EventArgs e)
        {
            Response.Redirect("DeleteCourse.aspx");
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

        protected void btnAddMarks_click(object sender, EventArgs e)
        {
            Response.Redirect("AddMarks.aspx");
        }

        protected void btnUpdateMarks_click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateMarks.aspx");
        }
    }
}