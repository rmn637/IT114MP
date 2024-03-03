<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AgreementCommentsFaculty.aspx.cs" Inherits="WebApplication1.AgreementCommentsFaculty" %>
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
    <center>
        <div class="navbar">
            <asp:LinkButton ID="btnSection1" runat="server" OnClick="checkWeight">Section 1</asp:LinkButton> &nbsp; &nbsp; &nbsp;
            <asp:LinkButton ID="btnSection2" runat="server" OnClick="checkWeight">Section 2</asp:LinkButton> &nbsp; &nbsp; &nbsp;
            <asp:LinkButton ID="btnSection3" runat="server" style="color:black; background-color:#808080">Section 3</asp:LinkButton> &nbsp; &nbsp; &nbsp;
            <asp:LinkButton ID="btnOverall" runat="server" OnClick="checkWeight">Overall</asp:LinkButton>
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
                    <asp:TextBox ID="strength" runat="server" AutoPostBack="True" Width="1032px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style8">AREAS OF IMPROVEMENT</td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:TextBox ID="improvement" runat="server" AutoPostBack="True" Width="1032px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style8">DEVELOPMENT PLANS (PLEASE SPECIFY TARGET DATE)</td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:TextBox ID="development" runat="server" AutoPostBack="True" Width="1032px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style8">EMPLOYEE&#39;S COMMENTS/ACKNOWLEDGEMENT</td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:TextBox ID="acknowledgement" runat="server" AutoPostBack="True" Width="1032px"></asp:TextBox>
                </td>
            </tr>
        </table>
    </center>
</asp:Content>
