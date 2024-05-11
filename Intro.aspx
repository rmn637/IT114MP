<%@ Page Title="" Language="C#" MasterPageFile="~/Parent.Master" AutoEventWireup="true" CodeBehind="Intro.aspx.cs" Inherits="WebApplication1.Intro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Style.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            width: 411px;
            height: 123px;
            cursor:default;
        }
        div .center {
            text-align: center;
            display: inline-block;
            position: absolute;
            top: 30%;
            left: 36%;
            width: 500px;
            padding: 10px;
            border: 1px solid lightgrey;
            background-color: white;
            cursor:default;
        }
        body {
            background-image:url('images/MMCL bg.png');
            background-position-y:-11.5%;
            background-size:cover;
            background-repeat:no-repeat;
            cursor:default;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
    <div class="center">
        <h2 style="cursor:default;">About Mapúa MCL Evaluation Form</h2>
        <br />
        <p style="cursor:default;">This website is a requirement for IT114 Machine Problem. This group is comprised of Aaron Cabuenas, Jerome Mendoza and Reese Ramos</p>
        <center>
        <asp:Button ID="LogIn" runat="server" Text=" Sign In " OnClick="Submit_Click" Height="38px" Width="197px" Font-Size="24px"/>
        </center>
    </div>
    </div>
</asp:Content>
