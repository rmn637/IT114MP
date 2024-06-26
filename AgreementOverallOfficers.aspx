﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AgreementOverallOfficers.aspx.cs" Inherits="WebApplication1.AgreementOverallOfficers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <style type="text/css">
    .auto-style9 {
        width: 101px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <div class="navbar" id="navibar">
            <asp:LinkButton ID="btnSection1" runat="server" OnClick="checkWeight">Section 1</asp:LinkButton> &nbsp; &nbsp; &nbsp;
            <asp:LinkButton ID="btnSection2" runat="server" OnClick="checkWeight">Section 2</asp:LinkButton> &nbsp; &nbsp; &nbsp;
            <asp:LinkButton ID="btnSection3" runat="server" OnClick="checkWeight">Section 3</asp:LinkButton> &nbsp; &nbsp; &nbsp;
            <asp:LinkButton ID="btnSection4" runat="server" OnClick="checkWeight">Section 4</asp:LinkButton> &nbsp; &nbsp; &nbsp;
            <asp:LinkButton ID="btnOverall" runat="server" Enabled="false" style="color:black; background-color:#eaeaea">Overall</asp:LinkButton>
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
                    <asp:TextBox ID="weight1_1" runat="server" AutoPostBack="True" Height="18px" Width="91px" Text="30" Enabled="False" CssClass="normal"></asp:TextBox>
                </td>
                <td class="auto-style9">
                </td>
            </tr>
            <tr>
                <td class="auto-style17"><strong>SECTION 2</strong></td>
                <td class="auto-style9">
                    <asp:TextBox ID="weight1_2" runat="server" AutoPostBack="True" Height="18px" Width="91px" Text="20" Enabled="False" CssClass="normal"></asp:TextBox>
                </td>
                <td class="auto-style9">
                </td>
            </tr>
            <tr>
                <td class="auto-style17"><strong>SECTION 3</strong></td>
                <td class="auto-style9">
                    <asp:TextBox ID="weight1_3" runat="server" AutoPostBack="True" Height="18px" Width="91px" Text="30" Enabled="False" CssClass="normal"></asp:TextBox>
                </td>
                <td class="auto-style9">
                </td>
            </tr>
            <tr>
                <td class="auto-style17"><strong>SECTION 4</strong></td>
                <td class="auto-style9">
                    <asp:TextBox ID="weight1_4" runat="server" AutoPostBack="True" Height="18px" TextMode="Number" Width="91px" Text="20" Enabled="False" CssClass="normal"></asp:TextBox>
                </td>
                <td class="auto-style9">
                </td>
            </tr>
            <tr>
                <td class="auto-style17">&nbsp;</td>
                <td class="auto-style9">
                    <asp:Label ID="labelTotal1" runat="server">100</asp:Label>
                </td>
                <td class="auto-style9">
                        
                </td>
            </tr>
            <tr>
                <td class="auto-style16" colspan="2"><strong>TOTAL OVERALL PERFORMANCE POINTS</strong></td>
                <td class="auto-style9">
                    &nbsp;</td>
            </tr>
        </table>
        <asp:Button ID="Submit" runat="server" Text=" Submit " OnClick="Submit_Click" Enabled="false"/>
        <asp:Button ID="Agree" runat="server" Text=" Agree " OnClick="Agree_Click"/>
        <asp:Button ID="Disagree" runat="server" Text=" Disagree " OnClick="Disgree_Click"/>
        <br />
    </center>
</asp:Content>
