<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Evaluation.aspx.cs" Inherits="WebApplication1.Evaluation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Evaluation</title>
    <link href="Style.css" rel="stylesheet" />
    <script>
        function openNav() {
            document.getElementById("mySidenav").style.width = "250px";
            document.getElementById("main").style.marginLeft = "250px";
        }
        function closeNav() {
            document.getElementById("mySidenav").style.width = "0";
            document.getElementById("main").style.marginLeft = "0";
        }
    </script>
    <style type="text/css">
        .auto-style1 {
            height: 23px;
        }
        .auto-style2 {
            width: 80%;
        }
        .auto-style3 {
            width: 914px;
        }
        .auto-style4 {
            width: 98px;
        }
        .auto-style5 {
            width: 102px;
        }
        .auto-style6 {
            width: 914px;
            text-align: left;
        }
        .auto-style7 {
            width: 914px;
            height: 24px;
        }
        .auto-style8 {
            width: 102px;
            height: 24px;
        }
        .auto-style9 {
            width: 98px;
            height: 24px;
        }
        .auto-style10 {
            height: 24px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="mySidenav" class="sidenav">
          <p>Welcome, username.</p>
          <a href="javascript:void(0)" class="closebtn" onclick="closeNav()">&times;</a>
          <a href="Welcome.aspx">About</a>
          <a href="Agreement.aspx">Agreement</a>
          <a class="active">Evaluation</a>
          <a href="#">Settings</a>
          <a href="LogIn.aspx">Sign Out</a> 
        </div>
        <div id="main">
            <span class="menu" onclick="openNav()">+</span>
            <center>
            <a href="EvaluationFaculty.aspx">Faculty Members</a>
            <a href="EvaluationOfficers.aspx">Officers</a>
            <a href="EvaluationStaff.aspx">Staff</a>
            </center>
        </div>
        </div>
        <center>
            <table>
                <thead>
                    <tr>
                        <th>Staff</th>
                        <th>Faculty Member</th>
                        <th>Officer</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>
                            <asp:Button runat="server" ID="staff" OnClick="StaffClicked" Text="Reese Ramos" Enabled="False" ></asp:Button>
                        </td>
                        <td>Aaron Cabueñas</td>
                        <td>Jerome Mendoza</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button runat="server" ID="staff2" OnClick="StaffClicked" Text="Reese Ramos2" Enabled="False" ></asp:Button>
                        </td>
                        <td>Aaron Cabueñas</td>
                        <td>Jerome Mendoza</td>
                    </tr>
                </tbody>
            </table>
        </center>
    </form>
</body>
</html>
