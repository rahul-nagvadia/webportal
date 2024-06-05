<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditStudent.aspx.cs" Inherits="webportal.EditStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit Student</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Edit Student Details</h1>

            <asp:HiddenField ID="hfStudentId" runat="server" />
            <asp:TextBox ID="txtStuName" runat="server" CssClass="form-control" />
            <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" />
            <!-- Add more fields as needed -->

            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
        </div>
    </form>
</body>
</html>
