﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AgreementStaff.aspx.cs" Inherits="WebApplication1.AgreementStaff" %>
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
        <asp:Button ID="EvaluateBtn" runat="server" Text="Create Agreement" OnClick="EvaluateBtn_Click" />
    </div>    
</asp:Content>
    
