<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Evaluation.aspx.cs" Inherits="WebApplication1.Evaluation1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Style.css" rel="stylesheet" />
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                <td>
                    <asp:Button runat="server" ID="faculty1" OnClick="FacultyClicked" Text="Aaron Cabuenas" Enabled="False" ></asp:Button>
                </td>
                <td>
                    <asp:Button runat="server" ID="officer1" OnClick="OfficerClicked" Text="Jerome Mendoza" Enabled="False" ></asp:Button>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button runat="server" ID="staff2" OnClick="StaffClicked" Text="Reese Ramos2" Enabled="False" ></asp:Button>
                </td>
                <td>
                    <asp:Button runat="server" ID="faculty2" OnClick="FacultyClicked" Text="Aaron Cabuenas2" Enabled="False" ></asp:Button>
                </td>
                <td>
                    <asp:Button runat="server" ID="officer2" OnClick="OfficerClicked" Text="Jerome Mendoza2" Enabled="False" ></asp:Button>
                </td>
            </tr>
        </tbody>
    </table>
</center>
</asp:Content>
