using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class AgreementOfficers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            ((Site1)Page.Master).opt2class = "active";
        }
        protected void weight_TextChanged1(object sender, EventArgs e)
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
                    if (rating.ID == "weight1_3")
                    {
                        if (int.Parse(weight1_3.Text) > 100)
                        {
                            weight1_3.Text = "100";
                        }
                    }
                    if (rating.ID == "weight1_4")
                    {
                        if (int.Parse(weight1_4.Text) > 100)
                        {
                            weight1_4.Text = "100";
                        }
                    }
                    if (rating.ID == "weight1_5")
                    {
                        if (int.Parse(weight1_5.Text) > 100)
                        {
                            weight1_5.Text = "100";
                        }
                    }
                    else
                    {
                        if (double.Parse(weight1_6.Text) > 100)
                        {
                            weight1_6.Text = "100";
                        }
                    }
                }
                computeTotalWeight1();
            }
            catch (FormatException)
            {
                Response.Write("<script>alert('Error: Please type a positive number')</script>");
            }
        }
        protected void computeTotalWeight1()
        {
            double weight1 = 0, weight2 = 0, weight3 = 0, weight4 = 0, weight5 = 0, weight6 = 0, total = 0;
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
            if (weight1_6.Text != "0")
            {
                weight6 = double.Parse(weight1_6.Text);
            }
            else
            {
                weight6 = 0;
            }
            total = weight1 + weight2 + weight3 + weight4 + weight5 + weight6;
            labelTotal1.Text = total.ToString("0.00");

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
                }
                computeTotalWeight2();
            }
            catch (FormatException)
            {
                Response.Write("<script>alert('Error: Please type a positive number')</script>");
            }
        }
        protected void computeTotalWeight2()
        {
            double weight1 = 0, weight2 = 0, weight3 = 0, weight4 = 0, total = 0;
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
            total = weight1 + weight2 + weight3 + weight4;
            labelTotal2.Text = total.ToString("0.00");
            
        }
        protected void weight_TextChanged3(object sender, EventArgs e)
        {
            try
            {
                TextBox rating = sender as TextBox;
                if (rating.ID == "weight3_1")
                {
                    if (int.Parse(weight3_1.Text) > 100)
                    {
                        weight3_1.Text = "100";
                    }
                }
                else
                {
                    if (rating.ID == "weight3_2")
                    {
                        if (int.Parse(weight3_2.Text) > 100)
                        {
                            weight3_2.Text = "100";
                        }
                    }
                    else if (rating.ID == "weight3_3")
                    {
                        if (int.Parse(weight3_3.Text) > 100)
                        {
                            weight3_3.Text = "100";
                        }
                    }
                    else if (rating.ID == "weight3_4")
                    {
                        if (int.Parse(weight3_4.Text) > 100)
                        {
                            weight3_4.Text = "100";
                        }
                    }
                    else if (rating.ID == "weight3_5")
                    {
                        if (int.Parse(weight3_5.Text) > 100)
                        {
                            weight3_5.Text = "100";
                        }
                    }
                }
                computeTotalWeight3();
            }
            catch (FormatException)
            {
                Response.Write("<script>alert('Error: Please type a positive number')</script>");
            }
        }
        protected void computeTotalWeight3()
        {
            double weight1 = 0, weight2 = 0, weight3 = 0, weight4 = 0, weight5 = 0, total = 0;
            if (weight3_1.Text != "0")
            {
                weight1 = double.Parse(weight3_1.Text);
            }
            else
            {
                weight1 = 0;
            }
            if (weight3_2.Text != "0")
            {
                weight2 = double.Parse(weight3_2.Text);
            }
            else
            {
                weight2 = 0;
            }
            if (weight3_3.Text != "0")
            {
                weight3 = double.Parse(weight3_3.Text);
            }
            else
            {
                weight3 = 0;
            }
            if (weight3_4.Text != "0")
            {
                weight4 = double.Parse(weight3_4.Text);
            }
            else
            {
                weight4 = 0;
            }
            if (weight3_5.Text != "0")
            {
                weight5 = double.Parse(weight3_5.Text);
            }
            else
            {
                weight5 = 0;
            }
            total = weight1 + weight2 + weight3 + weight4 + weight5;
            labelTotal3.Text = total.ToString("0.00");
        }
        protected void weight_TextChanged4(object sender, EventArgs e)
        {
            try
            {
                TextBox rating = sender as TextBox;
                if (rating.ID == "weight4_1")
                {
                    if (int.Parse(weight4_1.Text) > 100)
                    {
                        weight4_1.Text = "100";
                    }
                }
                else
                {
                    if (rating.ID == "weight4_2")
                    {
                        if (int.Parse(weight4_2.Text) > 100)
                        {
                            weight4_2.Text = "100";
                        }
                    }
                    else if (rating.ID == "weight4_3")
                    {
                        if (int.Parse(weight4_3.Text) > 100)
                        {
                            weight4_3.Text = "100";
                        }
                    }
                    else if (rating.ID == "weight4_4")
                    {
                        if (int.Parse(weight4_4.Text) > 100)
                        {
                            weight4_4.Text = "100";
                        }
                    }
                    else if (rating.ID == "weight4_5")
                    {
                        if (int.Parse(weight4_5.Text) > 100)
                        {
                            weight4_5.Text = "100";
                        }
                    }
                    else if (rating.ID == "weight4_6")
                    {
                        if (int.Parse(weight4_6.Text) > 100)
                        {
                            weight4_6.Text = "100";
                        }
                    }
                    else if (rating.ID == "weight4_7")
                    {
                        if (int.Parse(weight4_7.Text) > 100)
                        {
                            weight4_7.Text = "100";
                        }
                    }
                    else if (rating.ID == "weight4_8")
                    {
                        if (int.Parse(weight4_8.Text) > 100)
                        {
                            weight4_8.Text = "100";
                        }
                    }
                }
                computeTotalWeight4();
            }
            catch (FormatException)
            {
                Response.Write("<script>alert('Error: Please type a positive number')</script>");
            }
        }
        protected void computeTotalWeight4()
        {
            double weight1 = 0, weight2 = 0, weight3 = 0, weight4 = 0, weight5 = 0, weight6 = 0, weight7 = 0, weight8 = 0, total = 0;
            if (weight4_1.Text != "0")
            {
                weight1 = double.Parse(weight4_1.Text);
            }
            else
            {
                weight1 = 0;
            }
            if (weight4_2.Text != "0")
            {
                weight2 = double.Parse(weight4_2.Text);
            }
            else
            {
                weight2 = 0;
            }
            if (weight4_3.Text != "0")
            {
                weight3 = double.Parse(weight4_3.Text);
            }
            else
            {
                weight3 = 0;
            }
            if (weight4_4.Text != "0")
            {
                weight4 = double.Parse(weight4_4.Text);
            }
            else
            {
                weight4 = 0;
            }
            if (weight4_5.Text != "0")
            {
                weight5 = double.Parse(weight4_5.Text);
            }
            else
            {
                weight5 = 0;
            }
            if (weight4_6.Text != "0")
            {
                weight6 = double.Parse(weight4_6.Text);
            }
            else
            {
                weight6 = 0;
            }
            if (weight4_7.Text != "0")
            {
                weight7 = double.Parse(weight4_7.Text);
            }
            else
            {
                weight7 = 0;
            }
            if (weight4_8.Text != "0")
            {
                weight8 = double.Parse(weight4_8.Text);
            }
            else
            {
                weight8 = 0;
            }
            total = weight1 + weight2 + weight3 + weight4 + weight5 + weight6 + weight7 + weight8;
            labelTotal3.Text = total.ToString("0.00");
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