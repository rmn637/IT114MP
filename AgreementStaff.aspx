<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AgreementStaff.aspx.cs" Inherits="WebApplication1.AgreementStaff" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 30px;
        }
        .auto-style2 {
            width: 80%;
                          
        }
        .auto-style4 {
            width: 98px;
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
        </style>
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
        <asp:Button ID="EvaluateBtn" runat="server" Text="Evaluate" OnClick="EvaluateBtn_Click" />
    </div>    
</asp:Content>
    
