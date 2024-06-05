<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCourse.aspx.cs" Inherits="webportal.AddCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Course</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Add Course</h2>
            <asp:Label runat="server" ID="lblMessage" ForeColor="Red"></asp:Label>
            <br />
            <asp:Label runat="server" ID="lblCourseName" Text="Course Name:"></asp:Label>
            <asp:TextBox runat="server" ID="txtCourseName"></asp:TextBox>
            <br />
            <asp:Label runat="server" ID="lblDeptName" Text="Department Name:"></asp:Label>
            <asp:DropDownList runat="server" ID="ddlDeptName"></asp:DropDownList>
            <br />
            <asp:Label runat="server" ID="lblSemester" Text="Semester:"></asp:Label>
            <asp:DropDownList runat="server" ID="ddlSemester">
                <asp:ListItem Text="Select Semester" Value="" />
                <asp:ListItem Text="Semester 1" Value="1" />
                <asp:ListItem Text="Semester 2" Value="2" />
                <asp:ListItem Text="Semester 3" Value="3" />
                <asp:ListItem Text="Semester 4" Value="4" />
                <asp:ListItem Text="Semester 5" Value="5" />
                <asp:ListItem Text="Semester 6" Value="6" />
                <asp:ListItem Text="Semester 7" Value="7" />
                <asp:ListItem Text="Semester 8" Value="8" />
                
            </asp:DropDownList>
            <br />
            <asp:Label runat="server" ID="lblCredit" Text="Credit:"></asp:Label>
            <asp:TextBox runat="server" ID="txtCredit"></asp:TextBox>
            <br />
            <asp:Button runat="server" ID="btnAddCourse" Text="Add Course" OnClick="btnAddCourse_Click" />
        </div>
    </form>
</body>
</html>
