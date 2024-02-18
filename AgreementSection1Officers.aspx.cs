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
                using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=12345;Database=postgres;"))
                //using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=123456;Database=EmplyeeEval;"))
                {
                    connection.Open();


                    string storedOfficersFormID = Session["OfficerFormID"].ToString();

                    string sqlCode = @"SELECT ""Section1IOWR"" FROM ""OfficerForm"" WHERE ""OfficerFormID"" = @OfficerFormID";
                    NpgsqlCommand command = new NpgsqlCommand(sqlCode, connection);
                    command.Parameters.AddWithValue("@OfficerFormID", storedOfficersFormID);

                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        CWR = reader.GetString(0);
                    }
                    reader.Close();

                    if (CWR != "0")
                    {
                        string[] CWRArr = CWR.Split(';');
                        string[] CWRArr2 = new string[5];
                        string[] initiatives = new string[6];
                        string[] objectives = new string[6];
                        string[] weightArr = new string[6];

                        for (int i = 0; i < CWRArr.Length; i++)
                        {
                            CWRArr2 = CWRArr[i].Split('|');
                            initiatives[i] = CWRArr2[1];
                            objectives[i] = CWRArr2[2];
                            weightArr[i] = CWRArr2[3];
                            
                        }

                        initiative1.Text = initiatives[0];
                        initiative2.Text = initiatives[1];
                        initiative3.Text = initiatives[2];
                        initiative4.Text = initiatives[3];
                        initiative5.Text = initiatives[4];
                        initiative6.Text = initiatives[5];
                        objectives1.Text = objectives[0];
                        objectives2.Text = objectives[1];
                        objectives3.Text = objectives[2];
                        objectives4.Text = objectives[3];
                        objectives5.Text = objectives[4];
                        objectives6.Text = objectives[5];
                        weight1_1.Text = weightArr[0];
                        weight1_2.Text = weightArr[1];
                        weight1_3.Text = weightArr[2];
                        weight1_4.Text = weightArr[3];
                        weight1_5.Text = weightArr[4];
                        weight1_6.Text = weightArr[5];
                        
                    }

                    computeTotalWeight1();
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
        }

        protected string CompileAnswers()
        {
            string text = "";

            text += $"1|{initiative1.Text}|{objectives1.Text}|{weight1_1.Text}|0;";
            text += $"2|{initiative2.Text}|{objectives2.Text}|{weight1_2.Text}|0;";
            text += $"3|{initiative3.Text}|{objectives3.Text}|{weight1_3.Text}|0;";
            text += $"4|{initiative4.Text}|{objectives4.Text}|{weight1_4.Text}|0;";
            text += $"5|{initiative5.Text}|{objectives5.Text}|{weight1_5.Text}|0;";
            text += $"6|{initiative6.Text}|{objectives6.Text}|{weight1_6.Text}|0";

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
            double weight1 = 0, weight2 = 0, weight3 = 0, weight4 = 0, weight5 = 0, weight6 = 0, total = 0;
            weight1 = inputChecker(weight1_1.Text);
            weight2 = inputChecker(weight1_2.Text);
            weight3 = inputChecker(weight1_3.Text);
            weight4 = inputChecker(weight1_4.Text);
            weight5 = inputChecker(weight1_5.Text);
            weight6 = inputChecker(weight1_6.Text);
            total = weight1 + weight2 + weight3 + weight4 + weight5 + weight6;
            labelTotal1.Text = total.ToString("0.00");
        }
        protected void checkWeight(object sender, EventArgs e)
        {
            LinkButton link = sender as LinkButton;
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
}