<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Start.aspx.cs" Inherits="WebApplication1.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>About</title>
    <link href="Style.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            width: 411px;
            height: 123px;
        }
        .auto-style2 {
            float: right;
            font-size: 24;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <img class="auto-style1" src="images/MMCL%20Logo.png"/><div class="center">
                <h2>About Mapua MCL Evaluation Form</h2>
                <br />
                <p>Lorem Ipsum</p>
            </div>
            <asp:Button ID="LogIn" runat="server" Text=" Sign In " OnClick="Submit_Click" CssClass="auto-style2" Height="38px" Width="197px"/>
        </div>
    </form>
</body>
</html>
