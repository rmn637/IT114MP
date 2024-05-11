<%@ Page Title="" Language="C#" MasterPageFile="~/Parent.Master" AutoEventWireup="true" CodeBehind="LogInPage.aspx.cs" Inherits="WebApplication1.LogInPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Style.css" rel="stylesheet" />
    <style type="text/css">
    .forgetpassStyle{
     color: #0000FF; 
     text-decoration: underline;
     font-size: 14px;
    }
    .forgetpassStyle:hover { 
        text-decoration: none; 
        color: #0096FF; 
    }
    div .login {
        text-align: center;
        display: inline-block;
        position: absolute;
        top: 30%;
        left: 36%;
        width: 500px;
        padding: 10px;
        border: 1px solid lightgrey;
        background-color: white;
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
    <center> 
    <div class="login">
        <center>
        <h2>Sign In</h2>
        <strong>
        <p>Email:<asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="*" ControlToValidate="usernameTxt"></asp:RequiredFieldValidator>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  <asp:TextBox type="email" ID="usernameTxt" placeholder="Username" runat="server"/></p>
        <p>Password:<asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="*" ControlToValidate="passwordTxt"></asp:RequiredFieldValidator>&nbsp;&nbsp; <asp:TextBox type="password" ID="passwordTxt" placeholder="Password" runat="server" /><img src=""></p>
        <p><asp:LinkButton ID="ForgetPass" runat ="server" CssClass ="forgetpassStyle" CausesValidation="False" OnClick="ForgetPass_Click" >Forget Password?</asp:LinkButton></p>
        <asp:Button ID="Submit" runat="server" Text=" Sign In " OnClick="Submit_Click" />
        </strong>
        </center>
    </div>
    </center> 
</asp:Content>
