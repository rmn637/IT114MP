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
        string empID, empType, process, field = "Section2CNWR";
        protected static int totalnumberadded;
        protected static int[] scopesNum = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        protected static TextBox[] scopesWeight = new TextBox[10];
        protected static TextBox[] scopes = new TextBox[10];
        protected static TextBox[] array1 = new TextBox[10], array2 = new TextBox[10], array3 = new TextBox[10], array4 = new TextBox[10], array5 = new TextBox[10],
        array6 = new TextBox[10], array7 = new TextBox[10], array8 = new TextBox[10], array9 = new TextBox[10], array10 = new TextBox[10];
        protected static TextBox[][] notesArray = new TextBox[10][] { array1, array2, array3, array4, array5, array6, array7, array8, array9, array10 };
        protected static Label lblTotalWeight = new Label { ID = "labelTotal", Text = " ", Width = 90 };
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
            if (totalnumberadded == 9)
            {
                addScopebtn.Enabled = false;
                addScopebtn.Visible = false;
            }
        }

        protected void Initialize()
        {
            string SQLcmd, CWR = "", PAVal = "";
            using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=1234;Database=EmployeeEval;"))
            {
                connection.Open();
                SQLcmd = @"SELECT ""Section2CNWR"", ""ReportID"", ""PAValidation"" FROM ""OfficerForm"" INNER JOIN ""EmployeePerformance"" ON ""OfficerForm"".""FormID"" = ""EmployeePerformance"".""FormID"" INNER JOIN ""StatusReport"" ON ""EmployeePerformance"".""EmpID"" = ""StatusReport"".""EmpID"" WHERE ""OfficerFormID"" = @OfficerFormID";
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

            Session["PAValDone"] = PAVal != "0" && PAVal != null;

            if (CWR != "0")
            {
                string[] CWRArr = CWR.Split(';');
                totalnumberadded = CWRArr.Length;
                string[] CWRArr2 = new string[10];
                string[] scopeArr = new string[CWRArr2.Length];
                string[] weightArr = new string[CWRArr2.Length];
                string[][] notesArr = new string[CWRArr2.Length][];

                for (int i = 0; i < totalnumberadded; i++)
                {
                    CWRArr2 = CWRArr[i].Split('|');
                    scopeArr[i] = CWRArr2[1];
                    notesArr[i] = CWRArr2[2].Split('_');
                    scopesNum[i] = CWRArr2[2].Split('_').Length - 1;
                    weightArr[i] = CWRArr2[3];
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
                            notesArray[i][k].Text = "";
                        else
                            notesArray[i][k].Text = notesArr[i][k];
                    }
                    scopesWeight[i].Text = weightArr[i];
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
                    text += $"|{scopesWeight[i].Text}|0";
                    break;
                }
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
                text += $"|{scopesWeight[i].Text}|0;";

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

        protected void addSpecificobjctivebtn(object sender, EventArgs e)
        {
            Button addobjective = sender as Button;
            int index = int.Parse(addobjective.ID[11].ToString());
            if (index > totalnumberadded || index <= 0)
            {
                Response.Write("<script>alert('The inputted KRA is not found.')</script>");
            }
            else if (scopesNum[index - 1] > 10 || scopesNum[index - 1] < 0)
            {
                Response.Write("<script>alert('You cannot add more specific objectives.')</script>");
            }
            else
            {
                lastRow.Cells.Clear();
                tableScope.Rows.Remove(lastRow);
                addSpecificobjctive(index);
                int total = scopesNum[index - 1] + 1;
                scopesNum[index - 1] = total;
                addFinalRow();
            }
        }

        protected void removeSpecificobjctivebtn(object sender, EventArgs e)
        {
            Button removeobjective = sender as Button;
            int index = int.Parse(removeobjective.ID[14].ToString());
            if (index > totalnumberadded || index <= 0)
            {
                Response.Write("<script>alert('The inputted KRA is not found.')</script>");
            }
            else if (scopesNum[index - 1] > 10 || scopesNum[index - 1] <= 0)
            {
                Response.Write("<script>alert('You cannot remove more specific objectives.')</script>");
            }
            else
            {
                lastRow.Cells.Clear();
                tableScope.Rows.Remove(lastRow);
                int total = scopesNum[index - 1] - 1;
                scopesNum[index - 1] = total;
                removeSpecificobjctive(index);
                addFinalRow();
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
            Label Space = new Label { ID = "Space" + (1 + i).ToString(), Text = "    " };
            Button addScopebtn = new Button { ID = "addScopebtn" + (1 + i).ToString(), Text = "+", CssClass = "z" };
            Button removeScopebtn = new Button { ID = "removeScopebtn" + (1 + i).ToString(), Text = "-", CssClass = "z" };

            addScopebtn.Click += addSpecificobjctivebtn;
            removeScopebtn.Click += removeSpecificobjctivebtn;
            notesArray[i][0] = note;
            tdnotes1.Controls.Add(note);
            tdnotes1.Controls.Add(addScopebtn);
            tdnotes1.Controls.Add(Space);
            tdnotes1.Controls.Add(removeScopebtn);
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
                TextBox note = new TextBox { Height = 18, Width = 1200, CssClass = "normal" };
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

        protected void addSpecificobjctive(int index)
        {
            int total = 0;
            for (int totalscopes = 0; totalscopes < index; totalscopes++)
            {
                total += scopesNum[totalscopes];
            }
            TableRow tr4 = new TableRow();
            TableCell tdNotes = new TableCell { ColumnSpan = 5 };
            TextBox note = new TextBox { Height = 18, Width = 1200, CssClass = "normal" };
            tdNotes.Controls.Add(note);
            notesArray[index - 1][scopesNum[index - 1]] = note;
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

        protected void removeSpecificobjctive(int index)
        {
            int total = 0;
            for (int totalscopes = 0; totalscopes < index; totalscopes++)
            {
                total += scopesNum[totalscopes];
            }
            notesArray[index - 1][scopesNum[index - 1] + 1] = null;
            if (index == 1)
            {
                tableScope.Rows.RemoveAt(1 + index * 2);
            }
            else
            {
                tableScope.Rows.RemoveAt(1 + index * 2 + total);
            }
        }
        protected void removeScope(int i)
        {
            if (i == 1)
            {
                notesArray[i] = new TextBox[10];
                scopes[i] = null;
                scopesWeight[i] = null;
                for (int k = 0; k < scopesNum[i] + 2; k++)
                {
                    tableScope.Rows.RemoveAt(i * 2 + 1 + scopesNum[0]);
                }
                scopesNum[i] = 0;
            }
            else
            {
                int total = 0;
                notesArray[i] = new TextBox[10];
                scopes[i] = null;
                scopesWeight[i] = null;
                for (int totalscopes = 0; totalscopes < i; totalscopes++)
                {
                    total += scopesNum[totalscopes];
                }
                for (int k = 0; k < scopesNum[i] + 2; k++)
                {
                    tableScope.Rows.RemoveAt(i * 2 + 1 + total);
                }
                scopesNum[i] = 0;
            }
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

        protected void removescopebtn(object sender, EventArgs e)
        {
            if (totalnumberadded == 1)
            {
                Response.Write("<script>alert('Yo need to have one KRA')</script>");
            }
            else
            {
                totalnumberadded--;
                lastRow.Cells.Clear();
                removeScope(totalnumberadded - 1);
                tableScope.Rows.Remove(lastRow);
                addFinalRow();
            }
        }

        protected void ChangeSection(object sender, EventArgs e)
        {
            LinkButton link = sender as LinkButton;
            if (!bool.Parse(Session["PAValDone"].ToString()))
                UpdateCWR();

            if (link.ID == "btnSection1")
                Response.Redirect("~/OAS1.aspx");
            else if (link.ID == "btnSection2")
                Response.Redirect("~/OAS2.aspx");
            else if (link.ID == "btnSection3")
                Response.Redirect("~/OAS3.aspx");
            else if (link.ID == "btnSection4")
                Response.Redirect("~/OAS4.aspx");
            else if (link.ID == "btnOverall")
                Response.Redirect("~/OAO.aspx");
        }
    
}
}