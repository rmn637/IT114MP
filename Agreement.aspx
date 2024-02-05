<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Agreement.aspx.cs" Inherits="WebApplication1.Agreement" %>

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
            width: 100%;
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="mySidenav" class="sidenav">
          <p>Welcome, username.</p>
          <a href="javascript:void(0)" class="closebtn" onclick="closeNav()">&times;</a>
          <a href="Welcome.aspx">About</a>
          <a class="active">Agreement</a>
          <a href="Evaluation.aspx">Evaluation</a>
          <a href="#">Settings</a>
          <a href="LogIn.aspx">Sign Out</a> 
        </div>
        <div id="main">
            <span class="menu" onclick="openNav()">+</span>
            <center>
            <a href="AgreementFaculty.aspx">Faculty Members</a>
            <a href="AgreementOfficers.aspx">Officers</a>
            <a href="AgreementStaff.aspx">Staff</a>
            </center>
       
        </div>
        
    </form>
</body>
</html>