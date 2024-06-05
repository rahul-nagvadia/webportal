<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateTeacher.aspx.cs" Inherits="webportal.UpdateTeacher" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
    <asp:Button runat="server" ID="homeButton" Text="Home" CssClass="btn" OnClick="btnHome_click" />
</li>
                       <li class="nav-item">
                           <asp:Button runat="server" ID="btnLogout" Text="Logout" CssClass="btn btn-danger" OnClick="btnLogout_Click" />
                       </li>
                   </ul>
               </div>
           </nav>
        <div>

            <asp:Label ID="Label1" runat="server" Text="Provide Id Of The Teacher For Which Updation Is Required"></asp:Label>
            <br />
            <br />
            <asp:Label ID="idText" runat="server" Text="Id"></asp:Label>
&nbsp;&nbsp;
            <asp:TextBox ID="idTextBox" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="getTeacherBtn" runat="server" Text="Get Teachers" OnClick="getTeacherBtn_Click" />
            <br />
            <br />

        </div>

         <div>
            <h2>Update Teacher</h2>
            <asp:Label ID="lblWarning" runat="server" ForeColor="Green" EnableViewState="False"></asp:Label>
            <br />

             <asp:Label ID="IdLabel" runat="server"></asp:Label>

             <br />

             <asp:Label ID="teacherNameLabel" runat="server">Teacher Name </asp:Label>

            <asp:TextBox ID="txtTeacherName" runat="server" placeholder="Teacher Name"></asp:TextBox>
            <br />

             <asp:Label ID="teacherUsernameLabel" runat="server">UserName </asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtUsername" runat="server" placeholder="Username"></asp:TextBox>
            <br />

 
             <h2>Select Courses:</h2>
             <asp:CheckBoxList ID="cblCourses" runat="server" RepeatDirection="Vertical"></asp:CheckBoxList><br />

             <br />
            <asp:Button ID="btnUpdateTeacher" runat="server" Text="Update Teacher" OnClick="btnUpdateTeacher_Click" />
        </div>
    </form>
</body>
</html>
