<%@ Page Title="Admin Dashboard" Language="C#" MasterPageFile="~/Child.Master" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="WebApplication1.admin" %>
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
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server"></asp:UpdatePanel>
        <center>
        <asp:Button ID="btnEnable" runat="server" Text="Activate All Users" OnClick="btnEnable_Click" />
        <asp:Button ID="btnDisable" runat="server" Text="Inactivate All Users" OnClick="btnDisable_Click"/>
        </center>
        <contentTemplate>
        <form class="form-check form-switch">
            <asp:Table runat="server" ID="reportTable" Width="100%">

            </asp:Table>
        </form>
        </contentTemplate>
    </center>
</asp:Content>
