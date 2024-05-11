<%@ Page Title="Employee Evaluation" Language="C#" MasterPageFile="~/Child.Master" AutoEventWireup="true" CodeBehind="Evaluation.aspx.cs" Inherits="WebApplication1.Evaluation1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
        <asp:table runat="server" ID="evaluationTable" Width="80%">
            <asp:TableRow>
                <asp:TableCell ColumnSpan="4" style="background-color: #C0C0C0"><strong>Employee Evaluations</strong></asp:TableCell>
            </asp:TableRow>
        </asp:table>
</center>
</asp:Content>
