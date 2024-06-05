<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="webportal.AdminPage" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Page</title>
        <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />

    <style>
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">

            <nav class="navbar navbar-expand-lg navbar-dark bg-primary">
                <a class="navbar-brand" href="welcome.aspx">College Management System</a>
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarNav">
                    <ul class="navbar-nav ml-auto">
                         <li class="nav-item">
     <asp:Button runat="server" ID="homeButton" Text="Home" CssClass="btn" OnClick="btnHome_click" />
 </li>
                        <li class="nav-item">
                            <asp:Button runat="server" ID="btnLogout" Text="Logout" CssClass="btn btn-danger" OnClick="btnLogout_Click" />
                        </li>
                    </ul>
                </div>
            </nav>
            <h1>Admin Page</h1>

            <div class="row justify-content-center">
                <div class="col-4">
                    <asp:Button CssClass="btn btn-primary btn-lg btn-block mb-3" runat="server" ID="btnAddStudent" Text="Add Student" OnClick="btnAddStudent_Click" /><br />
                    <asp:Button CssClass="btn btn-primary btn-lg btn-block mb-3" runat="server" ID="btnAddTeacher" Text="Add Teacher" OnClick="btnAddTeacher_Click" /><br />
                    <asp:Button CssClass="btn btn-primary btn-lg btn-block mb-3" runat="server" ID="btnAddCourse" Text="Add Course" OnClick="btnAddCourse_Click" /><br />
                </div>

                <div class="col-4">


                    <asp:Button CssClass="btn btn-primary btn-lg btn-block mb-3" runat="server" ID="btnUpdateStudent" Text="Update Student" OnClick="btnUpdateStudent_Click" /><br />
                    <asp:Button CssClass="btn btn-primary btn-lg btn-block mb-3" runat="server" ID="btnUpdateTeacher" Text="Update Teacher" OnClick="btnUpdateTeacher_Click" /><br />
                    <asp:Button CssClass="btn btn-primary btn-lg btn-block mb-3" runat="server" ID="btnUpdateCourse" Text="Update Course" OnClick="btnUpdateCourse_Click" /><br />
                </div>

                <div class="col-4">

                    <asp:Button CssClass="btn btn-primary btn-lg btn-block mb-3" runat="server" ID="btnDeleteStudent" Text="Delete Student" OnClick="btnDeleteStudent_Click" /><br />
                    <asp:Button CssClass="btn btn-primary btn-lg btn-block mb-3" runat="server" ID="btnDeleteTeacher" Text="Delete Teacher" OnClick="btnDeleteTeacher_Click" /><br />
                    <asp:Button CssClass="btn btn-primary btn-lg btn-block mb-3" runat="server" ID="btnDeleteCourse" Text="Delete Course" OnClick="btnDeleteCourse_Click" /><br />
                </div>

                <div class="col-4">

    <asp:Button CssClass="btn btn-primary btn-lg btn-block mb-3" runat="server" ID="addMarks" Text="Add Marks" OnClick="btnAddMarks_click" /><br />
    <asp:Button CssClass="btn btn-primary btn-lg btn-block mb-3" runat="server" ID="updateMarks" Text="Update Marks" OnClick="btnUpdateMarks_click" /><br />
   
</div>

            </div>
        </div>
    </form>
</body>
</html>
