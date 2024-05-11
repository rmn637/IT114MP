using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class EvaluationSection2Officers : System.Web.UI.Page
    {
        string empID, empType, process, field = "Section2CNWR";
        protected static int totalnumberadded;
        protected static int[] scopesNum = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        protected static TextBox[] scoperating = new TextBox[10];
        protected static Label[] scopesWeight = new Label[10], scopeweightedscore = new Label[10];
        protected static TextBox[] scopes = new TextBox[10];
        protected static TextBox[] array1 = new TextBox[10], array2 = new TextBox[10], array3 = new TextBox[10], array4 = new TextBox[10], array5 = new TextBox[10],
        array6 = new TextBox[10], array7 = new TextBox[10], array8 = new TextBox[10], array9 = new TextBox[10], array10 = new TextBox[10];
        protected static TextBox[][] notesArray = new TextBox[10][] { array1, array2, array3, array4, array5, array6, array7, array8, array9, array10 };
        protected static Label lblTotalWeight = new Label { ID = "labelTotal", Text = " ", Width = 90 };
        protected static Label lblTotalWeightScore = new Label { ID = "labelTotalWS1", Text = " ", Width = 90 };
        protected TableRow lastRow = new TableRow { ID = "lastRow" };

        

        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            ((Child)Page.Master).opt2class = "active";
            Page.MaintainScrollPositionOnPostBack = true;

            if (Session["Process"] is null)
                Session["Process"] = "Submission";

            process = Session["Process"].ToString();

            if (Session["Process"].ToString() == "Validation")
                empType = Session["RateeEmpType"].ToString();
            else
                empType = Session["EmpType"].ToString();

            if (!IsPostBack)
                Initialize();


            if (IsPostBack)
            {
                for (int i = 0; i < totalnumberadded; i++)
                {
                    addScope(i);
                    if (scopesNum[i] != 0)
                    {
                        addSpecificobjctive(i + 1, scopesNum[i]);
                    }
                }
                addFinalRow();
            }
        }

        protected void Initialize()
        {
            string CWR, PEVal;
            bool PEValDone;
            string[] sessionInfo;

            empID = Session["RateeID"].ToString();


            sessionInfo = Child.EmpInitEvalSec(empType, empID, field);

            Session["FormID"] = sessionInfo[0];
            Session["OfficerFormID"] = sessionInfo[1];
            Session["ReportID"] = sessionInfo[2];
            //Session["RateeID"] = sessionInfo[3]; 
            CWR = sessionInfo[4];
            PEValDone = bool.Parse(sessionInfo[5]);


            //Response.Write($"<script>alert('{Session["Process"]}+{Session["EmpType"]}+{empID}+{field}+{CWR}')</script>");

            Session["PEValDone"] = PEValDone.ToString();

            if (CWR != "0")
            {
                string[] CWRArr = CWR.Split(';');
                totalnumberadded = CWRArr.Length;
                string[] CWRArr2 = new string[10];
                string[] scopeArr = new string[CWRArr2.Length];
                string[] weightArr = new string[CWRArr2.Length];
                string[][] notesArr = new string[CWRArr2.Length][];
                string[] rating = new string[CWRArr2.Length];

                for (int i = 0; i < totalnumberadded; i++)
                {
                    CWRArr2 = CWRArr[i].Split('|');
                    scopeArr[i] = CWRArr2[1];
                    notesArr[i] = CWRArr2[2].Split('_');
                    scopesNum[i] = CWRArr2[2].Split('_').Length - 1;
                    weightArr[i] = CWRArr2[3];
                    rating[i] = CWRArr2[4];
                }
                for (int i = 0; i < totalnumberadded; i++)
                {
                    addScope(i);
                    if (scopesNum[i] != 0)
                    {
                        addSpecificobjctive(i + 1, scopesNum[i]);
                    }
                    scopes[i].Text = scopeArr[i];
                    for (int k = 0; k < notesArr[i].Length; k++)
                    {
                        if (notesArr[i][k] is null)
                        {
                            notesArray[i][k].Text = "";
                        }
                        else
                            notesArray[i][k].Text = notesArr[i][k].ToString();
                    }
                    scopesWeight[i].Text = weightArr[i];
                    scoperating[i].Text = rating[i];
                }
                addFinalRow();
            }
            else if (CWR == "0")
            {
                for (int i = 0; i < 10; i++)
                {
                    scopesNum[i] = 0;
                }
                totalnumberadded = 1;
                for (int i = 0; i < totalnumberadded; i++)
                {
                    addScope(i);
                    if (scopesNum[i] != 0)
                    {
                        addSpecificobjctive(i + 1, scopesNum[i]);
                    }
                }
                addFinalRow();
            }
            computeTotalWeight1(totalnumberadded);


        }
        protected string CompileAnswers()
        {
            string text = "";

            for (int i = 0; i < totalnumberadded; i++)
            {
                if (i == totalnumberadded - 1)
                {
                    text += $"{i + 1}|{scopes[i].Text}|";
                    for (int k = 0; k < notesArray[i].Length; k++)
                    {
                        if (notesArray[i][k + 1] == null && notesArray[i][k] != null)
                        {
                            text += $"{notesArray[i][k].Text}";
                            break;
                        }
                        text += $"{notesArray[i][k].Text}_";
                    }
                    text += $"|{scopesWeight[i].Text}|{scoperating[i].Text}";
                    break;
                }
                text += $"{i + 1}|{scopes[i].Text}";
                for (int k = 0; k < notesArray[i].Length; k++)
                {
                    if (notesArray[i][k + 1] == null && notesArray[i][k] != null)
                    {
                        text += $"{notesArray[i][k].Text}";
                        break;
                    }
                    text += $"{notesArray[i][k].Text}_";
                }
                text += $"|{scopesWeight[i].Text}|{scoperating[i].Text};";

            }
            return text;
        }

        protected void UpdateCWR()
        {
            string compiledCWR = CompileAnswers();
            string storedOfficerFormID = Session["OfficerFormID"].ToString();

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=1234;Database=EmployeeEval;"))
                //using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=1234;Database=EmployeeEval;"))
                {
                    connection.Open();

                    NpgsqlCommand command = new NpgsqlCommand(@"UPDATE ""OfficerForm"" SET ""Section2CNWR"" = @Section2CNWR WHERE ""OfficerFormID"" = @OfficerFormID", connection);
                    command.Parameters.AddWithValue("@Section2CNWR", compiledCWR);
                    command.Parameters.AddWithValue("@OfficerFormID", storedOfficerFormID);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void weight_TextChanged(object sender, EventArgs e)
        {
            TextBox weight = sender as TextBox;
            try
            {
                inputChecker(weight.Text);
                Child.AdjustRating(ref scoperating, ref scopesWeight, ref scopeweightedscore, weight, ref lblTotalWeightScore);
            }
            catch
            {
                weight.Text = "0";
            }

        }
        protected double inputChecker(string weight)
        {
            if (weight != "0")
            {
                return double.Parse(weight);
            }
            else
            {
                return 0;
            }
        }
        protected void computeTotalWeight1(int kra)
        {
            double total = 0, total2 = 0;
            try
            {
                for (int i = 0; i < kra; i++)
                {
                    total += inputChecker(scopesWeight[i].Text);
                    double ws = double.Parse(scopesWeight[i].Text) * double.Parse(scoperating[i].Text) * .2;

                    total2 += ws;
                    scopeweightedscore[i].Text = ws.ToString("0.00");
                }
                lblTotalWeight.Text = total.ToString("0.00");
                lblTotalWeightScore.Text = total2.ToString("0.00");
            }
            catch
            {
                lblTotalWeight.Text = "";
                lblTotalWeightScore.Text = "";
            }
        }
        protected void addScope(int i)
        {
            TableRow tr1 = new TableRow();
            TableCell td1 = new TableCell { CssClass = "auto-style3" };
            TextBox scope = new TextBox { ID = "scope" + i.ToString(), MaxLength = 50, Width = 481, TabIndex = Convert.ToSByte(i * 4 + 1), Enabled = false };
            scopes[i] = scope;
            td1.Controls.Add(scope);
            tr1.Cells.Add(td1);
            TableCell td2 = new TableCell { CssClass = "auto-style5", Text = "W" };
            tr1.Cells.Add(td2);
            TableCell td3 = new TableCell { CssClass = "auto-style34", Text = "R" };
            tr1.Cells.Add(td3);
            TableCell td4 = new TableCell { CssClass = "auto-style33", Text = "WS" };
            tr1.Cells.Add(td4);

            tableScope.Rows.Add(tr1);

            //        <asp:TableCell class="auto-style33">
            //            <asp:Label ID = "label2_1" runat="server" Text="0"></asp:Label>
            //        </asp:TableCell>
            TableRow tr2 = new TableRow();
            TableCell tdnotes1 = new TableCell { CssClass = "auto-style6", Text = "Notes/Critical Incidents: " };
            TextBox note = new TextBox { ID = "notes" + i.ToString(), MaxLength = 50, Width = 481, TabIndex = Convert.ToSByte(i * 4 + 1), Enabled = false };
            notesArray[i][0] = note;
            tdnotes1.Controls.Add(note);
            tr2.Cells.Add(tdnotes1);

            TableCell tdnotes2 = new TableCell { CssClass = "auto-style5" };
            Label weight = new Label { ID = "weight1_" + i.ToString(), Height = 18, Width = 91, CssClass = "normal", TabIndex = Convert.ToSByte(i * 4 + 2), Enabled = false };
            scopesWeight[i] = weight;
            tdnotes2.Controls.Add(weight);
            tr2.Cells.Add(tdnotes2);

            TableCell tdnotes3 = new TableCell { CssClass = "auto-style34", Text = "" };
            TextBox rating = new TextBox { ID = "rating1_" + i, AutoPostBack = true, Height = 18, Width = 91, CssClass = "normal", TabIndex = Convert.ToSByte(i * 4 + 4)};
            rating.TextChanged += weight_TextChanged;
            tdnotes3 .Controls.Add(rating);
            scoperating[i] = rating;
            tr2.Cells.Add(tdnotes3);

            TableCell tdnotes4 = new TableCell { CssClass = "auto-style33" };
            Label labelws = new Label { ID = "label2_" + i.ToString(), Text = "0" };
            tdnotes4.Controls.Add(labelws);
            tr2.Cells.Add(tdnotes4);
            scopeweightedscore[i] = labelws;
            tableScope.Rows.Add(tr2);
        }

        protected void addscopebtn(object sender, EventArgs e)
        {
            totalnumberadded++;
            lastRow.Cells.Clear();
            tableScope.Rows.Remove(lastRow);
            addScope(totalnumberadded - 1);
            addFinalRow();
        }

        protected void addSpecificobjctive(int index, int objNum)
        {

            int total = 0;
            for (int totalscopes = 0; totalscopes < index - 1; totalscopes++)
            {
                total += scopesNum[totalscopes];
            }
            for (int i = 0; i < objNum; i++)
            {
                TableRow tr4 = new TableRow();
                TableCell tdNotes = new TableCell { ColumnSpan = 5 };
                TextBox note = new TextBox { Height = 18, Width = 1200, CssClass = "normal", Enabled = false };
                tdNotes.Controls.Add(note);
                notesArray[index - 1][i + 1] = note;
                tr4.Cells.Add(tdNotes);
                if (index == 1)
                {
                    tableScope.Rows.AddAt(1 + index * 2, tr4);
                }
                else
                {
                    tableScope.Rows.AddAt(1 + index * 2 + total, tr4);
                }

            }

        }

        protected void removeSpecificobjctive(int index, int objNum)
        {
            int total = 0;
            for (int totalscopes = 0; totalscopes < index - 1; totalscopes++)
            {
                total += scopesNum[totalscopes];
            }
            for (int i = 0; i < objNum; i++)
            {
                notesArray[index - 1][i] = null;
                if (index == 1)
                {

                    tableScope.Rows.RemoveAt(1 + index * 2);
                }
                else
                {
                    tableScope.Rows.RemoveAt(1 + index * 2 + total);
                }
            }
        }
        protected void addFinalRow()
        {
            TableCell td1 = new TableCell { CssClass = "auto-style7", Text = "TOTAL" };
            TableCell td2 = new TableCell { CssClass = "auto-style5" };
            td2.Controls.Add(lblTotalWeight);
            TableCell td3 = new TableCell { CssClass = "auto-style34" };
            TableCell td4 = new TableCell { CssClass = "auto-style33" };
            td4.Controls.Add(lblTotalWeightScore); 

            lastRow.Cells.Add(td1);
            lastRow.Cells.Add(td2);
            lastRow.Cells.Add(td3);
            lastRow.Cells.Add(td4);
            tableScope.Rows.Add(lastRow);
        }


        protected void ChangeSection(object sender, EventArgs e)
        {
            LinkButton link = sender as LinkButton;
            if ((process == "Submission" && bool.Parse(Session["PEValDone"].ToString())) != true)
                UpdateCWR();
            if (link.ID == "btnSection1")
            {
                //insert database commands here
                Response.Redirect("~/OES1.aspx");
            }
            else if (link.ID == "btnSection2")
            {
                //insert database commands here
                Response.Redirect("~/OES2.aspx");
            }
            else if (link.ID == "btnSection3")
            {
                //insert database commands here
                Response.Redirect("~/OES3.aspx");
            }
            else if (link.ID == "btnSection4")
            {
                //insert database commands here
                Response.Redirect("~/OES4.aspx");
            }
            else if (link.ID == "btnSection5")
            {
                //insert database commands here
                Response.Redirect("~/OEC.aspx");
            }
            else if (link.ID == "btnOverall")
            {
                //insert database commands here
                Response.Redirect("~/OEO.aspx");
            }

        }
    }
}