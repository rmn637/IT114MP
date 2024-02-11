using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace WebApplication1
{
    public partial class EvaluationOverallStaff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            ((Site1)Page.Master).opt3class = "active";
            Page.MaintainScrollPositionOnPostBack = true;


            if (!IsPostBack)
            {
                Initialize();
            }
            
        }

        protected void Initialize() 
        {
            SetSectionTotals();
            double sec1Total = 0, sec2Total = 0, total = 0;
            sec1Total = double.Parse(total1.Text);
            sec2Total = double.Parse(total2.Text);
            total = sec1Total*.60 + sec2Total*.40;
            labelTotal1.Text = total.ToString("0.00");
            Submit.Enabled = true;
        }

        protected void SetSectionTotals() 
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=123456;Database=EmplyeeEval;"))
            {
                string CWR1 = "", CWR2 = "";
                connection.Open();
                string storedStaffFormID = Session["StaffFormID"].ToString();

                string sqlCode = @"SELECT ""Section1CWR"", ""Section2CWR"" FROM ""StaffForm"" WHERE ""StaffFormID"" = @StaffFormID";
                NpgsqlCommand command = new NpgsqlCommand(sqlCode, connection);
                command.Parameters.AddWithValue("@StaffFormID", storedStaffFormID);

                NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    CWR1 = reader.GetString(0);
                    CWR2 = reader.GetString(1);
                }
                reader.Close();
                total1.Text = ComputeSectionTotals(CWR1);
                total2.Text = ComputeSectionTotals(CWR2);
            }
        }

        protected string ComputeSectionTotals(string CWR) 
        {
            if (CWR != "0")
            {
                string[] CWRArr = CWR.Split(';');
                string[] CWRArr2 = new string[3];
                double[] weightArr = new double[8];
                double[] ratingArr = new double[8]; 

                for (int i = 0; i < CWRArr.Length; i++)
                {
                    CWRArr2 = CWRArr[i].Split(',');
                    weightArr[i] = double.Parse(CWRArr2[1]);
                    ratingArr[i] = double.Parse(CWRArr2[2]);
                }

                double total = 0;

                for (int i = 0; i < weightArr.Length; i++)
                {
                    total += weightArr[i] * ratingArr[i] * .2;
                }

                return total.ToString();
            }
            return 0.ToString();
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if (CheckComments() == false)
            {
                Response.Write("<script>alert('You have not finished commenting.')</script>");
            }
            else if (total1.Text == "0") 
            {
                Response.Write("<script>alert('You have not finished evaulating in section 1.')</script>");
            }
            else if (total2.Text == "0")
            {
                Response.Write("<script>alert('You have not finished evaulating in section 2.')</script>");
            }
            else
            {
                UpdateEmpPerf();
                Response.Redirect("MyAccount.aspx");
            }
        }

        protected bool CheckComments() 
        {
            string strComment = "", impComment = "", devComment = "", ackComment = "";
            using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=123456;Database=EmplyeeEval;"))
            {
                connection.Open();
                string storedStaffFormID = Session["StaffFormID"].ToString();

                string sqlCode = @"SELECT ""Strength"", ""Improvement"", ""Development"", ""Acknowledgement"" FROM ""StaffForm"" WHERE ""StaffFormID"" = @StaffFormID";
                NpgsqlCommand command = new NpgsqlCommand(sqlCode, connection);
                command.Parameters.AddWithValue("@StaffFormID", storedStaffFormID);

                NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    strComment = reader.GetString(0);
                    impComment = reader.GetString(1);
                    devComment = reader.GetString(2);
                    ackComment = reader.GetString(3);
                }
                reader.Close();
            }
            if (strComment == "" || impComment == "" || devComment == "" || ackComment == "")
            {
                return false;
            }
            return true;
        }

        protected void UpdateEmpPerf()
        {
            string storedFormID = Session["FormID"].ToString();
            try
            {
                // reese: using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=12345;Database=postgres;"))
                using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=123456;Database=EmplyeeEval;"))
                {
                    connection.Open();

                    NpgsqlCommand command = new NpgsqlCommand(@"UPDATE ""EmployeePerformance"" SET ""PerfPts"" = @PerfPts, ""Status"" = @Status WHERE ""FormID"" = @FormID", connection);
                    command.Parameters.AddWithValue("@PerfPts", labelTotal1.Text);
                    command.Parameters.AddWithValue("@Status", "Done");
                    command.Parameters.AddWithValue("@FormID", storedFormID);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void total_TextChanged(object sender, EventArgs e)
        {
            
        }
        protected void checkWeight(object sender, EventArgs e)
        {
            LinkButton link = sender as LinkButton;
            if (link.ID == "btnSection1")
            {
                //insert database commands here
                Response.Redirect("~/EvaluationSection1Staff.aspx");
            }
            else if (link.ID == "btnSection2")
            {
                //insert database commands here
                Response.Redirect("~/EvaluationSection2Staff.aspx");
            }
            else if (link.ID == "btnSection3")
            {
                //insert database commands here
                Response.Redirect("~/EvaluationCommentsStaff.aspx");
            }
            else if (link.ID == "btnOverall")
            {
                //insert database commands here
                Response.Redirect("~/EvaluationOverallStaff.aspx");
            }
        }
    }
}