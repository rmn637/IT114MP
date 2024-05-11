using Npgsql;
using Org.BouncyCastle.Ocsp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class EvaluationSection1Officers : System.Web.UI.Page
    {
        string empID, empType, process, field = "Section1IOWR";
        protected static int totalnumberadded;
        protected static int[] scopes = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        protected static TextBox[] krarating = new TextBox[10];
        protected static Label[] kraWeightScore = new Label[10], kraweights = new Label[10];
        protected static TextBox[] initiatives = new TextBox[10];
        protected static TextBox[] array1 = new TextBox[10], array2 = new TextBox[10], array3 = new TextBox[10], array4 = new TextBox[10], array5 = new TextBox[10],
        array6 = new TextBox[10], array7 = new TextBox[10], array8 = new TextBox[10], array9 = new TextBox[10], array10 = new TextBox[10];
        protected static TextBox[][] objectives = new TextBox[10][] { array1, array2, array3, array4, array5, array6, array7, array8, array9, array10 };
        protected static Label lblTotalWeight = new Label { ID = "labelTotal1", Text = " ", Width = 90 };
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
                    addKRA(i);
                    if (scopes[i] != 0)
                    {
                        addSpecificobjctive(i + 1, scopes[i]);
                    }
                }
                addFinalRow();
            }
        }

        protected void checkWeight(object sender, EventArgs e)
        {

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
                string[] initiative = new string[CWRArr2.Length];
                string[][] objective = new string[CWRArr2.Length][];
                string[] weightArr = new string[CWRArr2.Length];
                string[] note = new string[CWRArr2.Length];

                for (int i = 0; i < totalnumberadded; i++)
                {
                    CWRArr2 = CWRArr[i].Split('|');
                    initiative[i] = CWRArr2[1];
                    objective[i] = CWRArr2[2].Split('_');
                    scopes[i] = CWRArr2[2].Split('_').Length - 1;
                    weightArr[i] = CWRArr2[3];
                    note[i] = CWRArr2[4];
                }
                for (int i = 0; i < totalnumberadded; i++)
                {
                    addKRA(i);
                    if (scopes[i] != 0)
                    {
                        addSpecificobjctive(i + 1, scopes[i]);
                    }
                    initiatives[i].Text = initiative[i];
                    for (int k = 0; k < objective[i].Length; k++)
                    {
                        objectives[i][k].Text = objective[i][k];

                    }
                    kraweights[i].Text = weightArr[i];
                    krarating[i].Text = note[i];
                }
                addFinalRow();
            }
            else if (CWR == "0")
            {
                for (int i = 0; i < 10; i++)
                {
                    scopes[i] = 0;
                }
                totalnumberadded = 1;
                for (int i = 0; i < totalnumberadded; i++)
                {
                    addKRA(i);
                    if (scopes[i] != 0)
                    {
                        addSpecificobjctive(i + 1, scopes[i]);
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
                    text += $"{i + 1}|{initiatives[i].Text}|";
                    for (int k = 0; k < objectives[i].Length; k++)
                    {
                        if (objectives[i][k] is null)
                        {
                            text += "";
                            continue;
                        }
                        else if (objectives[i][k].Text == "")
                        {
                            text += "";
                            continue;
                        }
                        else if (objectives[i][k + 1] == null && objectives[i][k] != null)
                        {
                            text += $"{objectives[i][k].Text}";
                            break;
                        }
                        text += $"{objectives[i][k].Text}_";
                    }
                    text += $"|{kraweights[i].Text}|{krarating[i].Text}";
                    break;
                }
                text += $"{i + 1}|{initiatives[i].Text}|";
                for (int k = 0; k < objectives[i].Length; k++)
                {
                    if (objectives[i][k] is null)
                    {
                        text += "";
                        continue;
                    }
                    else if (objectives[i][k].Text == "")
                    {
                        scopes[i] -= 1;
                        continue;
                    }
                    else
                    {
                        if (objectives[i][k + 1] == null && objectives[i][k] != null)
                        {
                            text += $"{objectives[i][k].Text}";
                            break;
                        }
                        text += $"{objectives[i][k].Text}_";
                    }
                }
                text += $"|{kraweights[i].Text}|{krarating[i].Text};";
                Response.Write($"<script>alert('{kraweights[i]}')</script>");
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

                    NpgsqlCommand command = new NpgsqlCommand(@"UPDATE ""OfficerForm"" SET ""Section1IOWR"" = @Section1IOWR WHERE ""OfficerFormID"" = @OfficerFormID", connection);
                    command.Parameters.AddWithValue("@Section1IOWR", compiledCWR);
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
                Child.AdjustRating(ref krarating, ref kraweights, ref kraWeightScore, weight, ref lblTotalWeightScore);
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
                    total += inputChecker(kraweights[i].Text);
                    double ws = double.Parse(krarating[i].Text) * double.Parse(kraweights[i].Text) * .2;

                    total2 += ws;
                    kraWeightScore[i].Text = ws.ToString("0.00");
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
        protected void addKRA(int i)
        {
            TableRow tr1 = new TableRow();
            TableCell td = new TableCell { ColumnSpan = 5 };
            td.Text = "KRA " + (1 + i);
            tr1.Cells.Add(td);
            tablekra.Rows.Add(tr1);

            TableRow tr2 = new TableRow();
            TableCell tdInitiative1 = new TableCell { CssClass = "auto-style20", Text = "Key Initiative" };
            tr2.Cells.Add(tdInitiative1);
            TableCell tdInitiative2 = new TableCell { CssClass = "auto-style27" };
            tr2.Cells.Add(tdInitiative2);
            TextBox initiative = new TextBox { ID = "initiative" + i.ToString(), Width = 528, MaxLength = 50, TabIndex = Convert.ToSByte(i * 4 + 1), Enabled = false };
            initiatives[i] = initiative;
            tdInitiative2.Controls.Add(initiative);
            TableCell tdInitiative3 = new TableCell { CssClass = "auto-style9", Text = "W" };
            tr2.Cells.Add(tdInitiative3);
            TableCell tdInitiative4 = new TableCell { CssClass = "auto-style30", Text = "R" };
            tr2.Cells.Add(tdInitiative4);
            TableCell tdInitiative5 = new TableCell { CssClass = "auto-style31", Text = "WS" };
            tr2.Cells.Add(tdInitiative5);
            tablekra.Rows.Add(tr2);

            TableRow tr3 = new TableRow();
            TableCell tdObjective1 = new TableCell { CssClass = "auto-style20", Text = "" };
            Label SpecificObjectives = new Label { ID = "SpecificObjectives" + (1 + i).ToString(), Text = "Specific Objectives: " };
            tdObjective1.Controls.Add(SpecificObjectives);
            TableCell tdObjective2 = new TableCell { CssClass = "auto-style6" };
            TextBox objective = new TextBox { ID = "objectives" + i, Width = 528, MaxLength = 50, TabIndex = Convert.ToSByte(i * 4 + 2), Enabled = false };
            tdObjective2.Controls.Add(objective);
            objectives[i][0] = objective;
            TableCell tdObjective3 = new TableCell { CssClass = "auto-style18" };
            Label weight = new Label { ID = "weight1_" + i, Height = 18, Width = 91, CssClass = "normal", TabIndex = Convert.ToSByte(i * 4 + 3), Enabled = false };
            tdObjective3.Controls.Add(weight);
            kraweights[i] = weight;
            TableCell tdObjective4 = new TableCell { CssClass = "auto-style30" };
            //rating textbox add
            TextBox rating = new TextBox { ID = "rating1_" + i, AutoPostBack = true, Height = 18, Width = 91, CssClass = "normal", TabIndex = Convert.ToSByte(i * 4 + 4)};
            rating.TextChanged += weight_TextChanged;
            tdObjective4.Controls.Add(rating);
            krarating[i] = rating;
            TableCell tdObjective5 = new TableCell { CssClass = "auto-style31" };
            Label ws = new Label { ID = "label1_" + i, Text = "0" };
            tdObjective5.Controls.Add(ws);
            kraWeightScore[i] = ws;
            tr3.Cells.Add(tdObjective1);
            tr3.Cells.Add(tdObjective2);
            tr3.Cells.Add(tdObjective3);
            tr3.Cells.Add(tdObjective4);
            tr3.Cells.Add(tdObjective5);
            tablekra.Rows.Add(tr3);
        }

        protected void addSpecificobjctivebtn(object sender, EventArgs e)
        {
            Button addobjective = sender as Button;
            int index = int.Parse(addobjective.ID[11].ToString());
            if (index > totalnumberadded || index <= 0)
            {
                Response.Write("<script>alert('The inputted KRA is not found.')</script>");
            }
            else if (scopes[index - 1] > 10 || scopes[index - 1] < 0)
            {
                Response.Write("<script>alert('You cannot add more specific objectives.')</script>");
            }
            else
            {
                lastRow.Cells.Clear();
                tablekra.Rows.Remove(lastRow);
                addSpecificobjctive(index);
                int total = scopes[index - 1] + 1;
                scopes[index - 1] = total;
                addFinalRow();
            }
        }

        protected void addSpecificobjctive(int index, int objNum)
        {

            int total = 0;
            for (int totalscopes = 0; totalscopes < index - 1; totalscopes++)
            {
                total += scopes[totalscopes];
            }
            for (int i = 0; i < objNum; i++)
            {
                TableRow tr4 = new TableRow();
                TableCell tdNotes = new TableCell { ColumnSpan = 5 };
                TextBox note = new TextBox { Height = 18, Width = 1200, CssClass = "normal", Enabled = false };
                tdNotes.Controls.Add(note);
                objectives[index - 1][i + 1] = note;
                tr4.Cells.Add(tdNotes);
                if (index == 1)
                {
                    tablekra.Rows.AddAt(1 + index * 3, tr4);
                }
                else
                {
                    tablekra.Rows.AddAt(1 + index * 3 + total, tr4);
                }

            }

        }


        protected void addSpecificobjctive(int index)
        {
            int total = 0;
            for (int totalscopes = 0; totalscopes < index; totalscopes++)
            {
                total += scopes[totalscopes];
            }
            TableRow tr4 = new TableRow();
            TableCell tdNotes = new TableCell { ColumnSpan = 5 };
            TextBox note = new TextBox { Height = 18, Width = 1200, CssClass = "normal", Enabled = false };
            tdNotes.Controls.Add(note);
            objectives[index - 1][scopes[index - 1]] = note;
            tr4.Cells.Add(tdNotes);
            if (index == 1)
            {
                tablekra.Rows.AddAt(1 + index * 3, tr4);
            }
            else
            {
                tablekra.Rows.AddAt(1 + index * 3 + total, tr4);
            }
        }

        protected void addFinalRow()
        {
            TableCell td1 = new TableCell { CssClass = "auto-style20" };
            TableCell td2 = new TableCell { CssClass = "auto-style6", Text = "TOTAL" };
            TableCell td3 = new TableCell { CssClass = "auto-style18" };
            td3.Controls.Add(lblTotalWeight);
            TableCell td4 = new TableCell { CssClass = "auto-style30" };
            TableCell td5 = new TableCell { CssClass = "auto-style31" };
            td5.Controls.Add(lblTotalWeightScore);

            lastRow.Cells.Add(td1);
            lastRow.Cells.Add(td2);
            lastRow.Cells.Add(td3);
            lastRow.Cells.Add(td4);
            lastRow.Cells.Add(td5);
            tablekra.Rows.Add(lastRow);
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