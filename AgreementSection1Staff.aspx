<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AgreementSection1Staff.aspx.cs" Inherits="WebApplication1.AgreementSection1Staff" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
    function openNav() {
        document.getElementById("mySidenav").style.width = "250px";
        document.getElementById("main").style.marginLeft = "250px";
        document.getElementById("page1").style.marginLeft = "250px";
    }
    function closeNav() {
        document.getElementById("mySidenav").style.width = "0";
        document.getElementById("main").style.marginLeft = "0";
        document.getElementById("page1").style.marginLeft = "0";
    }
    </script>
    <style type="text/css">
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <br />
        <center>
        <div class="navbar" id="navibar">
            <asp:LinkButton ID="btnSection1" runat="server" Enabled="false" style="color:black; background-color:#eaeaea">Section 1</asp:LinkButton> &nbsp; &nbsp; &nbsp;
            <asp:LinkButton ID="btnSection2" runat="server" OnClick="ChangeSection">Section 2</asp:LinkButton> &nbsp; &nbsp; &nbsp;
            <asp:LinkButton ID="btnOverall" runat="server" OnClick="ChangeSection">Overall</asp:LinkButton>
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
                <td class="auto-style9">
                    <asp:TextBox ID="weight1_1" runat="server" AutoPostBack="True" Height="18px" Width="91px" OnTextChanged="weight_TextChanged" Text="0" CssClass="normal" TabIndex="1"></asp:TextBox>
                </td>
                <td class="auto-style4">
                    &nbsp;</td>
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
                <td class="auto-style9" id="weight1_2">
                    <asp:TextBox ID="weight1_2" runat="server" AutoPostBack="True" Height="18px" Width="91px" OnTextChanged="weight_TextChanged" CssClass="normal" TabIndex="2">0</asp:TextBox>
                </td>
                <td class="auto-style4">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
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
                <td class="auto-style9">
                    <asp:TextBox ID="weight1_3" runat="server" AutoPostBack="True" Height="18px" Width="91px" OnTextChanged="weight_TextChanged" CssClass="normal" TabIndex="3">0</asp:TextBox>
                </td>
                <td class="auto-style4">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
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
                <td class="auto-style9">
                    <asp:TextBox ID="weight1_4" runat="server" AutoPostBack="True" Height="18px" Width="91px" OnTextChanged="weight_TextChanged" CssClass="normal" TabIndex="4">0</asp:TextBox>
                </td>
                <td class="auto-style4">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
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
                <td class="auto-style9">
                    <asp:TextBox ID="weight1_5" runat="server" AutoPostBack="True" Height="18px" Width="91px" OnTextChanged="weight_TextChanged" CssClass="normal" TabIndex="5">0</asp:TextBox>
                </td>
                <td class="auto-style4">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
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
                <td class="auto-style9">
                    <asp:TextBox ID="weight1_6" runat="server" AutoPostBack="True" Height="18px" Width="91px" OnTextChanged="weight_TextChanged" CssClass="normal" TabIndex="6">0</asp:TextBox>
                </td>
                <td class="auto-style4">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
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
                <td class="auto-style9">
                    <asp:TextBox ID="weight1_7" runat="server" AutoPostBack="True" Height="18px" Width="91px" OnTextChanged="weight_TextChanged" CssClass="normal" TabIndex="7">0</asp:TextBox>
                </td>
                <td class="auto-style4">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
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
                <td class="auto-style9" id="weight1_8">
                    <asp:TextBox ID="weight1_8" runat="server" AutoPostBack="True" Height="18px" Width="91px" OnTextChanged="weight_TextChanged" CssClass="normal" TabIndex="8">0</asp:TextBox>
                </td>
                <td class="auto-style4">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
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
                    <asp:Label ID="labelTotal1" runat="server"></asp:Label>
                </td>
                <td class="auto-style4" style="border-style: none"><strong>TOTAL</strong></td>
                <td style="border-style: none">
                    &nbsp;</td>
            </tr>
        </table>
    </center>
</asp:Content>
