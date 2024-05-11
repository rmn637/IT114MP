<%@ Page Title="Create Account" Language="C#" MasterPageFile="~/Child.Master" AutoEventWireup="true" CodeBehind="CreateAcc.aspx.cs" Inherits="WebApplication1.CreateAcc" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Style.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            text-align: center;
        }
        .auto-style3 {
            text-align: right;
            width: 50%;
        }
        .auto-style4 {
            text-align: left;
        }
        input[type=password] {
            text-align: left;
            background-color: #FFFFFF;
            width: 164px;
            height: 20px;
            margin-top: 0vh;
            border-radius: 0;
        }

    </style>
    
    <table class="auto-style1">
        <tr>
            <td class="auto-style2" colspan="2"><h1>Account Information</h1></td>
        </tr>
        <tr>
            <td class="auto-style3">Employee ID<asp:RequiredFieldValidator ID="RFVID" runat="server" ControlToValidate="empID" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
            <td class="auto-style4">
                <asp:TextBox ID="empID" runat="server" MaxLength="10" AutoPostBack="True" OnTextChanged="empID_TextChanged"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Employee Name<asp:RequiredFieldValidator ID="RFVName" runat="server" ControlToValidate="empName" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
            <td class="auto-style4">
                <asp:TextBox ID="empName" runat="server" MaxLength="50"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Employee Position<asp:RequiredFieldValidator ID="RFVPos" runat="server" ControlToValidate="empPos" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
            <td class="auto-style4">
                <asp:TextBox ID="empPos" runat="server" MaxLength="20"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Employee Department<asp:RequiredFieldValidator ID="RFVDept" runat="server" ControlToValidate="empDept" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
            <td class="auto-style4">
                <asp:TextBox ID="empDept" runat="server" MaxLength="20"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Employee Type</td>
            <td class="auto-style4">
                <asp:DropDownList ID="ddlEmpType" runat="server">
                    <asp:ListItem>Faculty</asp:ListItem>
                    <asp:ListItem>Officer</asp:ListItem>
                    <asp:ListItem>Staff</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Employee&#39;s Supervisor ID</td>
            <td class="auto-style4">
                <asp:DropDownList ID="ddlEmpSupID" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style2" colspan="2"><h1>Account Email and Password</h1></td>
        </tr>
        <tr>
            <td class="auto-style3">Employee Username/Email<asp:RequiredFieldValidator ID="RFVUser" runat="server" ControlToValidate="empUser" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
            <td class="auto-style4">
                <asp:TextBox ID="empUser" runat="server" MaxLength="30" AutoPostBack="True" OnTextChanged="empUser_TextChanged"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Employee Password<asp:RequiredFieldValidator ID="RFVPass" runat="server" ControlToValidate="empPassword" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
            <td class="auto-style4">
                <asp:TextBox ID="empPassword" runat="server" MaxLength="20" TextMode="Password"></asp:TextBox>
                <asp:CheckBox ID="showPass" runat="server" AutoPostBack="True" OnCheckedChanged="showPass_CheckedChanged" />
            </td>
        </tr>
        </table>
        <br/>
    <center>
    <asp:Button ID="btnCreate" runat="server" Text="Create Account" OnClick="btnCreate_Click" />
    </center>
    
</asp:Content>
