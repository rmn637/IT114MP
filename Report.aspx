<%@ Page Title="Supervisor Report" Language="C#" MasterPageFile="~/Child.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="WebApplication1.Report" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Style.css" rel="stylesheet" />
    <style type="text/css">
    .headerCellClass {
        background-color: #C0C0C0;
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
    <asp:Table runat="server" ID="reportTable" Width="100%"> </asp:Table>
</center>
</asp:Content>
