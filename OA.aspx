﻿<%@ Page Title="Agreement Officer" Language="C#" MasterPageFile="~/Child.Master" AutoEventWireup="true" CodeBehind="OA.aspx.cs" Inherits="WebApplication1.AgreementOfficers" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 30px;
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
        .auto-style18 {
            width: 104px;
        }
        .auto-style20 {
            width: 296px;
            text-align: left;
        }
        .auto-style21 {
            width: 296px;
            text-align: left;
            height: 22px;
        }
        .auto-style22 {
            width: 914px;
            text-align: right;
            height: 22px;
        }
        .auto-style23 {
            width: 104px;
            height: 22px;
        }
        .auto-style24 {
            width: 223px;
            height: 22px;
        }
        .auto-style25 {
            height: 22px;
                width: 149px;
            }
        .auto-style26 {
            text-align: left;
            height: 24px;
        }
        .auto-style27 {
            width: 914px;
            text-align: center;
        }
        .auto-style28 {
            width: 69px;
        }
        .auto-style30 {
            width: 223px;
        }
        .auto-style31 {
            width: 149px;
        }
        .auto-style32 {
            width: 65px;
        }
        .auto-style33 {
            width: 86px;
        }
        .auto-style34 {
            width: 154px;
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
        <div class="center">
            <h2>Performance Agreement Survey for Officers</h2>
            <table>
                <tr id="trbc">
                    <td>Name of Employee</td>
                    <td>Position</td>
                    <td>College/Department</td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblEmpName" runat="server"></asp:Label></td>
<td><asp:Label ID="lblPos" runat="server"></asp:Label></td>
<td><asp:Label ID="lblDept" runat="server"></asp:Label></td>
                </tr>
                <tr id="trbc0">
                    <td class="auto-style1">Name of Rater</td>
                    <td class="auto-style1">Appraisal Period</td>
                    <td class="auto-style1">Date Prepared</td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblRaterName" runat="server"></asp:Label></td>
<td><asp:Label ID="lblAppraisal" runat="server" Text="-- -- ----" ></asp:Label></td>
<td><asp:Label ID="lblDatePrep" runat="server"></asp:Label></td>
                </tr>
            </table>
    <br />
        <asp:Button ID="EvaluateBtn" runat="server" Text="Create Agreement" OnClick="EvaluateBtn_Click" />
            <asp:Button ID="View" runat="server" Text="View Agreement" OnClick="ViewBtn_Click" Enabled ="false" Visible ="false"/>
        </div>
    </center>
</asp:Content>