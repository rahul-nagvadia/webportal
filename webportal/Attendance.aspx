<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Attendance.aspx.cs" Inherits="webportal.Attendence" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Attendence</title>
    <style>
        /* Add some basic styling to the navigation bar */
        ul.navbar {
            list-style-type: none;
            padding: 0;
            margin: 0;
            background-color: #333;
            overflow: hidden;
        }
        
        ul.navbar li {
            float: left;
        }
        
        ul.navbar li a {
            display: block;
            color: white;
            text-align: center;
            padding: 14px 16px;
            text-decoration: none;
        }
        
        ul.navbar li a:hover {
            background-color: #555;
        }
        .active-link {
            color: aquamarine; /* You can apply any styling you want here */
            font-weight: bold;
            text-decoration: underline;
            background-color: blueviolet;
        }
        .logout {
            background-color: red;
        }
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <ul class="navbar">
            <li><a href="welcome.aspx">Home</a></li>
            <li><a href="ExamResults.aspx">Exam Results</a></li>
            <li><a href="Attendance.aspx" class="active-link">Attendance</a></li>
            <li><a href="FeeVoucher.aspx">Fee Voucher</a></li>
            <li><a href="login.aspx" class="logout">Logut</a></li>
        </ul>
        
    </form>
</body>
</html>