<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AgreementSection1Officers.aspx.cs" Inherits="WebApplication1.AgreementSection1Officers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <style type="text/css">
        .auto-style2 {
            width: 80%;
                              
        }
        .auto-style3 {
            width: 914px;
        }
        .auto-style6 {
            width: 914px;
            text-align: left;
        }
        .auto-style9 {
            width: 101px;
        }
        .auto-style18 {
            width: 104px;
        }
        .auto-style20 {
                width: 367px;
                text-align: left;
            }
        .auto-style21 {
            width: 367px;
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
        .auto-style27 {
            width: 914px;
            text-align: center;
        }
        .auto-style30 {
            width: 223px;
        }
        .auto-style31 {
            width: 149px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
<br />
<div class="navbar" id="navibar">
    <asp:LinkButton ID="btnSection1" runat="server" Enabled="false" style="color:black; background-color:#eaeaea">Section 1</asp:LinkButton> &nbsp; &nbsp; &nbsp;
    <asp:LinkButton ID="btnSection2" runat="server" OnClick="ChangeSection">Section 2</asp:LinkButton> &nbsp; &nbsp; &nbsp;
    <asp:LinkButton ID="btnSection3" runat="server" OnClick="ChangeSection">Section 3</asp:LinkButton> &nbsp; &nbsp; &nbsp;
    <asp:LinkButton ID="btnSection4" runat="server" OnClick="ChangeSection">Section 4</asp:LinkButton> &nbsp; &nbsp; &nbsp;
    <asp:LinkButton ID="btnOverall" runat="server" OnClick="ChangeSection">Overall</asp:LinkButton>
</div>
    <asp:Table runat="server" ID="tablekra" class="auto-style2" >
        <asp:TableRow>
            <asp:TableCell ColumnSpan="5" style="background-color: #C0C0C0"><strong>SECTION 1: INSTITUTIONAL OBJECTIVES</strong></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <br />
    <asp:Button ID="addKRAbtn" runat="server" OnClick="addkrabtn" Text="Add KRA" /> &nbsp;&nbsp;
    <asp:Button ID="removeKRAbtn" runat="server" OnClick="removekrabtn" Text="Remove KRA" />
    <br />
    <asp:Textbox ID ="kraindex" runat="server" Textmode="Number" />
    <asp:Textbox ID ="objNum" runat="server" Textmode="Number" />
    <asp:Button ID="Button1" runat="server" OnClick="addSpecificobjctivebtn" Text="Add Scope" /> &nbsp;&nbsp;
    <asp:Button ID="Button2" runat="server" Text="Remove Scope" />
    <br />
</center>
</asp:Content>
