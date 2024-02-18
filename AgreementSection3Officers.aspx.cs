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
            Initialize();
        }

        protected void Initialize()
        {
            string CWR = "";

            if (!IsPostBack)
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=12345;Database=postgres;"))
                //using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=123456;Database=EmplyeeEval;"))
                {
                    connection.Open();


                    string storedOfficerFormID = Session["OfficerFormID"].ToString();

                    string sqlCode = @"SELECT ""Section3CWR"" FROM ""OfficerForm"" WHERE ""OfficerFormID"" = @OfficerFormID";
                    NpgsqlCommand command = new NpgsqlCommand(sqlCode, connection);
                    command.Parameters.AddWithValue("@OfficerFormID", storedOfficerFormID);

                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        CWR = reader.GetString(0);
                    }
                    reader.Close();

                    if (CWR != "0")
                    {
                        string[] CWRArr = CWR.Split(';');
                        string[] CWRArr2 = new string[3];
                        string[] weightArr = new string[8];

                        for (int i = 0; i < CWRArr.Length; i++)
                        {
                            CWRArr2 = CWRArr[i].Split('|');
                            weightArr[i] = CWRArr2[1];
                        }

                        weight1_1.Text = weightArr[0];
                        weight1_2.Text = weightArr[1];
                        weight1_3.Text = weightArr[2];
                        weight1_4.Text = weightArr[3];
                        weight1_5.Text = weightArr[4];
                        weight1_6.Text = weightArr[5];
                        weight1_7.Text = weightArr[6];
                        weight1_8.Text = weightArr[7];
                    }

                    computeTotalWeight1();

                    if (Session["AccType"].ToString() == "Supervisor")
                    {
                        DisableButtons();
                    }
                }
            }
        }

        protected void DisableButtons()
        {
            weight1_1.Enabled = false;
            weight1_2.Enabled = false;
            weight1_3.Enabled = false;
            weight1_4.Enabled = false;
            weight1_5.Enabled = false;
            weight1_6.Enabled = false;
            weight1_7.Enabled = false;
            weight1_8.Enabled = false;
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
                computeTotalWeight1();
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
        protected void computeTotalWeight1()
        {
            double weight1 = 0, weight2 = 0, weight3 = 0, weight4 = 0, weight5 = 0, weight6 = 0, weight7 = 0, weight8 = 0, total = 0;
            weight1 = inputChecker(weight1_1.Text);
            weight2 = inputChecker(weight1_2.Text);
            weight3 = inputChecker(weight1_3.Text);
            weight4 = inputChecker(weight1_4.Text);
            weight5 = inputChecker(weight1_5.Text);
            weight6 = inputChecker(weight1_6.Text);
            weight7 = inputChecker(weight1_7.Text);
            weight8 = inputChecker(weight1_8.Text);
            total = weight1 + weight2 + weight3 + weight4 + weight5 + weight6 + weight7 + weight8;
            labelTotal1.Text = total.ToString("0.00");
        }
        protected void checkWeight(object sender, EventArgs e)
        {
            LinkButton link = sender as LinkButton;
            if (weight1_1.Text == "0" || weight1_2.Text == "0" || weight1_3.Text == "0" || weight1_4.Text == "0" || weight1_5.Text == "0" || weight1_6.Text == "0" || weight1_7.Text == "0" || weight1_8.Text == "0")
            {
                Response.Write("<script>alert('Please input a number from 1-100.')</script>");
            }
            else
            {
                UpdateCWR();
                if (link.ID == "btnSection1")
                {
                    //insert database commands here
                    Response.Redirect("~/AgreementSection1Officers.aspx");
                }
                else if (link.ID == "btnSection2")
                {
                    //insert database commands here
                    Response.Redirect("~/AgreementSection2Officers.aspx");
                }
                else if (link.ID == "btnSection3")
                {
                    //insert database commands here
                    Response.Redirect("~/AgreementSection3Officers.aspx");
                }
                else if (link.ID == "btnSection4")
                {
                    //insert database commands here
                    Response.Redirect("~/AgreementSection4Officers.aspx");
                }
                else if (link.ID == "btnOverall")
                {
                    //insert database commands here
                    Response.Redirect("~/AgreementOverallOfficers.aspx");
                }
            }
        }

        protected string CompileAnswers()
        {
            string text = "";

            text += $"1|{weight1_1.Text}|0;";
            text += $"2|{weight1_2.Text}|0;";
            text += $"3|{weight1_3.Text}|0;";
            text += $"4|{weight1_4.Text}|0;";
            text += $"5|{weight1_5.Text}|0;";
            text += $"6|{weight1_6.Text}|0;";
            text += $"7|{weight1_7.Text}|0;";
            text += $"8|{weight1_8.Text}|0";

            return text;
        }

        protected void UpdateCWR()
        {
            string compiledCWR = CompileAnswers();
            string storedOfficerFormID = Session["OfficerFormID"].ToString();

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=12345;Database=postgres;"))
                //using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=123456;Database=EmplyeeEval;"))
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