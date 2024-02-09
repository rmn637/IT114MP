<%@ Page Title="Evaluation Form" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EvaluationStaff.aspx.cs" Inherits="WebApplication1.WebForm5" MaintainScrollPositionOnPostback="true"%>
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
    <div class="center">
    <center>
        <h2>Performance Evaluation Survey for Staff</h2>
            <table>
                <tr id="trbc">
                    <td>Name of Employee</td>
                    <td>Position</td>
                    <td>College/Department</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr id="trbc">
                    <td class="auto-style1">Name of Rater</td>
                    <td class="auto-style1">Appraisal Period</td>
                    <td class="auto-style1">Date Prepared</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            </center>
        <br />
        <center>
        <br />
    <asp:Button ID="EvaluateBtn" runat="server" Text="Evaluate" OnClick="EvaluateBtn_Click" />
</div>    
        <%--<div class="section" id="page3" width="80%" style="text-align:center">
            <center>
                <div class="navbar">
                    <a href="javascript:void(0)" onclick="page1()">Section 1</a> &nbsp; &nbsp; &nbsp;
                    <a href="javascript:void(0)" onclick="page2()">Section 2</a> &nbsp; &nbsp; &nbsp;
                    <a href="javascript:void(0)" onclick="page3()">Section 3</a> &nbsp; &nbsp; &nbsp;
                    <a href="javascript:void(0)" onclick="overall()">Overall</a>
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
                        <td class="auto-style8">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style8">EMPLOYEE&#39;S COMMENTS/ACKNOWLEDGEMENT</td>
                    </tr>
                    <tr>
                        <td class="auto-style8">&nbsp;</td>
                    </tr>
                </table>
            </center>
        </div>
        <br />
        <div class="section" id ="overall" width="30%" style="text-align:center">
            <center>
                <div class="navbar">
                    <a href="javascript:void(0)">Section 1</a> &nbsp; &nbsp; &nbsp;
                    <a href="javascript:void(0)">Section 2</a> &nbsp; &nbsp; &nbsp;
                    <a href="javascript:void(0)">Section 3</a> &nbsp; &nbsp; &nbsp;
                    <a href="javascript:void(0)">Overall</a>
                </div>
                <table width ="25%">
                    <tr>    
                        <td style="background-color: #C0C0C0" colspan="3"><strong>OVERALL</strong></td>
                        <br />
                        <br />
                    </tr>
                    <tr>
                        <td class="auto-style17"><strong>SECTION 1</strong></td>
                        <td class="auto-style9">50%</td>
                        <td class="auto-style9">
                            <asp:Label ID="sectionTotal_1" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style17"><strong>SECTION 2</strong></td>
                        <td class="auto-style9">50%</td>
                        <td class="auto-style9">
                            <asp:Label ID="sectionTotal_2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style17">&nbsp;</td>
                        <td class="auto-style9">100%</td>
                        <td class="auto-style9">
                            <asp:Label ID="sectionTotal_3" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style16" colspan="2"><strong>TOTAL OVERALL PERFORMANCE POINTS</strong></td>
                        <td class="auto-style9">
                            <asp:Label ID="sectionTotal_4" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            
            <asp:Button ID="Submit" runat="server" Text=" Submit "/>
                <br />
            </center>
        </div>--%>
<%--    </center>--%>
            
</asp:Content>
