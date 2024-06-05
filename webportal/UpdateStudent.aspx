<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateStudent.aspx.cs" Inherits="webportal.UpdateStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Details</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">

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
            <asp:Label ID="lblWarning" runat="server" ForeColor="Red" CssClass="mb-3"></asp:Label>

            <div class="form-group">
                <label for="idText">Enter ID of Student For Which Updation Is Required</label>
                <div class="input-group mb-3">
                    <asp:TextBox ID="idText" runat="server" CssClass="form-control"></asp:TextBox>
                    <div class="input-group-append">
                        <asp:Button ID="submitBtn" runat="server" OnClick="submitBtn_click" Text="Submit" CssClass="btn btn-primary" />
                    </div>
                </div>
            </div>

            <h1>Update Student</h1>
            <hr class="my-4" />

            <div class="form-group">
                <label for="txtStuName">Student Name:</label>
                <asp:TextBox ID="txtStuName" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="idBox">Student ID:</label>
                <asp:TextBox ID="idBox" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="txtUsername">Username:</label>
                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="txtDOB">Date of Birth:</label>
                <asp:TextBox ID="txtDOB" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="ddlGender">Gender:</label>
                <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-control">
                    <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                    <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                    <asp:ListItem Text="Other" Value="Other"></asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="form-group">
                <label for="ddlDeptName">Department Name:</label>
                <asp:DropDownList ID="ddlDeptName" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>

            <div class="form-group">
                <label for="txtMobileNumber">Mobile Number:</label>
                <asp:TextBox ID="txtMobileNumber" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="txtEmail">Email ID:</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="txtAddress">Address:</label>
                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="txtSemester">Semester:</label>
                <asp:TextBox ID="txtSemester" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <asp:Button ID="btnSubmit" runat="server" Text="Update Student" OnClick="btnUpdate_Click" CssClass="btn btn-primary mb-3" />
        </div>
    </form>

    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.9.2/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
