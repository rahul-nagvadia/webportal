<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="welcome.aspx.cs" Inherits="webportal.WebForm2" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Welcome</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
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
                        <a class="nav-link" href="ResultView.aspx">Exam Results</a>
                    </li>
                    <li class="nav-item">
                        <asp:Button runat="server" ID="btnLogout" Text="Logout" CssClass="btn btn-danger" OnClick="btnLogout_Click" />
                    </li>
                </ul>
            </div>
        </nav>

        <!-- Centered card for user information -->
        <div class="container mt-5">
            <div class="row justify-content-center">
                <div class="col-md-6">
                    <div class="card">
                        <div class="card-body">
                            <h1 class="card-title font-weight-bold">Student Information</h1>
                            <!-- Display user information here -->
                            <asp:Label runat="server" ID="lblStudentName"></asp:Label>
                            <br />
                            <asp:Label runat="server" ID="lblUsername"></asp:Label>
                            <br />
                            <asp:Label runat="server" ID="lblDateOfBirth"></asp:Label>
                            <br />
                            <asp:Label runat="server" ID="lblGender"></asp:Label>
                            <br />
                            <asp:Label runat="server" ID="lblDepartment"></asp:Label>
                            <br />
                            <asp:Label runat="server" ID="lblMobileNo"></asp:Label>
                            <br />
                            <asp:Label runat="server" ID="lblEmail"></asp:Label>
                            <br />
                            <asp:Label runat="server" ID="lblAddress"></asp:Label>
                        </div>
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
