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
            <h2>Performance Evaluation Survey Agreement</h2>
                <table>
                    <tr id="trbc">
                        <td>Name of Employee</td>
                        <td>Position</td>
                        <td>College/Department</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr id="trbc">
                        <td class="auto-style1">Name of Rater</td>
                        <td class="auto-style1">Appraisal Period</td>
                        <td class="auto-style1">Date Prepared</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
                </center>
            <br />
            <center>
            <p> Question1</p>
            <p> Weight: </p>
            <asp:RadioButtonList ID="question1" runat="server" RepeatDirection="Horizontal" Width="47px">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
            </asp:RadioButtonList>
                <br />
            
                <br />
                <br />
            <div id ="section1A">
                <table class="auto-style2">
                    <tr>
                        <td colspan="4">Section 1-A: ACADEMIC PERFORMANCE</td>
                    </tr>
                    <tr>
                        <td class="auto-style3">&nbsp;</td>
                        <td class="auto-style5">W</td>
                        <td class="auto-style4">R</td>
                        <td>WS</td>
                    </tr>
                    <tr>
                        <td class="auto-style6">A.&nbsp; Faculty Evaluation by Students</td>
                        <td class="auto-style5">
                            <asp:TextBox ID="weight1_A" runat="server" AutoPostBack="True" Height="18px" OnTextChanged="weight1A_TextChanged" TextMode="Number" Width="106px">0</asp:TextBox>
                        </td>
                        <td class="auto-style4">
                            0</td>
                        <td>
                            <asp:Label ID="label1_A" runat="server" Text="0"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style6">B. Classroom Teaching Observation by Peers</td>
                        <td class="auto-style5">
                            <asp:TextBox ID="weight1_B" runat="server" AutoPostBack="True" Height="18px" OnTextChanged="weight1A_TextChanged" TextMode="Number" Width="106px">0</asp:TextBox>
                        </td>
                        <td class="auto-style4">
                            0</td>
                        <td>
                            <asp:Label ID="label1_B" runat="server" Text="0"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style6">C. Classroom Teaching Observation by Dean/Chair</td>
                        <td class="auto-style5">
                            <asp:TextBox ID="weight1_C" runat="server" AutoPostBack="True" Height="18px" OnTextChanged="weight1A_TextChanged" TextMode="Number" Width="106px">0</asp:TextBox>
                        </td>
                        <td class="auto-style4">
                            0</td>
                        <td>
                            <asp:Label ID="label1_C" runat="server" Text="0"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style6" style="border-style: none">&nbsp;</td>
                        <td class="auto-style5" style="border-style: none">
                            <asp:Label ID="labelWeightTotal1A" runat="server"></asp:Label>
                        </td>
                        <td class="auto-style4" style="border-style: none">&nbsp;</td>
                        <td style="border-style: none">
                            &nbsp;</td>
                    </tr>
                </table>
                <br />
            <div id ="section1B">
                <table class="auto-style2">
                    <tr>
                        <td colspan="4">Section 1.B: PROFESSIONAL ETHICS AND ADMINISTRATIVE COMPLIANCE</td>
                    </tr>
                    <tr>
                        <td class="auto-style3">&nbsp;</td>
                        <td class="auto-style5">W</td>
                        <td class="auto-style4">R</td>
                        <td>WS</td>
                    </tr>
                    <tr>
                        <td class="auto-style6">1.&nbsp; Timely Submission of Required Documents</td>
                        <td class="auto-style5">20</td>
                        <td class="auto-style4">
                            <asp:TextBox ID="rating1_1" runat="server" AutoPostBack="True" Height="18px" TextMode="Number" Width="91px" Enabled="False">0</asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="label1_1" runat="server" Text="0"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style6">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;The faculty member promptly submits his/her class records, final grades for printing, syllabus, other reports required by the chair/dean.</td>
                        <td class="auto-style5" style="border-style: none">&nbsp;</td>
                        <td class="auto-style4" style="border-style: none">
                            &nbsp;</td>
                        <td style="border-style: none">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style6">2.&nbsp; Participation in Official Mapua MCLFunctions, Events, and Activities</td>
                        <td class="auto-style5">20</td>
                        <td class="auto-style4">
                            <asp:TextBox ID="rating1_2" runat="server" AutoPostBack="True" Height="18px" TextMode="Number" Width="91px" Enabled="False">0</asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="label1_2" runat="server" Text="0"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style6">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;The faculty member attends institutional activities, functions and events as well as, all faculty and employee meetings.</td>
                        <td class="auto-style5" style="border-style: none">&nbsp;</td>
                        <td class="auto-style4" style="border-style: none">
                            &nbsp;</td>
                        <td style="border-style: none">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style6">3.&nbsp; Support for Quality Instruction</td>
                        <td class="auto-style5">20</td>
                        <td class="auto-style4">
                            <asp:TextBox ID="rating1_3" runat="server" AutoPostBack="True" Height="18px" TextMode="Number" Width="91px" Enabled="False">0</asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="label1_3" runat="server" Text="0"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style6">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;The faculty member assists the program for the attainment of its objectives for quality output.</td>
                        <td class="auto-style5" style="border-style: none">&nbsp;</td>
                        <td class="auto-style4" style="border-style: none">
                            &nbsp;</td>
                        <td style="border-style: none">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style6">4.&nbsp; Research Initiatives</td>
                        <td class="auto-style5">20</td>
                        <td class="auto-style4">
                            <asp:TextBox ID="rating1_4" runat="server" AutoPostBack="True" Height="18px" TextMode="Number" Width="91px" Enabled="False">0</asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="label1_4" runat="server" Text="0"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style6">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;The faculty member contributes to the research undertaking of the college.</td>
                        <td class="auto-style5" style="border-style: none">&nbsp;</td>
                        <td class="auto-style4" style="border-style: none">
                            &nbsp;</td>
                        <td style="border-style: none">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style6">5.&nbsp; Extension Services</td>
                        <td class="auto-style5">20</td>
                        <td class="auto-style4">
                            <asp:TextBox ID="rating1_5" runat="server" AutoPostBack="True" Height="18px" TextMode="Number" Width="91px" Enabled="False">0</asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="label1_5" runat="server" Text="0"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style6">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;The faculty member initiates, attends, and participates in community engagements of the college.</td>
                        <td class="auto-style5" style="border-style: none">&nbsp;</td>
                        <td class="auto-style4" style="border-style: none">
                            &nbsp;</td>
                        <td style="border-style: none">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style6" style="border-style: none">&nbsp;</td>
                        <td class="auto-style5" style="border-style: none">100</td>
                        <td class="auto-style4" style="border-style: none">&nbsp;</td>
                        <td style="border-style: none">
                            <asp:Label ID="labelTotal1B" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
                <asp:Button ID="Submit" runat="server" Text=" Submit " OnClick="Submit_Click"/>
                </center>
            </div>
       
        </div>
        
    </form>
</body>
</html>