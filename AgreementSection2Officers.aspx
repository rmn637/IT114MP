﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AgreementSection2Officers.aspx.cs" Inherits="WebApplication1.AgreementSection2Officers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style2 {
        width: 80%;
    }
    .auto-style6 {
        width: 914px;
        text-align: left;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
           <center>
        <div class="navbar" id="navibar">
            <asp:LinkButton ID="btnSection1" runat="server" OnClick="ChangeSection">Section 1</asp:LinkButton> &nbsp; &nbsp; &nbsp;
            <asp:LinkButton ID="btnSection2" runat="server" Enabled="false" style="color:black; background-color:#eaeaea">Section 2</asp:LinkButton> &nbsp; &nbsp; &nbsp;
            <asp:LinkButton ID="btnSection3" runat="server" OnClick="ChangeSection">Section 3</asp:LinkButton> &nbsp; &nbsp; &nbsp;
            <asp:LinkButton ID="btnSection4" runat="server" OnClick="ChangeSection">Section 4</asp:LinkButton> &nbsp; &nbsp; &nbsp;
            <asp:LinkButton ID="btnOverall" runat="server" OnClick="ChangeSection">Overall</asp:LinkButton>
        </div>
        <br />
        <br />
        <asp:Table runat="server" ID="tableScope" class="auto-style2">
            <asp:TableRow>
                <asp:TableCell ColumnSpan="4" style="background-color: #C0C0C0"><strong>SECTION 2: GOVERNANCE, RISK MANAGEMENT AND CONTROL (GRC): Adherence to governance principles to ensure the continuin effectiveness of governance arrangements and take opportunities and counter threats through effective risk management and internal control. To be able to contribute strongly to meeting organizational objectives in respective assigned areas.</strong></asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br />
        <asp:Button ID="addScopebtn" runat="server" OnClick="addscopebtn" Text="Add Scope" />&nbsp;&nbsp;
        <asp:Button ID="removeScopebtn" runat="server" OnClick="removescopebtn" Text="Remove Scope" />
        <br />
</center>
</asp:Content>
