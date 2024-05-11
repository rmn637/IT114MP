<%@ Page Title="Agreement Faculty" Language="C#" MasterPageFile="~/Child.Master" AutoEventWireup="true" CodeBehind="FA.aspx.cs" Inherits="WebApplication1.AgreementFaculty" %>
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
    <div class="center">
        <center>
            <h2>Performance Agreement Survey for Faculty Members</h2>
                <table>
                    <tr id="trbc">
                        <td>Name of Employee</td>
                        <td>Position</td>
                        <td>College/Department</td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lblEmpName" runat="server"></asp:Label></td>
                        <td><asp:Label ID="lblPos" runat="server"></asp:Label></td>
                        <td><asp:Label ID="lblDept" runat="server"></asp:Label></td>
                    </tr>
                    <tr id="trbc">
                        <td class="auto-style1">Name of Rater</td>
                        <td class="auto-style1">Appraisal Period</td>
                        <td class="auto-style1">Date Prepared</td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lblRaterName" runat="server"></asp:Label></td>
                        <td><asp:Label ID="lblAppraisal" runat="server" Text="-- -- ----" ></asp:Label></td>
                        <td><asp:Label ID="lblDatePrep" runat="server"></asp:Label></td>
                    </tr>
                </table>
                </center>
            <br />
            <center>
                <br />
            <%--<div id ="section3" width="80%" style="text-align:center">
                    <center> 
                    <table class="auto-style2">
                        <tr>
                            <td style="background-color: #C0C0C0"><strong>SECTION 3</strong></td>
                        </tr>
                        <tr>
                            <td class="auto-style8">STRENGTH</td>
                        </tr>
                        <tr>
                            <td class="auto-style8">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style8">AREAS OF IMPROVEMENT</td>
                            </tr>
                        <tr>
                            <td class="auto-style8">&nbsp;</td>
                            </tr>
                        <tr>
                            <td class="auto-style8">DEVELOPMENT PLANS (PLEASE SPECIFY TARGET DATE)</td>
                            </tr>
                        <tr>
                            <td class="auto-style8">
                                <asp:TextBox ID="TextBox3" runat="server" Width="1005px"></asp:TextBox>
                            </td>
                            </tr>
                        <tr>
                            <td class="auto-style8">EMPLOYEE&#39;S COMMENTS/ACKNOWLEDGEMENT</td>
                            </tr>
                        <tr>
                            <td class="auto-style8">&nbsp;</td>
                            </tr>
                        </table>
                    </div>--%>
                <br />
            <asp:Button ID="Submit" runat="server" Text="Create Agreement" OnClick="EvaluateBtn_Click"/>
            <asp:Button ID="View" runat="server" Text="View Agreement" OnClick="ViewBtn_Click" Enabled ="false" Visible ="false"/>
            </div>
         </center>
</asp:Content>
