<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="WebApplication1.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="Style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <center>
            <h1>Mapua MCL Evaluation Form</h1>
            <h2>Sign In</h2>
            <strong>
            <p>Email:<asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="*" ControlToValidate="usernameTxt"></asp:RequiredFieldValidator>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  <asp:TextBox type="email" ID="usernameTxt" placeholder="Username" runat="server"/></p>
            <p>Password:<asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="*" ControlToValidate="passwordTxt"></asp:RequiredFieldValidator>&nbsp;&nbsp; <asp:TextBox type="password" ID="passwordTxt" placeholder="Password" runat="server" /><img src=""></p>
            <asp:Button ID="Submit" runat="server" Text=" Sign In " OnClick="Submit_Click" />
            </center>
            </strong>
        </div>
    </form>
</body>
</html>
