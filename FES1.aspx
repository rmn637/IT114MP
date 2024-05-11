<%@ Page Title="Faculty Evaluation Section 1" Language="C#" MasterPageFile="~/Child.Master" AutoEventWireup="true" CodeBehind="FES1.aspx.cs" Inherits="WebApplication1.EvaluationSection1Faculty" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
    .auto-style1 {
        height: 30px;
    }
    .auto-style2 {
        width: 80%;     
    }
    .auto-style4 {
        width: 98px;
    }
    .auto-style6 {
        width: 914px;
        text-align: left;
    }
    .active {
        padding: 8px 8px 8px 32px;
        text-decoration: none;
        font-size: 25px;
        color: #a8a8a8;
        background-color:#4a4a4a;
        display: block;
        transition: 0.3s;
    }
    </style>
        <center> 
            <div class="navbar">
                <asp:LinkButton ID="btnSection1" runat="server" Enabled="false" style="color:black; background-color:#808080">Section 1</asp:LinkButton> &nbsp; &nbsp; &nbsp;
                <asp:LinkButton ID="btnSection2" runat="server" OnClick="ChangeSection">Section 2</asp:LinkButton> &nbsp; &nbsp; &nbsp;
                <asp:LinkButton ID="btnSection3" runat="server" OnClick="ChangeSection">Section 3</asp:LinkButton> &nbsp; &nbsp; &nbsp;
                <asp:LinkButton ID="btnOverall" runat="server" OnClick="ChangeSection">Overall</asp:LinkButton>
            </div>
            <br />
            <br />
        <table class="auto-style2">
            <tr>
                <td colspan="4" style="background-color: #C0C0C0"><strong>SECTION 1-A: ACADEMIC PERFORMANCE</strong></td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style18">W</td>
                <td class="auto-style4">R</td>
                <td>WS</td>
            </tr>
            <tr>
                <td class="auto-style6">A.&nbsp; Faculty Evaluation by Students</td>
                <td class="auto-style18">
                    <asp:Label ID="weight1_A" runat="server" Text="0"></asp:Label>
                </td>
                <td class="auto-style4">
                    <asp:TextBox ID="rating1_A" runat="server" AutoPostBack="True" Height="18px" OnTextChanged="rating1A_TextChanged" TextMode="Number" Width="91px">0</asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="label1_A" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">B. Classroom Teaching Observation by Peers</td>
                <td class="auto-style18">
                    <asp:Label ID="weight1_B" runat="server" Text="0"></asp:Label>
                </td>
                <td class="auto-style4">
                    <asp:TextBox ID="rating1_B" runat="server" AutoPostBack="True" Height="18px" OnTextChanged="rating1A_TextChanged" TextMode="Number" Width="91px">0</asp:TextBox>
                </td>
                <td class="auto-style1">
                    <asp:Label ID="label1_B" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">C. Classroom Teaching Observation by Dean/Chair</td>
                <td class="auto-style18">
                    <asp:Label ID="weight1_C" runat="server" Text="0"></asp:Label>
                </td>
                <td class="auto-style4">
                    <asp:TextBox ID="rating1_C" runat="server" AutoPostBack="True" Height="18px" OnTextChanged="rating1A_TextChanged" TextMode="Number" Width="91px">0</asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="label1_C" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style6" style="border-style: none">&nbsp;</td>
                <td class="auto-style18" style="border-style: none">100</td>
                <td class="auto-style4" style="border-style: none">&nbsp;</td>
                <td style="border-style: none">
                    <asp:Label ID="labelTotal1A" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        </center>
    </div>
        <center>
        <table class="auto-style2">
            <tr>
                <td colspan="4" style="background-color: #C0C0C0"><strong>SECTION 1.B: PROFESSIONAL ETHICS AND ADMINISTRATIVE COMPLIANCE</strong></td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style5">W</td>
                <td class="auto-style4">R</td>
                <td>WS</td>
            </tr>
            <tr>
                <td class="auto-style6">1.&nbsp; Timely Submission of Required Documents</td>
                <td class="auto-style5">
                    <asp:Label ID="weight1_1" runat="server" Text="0"></asp:Label>
                </td>
                <td class="auto-style4">
                    <asp:TextBox ID="rating1_1" runat="server" AutoPostBack="True" Height="18px" OnTextChanged="rating1B_TextChanged" TextMode="Number" Width="91px">0</asp:TextBox>
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
                <td class="auto-style6">2.&nbsp; Participation in Official Mapua MCL Functions, Events, and Activities</td>
                <td class="auto-style5">
                    <asp:Label ID="weight1_2" runat="server" Text="0"></asp:Label>
                </td>
                <td class="auto-style4">
                    <asp:TextBox ID="rating1_2" runat="server" AutoPostBack="True" Height="18px" OnTextChanged="rating1B_TextChanged" TextMode="Number" Width="91px">0</asp:TextBox>
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
                <td class="auto-style5">
                    <asp:Label ID="weight1_3" runat="server" Text="0"></asp:Label>
                </td>
                <td class="auto-style4">
                    <asp:TextBox ID="rating1_3" runat="server" AutoPostBack="True" Height="18px" OnTextChanged="rating1B_TextChanged" TextMode="Number" Width="91px">0</asp:TextBox>
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
                <td class="auto-style5">
                    <asp:Label ID="weight1_4" runat="server" Text="0"></asp:Label>
                </td>
                <td class="auto-style4">
                    <asp:TextBox ID="rating1_4" runat="server" AutoPostBack="True" Height="18px" OnTextChanged="rating1B_TextChanged" TextMode="Number" Width="91px">0</asp:TextBox>
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
                <td class="auto-style5">
                    <asp:Label ID="weight1_5" runat="server" Text="0"></asp:Label>

                </td>
                <td class="auto-style4">
                    <asp:TextBox ID="rating1_5" runat="server" AutoPostBack="True" Height="18px" OnTextChanged="rating1B_TextChanged" TextMode="Number" Width="91px">0</asp:TextBox>
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
        </center>
</asp:Content>
