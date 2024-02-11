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

            Initialize();
        }

        protected void Initialize() 
        {
            string CWR = "";

            if (!IsPostBack)
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=123456;Database=EmplyeeEval;"))
                {
                    connection.Open();

                    string storedStaffFormID = Session["StaffFormID"].ToString();

                    string sqlCode = @"SELECT ""Section2CWR"" FROM ""StaffForm"" WHERE ""StaffFormID"" = @StaffFormID";
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

                        weight2_1.Text = weightArr[0];
                        weight2_2.Text = weightArr[1];
                        weight2_3.Text = weightArr[2];
                        weight2_4.Text = weightArr[3];
                        weight2_5.Text = weightArr[4];

                        computeTotalWeight2();

                        if (Session["AccType"].ToString() == "Supervisor")
                        {
                            DisableButtons();
                        }
                    }
                }
            }
        }
        protected void DisableButtons()
        {
            weight2_1.Enabled = false;
            weight2_2.Enabled = false;
            weight2_3.Enabled = false;
            weight2_4.Enabled = false;
            weight2_5.Enabled = false;
        }
        protected void weight_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox weight = sender as TextBox;
                double weightedScore;
                if (weight.ID == "weight2_1")
                {
                    if (double.Parse(weight.Text) > 100)
                    {
                        weight2_1.Text = "100";
                    }
                    weightedScore = double.Parse(weight2_1.Text);
                }
                else if (weight.ID == "weight2_2")
                {
                    if (double.Parse(weight.Text) > 100)
                    {
                        weight2_2.Text = "100";
                    }
                    weightedScore = double.Parse(weight2_2.Text);
                }
                else if (weight.ID == "weight2_3")
                {
                    if (double.Parse(weight.Text) > 100)
                    {
                        weight2_3.Text = "100";
                    }
                    weightedScore = double.Parse(weight2_3.Text);
                }
                else if (weight.ID == "weight2_4")
                {
                    if (double.Parse(weight.Text) > 100)
                    {
                        weight2_4.Text = "100";
                    }
                    weightedScore = double.Parse(weight2_4.Text);
                }
                else
                {
                    if (double.Parse(weight.Text) > 100)
                    {
                        weight2_5.Text = "100";
                    }
                    weightedScore = double.Parse(weight2_5.Text);
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
            double weight1 = 0, weight2 = 0, weight3 = 0, weight4 = 0, weight5 = 0, total = 0;
            weight1 = inputChecker(weight2_1.Text);
            weight2 = inputChecker(weight2_2.Text);
            weight3 = inputChecker(weight2_3.Text);
            weight4 = inputChecker(weight2_4.Text);
            weight5 = inputChecker(weight2_5.Text);
            total = weight1 + weight2 + weight3 + weight4 + weight5;
            labelTotal2.Text = total.ToString("0.00");
        }
        protected void checkWeight(object sender, EventArgs e)
        {
            LinkButton link = sender as LinkButton;
            if (weight2_1.Text == "0" || weight2_2.Text == "0" || weight2_3.Text == "0" || weight2_4.Text == "0" || weight2_5.Text == "0")
            {
                Response.Write("<script>alert('Please input a number from 1-100.')</script>");
            }
            else if (labelTotal2.Text != "100.00")
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

            try
            {
                // reese: using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=12345;Database=postgres;"))
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
            string text = "";

            text += $"1,{weight2_1.Text},0;";
            text += $"2,{weight2_2.Text},0;";
            text += $"3,{weight2_3.Text},0;";
            text += $"4,{weight2_4.Text},0;";
            text += $"5,{weight2_5.Text},0";

            return text;
        }
    }
}