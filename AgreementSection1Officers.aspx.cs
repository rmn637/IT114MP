using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class AgreementSection1Officers : System.Web.UI.Page
    {
        protected static int totalnumberadded;
        protected static int[] scopes = { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        protected static TextBox[] kraweights = new TextBox[10];
        protected static TextBox[] initiatives = new TextBox[10];
        protected static TextBox[] objectives = new TextBox[10];
        protected static TextBox[] notes = new TextBox[10];
        protected static TextBox[] notes2 = new TextBox[10];
        protected static Label lblTotalWeight = new Label { ID = "labelTotal1", Text = " ", Width = 90 };
        protected TableRow lastRow = new TableRow { ID = "lastRow" };
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            ((Site1)Page.Master).opt2class = "active";
            Page.MaintainScrollPositionOnPostBack = true;
            if(!IsPostBack)
                Initialize();

            if (IsPostBack)
            {
                for (int i = 0; i < totalnumberadded; i++)
                {
                    addKRA(i);
                }
                addFinalRow();
            }
            if (totalnumberadded == 9)
            {
                addKRAbtn.Enabled = false;
                addKRAbtn.Visible = false;
            }
        }

        protected void Initialize()
        {
            string SQLcmd, CWR = "", PAVal = "";
            using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=123456;Database=EmplyeeEval;"))
            {
                connection.Open();
                SQLcmd = @"SELECT ""Section1IOWR"", ""ReportID"", ""PAValidation"" FROM ""OfficerForm"" INNER JOIN ""EmployeePerformance"" ON ""OfficerForm"".""FormID"" = ""EmployeePerformance"".""FormID"" INNER JOIN ""StatusReport"" ON ""EmployeePerformance"".""EmpID"" = ""StatusReport"".""EmpID"" WHERE ""OfficerFormID"" = @OfficerFormID";
                NpgsqlCommand command = new NpgsqlCommand(SQLcmd, connection);
                command.Parameters.AddWithValue("@OfficerFormID", Session["OfficerFormID"].ToString());

                NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    CWR = reader.GetString(0);
                    Session["ReportID"] = reader.GetString(1);
                    PAVal = reader.GetString(2);
                }
                reader.Close();
            }

            if (CWR != "0")
            {
                string[] CWRArr = CWR.Split(';');
                totalnumberadded = CWRArr.Length;
                string[] CWRArr2 = new string[6];
                string[] initiative = new string[CWRArr2.Length];
                string[] objective = new string[CWRArr2.Length];
                string[] weightArr = new string[CWRArr2.Length];
                string[] note = new string[CWRArr2.Length];

                for (int i = 0; i < totalnumberadded; i++)
                {
                    CWRArr2 = CWRArr[i].Split('|');
                    initiative[i] = CWRArr2[1];
                    objective[i] = CWRArr2[2];
                    weightArr[i] = CWRArr2[3];
                    note[i] = CWRArr2[4];
                }
                for (int i = 0; i < totalnumberadded; i++)
                {
                    addKRA(i);
                    initiatives[i].Text = initiative[i];
                    objectives[i].Text = objective[i];
                    notes[i].Text = note[i];
                    kraweights[i].Text = weightArr[i];
                }
                addFinalRow();
            }
            else if (CWR == "0")
            {
                totalnumberadded = 1;
                for (int i = 0; i < totalnumberadded; i++)
                {
                    addKRA(i);
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
                    text += $"{i + 1}|{initiatives[i].Text}|{objectives[i].Text}|{notes[i].Text}|{kraweights[i].Text}|0";
                    break;
                }
                text += $"{i + 1}|{initiatives[i].Text}|{objectives[i].Text}|{notes[i].Text}|{kraweights[i].Text}|0;";

            }
            return text;
        }

        protected void UpdateCWR()
        {
            string compiledCWR = CompileAnswers();
            string storedOfficerFormID = Session["OfficerFormID"].ToString();

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=123456;Database=EmplyeeEval;"))
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
                if (double.Parse(weight.Text) > 100)
                {
                    weight.Text = "100";
                }
                else if (double.Parse(weight.Text) < 0)
                {
                    weight.Text = "0";
                }
                computeTotalWeight1(totalnumberadded);
            }
            catch (FormatException)
            {
                Response.Write("<script>alert('Error: Please type a positive number')</script>");
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
            double total = 0;
            try
            {
                for (int i = 0; i < kra; i++)
                {
                    total += inputChecker(kraweights[i].Text);
                }
                lblTotalWeight.Text = total.ToString("0.00");
            }
            catch
            {
                lblTotalWeight.Text = "";
            }
        }
        protected void ChangeSection(object sender, EventArgs e)
        {
            LinkButton link = sender as LinkButton;
            UpdateCWR();

            if (link.ID == "btnSection1")
                Response.Redirect("~/AgreementSection1Officers.aspx");
            else if (link.ID == "btnSection2")
                Response.Redirect("~/AgreementSection2Officers.aspx");
            else if (link.ID == "btnSection3")
                Response.Redirect("~/AgreementSection3Officers.aspx");
            else if (link.ID == "btnSection4")
                Response.Redirect("~/AgreementSection4Officers.aspx");
            else if (link.ID == "btnOverall")
                Response.Redirect("~/AgreementOverallOfficers.aspx");
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
            TextBox initiative = new TextBox { ID = "initiative" + i.ToString(), Width = 528, MaxLength = 50, TabIndex = Convert.ToSByte(i * 4 + 1) };
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
            TableCell tdObjective1 = new TableCell { CssClass = "auto-style20", Text = "Specific Objectives" };
            TableCell tdObjective2 = new TableCell { CssClass = "auto-style6" };
            TextBox objective = new TextBox { ID = "objectives" + i, Width = 528, MaxLength = 50, TabIndex = Convert.ToSByte(i * 4 + 2) };
            tdObjective2.Controls.Add(objective);
            objectives[i] = objective;
            TableCell tdObjective3 = new TableCell { CssClass = "auto-style18" };
            TextBox weight = new TextBox { ID = "weight1_" + i, AutoPostBack = true, Height = 18, Width = 91, CssClass = "normal", TabIndex = Convert.ToSByte(i * 4 + 3) };
            weight.TextChanged += weight_TextChanged;
            tdObjective3.Controls.Add(weight);
            kraweights[i] = weight;
            TableCell tdObjective4 = new TableCell { CssClass = "auto-style30" };
            TableCell tdObjective5 = new TableCell { CssClass = "auto-style31" };
            Label ws = new Label { ID = "label1_" + i, Text = "0" };
            tdObjective4.Controls.Add(ws);
            tr3.Cells.Add(tdObjective1);
            tr3.Cells.Add(tdObjective2);
            tr3.Cells.Add(tdObjective3);
            tr3.Cells.Add(tdObjective4);
            tr3.Cells.Add(tdObjective5);
            tablekra.Rows.Add(tr3);

            TableRow tr4 = new TableRow();
            TableCell tdNotes = new TableCell { ColumnSpan = 5 };
            TextBox note = new TextBox { Height = 18, Width = 1200, CssClass = "normal", TabIndex = Convert.ToSByte(i * 4 + 4) };
            tdNotes.Controls.Add(note);
            notes[i] = note;
            tr4.Cells.Add(tdNotes);
            tablekra.Rows.Add(tr4);
        }

        protected void addSpecificobjctivebtn(object sender, EventArgs e)
        {
            int index = int.Parse(kraindex.Text);
            int index2 = int.Parse(objNum.Text);
            if (index < totalnumberadded && index < 0)
            {
                Response.Write("<script>alert('The inputted KRA is not found.')</script>");
            }
            else
            {
                lastRow.Cells.Clear();
                tablekra.Rows.Remove(lastRow);
                addSpecificobjctive(totalnumberadded, index, index2);
                addFinalRow();
            }

        }

        protected void addSpecificobjctive(int totalnumberadd, int index, int objNum)
        {
            for (int i = 0; i < objNum; i++)
            {
                TableRow tr4 = new TableRow();
                TableCell tdNotes = new TableCell { ColumnSpan = 5 };
                TextBox note = new TextBox { Height = 18, Width = 1200, CssClass = "normal" };
                tdNotes.Controls.Add(note);
                notes2[totalnumberadd] = note;
                tr4.Cells.Add(tdNotes);
                tablekra.Rows.Add(tr4);
            }

        }

        protected void addkrabtn(object sender, EventArgs e)
        {
            totalnumberadded++;
            scopes[totalnumberadded] += 1;
            lastRow.Cells.Clear();
            tablekra.Rows.Remove(lastRow);
            addKRA(totalnumberadded - 1);
            addFinalRow();
        }

        protected void removekrabtn(object sender, EventArgs e)
        {
            if (totalnumberadded == 1)
            {
                Response.Write("<script>alert('You need to have one KRA')</script>");
            }
            else
            {
                totalnumberadded--;
                lastRow.Cells.Clear();
                removeKRA(totalnumberadded - 1);
                tablekra.Rows.Remove(lastRow);
                addFinalRow();
            }
        }
        protected void removeKRA(int i)
        {
            initiatives[i] = null;
            objectives[i] = null;
            kraweights[i] = null;
            notes[i] = null;
            tablekra.Rows.RemoveAt(i * 4 + 2);
            tablekra.Rows.RemoveAt(i * 4 + 2);
            tablekra.Rows.RemoveAt(i * 4 + 2);
            tablekra.Rows.RemoveAt(i * 4 + 2);
        }
        protected void addFinalRow()
        {
            TableCell td1 = new TableCell { CssClass = "auto-style20" };
            TableCell td2 = new TableCell { CssClass = "auto-style6", Text = "TOTAL" };
            TableCell td3 = new TableCell { CssClass = "auto-style18" };
            td3.Controls.Add(lblTotalWeight);
            TableCell td4 = new TableCell { CssClass = "auto-style30" };
            TableCell td5 = new TableCell { CssClass = "auto-style31" };

            lastRow.Cells.Add(td1);
            lastRow.Cells.Add(td2);
            lastRow.Cells.Add(td3);
            lastRow.Cells.Add(td4);
            lastRow.Cells.Add(td5);
            tablekra.Rows.Add(lastRow);
        }
    }
}
