<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EvaluationSection2Officers.aspx.cs" Inherits="WebApplication1.EvaluationSection2Officers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style2 {
        width: 80%;
    }
    .auto-style6 {
        width: 914px;
        text-align: left;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <center>
            <div class="navbar" id="navibar">
                <asp:LinkButton ID="btnSection1" runat="server" OnClick="checkWeight">Section 1</asp:LinkButton> &nbsp; &nbsp; &nbsp;
                <asp:LinkButton ID="btnSection2" runat="server" Enabled="false">Section 2</asp:LinkButton> &nbsp; &nbsp; &nbsp;
                <asp:LinkButton ID="btnSection3" runat="server" OnClick="checkWeight">Section 3</asp:LinkButton> &nbsp; &nbsp; &nbsp;
                <asp:LinkButton ID="btnSection4" runat="server" OnClick="checkWeight">Section 4</asp:LinkButton> &nbsp; &nbsp; &nbsp;
                <asp:LinkButton ID="btnSection5" runat="server" OnClick="checkWeight">Section 5</asp:LinkButton> &nbsp; &nbsp; &nbsp;
                <asp:LinkButton ID="btnOverall" runat="server" OnClick="checkWeight">Overall</asp:LinkButton>
            </div>
            <br />
            <br />
            <table class="auto-style2">
                <tr>
                    <td colspan="4" style="background-color: #C0C0C0"><strong>SECTION 2: GOVERNANCE, RISK MANAGEMENT AND CONTROL (GRC): Adherence to governance principles to ensure the continuin effectiveness of governance arrangements and take opportunities and counter threats through effective risk management and internal control. To be able to contribute strongly to meeting organizational objectives in respective assigned areas.</strong></td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="scope1" runat="server" Width="528px"></asp:Label>
                    </td>
                    <td class="auto-style5">W</td>
                    <td class="auto-style34">R</td>
                    <td class="auto-style33">WS</td>
                </tr>
                <tr>
                    <td class="auto-style6">Notes/Critical Incidents: 
                        <asp:TextBox ID="notes1" runat="server" MaxLength="50" Width="496px"></asp:TextBox>
                    </td>
                    <td class="auto-style5">
                        <asp:Label ID="weight2_1" runat="server" AutoPostBack="True" Height="18px" TextMode="Number" Width="91px">0</asp:Label>
                    </td>
                    <td class="auto-style34">
                            <asp:TextBox ID="rating2_1" runat="server" AutoPostBack="True" Height="18px" TextMode="Number" Width="91px">0</asp:TextBox>
                        </td>
                    <td class="auto-style33">
                        <asp:Label ID="label2_1" runat="server" Text="0"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="scope2" runat="server" Width="528px"></asp:Label>
                    </td>
                    <td class="auto-style5">W</td>
                    <td class="auto-style34">R</td>
                    <td class="auto-style33">WS</td>
                </tr>
                <tr>
                    <td class="auto-style6">Notes/Critical Incidents:<asp:TextBox ID="notes2" runat="server" MaxLength="50" Width="496px"></asp:TextBox>
                    </td>
                    <td class="auto-style5">
                        <asp:Label ID="weight2_2" runat="server" AutoPostBack="True" Height="18px" TextMode="Number" Width="91px">0</asp:Label>
                    </td>
                    <td class="auto-style34">
                            <asp:TextBox ID="rating2_2" runat="server" AutoPostBack="True" Height="18px" TextMode="Number" Width="91px">0</asp:TextBox>
                        </td>
                    <td class="auto-style33">
                        <asp:Label ID="label2_2" runat="server" Text="0"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="scope3" runat="server" Width="528px"></asp:Label>
                    </td>
                    <td class="auto-style5">W</td>
                    <td class="auto-style34">R</td>
                    <td class="auto-style33">WS</td>
                </tr>
                <tr>
                    <td class="auto-style6">Notes/Critical Incidents:<asp:TextBox ID="notes3" runat="server" MaxLength="50" Width="496px"></asp:TextBox>
                    </td>
                    <td class="auto-style5">
                        <asp:Label ID="weight2_3" runat="server" AutoPostBack="True" Height="18px" TextMode="Number" Width="91px">0</asp:Label>
                    </td>
                    <td class="auto-style34">
                            <asp:TextBox ID="rating2_3" runat="server" AutoPostBack="True" Height="18px" TextMode="Number" Width="91px">0</asp:TextBox>
                        </td>
                    <td class="auto-style33">
                        <asp:Label ID="label2_3" runat="server" Text="0"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="scope4" runat="server" Width="528px"></asp:Label>
                    </td>
                    <td class="auto-style5">W</td>
                    <td class="auto-style34">R</td>
                    <td class="auto-style33">WS</td>
                </tr>
                <tr>
                    <td class="auto-style6">Notes/Critical Incidents:<asp:TextBox ID="notes4" runat="server" MaxLength="50" Width="496px"></asp:TextBox>
                    </td>
                    <td class="auto-style5">
                        <asp:Label ID="weight2_4" runat="server" AutoPostBack="True" Height="18px" TextMode="Number" Width="91px">0</asp:Label>
                    </td>
                    <td class="auto-style34">
                            <asp:TextBox ID="rating2_4" runat="server" AutoPostBack="True" Height="18px" TextMode="Number" Width="91px">0</asp:TextBox>
                        </td>
                    <td class="auto-style33">
                        <asp:Label ID="label2_4" runat="server" Text="0"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6" style="border-style: none">&nbsp;</td>
                    <td class="auto-style5" style="border-style: none">
                        &nbsp;</td>
                    <td class="auto-style34" style="border-style: none">TOTAL</td>
                    <td style="border-style: none" class="auto-style33">
                        <asp:Label ID="labelTotal2" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
    </center>
</asp:Content>
