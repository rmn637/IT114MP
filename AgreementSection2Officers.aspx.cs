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
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            ((Site1)Page.Master).opt2class = "active";
            Page.MaintainScrollPositionOnPostBack = true;
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
                else if (weight.ID == "weight1_6")
                {
                    if (double.Parse(weight.Text) > 100)
                    {
                        weight1_6.Text = "100";
                    }
                    weightedScore = double.Parse(weight1_6.Text);
                }
                else if (weight.ID == "weight1_7")
                {
                    if (double.Parse(weight.Text) > 100)
                    {
                        weight1_7.Text = "100";
                    }
                    weightedScore = double.Parse(weight1_7.Text);
                }
                else
                {
                    if (double.Parse(weight.Text) > 100)
                    {
                        weight1_8.Text = "100";
                    }
                    weightedScore = double.Parse(weight1_8.Text);
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
            else if (labelTotal1.Text != "100.00")
            {
                Response.Write("<script>alert('Your total weight is not 100.')</script>");
            }
            else
            {
                string compiledCWR = CompileAnswers();
                string storedFormID = "1234567890";
                string storedEmpID = Session["EmpID"].ToString();
                Response.Write("<script>alert('PAG ETO DI PUMASOK PUTANGINAMO')</script>");
                try
                {
                    Response.Write("<script>alert('PASOK')</script>");
                    using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=12345;Database=postgres;"))
                    {
                        connection.Open();

                        NpgsqlCommand command = new NpgsqlCommand(@"SELECT ""FormID"" FROM ""EmployeePerformance"" INNER JOIN ""Employee"" ON ""EmployeePerformance"".""EmpID"" = ""Employee"".""EmpID"" WHERE ""Employee"".""EmpID"" = @empID", connection);
                        command.Parameters.AddWithValue("@empID", storedEmpID);
                        NpgsqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            storedFormID = reader.GetString(0);
                            Session["FormID"] = storedFormID;
                            Response.Write($"<script>alert('{storedFormID} {compiledCWR}')</script>");
                        }
                        reader.Close();


                        //command = new NpgsqlCommand(@"UPDATE ""StaffForm"" SET ""Section1CWR"" = @Section1CWR WHERE ""FormID"" = @FormID", connection);
                        command = new NpgsqlCommand(@"UPDATE ""StaffForm"" SET ""Section1CWR"" = @Section1CWR WHERE ""FormID"" = @FormID", connection);
                        command.Parameters.AddWithValue("@Section1CWR", compiledCWR);
                        command.Parameters.AddWithValue("@FormID", storedFormID);
                        int vr = command.ExecuteNonQuery();
                        //Response.Write("<script>alert('aaaaaaaaaaaaaaa')</script>");
                        Response.Write($"<script>alert('{storedFormID} {vr}')</script>");

                        Response.Write("<script>alert('pumasok')</script>");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('walang pumasok')</script>");
                }

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

            text += $"1,{weight1_1.Text},0;";
            text += $"2,{weight1_2.Text},0;";
            text += $"3,{weight1_3.Text},0;";
            text += $"4,{weight1_4.Text},0;";
            text += $"5,{weight1_5.Text},0;";
            text += $"6,{weight1_6.Text},0;";
            text += $"7,{weight1_7.Text},0;";
            text += $"8,{weight1_8.Text},0;";

            return text;
        }
    }
}