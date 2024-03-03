using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class AgreementSection2Officers : System.Web.UI.Page
    {
        protected static int totalnumberadded;
        protected static TextBox[] scopesWeight = new TextBox[10];
        protected static TextBox[] scopes = new TextBox[10];
        protected static TextBox[] notes = new TextBox[10];
        protected static Label lblTotalWeight = new Label { ID = "labelTotal", Text = " ", Width = 90 };
        protected TableRow lastRow = new TableRow { ID = "lastRow" };
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            ((Site1)Page.Master).opt2class = "active";
            Page.MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
                Initialize();
            if (IsPostBack)
            {
                for (int i = 0; i < totalnumberadded; i++)
                {
                    addScope(i);
                }
                addFinalRow();
            }
            if (totalnumberadded == 9)
            {
                addScopebtn.Enabled = false;
                addScopebtn.Visible = false;
            }
        }

        protected void Initialize()
        {
            string SQLcmd, CWR = "", PAVal = "";
            using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=123456;Database=EmplyeeEval;"))
            {
                connection.Open();
                SQLcmd = @"SELECT ""Section2CNWR"", ""ReportID"", ""PAValidation"" FROM ""FacultyForm"" INNER JOIN ""EmployeePerformance"" ON ""FacultyForm"".""FormID"" = ""EmployeePerformance"".""FormID"" INNER JOIN ""StatusReport"" ON ""EmployeePerformance"".""EmpID"" = ""StatusReport"".""EmpID"" WHERE ""FacultyFormID"" = @FacultyFormID";
                NpgsqlCommand command = new NpgsqlCommand(SQLcmd, connection);
                command.Parameters.AddWithValue("@FacultyFormID", Session["FacultyFormID"].ToString());

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
                string[] CWRArr2 = new string[10];
                string[] scopeArr = new string[CWRArr2.Length];
                string[] weightArr = new string[CWRArr2.Length];
                string[] notesArr = new string[CWRArr2.Length];

                for (int i = 0; i < totalnumberadded; i++)
                {
                    CWRArr2 = CWRArr[i].Split('|');
                    scopeArr[i] = CWRArr2[1];
                    notesArr[i] = CWRArr2[2];
                    weightArr[i] = CWRArr2[3];
                }
                for (int i = 0; i < totalnumberadded; i++)
                {
                    addScope(i);
                    scopes[i].Text = scopeArr[i];
                    notes[i].Text = notesArr[i];
                    scopesWeight[i].Text = weightArr[i];
                }
                addFinalRow();
            }
            else if (CWR == "0")
            {
                totalnumberadded = 1;
                for (int i = 0; i < totalnumberadded; i++)
                {
                    addScope(i);
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
                    text += $"{i + 1}|{scopes[i].Text}|{notes[i].Text}|{scopesWeight[i].Text}|0";
                    break;
                }
                text += $"{i + 1}|{scopes[i].Text}|{notes[i].Text}|{scopesWeight[i].Text}|0;";

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
                //using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=123456;Database=EmplyeeEval;"))
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
                    total += inputChecker(scopesWeight[i].Text);
                }
                lblTotalWeight.Text = total.ToString("0.00");
            }
            catch
            {
                lblTotalWeight.Text = "";
            }
        }
        protected void addScope(int i)
        {
            TableRow tr1 = new TableRow();
            TableCell td1 = new TableCell { CssClass = "auto-style3" };
            TextBox scope = new TextBox { ID = "scope" + i.ToString(), MaxLength = 50, Width = 481, TabIndex = Convert.ToSByte(i * 4 + 1) };
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
            TextBox note = new TextBox { ID = "notes" + i.ToString(), MaxLength = 50, Width = 481, TabIndex = Convert.ToSByte(i * 4 + 1) };
            notes[i] = note;
            tdnotes1.Controls.Add(note);
            tr2.Cells.Add(tdnotes1);

            TableCell tdnotes2 = new TableCell { CssClass = "auto-style5" };
            TextBox weight = new TextBox { ID = "weight1_" + i.ToString(), AutoPostBack = true, Height = 18, Width = 91, CssClass = "normal", TabIndex = Convert.ToSByte(i * 4 + 2) };
            weight.TextChanged += weight_TextChanged;
            scopesWeight[i] = weight;
            tdnotes2.Controls.Add(weight);
            tr2.Cells.Add(tdnotes2);

            TableCell tdnotes3 = new TableCell { CssClass = "auto-style34", Text = " " };
            tr2.Cells.Add(tdnotes3);

            TableCell tdnotes4 = new TableCell { CssClass = "auto-style33" };
            Label labelws = new Label { ID = "label2_" + i.ToString(), Text = "0" };
            tr2.Cells.Add(tdnotes4);
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

        protected void removekrabtn(object sender, EventArgs e)
        {
            if (totalnumberadded == 1)
            {
                Response.Write("<script>alert('Yo need to have one KRA')</script>");
            }
            else
            {
                totalnumberadded--;
                lastRow.Cells.Clear();
                removeKRA(totalnumberadded - 1);
                tableScope.Rows.Remove(lastRow);
                addFinalRow();
            }
        }
        protected void removeKRA(int i)
        {
            notes[i] = null;
            scopes[i] = null;
            scopesWeight[i] = null;
            tableScope.Rows.RemoveAt(i * 2 + 2);
            tableScope.Rows.RemoveAt(i * 4 + 2);
        }
        protected void addFinalRow()
        {
            TableCell td1 = new TableCell { CssClass = "auto-style7", Text = "TOTAL" };
            TableCell td2 = new TableCell { CssClass = "auto-style5" };
            td2.Controls.Add(lblTotalWeight);
            TableCell td3 = new TableCell { CssClass = "auto-style34" };
            TableCell td4 = new TableCell { CssClass = "auto-style33" };

            lastRow.Cells.Add(td1);
            lastRow.Cells.Add(td2);
            lastRow.Cells.Add(td3);
            lastRow.Cells.Add(td4);
            tableScope.Rows.Add(lastRow);
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
    }
}