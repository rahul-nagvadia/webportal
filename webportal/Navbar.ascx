<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Navbar.ascx.cs" Inherits="webportal.WebUserControl1" %>
<nav class="navbar navbar-expand-lg navbar-dark bg-primary">
    <a class="navbar-brand" href="welcome.aspx">College Management System</a>
    <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarNav">
        <ul class="navbar-nav ml-auto">
             <li class="nav-item">
            <a class="nav-link" href="welcome.aspx">Home</a>
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