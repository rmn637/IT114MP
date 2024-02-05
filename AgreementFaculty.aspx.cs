using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class AgreementFaculty : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }
        protected void weight_TextChanged1_A(object sender, EventArgs e)
        {
            try
            {
                TextBox rating = sender as TextBox;
                if (rating.ID == "weight1_A")
                {
                    if (int.Parse(weight1_A.Text) > 100)
                    {
                        weight1_A.Text = "100";
                    }
                }
                else
                {
                    if (rating.ID == "weight1_C")
                    {
                        if (int.Parse(weight1_B.Text) > 100)
                        {
                            weight1_B.Text = "100";
                        }
                    }
                    else
                    {
                        if (double.Parse(weight1_C.Text) > 100)
                        {
                            weight1_C.Text = "100";
                        }
                    }
                }
                computeTotalWeight1_A();
            }
            catch (FormatException)
            {
                Response.Write("<script>alert('Error: Please type a positive number')</script>");
            }
        }

        protected void weight_TextChanged1_B(object sender, EventArgs e)
        {
            try
            {
                TextBox rating = sender as TextBox;
                if (rating.ID == "weight1_1")
                {
                    if (int.Parse(weight1_1.Text) > 100)
                    {
                        weight1_1.Text = "100";
                    }
                }
                else
                {
                    if (rating.ID == "weight1_2")
                    {
                        if (int.Parse(weight1_2.Text) > 100)
                        {
                            weight1_2.Text = "100";
                        }
                    }
                    else if (rating.ID == "weight1_3")
                    {
                        if (int.Parse(weight1_3.Text) > 100)
                        {
                            weight1_3.Text = "100";
                        }
                    }
                    else if (rating.ID == "weight1_4")
                    {
                        if (int.Parse(weight1_4.Text) > 100)
                        {
                            weight1_4.Text = "100";
                        }
                    }
                    else
                    {
                        if (double.Parse(weight1_5.Text) > 100)
                        {
                            weight1_5.Text = "100";
                        }
                    }
                }
                computeTotalWeight1_B();
            }
            catch (FormatException)
            {
                Response.Write("<script>alert('Error: Please type a positive number')</script>");
            }
        }
        protected void weight_TextChanged2(object sender, EventArgs e)
        {
            try
            {
                TextBox rating = sender as TextBox;
                if (rating.ID == "weight2_1")
                {
                    if (int.Parse(weight2_1.Text) > 100)
                    {
                        weight2_1.Text = "100";
                    }
                }
                else
                {
                    if (rating.ID == "weight2_2")
                    {
                        if (int.Parse(weight2_2.Text) > 100)
                        {
                            weight2_2.Text = "100";
                        }
                    }
                    else if (rating.ID == "weight2_3")
                    {
                        if (int.Parse(weight2_3.Text) > 100)
                        {
                            weight2_3.Text = "100";
                        }
                    }
                    else if (rating.ID == "weight2_4")
                    {
                        if (int.Parse(weight2_4.Text) > 100)
                        {
                            weight2_4.Text = "100";
                        }
                    }
                    else
                    {
                        if (double.Parse(weight2_5.Text) > 100)
                        {
                            weight2_5.Text = "100";
                        }
                    }
                }
                computeTotalWeight2();
            }
            catch (FormatException)
            {
                Response.Write("<script>alert('Error: Please type a positive number')</script>");
            }
        }

        protected void computeTotalWeight1_A()
        {
            double weightA = 0, weightB = 0, weightC = 0, total = 0;
            if (weight1_A.Text != "0")
            {
                weightA = double.Parse(weight1_A.Text);
            }
            else
            {
                weightA = 0;
            }
            if (weight1_B.Text != "0")
            {
                weightB = double.Parse(weight1_B.Text);
            }
            else
            {
                weightB = 0;
            }
            if (weight1_C.Text != "0")
            {
                weightC = double.Parse(weight1_C.Text);
            }
            else
            {
                weightC = 0;
            }
            total = weightA + weightB + weightC;
            labelTotal1A.Text = total.ToString("0.00");
        }
        protected void computeTotalWeight1_B()
        {
            double weight1 = 0, weight2 = 0, weight3 = 0, weight4 = 0, weight5 = 0, total = 0;
            if (weight1_1.Text != "0")
            {
                weight1 = double.Parse(weight1_1.Text);
            }
            else
            {
                weight1 = 0;
            }
            if (weight1_2.Text != "0")
            {
                weight2 = double.Parse(weight1_2.Text);
            }
            else
            {
                weight2 = 0;
            }
            if (weight1_3.Text != "0")
            {
                weight3 = double.Parse(weight1_3.Text);
            }
            else
            {
                weight3 = 0;
            }
            if (weight1_4.Text != "0")
            {
                weight4 = double.Parse(weight1_4.Text);
            }
            else
            {
                weight4 = 0;
            }
            if (weight1_5.Text != "0")
            {
                weight5 = double.Parse(weight1_5.Text);
            }
            else
            {
                weight5 = 0;
            }
            total = weight1 + weight2 + weight3 + weight4 + weight5;
            labelTotal1B.Text = total.ToString("0.00");
            
        }
        
        protected void computeTotalWeight2()
        {
            double weight1 = 0, weight2 = 0, weight3 = 0, weight4 = 0, weight5 = 0, total = 0;
            if (weight2_1.Text != "0")
            {
                weight1 = double.Parse(weight2_1.Text);
            }
            else
            {
                weight1 = 0;
            }
            if (weight2_2.Text != "0")
            {
                weight2 = double.Parse(weight2_2.Text);
            }
            else
            {
                weight2 = 0;
            }
            if (weight2_3.Text != "0")
            {
                weight3 = double.Parse(weight2_3.Text);
            }
            else
            {
                weight3 = 0;
            }
            if (weight2_4.Text != "0")
            {
                weight4 = double.Parse(weight2_4.Text);
            }
            else
            {
                weight4 = 0;
            }
            if (weight2_5.Text != "0")
            {
                weight5 = double.Parse(weight2_5.Text);
            }
            else
            {
                weight5 = 0;
            }
            total = weight1 + weight2 + weight3 + weight4 + weight5;
            labelTotal2.Text = total.ToString("0.00");
            
        }
        protected void Submit_Click(object sender, EventArgs e)
        {
            if (labelTotal1A.Text != "100")
                {
                    Response.Write("<script>alert('Error: Please equate your weights in section 1 - A to 100')</script>");
                    weight1_A.Text = "0";
                    weight1_B.Text = "0";
                    weight1_C.Text = "0";
                }
            else if (labelTotal1B.Text != "100")
                {
                    Response.Write("<script>alert('Error: Please equate your weights in section 1 - B to 100')</script>");
                    weight1_1.Text = "0";
                    weight1_2.Text = "0";
                    weight1_3.Text = "0";
                    weight1_4.Text = "0";
                    weight1_5.Text = "0";
                }
            else if (labelTotal2.Text != "100")
                {
                    Response.Write("<script>alert('Error: Please equate your weights in section 2 to 100')</script>");
                    weight1_1.Text = "0";
                    weight1_2.Text = "0";
                    weight1_3.Text = "0";
                    weight1_4.Text = "0";
                    weight1_5.Text = "0";
                }
            else if (totalWeight.Text != "100")
                {
                    Response.Write("<script>alert('Error: Please equate your weights in the final section to 100')</script>");
                    weight1_1.Text = "0";
                    weight1_2.Text = "0";
                    weight1_3.Text = "0";
                    weight1_4.Text = "0";
                    weight1_5.Text = "0";
                }
        }

        protected void totalWeight_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox rating = sender as TextBox;
                if (rating.ID == "totalWeight_1")
                {
                    if (int.Parse(totalWeight_1.Text) > 100)
                    {
                        totalWeight_1.Text = "100";
                    }
                }
                else
                {
                    if (rating.ID == "totalWeight_2")
                    {
                        if (int.Parse(totalWeight_2.Text) > 100)
                        {
                            totalWeight_2.Text = "100";
                        }
                    }
                    else if (rating.ID == "totalWeight_1_3")
                    {
                        if (int.Parse(totalWeight_3.Text) > 100)
                        {
                            totalWeight_3.Text = "100";
                        }
                    }
                    else if (rating.ID == "totalWeight_4")
                    {
                        if (int.Parse(totalWeight_4.Text) > 100)
                        {
                            totalWeight_4.Text = "100";
                        }
                    }
                }
                computeTotalWeight();
            }
            catch (FormatException)
            {
                Response.Write("<script>alert('Error: Please type a positive number')</script>");
            }
        }
        protected void computeTotalWeight()
        {
            double weight1 = 0, weight2 = 0, weight3 = 0, weight4 = 0, total = 0;
            if (totalWeight_1.Text != "0")
            {
                weight1 = double.Parse(totalWeight_1.Text);
            }
            else
            {
                weight1 = 0;
            }
            if (totalWeight_2.Text != "0")
            {
                weight2 = double.Parse(totalWeight_2.Text);
            }
            else
            {
                weight2 = 0;
            }
            if (totalWeight_3.Text != "0")
            {
                weight3 = double.Parse(totalWeight_3.Text);
            }
            else
            {
                weight3 = 0;
            }
            if (totalWeight_4.Text != "0")
            {
                weight4 = double.Parse(totalWeight_4.Text);
            }
            else
            {
                weight4 = 0;
            }
            total = weight1 + weight2 + weight3 + weight4;
            totalWeight.Text = total.ToString("0.00");
        }
    }
}