<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddTeacher.aspx.cs" Inherits="YourNamespace.Teachers" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Teacher and Course Management</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Teacher and Course Management</h1>

            <label for="txtTeacherName">Teacher Name:</label>
            <asp:TextBox ID="txtTeacherName" runat="server"></asp:TextBox><br />

            <label for="txtUsername">Username:</label>
            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox><br />

            <label for="txtPassword">Password:</label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox><br />

            <h2>Select Courses:</h2>
            <asp:CheckBoxList ID="cblCourses" runat="server" RepeatDirection="Vertical"></asp:CheckBoxList><br />

            <asp:Button ID="btnAddTeacher" runat="server" Text="Add Teacher" OnClick="btnAddTeacher_Click" />
        </div>
    </form>
</body>
</html>