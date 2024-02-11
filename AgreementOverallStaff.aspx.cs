using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class AgreementOverallStaff : System.Web.UI.Page
    {
        public bool btnOverallVisible { get { return Submit.Visible; } set { Submit.Visible = value; } }
        public bool btnOverallEnable { get { return Submit.Enabled; } set { Submit.Enabled = value; } }
        public bool agreeEnable { get { return Agree.Enabled; } set { Agree.Enabled = value; } }
        public bool agreeVisible { get { return Agree.Visible; } set { Agree.Visible = value; } }
        public bool disagreeEnable { get { return Disagree.Enabled; } set { Disagree.Enabled = value; } }
        public bool disagreeVisible { get { return Disagree.Visible; } set { Disagree.Visible = value; } }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            ((Site1)Page.Master).opt2class = "active";
            Page.MaintainScrollPositionOnPostBack = true;

            Initialize();
        }
        protected void Initialize() 
        {
            string CWR = "";

            if (!IsPostBack)
            {
                if (Session["AccType"].ToString() == "Supervisor")
                {
                    DisableButtons();
                }
                else
                {
                    agreeEnable = false;
                    agreeVisible = false;
                    disagreeEnable = false;
                    disagreeVisible = false;
                }
                using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=123456;Database=EmplyeeEval;"))
                {
                    connection.Open();

                    string storedStaffFormID = Session["StaffFormID"].ToString();

                    string sqlCode = @"SELECT ""OverallWR"" FROM ""StaffForm"" WHERE ""StaffFormID"" = @StaffFormID";
                    NpgsqlCommand command = new NpgsqlCommand(sqlCode, connection);
                    command.Parameters.AddWithValue("@StaffFormID", storedStaffFormID);

                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        CWR = reader.GetString(0);
                        Response.Write($"<script>alert('{CWR}')</script>");
                    }
                    reader.Close();

                    if (CWR != "0")
                    {
                        string[] CWRArr = CWR.Split(';');
                        string[] CWRArr2 = new string[3];
                        string[] weightArr = new string[8];

                        for (int i = 0; i < CWRArr.Length; i++)
                        {
                            CWRArr2 = CWRArr[i].Split(',');
                            weightArr[i] = CWRArr2[1];
                        }

                        weight1_1.Text = weightArr[0];
                        weight1_2.Text = weightArr[1];

                        
                    }
                    computeTotalWeight2();

                    
                }
            }
        }

        protected void DisableButtons() 
        {
            weight1_1.Enabled = false;
            weight1_2.Enabled = false;
            btnOverallVisible = false;
            btnOverallEnable = false;
            agreeEnable = true;
            agreeVisible = true;
            disagreeEnable = true;
            disagreeVisible = true;
        }

        protected void weight_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox weight = sender as TextBox;
                double weightedScore;
                if (weight.ID == "weight1_1")
                {
                    if (double.Parse(weight.Text) > 100)
                    {
                        weight1_1.Text = "100";
                    }
                    weightedScore = double.Parse(weight1_1.Text);
                }
                else if (weight.ID == "weight1_2")
                {
                    if (double.Parse(weight.Text) > 100)
                    {
                        weight1_2.Text = "100";
                    }
                    weightedScore = double.Parse(weight1_2.Text);
                }
                computeTotalWeight2();
            }
            catch (FormatException)
            {
                Response.Write("<script>alert('Error: Please type a positive number')</script>");
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
        protected void computeTotalWeight2()
        {
            double weight1 = 0, weight2 = 0, total = 0;
            weight1 = inputChecker(weight1_1.Text);
            weight2 = inputChecker(weight1_2.Text);
            total = weight1 + weight2;
            labelTotal1.Text = total.ToString("0.00");
            if (labelTotal1.Text == "100.00")
            {
                Submit.Enabled = true;
            }
        }
        protected void checkWeight(object sender, EventArgs e)
        {
            LinkButton link = sender as LinkButton;
            if (weight1_1.Text == "0" || weight1_2.Text == "0")
            {
                Response.Write("<script>alert('Please input a number from 1-100.')</script>");
            }
            else if (labelTotal1.Text != "100.00")
            {
                Response.Write("<script>alert('Your total weight is not 100.')</script>");
            }
            else
            {
                UpdateCWR();

                if (link.ID == "btnSection1")
                {
                    //insert database commands here
                    Response.Redirect("~/AgreementSection1Staff.aspx");
                }
                else if (link.ID == "btnSection2")
                {
                    //insert database commands here
                    Response.Redirect("~/AgreementSection2Staff.aspx");
                }
                else if (link.ID == "btnOverall")
                {
                    //insert database commands here
                    Response.Redirect("~/AgreementOverallStaff.aspx");
                }
            }
        }

        protected void UpdateCWR() 
        {
            string compiledCWR = CompileAnswers();
            string storedStaffFormID = Session["StaffFormID"].ToString();

            // reese: using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=12345;Database=postgres;"))
            using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=123456;Database=EmplyeeEval;"))
            {
                connection.Open();

                NpgsqlCommand command = new NpgsqlCommand(@"UPDATE ""StaffForm"" SET ""OverallWR"" = @OverallWR WHERE ""StaffFormID"" = @StaffFormID", connection);
                command.Parameters.AddWithValue("@OverallWR", compiledCWR);
                command.Parameters.AddWithValue("@StaffFormID", storedStaffFormID);
                command.ExecuteNonQuery();
            }
        }
        protected string CompileAnswers()
        {
            string text = "";

            text += $"1,{weight1_1.Text},0;";
            text += $"2,{weight1_2.Text},0";


            return text;
        }
        protected void Submit_Click(object sender, EventArgs e)
        {

            //if (weight1_1.Text == "0" || weight1_2.Text == "0")
            //{
            //    Response.Write("<script>alert('Please complete the form first.')</script>");
            //}
            //else
            //{
            //    Response.Redirect("MyAccount.aspx");
            //}

            using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=123456;Database=EmplyeeEval;"))
            {
                string CWR1 = "", CWR2= "", CWR3 = "";
                string storedStaffFormID = Session["StaffFormID"].ToString();
                connection.Open();

                NpgsqlCommand command = new NpgsqlCommand(@"SELECT ""Section1CWR"", ""Section2CWR"", ""OverallWR"" FROM ""StaffForm"" WHERE ""StaffFormID"" = @StaffFormID", connection);
                command.Parameters.AddWithValue("@StaffFormID", storedStaffFormID);

                NpgsqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    CWR1 = reader.GetString(0);
                    CWR2 = reader.GetString(1);
                    CWR3 = reader.GetString(2);
                }
                reader.Close();

                int sec1Weight, sec2Weight, overallWeight;
                sec1Weight = GetTotalWeight(CWR1);
                sec2Weight = GetTotalWeight(CWR2);
                overallWeight = GetTotalWeight(CWR3);

                if (sec1Weight != 100)
                    Response.Write("<script>alert('The total weight in section 1 is not equal to 100.')</script>");
                else if (sec2Weight != 100)
                    Response.Write("<script>alert('The total weight in section 2 is not equal to 100.')</script>");
                else 
                {
                    UpdateCWR();
                    string storedFormID = Session["FormID"].ToString();
                    string status = "To Be Checked";
                    // reese: using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=12345;Database=postgres;"))
                    using (NpgsqlConnection connection2 = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=123456;Database=EmplyeeEval;"))
                    {
                        connection2.Open();

                        command = new NpgsqlCommand(@"UPDATE ""EmployeePerformance"" SET ""Status"" = @Status WHERE ""FormID"" = @FormID", connection2);
                        command.Parameters.AddWithValue("@Status", status);
                        command.Parameters.AddWithValue("@FormID", storedFormID);
                        command.ExecuteNonQuery();
                    }
                    Response.Redirect("MyAccount.aspx");
                }
            }
        }

        protected int GetTotalWeight(string text) 
        {
            if (text != "0")
            {
                string[] textArr = text.Split(';');
                string[] textArr2 = new string[3];
                string[] weight1Arr = new string[textArr.Length];

                for (int i = 0; i < textArr.Length; i++)
                {
                    textArr2 = textArr[i].Split(',');
                    weight1Arr[i] = textArr2[1];
                }

                int weight = 0;
                foreach (var item in weight1Arr)
                {
                    weight += int.Parse(item);
                }
                return weight;
            }
            else 
            {
                return 0;
            }
        }

        protected void Agree_Click(object sender, EventArgs e) 
        {
            string storedFormID = Session["FormID"].ToString();
            string status = "Approved";
            // reese: using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=12345;Database=postgres;"))
            using (NpgsqlConnection connection2 = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=123456;Database=EmplyeeEval;"))
            {
                connection2.Open();

                NpgsqlCommand command = new NpgsqlCommand(@"UPDATE ""EmployeePerformance"" SET ""Status"" = @Status WHERE ""FormID"" = @FormID", connection2);
                command.Parameters.AddWithValue("@Status", status);
                command.Parameters.AddWithValue("@FormID", storedFormID);
                command.ExecuteNonQuery();
            }
            Response.Redirect("MyAccount.aspx");
        }

        protected void Disgree_Click(object sender, EventArgs e)
        {
            string storedStaffFormID = Session["StaffFormID"].ToString();
            string storedFormID = Session["FormID"].ToString();
            string status = "Rejected";
            // reese: using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=12345;Database=postgres;"))
            using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=123456;Database=EmplyeeEval;"))
            {
                connection.Open();

                NpgsqlCommand command = new NpgsqlCommand(@"UPDATE ""EmployeePerformance"" SET ""Status"" = @Status WHERE ""FormID"" = @FormID", connection);
                command.Parameters.AddWithValue("@Status", status);
                command.Parameters.AddWithValue("@FormID", storedFormID);
                command.ExecuteNonQuery();

                command = new NpgsqlCommand(@"UPDATE ""StaffForm"" SET ""Section1CWR"" = 0, ""Section2CWR"" = 0, ""OverallWR"" = 0 WHERE ""StaffFormID"" = @StaffFormID", connection);
                command.Parameters.AddWithValue("@StaffFormID", storedStaffFormID);
                command.ExecuteNonQuery();

            }
            Response.Redirect("MyAccount.aspx");

        }

    }
}