using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class AgreementSection3Officers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            ((Site1)Page.Master).opt2class = "active";
            Page.MaintainScrollPositionOnPostBack = true;
            if(!IsPostBack)
                Initialize();
        }

        protected void Initialize()
        {
            string SQLcmd, CWR = "", PAVal = "";

            using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=123456;Database=EmplyeeEval;"))
            {
                connection.Open();

                SQLcmd = @"SELECT ""Section3CWR"", ""ReportID"", ""PAValidation"" FROM ""OfficerForm"" INNER JOIN ""EmployeePerformance"" ON ""OfficerForm"".""FormID"" = ""EmployeePerformance"".""FormID"" INNER JOIN ""StatusReport"" ON ""EmployeePerformance"".""EmpID"" = ""StatusReport"".""EmpID"" WHERE ""OfficerFormID"" = @OfficerFormID";
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

            List<TextBox> weightTextBoxes = new List<TextBox> {
                    weight1_1,
                    weight1_2,
                    weight1_3,
                    weight1_4,
                    weight1_5,
                    weight1_6,
                    weight1_7,
                    weight1_8
            };

            if (CWR != "0")
            {
                string[] CWRArr = CWR.Split(';');
                for (int i = 0; i < CWRArr.Length; i++)
                {
                    string[] CWRValues = CWRArr[i].Split(',');
                    weightTextBoxes[i].Text = CWRValues[1];
                }
            }

            computeTotalWeight1();

            bool PAValDone = PAVal != "0" && PAVal != null;
            Session["PAValDone"] = PAValDone.ToString();
            foreach (var item in weightTextBoxes)
            {
                item.Enabled = !PAValDone;
            }
        }

        protected void weight_TextChanged(object sender, EventArgs e)
        {
            TextBox weight = sender as TextBox;
            try
            {
                if (double.Parse(weight.Text) > 100)
                    weight.Text = "100";
                else if (double.Parse(weight.Text) < 0)
                    weight.Text = "0";
                computeTotalWeight1();
            }
            catch (FormatException)
            {
                Response.Write("<script>alert('Error: Please type a positive number')</script>");
                weight.Text = "0";
            }
        }
        protected void computeTotalWeight1()
        {
            double weight1, weight2, weight3, weight4, weight5, weight6, weight7, weight8, total;
            weight1 = double.Parse(weight1_1.Text);
            weight2 = double.Parse(weight1_2.Text);
            weight3 = double.Parse(weight1_3.Text);
            weight4 = double.Parse(weight1_4.Text);
            weight5 = double.Parse(weight1_5.Text);
            weight6 = double.Parse(weight1_6.Text);
            weight7 = double.Parse(weight1_7.Text);
            weight8 = double.Parse(weight1_8.Text);
            total = weight1 + weight2 + weight3 + weight4 + weight5 + weight6 + weight7 + weight8;
            labelTotal1.Text = total.ToString("0.00");

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
        protected string CompileAnswers()
        {
            return $"1,{weight1_1.Text},0;" +
            $"2,{weight1_2.Text},0;" +
            $"3,{weight1_3.Text},0;" +
            $"4,{weight1_4.Text},0;" +
            $"5,{weight1_5.Text},0;" +
            $"6,{weight1_6.Text},0;" +
            $"7,{weight1_7.Text},0;" +
            $"8,{weight1_8.Text},0";
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

                    NpgsqlCommand command = new NpgsqlCommand(@"UPDATE ""OfficerForm"" SET ""Section3CWR"" = @Section3CWR WHERE ""OfficerFormID"" = @OfficerFormID", connection);
                    command.Parameters.AddWithValue("@Section3CWR", compiledCWR);
                    command.Parameters.AddWithValue("@OfficerFormID", storedOfficerFormID);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}