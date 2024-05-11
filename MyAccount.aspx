<%@ Page Title="My Account" Language="C#" MasterPageFile="~/Child.Master" AutoEventWireup="true" CodeBehind="MyAccount.aspx.cs" Inherits="WebApplication1.WebForm1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        div .center {
            text-align: center;
            display: inline-block;
            position: absolute;
            top: 30%;
            left: 36%;
            width: 500px;
            padding: 10px;
            border: 1px solid lightgrey
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
    <div class="center">
        <h1>My Account</h1>
        <h2>Employee Information</h2>
        <br />
        <center>
        <strong>
        <table class="table table-hover" style="border:0px solid">
            <tr>
              <th scope="row" style="text-align:right;border:0px solid">ID:</th>
              <td style="border:0px solid"><asp:Label ID="lblEmpID" runat="server" ></asp:Label></td>
            </tr>
            <tr>
              <th scope="row" style="text-align:right;border:0px solid">Name:</th>
              <td style="border:0px solid"><asp:Label ID="lblEmpName" runat="server" ></asp:Label></td>
            </tr>
            <tr>
              <th scope="row" style="text-align:right;border:0px solid">Department:</th>
              <td style="border:0px solid"><asp:Label ID="lblEmpDept" runat="server" ></asp:Label></td>
            </tr>
            <tr>
              <th scope="row" style="text-align:right;border:0px solid">Position:</th>
              <td style="border:0px solid"><asp:Label ID="lblEmpPos" runat="server" ></asp:Label></td>
            </tr>
            <tr>
              <th scope="row" style="text-align:right;border:0px solid">Supervisor:</th>
              <td style="border:0px solid"><asp:Label ID="lblEmpSupervisor" runat="server" ></asp:Label></td>
            </tr>
        </table>
        </center>
        </strong>
    </div>
</asp:Content>
