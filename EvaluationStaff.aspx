<%@ Page Title="Evaluation Form" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EvaluationStaff.aspx.cs" Inherits="WebApplication1.WebForm5" MaintainScrollPositionOnPostback="true"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function openNav() {
            document.getElementById("mySidenav").style.width = "250px";
            document.getElementById("main").style.marginLeft = "250px";
            document.getElementById("page1").style.marginLeft = "250px";
            document.getElementById("page2").style.marginLeft = "250px";
            document.getElementById("page3").style.marginLeft = "250px";
            document.getElementById("overall").style.marginLeft = "250px";
        }
        function closeNav() {
            document.getElementById("mySidenav").style.width = "0";
            document.getElementById("main").style.marginLeft = "0";
            document.getElementById("page1").style.marginLeft = "0";
            document.getElementById("page2").style.marginLeft = "0";
            document.getElementById("page3").style.marginLeft = "0";
            document.getElementById("overall").style.marginLeft = "0";
        }
        function page1() {
            document.getElementById("page1").style.width = "100%";
            document.getElementById("page2").style.width = "0";
            document.getElementById("page3").style.width = "0";
            document.getElementById("overall").style.width = "0";
            document.getElementById("page1").addClass(" ");
        }
        function page2() {
            document.getElementById("page1").style.width = "0";
            document.getElementById("page2").style.width = "100%";
            document.getElementById("page3").style.width = "0";
            document.getElementById("overall").style.width = "0";
        }
        function page3() {
            document.getElementById("page1").style.width = "0";
            document.getElementById("page2").style.width = "0";
            document.getElementById("page3").style.width = "100%";
            document.getElementById("overall").style.width = "0";
        }
        function overall() {
            document.getElementById("page1").style.width = "0";
            document.getElementById("page2").style.width = "0";
            document.getElementById("page3").style.width = "0";
            document.getElementById("overall").style.width = "100%";
        }
    </script>
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
        <br />
        <div class="section" id="page1">
            <center>
            <div class="navbar" id="navibar">
                <a href="javascript:void(0)" onclick="page1()">Section 1</a> &nbsp; &nbsp; &nbsp;
                <a href="javascript:void(0)" onclick="page2()">Section 2</a> &nbsp; &nbsp; &nbsp;
                <a href="javascript:void(0)" onclick="page3()">Section 3</a> &nbsp; &nbsp; &nbsp;
                <a href="javascript:void(0)" onclick="overall()">Overall</a>
            </div>
            </center>
            <br />
            <br />
            <table class="auto-style2">
                <tr>
                    <td colspan="5" class="auto-style15" style="background-color: #C0C0C0"><strong>SECTION 1: PROFICIENCY / BEHAVIORAL-BASED PERFORMANCE</strong></td>
                </tr>
                <tr>
                    <td colspan="2" rowspan="2"><strong>JOB KNOWLEDGE</strong></td>
                    <td class="auto-style9">W</td>
                    <td class="auto-style4">R</td>
                    <td>WS</td>
                </tr>
                <tr>
                    <td class="auto-style9">20</td>
                    <td class="auto-style4">
                        <asp:TextBox ID="rating1_1" runat="server" AutoPostBack="True" Height="18px" TextMode="Number" Width="91px">0</asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="label1_1" runat="server" Text="0"></asp:Label>
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
                    <td>WS</td>
                </tr>
                <tr>
                    <td class="auto-style9">20</td>
                    <td class="auto-style4">
                        <asp:TextBox ID="rating1_2" runat="server" AutoPostBack="True" Height="18px" TextMode="Number" Width="91px">0</asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="label1_2" runat="server" Text="0"></asp:Label>
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
                    <td>WS</td>
                </tr>
                <tr>
                    <td class="auto-style9">20</td>
                    <td class="auto-style4">
                        <asp:TextBox ID="rating1_3" runat="server" AutoPostBack="True" Height="18px" TextMode="Number" Width="91px">0</asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="label1_3" runat="server" Text="0"></asp:Label>
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
                    <td>WS</td>
                </tr>
                <tr>
                    <td class="auto-style9">20</td>
                    <td class="auto-style4">
                        <asp:TextBox ID="rating1_4" runat="server" AutoPostBack="True" Height="18px" TextMode="Number" Width="91px">0</asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="label1_4" runat="server" Text="0"></asp:Label>
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
                    <td>WS</td>
                </tr>
                <tr>
                    <td class="auto-style9">20</td>
                    <td class="auto-style4">
                        <asp:TextBox ID="rating1_5" runat="server" AutoPostBack="True" Height="18px" TextMode="Number" Width="91px">0</asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="label1_5" runat="server" Text="0"></asp:Label>
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
                    <td>WS</td>
                </tr>
                <tr>
                    <td class="auto-style9">20</td>
                    <td class="auto-style4">
                        <asp:TextBox ID="rating1_6" runat="server" AutoPostBack="True" Height="18px" TextMode="Number" Width="91px">0</asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="label1_6" runat="server" Text="0"></asp:Label>
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
                    <td>WS</td>
                </tr>
                <tr>
                    <td class="auto-style9">20</td>
                    <td class="auto-style4">
                        <asp:TextBox ID="rating1_7" runat="server" AutoPostBack="True" Height="18px" TextMode="Number" Width="91px">0</asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="label1_7" runat="server" Text="0"></asp:Label>
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
                    <td>WS</td>
                </tr>
                <tr>
                    <td class="auto-style9">20</td>
                    <td class="auto-style4">
                        <asp:TextBox ID="rating1_8" runat="server" AutoPostBack="True" Height="18px" TextMode="Number" Width="91px">0</asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="label1_8" runat="server" Text="0"></asp:Label>
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
                    <td class="auto-style9" style="border-style: none">&nbsp;</td>
                    <td class="auto-style4" style="border-style: none"><strong>TOTAL</strong></td>
                    <td style="border-style: none">
                        <asp:Label ID="labelTotal1" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="section" id ="page2">
            <div class="navbar">
                <a href="javascript:void(0)" onclick="page1()">Section 1</a> &nbsp; &nbsp; &nbsp;
                <a href="javascript:void(0)" onclick="page2()">Section 2</a> &nbsp; &nbsp; &nbsp;
                <a href="javascript:void(0)" onclick="page3()">Section 3</a> &nbsp; &nbsp; &nbsp;
                <a href="javascript:void(0)" onclick="overall()">Overall</a>
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
        </div>
        <br />
        <div class="section" id="page3" width="80%" style="text-align:center">
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
                    <a href="javascript:void(0)" onclick="page1()">Section 1</a> &nbsp; &nbsp; &nbsp;
                    <a href="javascript:void(0)" onclick="page2()">Section 2</a> &nbsp; &nbsp; &nbsp;
                    <a href="javascript:void(0)" onclick="page3()">Section 3</a> &nbsp; &nbsp; &nbsp;
                    <a href="javascript:void(0)" onclick="overall()">Overall</a>
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
        </div>
    </center>
            
</asp:Content>
