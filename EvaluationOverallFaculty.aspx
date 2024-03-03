<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EvaluationOverallFaculty.aspx.cs" Inherits="WebApplication1.EvaluationOverallFaculty" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style9 {
        width: 101px;
    }
    .auto-style16 {
        text-align: right;
    }
    .auto-style17 {
        text-align: left;
        width: 183px;
    }
        .auto-style18 {
            width: 101px;
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <div class="navbar">
            <asp:LinkButton ID="btnSection1" runat="server" OnClick="ChangeSection">Section 1</asp:LinkButton> &nbsp; &nbsp; &nbsp;
            <asp:LinkButton ID="btnSection2" runat="server" OnClick="ChangeSection">Section 2</asp:LinkButton> &nbsp; &nbsp; &nbsp;
            <asp:LinkButton ID="btnSection3" runat="server" OnClick="ChangeSection">Section 3</asp:LinkButton> &nbsp; &nbsp; &nbsp;
            <asp:LinkButton ID="btnOverall" runat="server"  Enabled="false" style="color:black; background-color:#808080">Overall</asp:LinkButton>
        </div>
        <table width ="25%">
            <tr>    
                <td style="background-color: #C0C0C0" colspan="3"><strong>OVERALL</strong></td>
                <br />
                <br />
            </tr>
            <tr>
                <td class="auto-style17"><strong>SECTION 1-A</strong></td>
                <td class="auto-style9">
                    <asp:Label ID="lblTotalWeight1A" runat="server" Text="50%"></asp:Label>
                </td>
                <td class="auto-style18">
                    <asp:TextBox ID="total1" runat="server" AutoPostBack="True" Height="18px" TextMode="Number" Width="91px" Enabled="False">0</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style17"><strong>SECTION 1-B</strong></td>
                <td class="auto-style9">
                    <asp:Label ID="lblTotalWeight1B" runat="server" Text="20%"></asp:Label>
                </td>
                <td class="auto-style18">
                    <asp:TextBox ID="total2" runat="server" AutoPostBack="True" Height="18px" TextMode="Number" Width="91px" Enabled="False">0</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style17"><strong>SECTION 2</strong></td>
                <td class="auto-style9">
                    <asp:Label ID="lblTotalWeight2" runat="server" Text="30%"></asp:Label>
                </td>
                <td class="auto-style9">
                    <asp:TextBox ID="total3" runat="server" AutoPostBack="True" Height="18px" TextMode="Number" Width="91px" Enabled="False">0</asp:TextBox>
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
