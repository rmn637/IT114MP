using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class AgreementSection2Staff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //write form id
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            ((Site1)Page.Master).opt2class = "active";
            Page.MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
               Initialize();
        }

        protected void Initialize() 
        {
            string SQLcmd, CWR = "", PAVal = "";
            using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=123456;Database=EmplyeeEval;"))
            {
                connection.Open();
                SQLcmd = @"SELECT ""Section2CWR"", ""ReportID"", ""PAValidation"" FROM ""StaffForm"" INNER JOIN ""EmployeePerformance"" ON ""StaffForm"".""FormID"" = ""EmployeePerformance"".""FormID"" INNER JOIN ""StatusReport"" ON ""EmployeePerformance"".""EmpID"" = ""StatusReport"".""EmpID"" WHERE ""StaffFormID"" = @StaffFormID";
                NpgsqlCommand command = new NpgsqlCommand(SQLcmd, connection);
                command.Parameters.AddWithValue("@StaffFormID", Session["StaffFormID"].ToString());

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
                    weight2_1,
                    weight2_2,
                    weight2_3,
                    weight2_4,
                    weight2_5
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
            computeTotalWeight2();

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
                computeTotalWeight2();
            }
            catch (FormatException)
            {
                Response.Write("<script>alert('Error: Please type a positive number')</script>");
                weight.Text = "0";
            }
        }
        protected void computeTotalWeight2()
        {
            double weight1 = 0, weight2 = 0, weight3 = 0, weight4 = 0, weight5 = 0, total = 0;
            weight1 = double.Parse(weight2_1.Text);
            weight2 = double.Parse(weight2_2.Text);
            weight3 = double.Parse(weight2_3.Text);
            weight4 = double.Parse(weight2_4.Text);
            weight5 = double.Parse(weight2_5.Text);
            total = weight1 + weight2 + weight3 + weight4 + weight5;
            labelTotal2.Text = total.ToString("0.00");
        }
        protected void ChangeSection(object sender, EventArgs e)
        {
            LinkButton link = sender as LinkButton;
            if (!bool.Parse(Session["PAValDone"].ToString()))
                UpdateCWR();

            if (link.ID == "btnSection1")
                Response.Redirect("~/AgreementSection1Staff.aspx");
            else if (link.ID == "btnSection2")
                Response.Redirect("~/AgreementSection2Staff.aspx");
            else if (link.ID == "btnOverall")
                Response.Redirect("~/AgreementOverallStaff.aspx");
        }

        protected void UpdateCWR() 
        {
            string compiledCWR = CompileAnswers();
            string storedStaffFormID = Session["StaffFormID"].ToString();

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=123456;Database=EmplyeeEval;"))
                {
                    connection.Open();

                    NpgsqlCommand command = new NpgsqlCommand(@"UPDATE ""StaffForm"" SET ""Section2CWR"" = @Section2CWR WHERE ""StaffFormID"" = @StaffFormID", connection);
                    command.Parameters.AddWithValue("@Section2CWR", compiledCWR);
                    command.Parameters.AddWithValue("@StaffFormID", storedStaffFormID);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected string CompileAnswers()
        {
            return $"1,{weight2_1.Text},0;" +
                $"2,{weight2_2.Text},0;" +
                $"3,{weight2_3.Text},0;" +
                $"4,{weight2_4.Text},0;" +
                $"5,{weight2_5.Text},0";
        }
    }
}