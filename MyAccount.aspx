<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MyAccount.aspx.cs" Inherits="WebApplication1.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="center">
        <h2>Employee Information</h2>
        <br />
        <strong>
        <asp:Label ID="lblEmpID" runat="server" ></asp:Label>
        <br />
        <asp:Label ID="lblEmpName" runat="server" ></asp:Label>
        <br />
        <asp:Label ID="lblEmpDept" runat="server" ></asp:Label>
        <br />
        <asp:Label ID="lblEmpPos" runat="server" ></asp:Label>
        <br />
        <asp:Label ID="lblEmpSupervisor" runat="server" ></asp:Label>
        </strong>
    </div>
</asp:Content>
