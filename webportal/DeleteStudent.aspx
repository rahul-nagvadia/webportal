<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeleteStudent.aspx.cs" Inherits="webportal.DeleteStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Delete Students</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
</head>
<body>
    <form id="form1" runat="server">
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
        <div class="container mt-4">
            <h2>Delete Students</h2>
            <div class="form-group">
                <asp:CheckBoxList runat="server" ID="chkStudents" CssClass="form-check">
                </asp:CheckBoxList>
            </div>
            <asp:Button runat="server" ID="btnDelete" Text="Delete Selected Students" CssClass="btn btn-danger" OnClick="btnDelete_Click" />
        </div>
    </form>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
</body>
</html>
