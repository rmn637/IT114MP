<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AgreementOfficers.aspx.cs" Inherits="WebApplication1.AgreementOfficers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 30px;
        }
        .auto-style2 {
            width: 80%;
                              
        }
        .auto-style3 {
            width: 914px;
        }
        .auto-style4 {
            width: 98px;
        }
        .auto-style5 {
            width: 102px;
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
        .auto-style26 {
            text-align: left;
            height: 24px;
        }
        .auto-style27 {
            width: 914px;
            text-align: center;
        }
        .auto-style28 {
            width: 69px;
        }
        .auto-style30 {
            width: 223px;
        }
        .auto-style31 {
            width: 149px;
        }
        .auto-style32 {
            width: 65px;
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
    <h2>Performance Evaluation Survey for Officers</h2>
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
        <tr id="trbc0">
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
    <div id ="section1" width="80%" style="text-align:center">
        <center>
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
                        <asp:TextBox ID="TextBox18" runat="server" Width="528px"></asp:TextBox>
                    </td>
                    <td class="auto-style9">W</td>
                    <td class="auto-style30">R</td>
                    <td class="auto-style31">WS</td>
                </tr>
                <tr>
                    <td class="auto-style20">Specific Objectives</td>
                    <td class="auto-style6">
                        <asp:TextBox ID="TextBox17" runat="server" Width="528px"></asp:TextBox>
                    </td>
                    <td class="auto-style18">
                        <asp:TextBox ID="weight1_1" runat="server" AutoPostBack="True" Height="18px" TextMode="Number" Width="91px" OnTextChanged="weight_TextChanged1">0</asp:TextBox>
                    </td>
                    <td class="auto-style30">
                        &nbsp;</td>
                    <td class="auto-style31">
                        <asp:Label ID="label1_A" runat="server" Text="0"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="5"><strong>KRA 2</strong></td>
                </tr>
                <tr>
                    <td class="auto-style20">Key Initiative</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="TextBox19" runat="server" Width="528px"></asp:TextBox>
                    </td>
                    <td class="auto-style9">W</td>
                    <td class="auto-style30">R</td>
                    <td class="auto-style31">WS</td>
                </tr>
                <tr>
                    <td class="auto-style20">Specific Objectives</td>
                    <td class="auto-style6">
                        <asp:TextBox ID="TextBox20" runat="server" Width="528px"></asp:TextBox>
                    </td>
                    <td class="auto-style18">
                        <asp:TextBox ID="weight1_2" runat="server" AutoPostBack="True" Height="18px" TextMode="Number" Width="91px" OnTextChanged="weight_TextChanged1">0</asp:TextBox>
                    </td>
                    <td class="auto-style30">
                        &nbsp;</td>
                    <td class="auto-style31">
                        <asp:Label ID="label1_A0" runat="server" Text="0"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="5"><strong>KRA 3</strong></td>
                </tr>
                <tr>
                    <td class="auto-style20">Key Initiative</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="TextBox21" runat="server" Width="528px"></asp:TextBox>
                    </td>
                    <td class="auto-style9">W</td>
                    <td class="auto-style30">R</td>
                    <td class="auto-style31">WS</td>
                </tr>
                <tr>
                    <td class="auto-style20">Specific Objectives</td>
                    <td class="auto-style6">
                        <asp:TextBox ID="TextBox22" runat="server" Width="528px"></asp:TextBox>
                    </td>
                    <td class="auto-style18">
                        <asp:TextBox ID="weight1_3" runat="server" AutoPostBack="True" Height="18px" TextMode="Number" Width="91px" OnTextChanged="weight_TextChanged1">0</asp:TextBox>
                    </td>
                    <td class="auto-style30">
                        &nbsp;</td>
                    <td class="auto-style31">
                        <asp:Label ID="label1_A1" runat="server" Text="0"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="5"><strong>KRA 4</strong></td>
                </tr>
                <tr>
                    <td class="auto-style20">Key Initiative</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="TextBox23" runat="server" Width="528px"></asp:TextBox>
                    </td>
                    <td class="auto-style9">W</td>
                    <td class="auto-style30">R</td>
                    <td class="auto-style31">WS</td>
                </tr>
                <tr>
                    <td class="auto-style20">Specific Objectives</td>
                    <td class="auto-style6">
                        <asp:TextBox ID="TextBox24" runat="server" Width="528px"></asp:TextBox>
                    </td>
                    <td class="auto-style18">
                        <asp:TextBox ID="weight1_4" runat="server" AutoPostBack="True" Height="18px" TextMode="Number" Width="91px" OnTextChanged="weight_TextChanged1">0</asp:TextBox>
                    </td>
                    <td class="auto-style30">
                        &nbsp;</td>
                    <td class="auto-style31">
                        <asp:Label ID="label1_A2" runat="server" Text="0"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="5"><strong>KRA 5</strong></td>
                </tr>
                <tr>
                    <td class="auto-style20">Key Initiative</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="TextBox25" runat="server" Width="528px"></asp:TextBox>
                    </td>
                    <td class="auto-style9">W</td>
                    <td class="auto-style30">R</td>
                    <td class="auto-style31">WS</td>
                </tr>
                <tr>
                    <td class="auto-style20">Specific Objectives</td>
                    <td class="auto-style6">
                        <asp:TextBox ID="TextBox26" runat="server" Width="528px"></asp:TextBox>
                    </td>
                    <td class="auto-style18">
                        <asp:TextBox ID="weight1_5" runat="server" AutoPostBack="True" Height="18px" TextMode="Number" Width="91px" OnTextChanged="weight_TextChanged1">0</asp:TextBox>
                    </td>
                    <td class="auto-style30">
                        &nbsp;</td>
                    <td class="auto-style31">
                        <asp:Label ID="label1_A3" runat="server" Text="0"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="5"><strong>KRA 6</strong></td>
                </tr>
                <tr>
                    <td class="auto-style20">Key Initiative</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="TextBox27" runat="server" Width="528px"></asp:TextBox>
                    </td>
                    <td class="auto-style9">W</td>
                    <td class="auto-style30">R</td>
                    <td class="auto-style31">WS</td>
                </tr>
                <tr>
                    <td class="auto-style20">Specific Objectives</td>
                    <td class="auto-style6">
                        <asp:TextBox ID="TextBox28" runat="server" Width="528px"></asp:TextBox>
                    </td>
                    <td class="auto-style18">
                        <asp:TextBox ID="weight1_6" runat="server" AutoPostBack="True" Height="18px" TextMode="Number" Width="91px" OnTextChanged="weight_TextChanged1">0</asp:TextBox>
                    </td>
                    <td class="auto-style30">
                        &nbsp;</td>
                    <td class="auto-style31">
                        <asp:Label ID="label1_A4" runat="server" Text="0"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style21" style="border-style: none"></td>
                    <td class="auto-style22" style="border-style: none">TOTAL</td>
                    <td class="auto-style23" style="border-style: none">
                        <asp:Label ID="labelTotal1" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style24" style="border-style: none"></td>
                    <td style="border-style: none" class="auto-style25">
                        &nbsp;</td>
                </tr>
            </table>
            <br />
        </center>
    </div>
    <div id ="section2">
        <center>
            <table class="auto-style2">
                <tr>
                    <td colspan="4" style="background-color: #C0C0C0"><strong>SECTION 2: GOVERNANCE, RISK MANAGEMENT AND CONTROL (GRC): Adherence to governance principles to ensure the continuin effectiveness of governance arrangements and take opportunities and counter threats through effective risk management and internal control. To be able to contribute strongly to meeting organizational objectives in respective assigned areas.</strong></td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:TextBox ID="TextBox29" runat="server" Width="528px"></asp:TextBox>
                    </td>
                    <td class="auto-style5">W</td>
                    <td class="auto-style34">R</td>
                    <td class="auto-style33">WS</td>
                </tr>
                <tr>
                    <td class="auto-style6">Notes/Critical Incidents:</td>
                    <td class="auto-style5">
                        <asp:TextBox ID="weight2_1" runat="server" AutoPostBack="True" Height="18px" TextMode="Number" Width="91px" OnTextChanged="weight_TextChanged2">0</asp:TextBox>
                    </td>
                    <td class="auto-style34">
                        &nbsp;</td>
                    <td class="auto-style33">
                        <asp:Label ID="label1_1" runat="server" Text="0"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:TextBox ID="TextBox30" runat="server" Width="528px"></asp:TextBox>
                    </td>
                    <td class="auto-style5">W</td>
                    <td class="auto-style34">R</td>
                    <td class="auto-style33">WS</td>
                </tr>
                <tr>
                    <td class="auto-style6">Notes/Critical Incidents:</td>
                    <td class="auto-style5">
                        <asp:TextBox ID="weight2_2" runat="server" AutoPostBack="True" Height="18px" TextMode="Number" Width="91px" OnTextChanged="weight_TextChanged2">0</asp:TextBox>
                    </td>
                    <td class="auto-style34">
                        &nbsp;</td>
                    <td class="auto-style33">
                        <asp:Label ID="label1_6" runat="server" Text="0"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:TextBox ID="TextBox31" runat="server" Width="528px"></asp:TextBox>
                    </td>
                    <td class="auto-style5">W</td>
                    <td class="auto-style34">R</td>
                    <td class="auto-style33">WS</td>
                </tr>
                <tr>
                    <td class="auto-style6">Notes/Critical Incidents:</td>
                    <td class="auto-style5">
                        <asp:TextBox ID="weight2_3" runat="server" AutoPostBack="True" Height="18px" TextMode="Number" Width="91px" OnTextChanged="weight_TextChanged2">0</asp:TextBox>
                    </td>
                    <td class="auto-style34">
                        &nbsp;</td>
                    <td class="auto-style33">
                        <asp:Label ID="label1_7" runat="server" Text="0"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:TextBox ID="TextBox32" runat="server" Width="528px"></asp:TextBox>
                    </td>
                    <td class="auto-style5">W</td>
                    <td class="auto-style34">R</td>
                    <td class="auto-style33">WS</td>
                </tr>
                <tr>
                    <td class="auto-style6">Notes/Critical Incidents:</td>
                    <td class="auto-style5">
                        <asp:TextBox ID="weight2_4" runat="server" AutoPostBack="True" Height="18px" TextMode="Number" Width="91px" OnTextChanged="weight_TextChanged2">0</asp:TextBox>
                    </td>
                    <td class="auto-style34">
                        &nbsp;</td>
                    <td class="auto-style33">
                        <asp:Label ID="label1_8" runat="server" Text="0"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6" style="border-style: none">&nbsp;</td>
                    <td class="auto-style5" style="border-style: none">
                        <asp:Label ID="labelTotal2" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style34" style="border-style: none">&nbsp;</td>
                    <td style="border-style: none" class="auto-style33">
                        &nbsp;</td>
                </tr>
            </table>
        </center>
    </div>
    <br />
    <div id ="section3">
        <table class="auto-style2">
            <tr>
                <td colspan="5" class="auto-style15" style="background-color: #C0C0C0"><strong>SECTION 3: DEMONSTRATION OF YGC CORE VALUES</strong></td>
            </tr>
            <tr>
                <td colspan="2"><strong>PASSION FOR EXCELLENCE</strong></td>
                <td class="auto-style9">W</td>
                <td class="auto-style4">R</td>
                <td class="auto-style28">WS</td>
            </tr>
            <tr>
                <td class="auto-style8" colspan="2">Stiving to be great and not just good. Continuously improving our results.</td>
                <td class="auto-style9">
                    <asp:TextBox ID="weight3_1" runat="server" AutoPostBack="True" Height="18px" TextMode="Number" Width="91px" OnTextChanged="weight_TextChanged3">0</asp:TextBox>
                </td>
                <td class="auto-style4">
                    &nbsp;</td>
                <td class="auto-style28">
                    <asp:Label ID="label7" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">1</td>
                <td class="auto-style8" colspan="4">&nbsp;Does not meet deadlines and standards. Displays low level of effort towards work. Has no concern for quality of products and services and commits numerous mistakes when working.</td>
            </tr>
            <tr>
                <td class="auto-style14">2</td>
                <td class="auto-style8" colspan="4">&nbsp;Works to meet performance standards but standards but sometimes completes tasks beyond deadline or at an unacceptable level.</td>
            </tr>
            <tr>
                <td class="auto-style14">3</td>
                <td class="auto-style8" colspan="4">&nbsp;Meets targets/objectives within set deadlines and at an acceptable level. Keep track of work progress and in cases of deviations, promptly takes corrective actions. Thinks of customer interest and business goals &nbsp;and finds, if not makes a way to fulfill, or even exceed these.</td>
            </tr>
            <tr>
                <td class="auto-style7">4</td>
                <td class="auto-style8" colspan="4">&nbsp;Works to exceed set targets and persists in achieving a standard of excellence that goes beyond expectations. Makes specific changes in work methods or operations to improve performance.</td>
            </tr>
            <tr>
                <td class="auto-style7">5</td>
                <td class="auto-style8" colspan="4">&nbsp;Leads/motivates teammates in attaining or exceeding targets/objectives. Analyzes performance information to predict emerging issues and patterns. Takes calculated risks.</td>
            </tr>
            <tr>
                <td colspan="2"><strong>SENSE OF URGENCY</strong></td>
                <td class="auto-style9">W</td>
                <td class="auto-style4">R</td>
                <td class="auto-style28">WS</td>
            </tr>
            <tr>
                <td class="auto-style8" colspan="2">Doing things fast. Taking initiative to respond to needs of various stakeholders.</td>
                <td class="auto-style9">
                    <asp:TextBox ID="weight3_2" runat="server" AutoPostBack="True" Height="18px" TextMode="Number" Width="91px" OnTextChanged="weight_TextChanged3">0</asp:TextBox>
                </td>
                <td class="auto-style4">
                    &nbsp;</td>
                <td class="auto-style28">
                    <asp:Label ID="label8" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">1</td>
                <td class="auto-style8" colspan="4">&nbsp;Works at his own pace. Requires prodding and requires constant reminder for tasks to be completed.</td>
            </tr>
            <tr>
                <td class="auto-style14">2</td>
                <td class="auto-style8" colspan="4">&nbsp;Responds to internal/external customer requests/complaints but may require regular monitoring of work by superior.</td>
            </tr>
            <tr>
                <td class="auto-style14">3</td>
                <td class="auto-style8" colspan="4">&nbsp;Responds/reacts immediately to internal/external customer requests/complaints without being reminded by superior re: deliverables.Prioritizes activities purposively. Does not procrastinate on things that need to &nbsp;be done today.</td>
            </tr>
            <tr>
                <td class="auto-style7">4</td>
                <td class="auto-style8" colspan="4">&nbsp;Acts independently to bring issues to closure. Performs tasks at a fast pace without sacrificing quality. With "fire in the belly": energetic and enthusiastic in meeting work requirements.</td>
            </tr>
            <tr>
                <td class="auto-style7">5</td>
                <td class="auto-style8" colspan="4">&nbsp;Motivates and enables teammates to bring issues to prompt closure. Anticipates hindrances and plans alternative courses of action by encouraging and/or enabling others to support the plan.</td>
            </tr>
            <tr>
                <td colspan="2"><strong>PROFESSIONAL DISCIPLINE</strong></td>
                <td class="auto-style9">W</td>
                <td class="auto-style4">R</td>
                <td class="auto-style28">WS</td>
            </tr>
            <tr>
                <td class="auto-style8" colspan="2">Strong work ethic. Deserving of trust and respect. Prudent use of company resources, including time. Acting with fairness and objectivity.</td>
                <td class="auto-style9">
                    <asp:TextBox ID="weight3_3" runat="server" AutoPostBack="True" Height="18px" TextMode="Number" Width="91px" OnTextChanged="weight_TextChanged3">0</asp:TextBox>
                </td>
                <td class="auto-style4">
                    &nbsp;</td>
                <td class="auto-style28">
                    <asp:Label ID="label9" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">1</td>
                <td class="auto-style8" colspan="4">&nbsp;&nbsp;Dishonest and/or wasteful. Authorities of others are frequently undermined. Makes decisions in a self-serving fashion.</td>
            </tr>
            <tr>
                <td class="auto-style14">2</td>
                <td class="auto-style8" colspan="4">&nbsp;Provides questionable excuses/xeplanations when confronted. Has a problem with maintaining confidentiality. Often observed to prioritize personal convenience over organization/work requirements.</td>
            </tr>
            <tr>
                <td class="auto-style14">3</td>
                <td class="auto-style8" colspan="4">&nbsp;Trustworthy with information and use of resources. Uses good judgement in maintaining confidentiality. Refrains from gossip/rumor-mill. Keeps well within company policies</td>
            </tr>
            <tr>
                <td class="auto-style7">4</td>
                <td class="auto-style8" colspan="4">&nbsp;Trusted to hold highly confidential information and manage contentious resources. When confronted with Issues , chooses ethical course in the face of pressure. Able totake unpopular stands when needed. Does what he says and says what he does.</td>
            </tr>
            <tr>
                <td class="auto-style7">5</td>
                <td class="auto-style8" colspan="4">&nbsp;Proactively takes extraordinary steps to ensure personal and organizational integrity. Has an impeccable track record of ethical conduct.Takes responsibility for his decisions, irrespective of consequences. Prudent and judicious in handling information and managing organizational resources under his care.</td>
            </tr>
            <tr>
                <td colspan="2"><strong>TEAMWORK </strong></td>
                <td class="auto-style9">W</td>
                <td class="auto-style4">R</td>
                <td class="auto-style28">WS</td>
            </tr>
            <tr>
                <td class="auto-style8" colspan="2">Actively tapping areas of synergy. Communicating and collaborating towards common goals.</td>
                <td class="auto-style9">
                    <asp:TextBox ID="weight3_4" runat="server" AutoPostBack="True" Height="18px" TextMode="Number" Width="91px" OnTextChanged="weight_TextChanged3">0</asp:TextBox>
                </td>
                <td class="auto-style4">
                    &nbsp;</td>
                <td class="auto-style28">
                    <asp:Label ID="label10" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">1</td>
                <td class="auto-style8" colspan="4">&nbsp;Withdrawn. Openly critical of other's suggestions Does not freely cooperate with others.</td>
            </tr>
            <tr>
                <td class="auto-style14">2</td>
                <td class="auto-style8" colspan="4">&nbsp;Communicates limitedly. Has the tendency to prefer warking alone rather than in a group setting. Cooperates w/ others but w/ reservation.</td>
            </tr>
            <tr>
                <td class="auto-style14">3</td>
                <td class="auto-style8" colspan="4">&nbsp;Works well in a team environment. Open to, or seeks out, opportunities for synergy. Willingly takes on whatever team role he is called upon to play. Actively &nbsp;participates in group deliberations and supports group decision even when this is not his original choice.</td>
            </tr>
            <tr>
                <td class="auto-style7">4</td>
                <td class="auto-style8" colspan="4">&nbsp;Strengthens team spirit by encouraging everyone to contribute. Focuses on the strengths & not the weakness of others. Speaks highly of team members to promote &nbsp;a friendly climate and strong morale. Shows confidence in others, recognizes their ability to meet expectations and to contribute effectively to the team's duties.</td>
            </tr>
            <tr>
                <td class="auto-style7">5</td>
                <td class="auto-style8" colspan="4">&nbsp;Acts as a catalyst in the team's vibrancy. Freely shares his expertise with his teammates. Carries his own load while helping others with theirs, as needed. Is not &nbsp;bothered as to who gets the credit, so long as things are done also respects & appreciates the similarities & differences among co-workers and demonstrates model &nbsp;behavior for working with diverse populations</td>
            </tr>
            <tr>
                <td colspan="2"><strong>LOYALTY</strong></td>
                <td class="auto-style9">W</td>
                <td class="auto-style4">R</td>
                <td class="auto-style28">WS</td>
            </tr>
            <tr>
                <td class="auto-style8" colspan="2">Being good corporate citizens. Pursuing corporate interests as his own. Speaking well of the company and taking pride of its achievements.</td>
                <td class="auto-style9">
                    <asp:TextBox ID="weight3_5" runat="server" AutoPostBack="True" Height="18px" TextMode="Number" Width="91px" OnTextChanged="weight_TextChanged3">0</asp:TextBox>
                </td>
                <td class="auto-style4">
                    &nbsp;</td>
                <td class="auto-style28">
                    <asp:Label ID="label11" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">1</td>
                <td class="auto-style8" colspan="4">&nbsp;Doesn't attempt to understand mission, direction, or goals of the organization. Or simply doesn't care where the organization is headed. Observed to be antagonistic toward the organization and/or its officers.</td>
            </tr>
            <tr>
                <td class="auto-style14">2</td>
                <td class="auto-style8" colspan="4">&nbsp;Has basic understanding of organizational goals and directions but requires guidance or regular reminders regarding personal alignment. When issues involving the company arise, takes a passive stance.</td>
            </tr>
            <tr>
                <td class="auto-style14">3</td>
                <td class="auto-style8" colspan="4">&nbsp;Understands organizational goals and directions and supports these. Defends corporate actions to others.</td>
            </tr>
            <tr>
                <td class="auto-style7">4</td>
                <td class="auto-style8" colspan="4">&nbsp;Identifies with organization goals and directions. Willing to make personal sacrifices for the greater good.</td>
            </tr>
            <tr>
                <td class="auto-style7">5</td>
                <td class="auto-style8" colspan="4">&nbsp;Rallies others towards supporting the organization, even when it is not personally convenient to do so. Willing to take tough stance in behalf of the organization.</td>
            </tr>
            <tr>
                <td class="auto-style7" style="border-style: none">&nbsp;</td>
                <td class="auto-style6" style="border-style: none">&nbsp;</td>
                <td class="auto-style9" style="border-style: none">
                    <asp:Label ID="labelTotal3" runat="server"></asp:Label>
                </td>
                <td class="auto-style4" style="border-style: none"><strong>TOTAL</strong></td>
                <td style="border-style: none" class="auto-style28">
                    &nbsp;</td>
            </tr>
        </table>
    </div>
    <br />
    <div id ="section3">
        <table class="auto-style2">
            <tr>
                <td colspan="5" class="auto-style15" style="background-color: #C0C0C0"><strong>SECTION 4: PROFICIENCY / BEHAVIORAL-BASED PERFORMANCE</strong></td>
            </tr>
            <tr>
                <td colspan="2" rowspan="2"><strong>JOB KNOWLEDGE</strong></td>
                <td class="auto-style9">W</td>
                <td class="auto-style4">R</td>
                <td class="auto-style32">WS</td>
            </tr>
            <tr>
                <td class="auto-style9">
                    <asp:TextBox ID="weight4_1" runat="server" AutoPostBack="True" Height="18px" TextMode="Number" Width="91px" OnTextChanged="weight_TextChanged4">0</asp:TextBox>
                </td>
                <td class="auto-style4">
                    &nbsp;</td>
                <td class="auto-style32">
                    <asp:Label ID="label1" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">1</td>
                <td class="auto-style8" colspan="4">&nbsp;Consistently not meeting Job requirements and needing substantially more supervision than should be required of someone with similar job functions and &nbsp;responsibilities. Typically the employee with an I rating has continued not to.</td>
            </tr>
            <tr>
                <td class="auto-style14">2</td>
                <td class="auto-style8" colspan="4">&nbsp;Successfully achieving SOME aspects of the job requirements and expectations and requiring substantial supervision for 2 his/her experlence level and grade. &nbsp;Overall, performance level is below others with similar job functions and responsibilities.</td>
            </tr>
            <tr>
                <td class="auto-style14">3</td>
                <td class="auto-style8" colspan="4">&nbsp;Making a solid contribution In key areas of responsibility with reasonable guidance and supervision. Performance level is at par with others with similar job &nbsp;functions and responsibilities.</td>
            </tr>
            <tr>
                <td class="auto-style14">4</td>
                <td class="auto-style26" colspan="4">&nbsp;Achieving results which exceeds the requirements and expectations of the job in all key areas of responsibility.&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">5</td>
                <td class="auto-style8" colspan="4">&nbsp;Role modeling, very high achievement for his or her experience level and grade.&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2" rowspan="2"><strong>JOB MANAGEMENT</strong></td>
                <td class="auto-style9">W</td>
                <td class="auto-style4">R</td>
                <td class="auto-style32">WS</td>
            </tr>
            <tr>
                <td class="auto-style9">
                    <asp:TextBox ID="weight4_2" runat="server" AutoPostBack="True" Height="18px" TextMode="Number" Width="91px" OnTextChanged="weight_TextChanged4">0</asp:TextBox>
                </td>
                <td class="auto-style4">
                    &nbsp;</td>
                <td class="auto-style32">
                    <asp:Label ID="label14" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">1</td>
                <td class="auto-style8" colspan="4">&nbsp;Consistently performing one or more aspects of the job below expectations for his/her experience level and grade.</td>
            </tr>
            <tr>
                <td class="auto-style14">2</td>
                <td class="auto-style8" colspan="4">&nbsp;Performing below expectations in one or more aspects of the job for his/her experience level and grade.</td>
            </tr>
            <tr>
                <td class="auto-style14">3</td>
                <td class="auto-style8" colspan="4">&nbsp;Performing major aspects of the job well. May at times exceed the standard scope of the job's requirements/expectations.</td>
            </tr>
            <tr>
                <td class="auto-style7">4</td>
                <td class="auto-style8" colspan="4">&nbsp;Performing all aspects of the job well and often exceeding the standard scope of job requirements/expectations.</td>
            </tr>
            <tr>
                <td class="auto-style7">5</td>
                <td class="auto-style8" colspan="4">&nbsp;Consistently exceeding the standaro scope of all job requirements/expectations.</td>
            </tr>
            <tr>
                <td colspan="2" rowspan="2"><strong>WORK DELIVERY</strong></td>
                <td class="auto-style9">W</td>
                <td class="auto-style4">R</td>
                <td class="auto-style32">WS</td>
            </tr>
            <tr>
                <td class="auto-style9">
                    <asp:TextBox ID="weight4_3" runat="server" AutoPostBack="True" Height="18px" TextMode="Number" Width="91px" OnTextChanged="weight_TextChanged4">0</asp:TextBox>
                </td>
                <td class="auto-style4">
                    &nbsp;</td>
                <td class="auto-style32">
                    <asp:Label ID="label15" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">1</td>
                <td class="auto-style8" colspan="4">&nbsp;Requiring repeated intervention or coaching by manager.</td>
            </tr>
            <tr>
                <td class="auto-style14">2</td>
                <td class="auto-style8" colspan="4">&nbsp;Requiring substantial supervisory or managerial follow-up commensurate with the employee's experience level and ability to assume responsibility.</td>
            </tr>
            <tr>
                <td class="auto-style14">3</td>
                <td class="auto-style8" colspan="4">&nbsp;Fulfilling assigned tasks within the required turn-around time.</td>
            </tr>
            <tr>
                <td class="auto-style7">4</td>
                <td class="auto-style8" colspan="4">&nbsp;Working independently in a highly competent and reliable manner, requiring no supervision.</td>
            </tr>
            <tr>
                <td class="auto-style7">5</td>
                <td class="auto-style8" colspan="4">&nbsp;Anticipating potential issues and problems that may arise and working independently in a highly competent and reliable.</td>
            </tr>
            <tr>
                <td colspan="2" rowspan="2"><strong>CREATIVITY</strong></td>
                <td class="auto-style9">W</td>
                <td class="auto-style4">R</td>
                <td class="auto-style32">WS</td>
            </tr>
            <tr>
                <td class="auto-style9">
                    <asp:TextBox ID="weight4_4" runat="server" AutoPostBack="True" Height="18px" TextMode="Number" Width="91px" OnTextChanged="weight_TextChanged4">0</asp:TextBox>
                </td>
                <td class="auto-style4">
                    &nbsp;</td>
                <td class="auto-style32">
                    <asp:Label ID="label16" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">1</td>
                <td class="auto-style8" colspan="4">&nbsp;Consistently falling to apply appropriate problem solving techniques to issues or problems.</td>
            </tr>
            <tr>
                <td class="auto-style14">2</td>
                <td class="auto-style8" colspan="4">&nbsp;Inconsistently applying appropriate problem solving/technical improvements to identified issue.</td>
            </tr>
            <tr>
                <td class="auto-style14">3</td>
                <td class="auto-style8" colspan="4">&nbsp;Able to generate ideas that address existing needs or gaps.</td>
            </tr>
            <tr>
                <td class="auto-style7">4</td>
                <td class="auto-style8" colspan="4">&nbsp;Ability to look beyond the present demands of the job in order to improve work plans, methods or results.</td>
            </tr>
            <tr>
                <td class="auto-style7">5</td>
                <td class="auto-style8" colspan="4">&nbsp;Able to think out of the box and generate ideas to make existing process more efficient.</td>
            </tr>
            <tr>
                <td colspan="2" rowspan="2"><strong>COMMUNICATION WITH OTHERS</strong></td>
                <td class="auto-style9">W</td>
                <td class="auto-style4">R</td>
                <td class="auto-style32">WS</td>
            </tr>
            <tr>
                <td class="auto-style9">
                    <asp:TextBox ID="weight4_5" runat="server" AutoPostBack="True" Height="18px" TextMode="Number" Width="91px" OnTextChanged="weight_TextChanged4">0</asp:TextBox>
                </td>
                <td class="auto-style4">
                    &nbsp;</td>
                <td class="auto-style32">
                    <asp:Label ID="label17" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">1</td>
                <td class="auto-style8" colspan="4">&nbsp;Selecting the "right" words and usage for the context of the conversation (including moral, ethnic and religious differences). Being clear and concise. Formulates thoughts to avoid rambling.</td>
            </tr>
            <tr>
                <td class="auto-style14">2</td>
                <td class="auto-style8" colspan="4">&nbsp;Physically align with others, connecting with them in form and movement. Mindful of posture, facial expressions, and hand gestures.</td>
            </tr>
            <tr>
                <td class="auto-style14">3</td>
                <td class="auto-style8" colspan="4">&nbsp;Is aware of various auditory cues, speaking to others in a manner more akin to their own ways (another form of "matching and mirroring").</td>
            </tr>
            <tr>
                <td class="auto-style7">4</td>
                <td class="auto-style8" colspan="4">&nbsp;Is aware of the emotional state, learning to pause and release negative emotions before attempting to connect with others. Words delivered with pride, anger or fear are rarely well received.</td>
            </tr>
            <tr>
                <td class="auto-style7">5</td>
                <td class="auto-style8" colspan="4">&nbsp;Hold the highest intention for the other person's wellbeing. This requires a unique level of mindfulness generally cultivated through compassion practices. When we are centered in a state of mastery, we're more likely to access this psychic dimension that holds great treasures of Insights into others, helping us communicate with greater ease.</td>
            </tr>
            <tr>
                <td colspan="2" rowspan="2"><strong>INITIATIVE</strong></td>
                <td class="auto-style9">W</td>
                <td class="auto-style4">R</td>
                <td class="auto-style32">WS</td>
            </tr>
            <tr>
                <td class="auto-style9">
                    <asp:TextBox ID="weight4_6" runat="server" AutoPostBack="True" Height="18px" TextMode="Number" Width="91px" OnTextChanged="weight_TextChanged4">0</asp:TextBox>
                </td>
                <td class="auto-style4">
                    &nbsp;</td>
                <td class="auto-style32">
                    <asp:Label ID="label18" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">1</td>
                <td class="auto-style8" colspan="4">&nbsp;Inability or unwillingness to work as part of the team or group and not viewed as a role model.</td>
            </tr>
            <tr>
                <td class="auto-style14">2</td>
                <td class="auto-style8" colspan="4">&nbsp;Difficulty working as part of the team or group and is not viewed as a role model.</td>
            </tr>
            <tr>
                <td class="auto-style14">3</td>
                <td class="auto-style8" colspan="4">&nbsp;Comprehensively doing his work unpromted.</td>
            </tr>
            <tr>
                <td class="auto-style7">4</td>
                <td class="auto-style8" colspan="4">&nbsp;Inspires and encourages co-employees to go the extra mile.</td>
            </tr>
            <tr>
                <td class="auto-style7">5</td>
                <td class="auto-style8" colspan="4">&nbsp;Taking on supplementary responsibilities, and willingly participating in and contributing to highly successful teams, typically becoming the formal or informal team leader.</td>
            </tr>
            <tr>
                <td colspan="2" rowspan="2"><strong>WORK DRIVE</strong></td>
                <td class="auto-style9">W</td>
                <td class="auto-style4">R</td>
                <td class="auto-style32">WS</td>
            </tr>
            <tr>
                <td class="auto-style9">
                    <asp:TextBox ID="weight4_7" runat="server" AutoPostBack="True" Height="18px" TextMode="Number" Width="91px" OnTextChanged="weight_TextChanged4">0</asp:TextBox>
                </td>
                <td class="auto-style4">
                    &nbsp;</td>
                <td class="auto-style32">
                    <asp:Label ID="label19" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">1</td>
                <td class="auto-style8" colspan="4">&nbsp;Consistently late in completing assigned tasks.</td>
            </tr>
            <tr>
                <td class="auto-style14">2</td>
                <td class="auto-style8" colspan="4">&nbsp;Occasionally late in competing assigned tasks.</td>
            </tr>
            <tr>
                <td class="auto-style14">3</td>
                <td class="auto-style8" colspan="4">&nbsp;Completes the assigned tasks within the agreed turn-around time.</td>
            </tr>
            <tr>
                <td class="auto-style7">4</td>
                <td class="auto-style8" colspan="4">&nbsp;Tasks are occasionally completed ahead of greed turn- around time.</td>
            </tr>
            <tr>
                <td class="auto-style7">5</td>
                <td class="auto-style8" colspan="4">&nbsp;Consistently completes the assigned tasks ahead of the agreed turn-around time.</td>
            </tr>
            <tr>
                <td colspan="2" rowspan="2"><strong>OBSERVANCE OF RULES AND REGULATIONS</strong></td>
                <td class="auto-style9">W</td>
                <td class="auto-style4">R</td>
                <td class="auto-style32">WS</td>
            </tr>
            <tr>
                <td class="auto-style9">
                    <asp:TextBox ID="weight4_8" runat="server" AutoPostBack="True" Height="18px" TextMode="Number" Width="91px" OnTextChanged="weight_TextChanged4">0</asp:TextBox>
                </td>
                <td class="auto-style4">
                    &nbsp;</td>
                <td class="auto-style32">
                    <asp:Label ID="label20" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">1</td>
                <td class="auto-style8" colspan="4">&nbsp;Observes rules and regulations when an officer is around.</td>
            </tr>
            <tr>
                <td class="auto-style14">2</td>
                <td class="auto-style8" colspan="4">&nbsp;Shows interest in organizational values, and use it to regulate personal behavior.</td>
            </tr>
            <tr>
                <td class="auto-style14">3</td>
                <td class="auto-style8" colspan="4">&nbsp;Behaves broadiv in line general organizational values.</td>
            </tr>
            <tr>
                <td class="auto-style7">4</td>
                <td class="auto-style8" colspan="4">&nbsp;Ensures all action are taken in the Organization's best interests.&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">5</td>
                <td class="auto-style8" colspan="4">&nbsp;Actively encourages adherence to codes of conduct and ethical principles inherent to "Excellence and Virtue".</td>
            </tr>
            <tr>
                <td class="auto-style7" style="border-style: none">&nbsp;</td>
                <td class="auto-style6" style="border-style: none">&nbsp;</td>
                <td class="auto-style9" style="border-style: none">
                    <asp:Label ID="labelTotal4" runat="server"></asp:Label>
                </td>
                <td class="auto-style4" style="border-style: none"><strong>TOTAL</strong></td>
                <td style="border-style: none" class="auto-style32">
                    &nbsp;</td>
            </tr>
        </table>
    </div>
    <br />
    <%--<div id ="section5" width="80%" style="text-align:center">
        <center>

            <table class="auto-style2">
                <tr>
                    <td style="background-color: #C0C0C0"><strong>SECTION 5</strong></td>
                </tr>
                <tr>
                    <td class="auto-style8">STRENGTH</td>
                </tr>
                <tr>
                    <td class="auto-style8">
                        <asp:TextBox ID="strength" runat="server" Width="1008px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style8">AREAS OF IMPROVEMENT</td>
                </tr>
                <tr>
                    <td class="auto-style8">
                        <asp:TextBox ID="improvement" runat="server" Width="1008px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style8">DEVELOPMENT PLANS (PLEASE SPECIFY TARGET DATE)</td>
                </tr>
                <tr>
                    <td class="auto-style8">
                        <asp:TextBox ID="development" runat="server" Width="1008px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style8">EMPLOYEE&#39;S COMMENTS/ACKNOWLEDGEMENT</td>
                </tr>
                <tr>
                    <td class="auto-style8">
                        <asp:TextBox ID="acknowledgement" runat="server" Width="1008px"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </center>
    </div>--%>
    <br />
<div id ="overall" width="30%" style="text-align:center">
        <center> 
        <table width ="25%">
            <tr>
                <td style="background-color: #C0C0C0" colspan="3"><strong>OVERALL</strong></td>
            </tr>
            <tr>
                <td class="auto-style17"><strong>SECTION 1</strong></td>
                <td class="auto-style9">
                <asp:TextBox ID="totalWeight_1" runat="server" AutoPostBack="True" Height="18px" OnTextChanged="totalWeight_TextChanged" TextMode="Number" Width="91px">0</asp:TextBox>
                </td>
                <td class="auto-style9">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style17"><strong>SECTION 2</strong></td>
                <td class="auto-style9">
                <asp:TextBox ID="totalWeight_2" runat="server" AutoPostBack="True" Height="18px" OnTextChanged="totalWeight_TextChanged" TextMode="Number" Width="91px">0</asp:TextBox>
                </td>
                <td class="auto-style9">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style17"><strong>SECTION 3</strong></td>
                <td class="auto-style9">
                <asp:TextBox ID="totalWeight_3" runat="server" AutoPostBack="True" Height="18px" OnTextChanged="totalWeight_TextChanged" TextMode="Number" Width="91px">0</asp:TextBox>
                </td>
                <td class="auto-style9">&nbsp;</td>
                </tr>
            <tr>
                <td class="auto-style17"><strong>SECTION 4</strong></td>
                <td class="auto-style9">
                <asp:TextBox ID="totalWeight_4" runat="server" AutoPostBack="True" Height="18px" OnTextChanged="totalWeight_TextChanged" TextMode="Number" Width="91px">0</asp:TextBox>
                </td>
                <td class="auto-style9">&nbsp;</td>
                </tr>
            <tr>
                <td class="auto-style17">&nbsp;</td>
                <td class="auto-style9">
                    <asp:Label ID="totalWeight" runat="server"></asp:Label>
                </td>
                <td class="auto-style9">&nbsp;</td>
                </tr>
            <tr>
                <td class="auto-style16" colspan="2"><strong>TOTAL OVERALL PERFORMANCE POINTS</strong></td>
                    <td class="auto-style9">&nbsp;</td>
                </tr>
            </table>
        </center>
</div>
    <br />
    <asp:Button ID="Submit" runat="server" Text=" Submit "/>
</center>
</asp:Content>
