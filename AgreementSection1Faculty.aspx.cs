using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class AgreementSection1Faculty : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            ((Site1)Page.Master).opt3class = "active";
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


                    string storedFacultyFormID = Session["FacultyFormID"].ToString();

                    string sqlCode = @"SELECT ""Section1CWR"" FROM ""FacultyForm"" WHERE ""FacultyFormID"" = @FacultyFormID";
                    NpgsqlCommand command = new NpgsqlCommand(sqlCode, connection);
                    command.Parameters.AddWithValue("@FacultyFormID", storedFacultyFormID);

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
                            CWRArr2 = CWRArr[i].Split(',');
                            weightArr[i] = CWRArr2[1];
                        }

                        weight1_1.Text = weightArr[0];
                        weight1_2.Text = weightArr[1];
                        weight1_3.Text = weightArr[2];
                        weight1_4.Text = weightArr[3];
                        weight1_5.Text = weightArr[4];
                        weight1_A.Text = weightArr[5];
                        weight1_B.Text = weightArr[6];
                        weight1_C.Text = weightArr[7];
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
                else if (weight.ID == "weight1_3")
                {
                    if (double.Parse(weight.Text) > 100)
                    {
                        weight1_3.Text = "100";
                    }
                    weightedScore = double.Parse(weight1_3.Text);
                }
                else if (weight.ID == "weight1_4")
                {
                    if (double.Parse(weight.Text) > 100)
                    {
                        weight1_4.Text = "100";
                    }
                    weightedScore = double.Parse(weight1_4.Text);
                }
                else if (weight.ID == "weight1_5")
                {
                    if (double.Parse(weight.Text) > 100)
                    {
                        weight1_5.Text = "100";
                    }
                    weightedScore = double.Parse(weight1_5.Text);
                }
                else if (weight.ID == "weight1_A")
                {
                    if (double.Parse(weight.Text) > 100)
                    {
                        weight1_A.Text = "100";
                    }
                    weightedScore = double.Parse(weight1_A.Text);
                }
                else if (weight.ID == "weight1_B")
                {
                    if (double.Parse(weight.Text) > 100)
                    {
                        weight1_B.Text = "100";
                    }
                    weightedScore = double.Parse(weight1_B.Text);
                }
                else
                {
                    if (double.Parse(weight.Text) > 100)
                    {
                        weight1_C.Text = "100";
                    }
                    weightedScore = double.Parse(weight1_C.Text);
                }
                computeTotalWeight1();
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
        protected void computeTotalWeight1()
        {
            double weight1 = 0, weight2 = 0, weight3 = 0, weight4 = 0, weight5 = 0, weightA = 0, weightB = 0, weightC = 0, total = 0;
            weight1 = inputChecker(weight1_1.Text);
            weight2 = inputChecker(weight1_2.Text);
            weight3 = inputChecker(weight1_3.Text);
            weight4 = inputChecker(weight1_4.Text);
            weight5 = inputChecker(weight1_5.Text);
            weightA = inputChecker(weight1_A.Text);
            weightB = inputChecker(weight1_B.Text);
            weightC = inputChecker(weight1_C.Text);
            total = weight1 + weight2 + weight3 + weight4 + weight5;
            labelTotal1B.Text = total.ToString("0.00");
            total = 0 + weightA + weightB + weightC;
            labelTotal1A.Text = total.ToString("0.00");

        }
        protected void checkWeight(object sender, EventArgs e)
        {
            LinkButton link = sender as LinkButton;
            if (weight1_1.Text == "0" || weight1_2.Text == "0" || weight1_3.Text == "0" || weight1_4.Text == "0" || weight1_5.Text == "0" || weight1_A.Text == "0" || weight1_B.Text == "0" || weight1_C.Text == "0")
            {
                Response.Write("<script>alert('Please input a number from 1-100.')</script>");
            }
            else if (labelTotal1A.Text != "100.00" && labelTotal1B.Text != "100.00")
            {
                Response.Write("<script>alert('Your total weight is not 100.')</script>");
            }
            else
            {
                UpdateCWR();

                if (link.ID == "btnSection1")
                {
                    //insert database commands here
                    Response.Redirect("~/AgreementSection1Faculty.aspx");
                }
                else if (link.ID == "btnSection2")
                {
                    //insert database commands here
                    Response.Redirect("~/AgreementSection2Faculty.aspx");
                }
                else if (link.ID == "btnOverall")
                {
                    //insert database commands here
                    Response.Redirect("~/AgreementOverallFaculty.aspx");
                }
            }
        }

        protected string CompileAnswers()
        {
            string text = "";

            text += $"1,{weight1_1.Text},0;";
            text += $"2,{weight1_2.Text},0;";
            text += $"3,{weight1_3.Text},0;";
            text += $"4,{weight1_4.Text},0;";
            text += $"5,{weight1_5.Text},0;";
            text += $"6,{weight1_A.Text},0;";
            text += $"7,{weight1_B.Text},0;";
            text += $"8,{weight1_C.Text},0";

            return text;
        }

        protected void UpdateCWR()
        {
            string compiledCWR = CompileAnswers();
            string storedFacultyForm = Session["FacultyFormID"].ToString();

            try
            {
                // reese: using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=12345;Database=postgres;"))
                using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=123456;Database=EmplyeeEval;"))
                {
                    connection.Open();

                    NpgsqlCommand command = new NpgsqlCommand(@"UPDATE ""FacultyForm"" SET ""Section1CWR"" = @Section1CWR WHERE ""FacultyFormID"" = @FacultyFormID", connection);
                    command.Parameters.AddWithValue("@Section1CWR", compiledCWR);
                    command.Parameters.AddWithValue("@FacultyFormID", storedFacultyForm);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

            }
        }



    }
}