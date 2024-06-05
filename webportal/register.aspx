<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="webportal.register" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Registration</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
    <style>
        /* Custom CSS for additional styling */
        body {
            background-color: #f7f7f7;
        }
        
    </style>
</head>
<body>
    <form runat="server">
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
            
            
                
                    <h2>Register a Student</h2>
                
                <div class="card-body">
                    <div class="form-group">
                        <label for="txtStudentName">Student Name:</label>
                        <asp:TextBox ID="txtStudentName" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="txtUsername">Username:</label>
                        <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="txtDOB">Date of Birth:</label>
                        <asp:TextBox ID="txtDOB" runat="server" CssClass="form-control"></asp:TextBox>
                        <!-- You can use a calendar control for date input if desired. -->
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
                        <asp:Label runat="server" ID="lblDeptName" Text="Department Name:"></asp:Label>
                        <asp:DropDownList runat="server" ID="ddlDeptName" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label for="txtMobile">Mobile No:</label>
                        <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="txtEmail">Email:</label>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="txtAddress">Address:</label>
                        <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" CssClass="btn btn-primary" />
                    </div>
                </div>
            </div>
    </form>
</body>
</html>

