<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResultView.aspx.cs" Inherits="webportal.ResultView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
</head>
<body>
     

    <form id="form1" runat="server" class="container mt-5">

            <nav class="navbar navbar-expand-lg navbar-dark bg-primary">
    <a class="navbar-brand" href="welcome.aspx">College Management System</a>
    <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarNav">
        <ul class="navbar-nav ml-auto">
            <li class="nav-item">
    <a class="nav-link" href="welcome.aspx">My Profile</a>
</li>
            <li class="nav-item">
                <a class="nav-link" href="ResultView.aspx">Exam Results</a>
            </li>
            <li class="nav-item">
                <asp:Button runat="server" ID="btnLogout" Text="Logout" CssClass="btn btn-danger" OnClick="btnLogout_Click" />
            </li>
        </ul>
    </div>
</nav>
        <div class="row">
            <div class="col-md-6">
                <div class="card">
                    <div class="card-header">
                        Student Details
                    </div>
                    <div class="card-body">
                        <asp:Label ID="lblStudentDetails" runat="server" CssClass="card-text"></asp:Label>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="card">
                    <div class="card-header">
                        Result
                    </div>
                    <div class="card-body">
                        <asp:Label ID="lblResult" runat="server" CssClass="card-text"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </form>

    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.9.2/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
