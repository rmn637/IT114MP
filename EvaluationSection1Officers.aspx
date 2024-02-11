<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EvaluationSection1Officers.aspx.cs" Inherits="WebApplication1.EvaluationSection1Officers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <style type="text/css">
        .auto-style2 {
            width: 80%;
                              
        }
        .auto-style3 {
            width: 914px;
        }
        .auto-style5 {
            width: 102px;
        }
        .auto-style6 {
            width: 914px;
            text-align: left;
        }
        .auto-style9 {
            width: 101px;
        }
        .auto-style18 {
            width: 104px;
        }
        .auto-style20 {
            width: 296px;
            text-align: left;
        }
        .auto-style21 {
            width: 296px;
            text-align: left;
            height: 22px;
        }
        .auto-style22 {
            width: 914px;
            text-align: right;
            height: 22px;
        }
        .auto-style23 {
            width: 104px;
            height: 22px;
        }
        .auto-style24 {
            width: 223px;
            height: 22px;
        }
        .auto-style25 {
            height: 22px;
                width: 149px;
            }
        .auto-style27 {
            width: 914px;
            text-align: center;
        }
        .auto-style30 {
            width: 223px;
        }
        .auto-style31 {
            width: 149px;
        }
        .auto-style33 {
            width: 86px;
        }
        .auto-style34 {
            width: 154px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
    <br />
    <div class="navbar" id="navibar">
        <asp:LinkButton ID="btnSection1" runat="server" Enabled="false">Section 1</asp:LinkButton> &nbsp; &nbsp; &nbsp;
        <asp:LinkButton ID="btnSection2" runat="server" OnClick="checkWeight">Section 2</asp:LinkButton> &nbsp; &nbsp; &nbsp;
        <asp:LinkButton ID="btnSection3" runat="server" OnClick="checkWeight">Section 3</asp:LinkButton> &nbsp; &nbsp; &nbsp;
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="checkWeight">Section 4</asp:LinkButton> &nbsp; &nbsp; &nbsp;
        <asp:LinkButton ID="btnOverall" runat="server" OnClick="checkWeight">Overall</asp:LinkButton>
    </div>
        <table class="auto-style2">
            <tr>
                <td colspan="5" style="background-color: #C0C0C0"><strong>SECTION 1: INSTITUTIONAL OBJECTIVES</strong></td>
            </tr>
            <tr>
                <td colspan="5"><strong>KRA 1</strong></td>
            </tr>
            <tr>
                <td class="auto-style20">Key Initiative</td>
                <td class="auto-style27">
                    <asp:Label ID="initiative1" runat="server" Width="528px" MaxLength="256"></asp:Label>
                </td>
                <td class="auto-style9">W</td>
                <td class="auto-style30">R</td>
                <td class="auto-style31">WS</td>
            </tr>
            <tr>
                <td class="auto-style20">Specific Objectives</td>
                <td class="auto-style6">
                    <asp:Label ID="objectives1" runat="server" Width="528px" MaxLength="256"></asp:Label>
                </td>
                <td class="auto-style18">
                    <asp:Label ID="weight1_1" runat="server" AutoPostBack="True" Height="18px" TextMode="Number" Width="91px">0</asp:Label>
                </td>
                <td class="auto-style30">
                        <asp:TextBox ID="rating1_1" runat="server" AutoPostBack="True" Height="18px" TextMode="Number" Width="91px" OnTextChanged="rating1_TextChanged">0</asp:TextBox>
                    </td>
                <td class="auto-style31">
                    <asp:Label ID="label1_1" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="5"><strong>KRA 2</strong></td>
            </tr>
            <tr>
                <td class="auto-style20">Key Initiative</td>
                <td class="auto-style3">
                    <asp:Label ID="initiative2" runat="server" Width="528px" MaxLength="256"></asp:Label>
                </td>
                <td class="auto-style9">W</td>
                <td class="auto-style30">R</td>
                <td class="auto-style31">WS</td>
            </tr>
            <tr>
                <td class="auto-style20">Specific Objectives</td>
                <td class="auto-style6">
                    <asp:Label ID="objectives2" runat="server" Width="528px" MaxLength="256"></asp:Label>
                </td>
                <td class="auto-style18">
                    <asp:Label ID="weight1_2" runat="server" AutoPostBack="True" Height="18px" TextMode="Number" Width="91px">0</asp:Label>
                </td>
                <td class="auto-style30">
                        <asp:TextBox ID="rating1_2" runat="server" AutoPostBack="True" Height="18px" TextMode="Number" Width="91px" OnTextChanged="rating1_TextChanged">0</asp:TextBox>
                    </td>
                <td class="auto-style31">
                    <asp:Label ID="label1_2" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="5"><strong>KRA 3</strong></td>
            </tr>
            <tr>
                <td class="auto-style20">Key Initiative</td>
                <td class="auto-style3">
                    <asp:Label ID="initiative3" runat="server" Width="528px" MaxLength="256"></asp:Label>
                </td>
                <td class="auto-style9">W</td>
                <td class="auto-style30">R</td>
                <td class="auto-style31">WS</td>
            </tr>
            <tr>
                <td class="auto-style20">Specific Objectives</td>
                <td class="auto-style6">
                    <asp:Label ID="objectives3" runat="server" Width="528px" MaxLength="256"></asp:Label>
                </td>
                <td class="auto-style18">
                    <asp:Label ID="weight1_3" runat="server" AutoPostBack="True" Height="18px" TextMode="Number" Width="91px">0</asp:Label>
                </td>
                <td class="auto-style30">
                        <asp:TextBox ID="rating1_3" runat="server" AutoPostBack="True" Height="18px" TextMode="Number" Width="91px" OnTextChanged="rating1_TextChanged">0</asp:TextBox>
                    </td>
                <td class="auto-style31">
                    <asp:Label ID="label1_3" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="5"><strong>KRA 4</strong></td>
            </tr>
            <tr>
                <td class="auto-style20">Key Initiative</td>
                <td class="auto-style3">
                    <asp:Label ID="initiative4" runat="server" Width="528px" MaxLength="256"></asp:Label>
                </td>
                <td class="auto-style9">W</td>
                <td class="auto-style30">R</td>
                <td class="auto-style31">WS</td>
            </tr>
            <tr>
                <td class="auto-style20">Specific Objectives</td>
                <td class="auto-style6">
                    <asp:Label ID="objectives4" runat="server" Width="528px" MaxLength="256"></asp:Label>
                </td>
                <td class="auto-style18">
                    <asp:Label ID="weight1_4" runat="server" AutoPostBack="True" Height="18px" TextMode="Number" Width="91px">0</asp:Label>
                </td>
                <td class="auto-style30">
                        <asp:TextBox ID="rating1_4" runat="server" AutoPostBack="True" Height="18px" TextMode="Number" Width="91px" OnTextChanged="rating1_TextChanged">0</asp:TextBox>
                    </td>
                <td class="auto-style31">
                    <asp:Label ID="label1_4" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="5"><strong>KRA 5</strong></td>
            </tr>
            <tr>
                <td class="auto-style20">Key Initiative</td>
                <td class="auto-style3">
                    <asp:Label ID="initiative5" runat="server" Width="528px" MaxLength="256"></asp:Label>
                </td>
                <td class="auto-style9">W</td>
                <td class="auto-style30">R</td>
                <td class="auto-style31">WS</td>
            </tr>
            <tr>
                <td class="auto-style20">Specific Objectives</td>
                <td class="auto-style6">
                    <asp:Label ID="objectives5" runat="server" Width="528px" MaxLength="256"></asp:Label>
                </td>
                <td class="auto-style18">
                    <asp:Label ID="weight1_5" runat="server" AutoPostBack="True" Height="18px" TextMode="Number" Width="91px">0</asp:Label>
                </td>
                <td class="auto-style30">
                        <asp:TextBox ID="rating1_5" runat="server" AutoPostBack="True" Height="18px" TextMode="Number" Width="91px" OnPreRender="rating1_TextChanged">0</asp:TextBox>
                    </td>
                <td class="auto-style31">
                    <asp:Label ID="label1_5" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="5"><strong>KRA 6</strong></td>
            </tr>
            <tr>
                <td class="auto-style20">Key Initiative</td>
                <td class="auto-style3">
                    <asp:Label ID="initiative6" runat="server" Width="528px" MaxLength="256"></asp:Label>
                </td>
                <td class="auto-style9">W</td>
                <td class="auto-style30">R</td>
                <td class="auto-style31">WS</td>
            </tr>
            <tr>
                <td class="auto-style20">Specific Objectives</td>
                <td class="auto-style6">
                    <asp:Label ID="objectives6" runat="server" Width="528px" MaxLength="256"></asp:Label>
                </td>
                <td class="auto-style18">
                    <asp:Label ID="weight1_6" runat="server" AutoPostBack="True" Height="18px" TextMode="Number" Width="91px">0</asp:Label>
                </td>
                <td class="auto-style30">
                        <asp:TextBox ID="rating1_6" runat="server" AutoPostBack="True" Height="18px" TextMode="Number" Width="91px" OnPreRender="rating1_TextChanged">0</asp:TextBox>
                    </td>
                <td class="auto-style31">
                    <asp:Label ID="label1_6" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style21" style="border-style: none"></td>
                <td class="auto-style22" style="border-style: none">&nbsp;</td>
                <td class="auto-style23" style="border-style: none">
                    &nbsp;</td>
                <td class="auto-style24" style="border-style: none">TOTAL</td>
                <td style="border-style: none" class="auto-style25">
                    <asp:Label ID="labelTotal1" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
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
                <td class="auto-style6">Notes/Critical Incidents: </td>
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
                <td class="auto-style6">Notes/Critical Incidents:</td>
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
                <td class="auto-style6">Notes/Critical Incidents:</td>
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
                <td class="auto-style6">Notes/Critical Incidents:</td>
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
