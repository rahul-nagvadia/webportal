
4<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddMarks.aspx.cs" Inherits="webportal.AddMarks" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Marks</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Add Marks</h2>
               
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
            <asp:Label runat="server" ID="lblStudentID" Text="Student ID:"></asp:Label>
<asp:TextBox runat="server" ID="txtStudentID"></asp:TextBox>

    <br />
    <div id="marksContainer" runat="server" class="marks-container">
</div>

   <asp:Repeater ID="rptCourses" runat="server">
    <ItemTemplate>
        <asp:Label runat="server" ID="lblCourseName" Text='<%# Eval("CourseName") %>'></asp:Label>
        <br />
        Sessional 1: <asp:TextBox runat="server" ID="txtSessional1" CssClass="sessional" /><br />
        Sessional 2: <asp:TextBox runat="server" ID="txtSessional2" CssClass="sessional" /><br />
        Sessional 3: <asp:TextBox runat="server" ID="txtSessional3" CssClass="sessional" /><br />
    </ItemTemplate>
</asp:Repeater>




            <asp:Button ID="btnSubmit" runat="server" Text="Get Courses For This Semester" OnClick="btnSubmit_Click" />
            <asp:Button ID="btnSubmitMarks" runat="server" Text="Submit" OnClick="btnSubmitMarks_Click" />
        </div>
    </form>
</body>
</html>
