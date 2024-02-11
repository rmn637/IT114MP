<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EvaluationOverallStaff.aspx.cs" Inherits="WebApplication1.EvaluationOverallStaff" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
    .auto-style7 {
        width: 27px;
        text-align: left;
    }
    .auto-style8 {
        text-align: left;
    }
    .auto-style9 {
        width: 101px;
    }
    .auto-style14 {
        width: 27px;
        text-align: left;
        height: 24px;
    }
    .auto-style15 {
        height: 24px;
    }
    .auto-style16 {
        text-align: right;
    }
    .auto-style17 {
        text-align: left;
        width: 183px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <div class="navbar">
            <asp:LinkButton ID="btnSection1" runat="server" OnClick="checkWeight">Section 1</asp:LinkButton> &nbsp; &nbsp; &nbsp;
            <asp:LinkButton ID="btnSection2" runat="server" OnClick="checkWeight">Section 2</asp:LinkButton> &nbsp; &nbsp; &nbsp;
            <asp:LinkButton ID="btnSection3" runat="server" OnClick="checkWeight">Section 3</asp:LinkButton> &nbsp; &nbsp; &nbsp;
            <asp:LinkButton ID="btnOverall" runat="server"  Enabled="false">Overall</asp:LinkButton>
        </div>
        <table width ="25%">
            <tr>    
                <td style="background-color: #C0C0C0" colspan="3"><strong>OVERALL</strong></td>
                <br />
                <br />
            </tr>
            <tr>
                <td class="auto-style17"><strong>SECTION 1</strong></td>
                <td class="auto-style9">
                    <asp:Label ID="lblTotalWeight1" runat="server" Text="60"></asp:Label>
                </td>
                <td class="auto-style9">
                    <asp:TextBox ID="total1" runat="server" AutoPostBack="True" Height="18px" TextMode="Number" Width="91px" Enabled="False">0</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style17"><strong>SECTION 2</strong></td>
                <td class="auto-style9">
                    <asp:Label ID="lblTotalWeight2" runat="server" Text="40"></asp:Label>
                </td>
                <td class="auto-style9">
                    <asp:TextBox ID="total2" runat="server" AutoPostBack="True" Height="18px" TextMode="Number" Width="91px" Enabled="False">0</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style17">&nbsp;</td>
                <td class="auto-style9">
                    100%</td>
                <td class="auto-style9">
                    
                </td>
            </tr>
            <tr>
                <td class="auto-style16" colspan="2"><strong>TOTAL OVERALL PERFORMANCE POINTS</strong></td>
                <td class="auto-style9">
                    <asp:Label ID="labelTotal1" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    <asp:Button ID="Submit" runat="server" Text=" Submit " OnClick="Submit_Click" Enabled="false"/>
        <br />
    </center>
</asp:Content>
