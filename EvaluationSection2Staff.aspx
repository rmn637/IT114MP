<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EvaluationSection2Staff.aspx.cs" Inherits="WebApplication1.EvaluationSection2Staff" %>
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
    <center>
    <div class="navbar">
        <asp:LinkButton ID="btnSection1" runat="server" OnClick="checkWeight">Section 1</asp:LinkButton> &nbsp; &nbsp; &nbsp;
        <asp:LinkButton ID="btnSection2" runat="server" Enabled="false">Section 2</asp:LinkButton> &nbsp; &nbsp; &nbsp;
        <asp:LinkButton ID="btnSection3" runat="server" OnClick="checkWeight">Section 3</asp:LinkButton> &nbsp; &nbsp; &nbsp;
        <asp:LinkButton ID="btnOverall" runat="server" OnClick="checkWeight">Overall</asp:LinkButton>
    </div>
    <br />
    <br />
    <table class="auto-style2">
        <tr>
            <td style="background-color: #C0C0C0" colspan="5" class="auto-style15"><strong>SECTION 2: DEMONSTRATION OF YGC CORE VALUES</strong></td>
        </tr>
        <tr>
            <td colspan="2"><strong>PASSION FOR EXCELLENCE</strong></td>
            <td class="auto-style9">W</td>
            <td class="auto-style4">R</td>
            <td>WS</td>
        </tr>
        <tr>
            <td class="auto-style8" colspan="2">Stiving to be great and not just good. Continuously improving our results.</td>
            <td class="auto-style9">20</td>
            <td class="auto-style4">
                <asp:TextBox ID="rating2_1" runat="server"
                    Height="18px" TextMode="Number" Width="91px" oninput="focusOnRating2_1()"
                    OnTextChanged="rating2_TextChanged" AutoPostBack="true">0</asp:TextBox>
            </td>
            <td>
                 <asp:Label ID="label2_1" runat="server" Text="0"></asp:Label>
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
            <td>WS</td>
        </tr>
        <tr>
            <td class="auto-style8" colspan="2">Doing things fast. Taking initiative to respond to needs of various stakeholders.</td>
            <td class="auto-style9">20</td>
            <td class="auto-style4">
                <asp:TextBox ID="rating2_2" runat="server" AutoPostBack="True" Height="18px" TextMode="Number" Width="91px" OnTextChanged="rating2_TextChanged">0</asp:TextBox>
            </td>
            <td>
                <asp:Label ID="label2_2" runat="server" Text="0"></asp:Label>
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
            <td>WS</td>
        </tr>
        <tr>
            <td class="auto-style8" colspan="2">Strong work ethic. Deserving of trust and respect. Prudent use of company resources, including time. Acting with fairness and objectivity.</td>
            <td class="auto-style9">20</td>
            <td class="auto-style4">
                <asp:TextBox ID="rating2_3" runat="server" AutoPostBack="True" Height="18px" TextMode="Number" Width="91px" OnTextChanged="rating2_TextChanged">0</asp:TextBox>
            </td>
            <td>
                <asp:Label ID="label2_3" runat="server" Text="0"></asp:Label>
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
            <td>WS</td>
        </tr>
        <tr>
            <td class="auto-style8" colspan="2">Actively tapping areas of synergy. Communicating and collaborating towards common goals.</td>
            <td class="auto-style9">20</td>
            <td class="auto-style4">
                <asp:TextBox ID="rating2_4" runat="server" AutoPostBack="True" Height="18px" TextMode="Number" Width="91px" OnTextChanged="rating2_TextChanged">0</asp:TextBox>
            </td>
            <td>
                <asp:Label ID="label2_4" runat="server" Text="0"></asp:Label>
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
            <td>WS</td>
        </tr>
        <tr>
            <td class="auto-style8" colspan="2">Being good corporate citizens. Pursuing corporate interests as his own. Speaking well of the company and taking pride of its achievements.</td>
            <td class="auto-style9">20</td>
            <td class="auto-style4">
                <asp:TextBox ID="rating2_5" runat="server" AutoPostBack="True" Height="18px" TextMode="Number" Width="91px" OnTextChanged="rating2_TextChanged">0</asp:TextBox>
            </td>
            <td>
                <asp:Label ID="label2_5" runat="server" Text="0"></asp:Label>
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
            <td class="auto-style9" style="border-style: none">&nbsp;</td>
            <td class="auto-style4" style="border-style: none"><strong>TOTAL</strong></td>
            <td style="border-style: none">
                <asp:Label ID="labelTotal2" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    </center>
</asp:Content>
