<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgetPass.aspx.cs" Inherits="WebApplication1.ForgetPass" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Forget Password</title>
    <link href="Style.css" rel="stylesheet" />
    <style type="text/css">
    </style>
    

</head>
<body>
    <form id="form1" runat="server" DefaultButton="SearchBtn">
        <div>
        <center>
        <h1>ForgetPass</h1>
        <h2>Find Username</h2>
        <asp:Panel ID="Panel1" runat="server" DefaultButton="SearchBtn">
        <p>Username:<asp:RequiredFieldValidator ID="rfvUser" runat="server" ErrorMessage="*" ControlToValidate="usernameTxt"></asp:RequiredFieldValidator>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   <asp:TextBox type="email" ID="usernameTxt" placeholder="Username" runat="server"/></p>
        <asp:Button ID="CancelBtn" runat="server" Text=" Cancel " OnClick="CancelBtn_Click" CausesValidation ="false" /><asp:Button ID="SearchBtn" runat="server" Text=" Search " OnClick="SearchBtn_Click" />
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server" DefaultButton="SubmitBtn" Visible="false">
        <h2 id="SetNew" hidden runat="server">Set New Password</h2>
        <p id="newPass" hidden runat="server">New Password:<asp:RequiredFieldValidator ID="rfvNewPassword" runat="server" ErrorMessage="*" ControlToValidate="newPasswordTxt" Visible ="false" ValidationGroup="Group1"></asp:RequiredFieldValidator>&nbsp;&nbsp;&nbsp;&nbsp;   <asp:TextBox type="password" ID="newPasswordTxt" placeholder="Password" runat="server" Visible ="false" ValidationGroup="Group1"/></p>
        <p id="confirmPass" hidden runat="server">Confirm Password:<asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" ErrorMessage="*" ControlToValidate="confirmPasswordTxt" Visible ="false" ValidationGroup="Group1"></asp:RequiredFieldValidator><asp:TextBox type="password" ID="confirmPasswordTxt" placeholder="Password" runat="server" Visible ="false" ValidationGroup="Group1"/></p>
        <asp:Button ID="CancelBtn1" runat="server" Text=" Cancel " OnClick="CancelBtn_Click" CausesValidation ="false" Visible ="false"/><asp:Button ID="SubmitBtn" runat="server" Text=" Submit " OnClick="SubmitBtn_Click" Visible ="false"/>
        </asp:Panel>
        </center>

        </div>
    </form>
</body>
</html>
