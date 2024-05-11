<%@ Page Title="Evaluation Comment Faculty" Language="C#" MasterPageFile="~/Child.Master" AutoEventWireup="true" CodeBehind="FEC.aspx.cs" Inherits="WebApplication1.EvaluationCommentsFaculty" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
        <div class="navbar">
            <asp:LinkButton ID="btnSection1" runat="server" OnClick="ChangeSection">Section 1</asp:LinkButton> &nbsp; &nbsp; &nbsp;
            <asp:LinkButton ID="btnSection2" runat="server" OnClick="ChangeSection">Section 2</asp:LinkButton> &nbsp; &nbsp; &nbsp;
            <asp:LinkButton ID="btnSection3" runat="server" Enabled="false" style="color:black; background-color:#808080">Section 3</asp:LinkButton> &nbsp; &nbsp; &nbsp;
            <asp:LinkButton ID="btnOverall" runat="server" OnClick="ChangeSection">Overall</asp:LinkButton>
        </div>
        <br/>
        <br />
        <table class="auto-style2">
            <tr>
                <td style="background-color: #C0C0C0"><strong>SECTION 3</strong></td>
            </tr>
            <tr>
                <td class="auto-style8">STRENGTH</td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:TextBox ID="strength" runat="server" AutoPostBack="True" Width="1032px" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style8">AREAS OF IMPROVEMENT</td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:TextBox ID="improvement" runat="server" AutoPostBack="True" Width="1032px" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style8">DEVELOPMENT PLANS (PLEASE SPECIFY TARGET DATE)</td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:TextBox ID="development" runat="server" AutoPostBack="True" Width="1032px" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style8">EMPLOYEE&#39;S COMMENTS/ACKNOWLEDGEMENT</td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:TextBox ID="acknowledgement" runat="server" AutoPostBack="True" Width="1032px" Enabled="False"></asp:TextBox>
                </td>
            </tr>
        </table>
    </center>
</asp:Content>
