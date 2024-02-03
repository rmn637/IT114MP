using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace WebApplication1
{
    public partial class Agreement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void weight1A_TextChanged(object sender, EventArgs e)
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
            }
            catch (FormatException)
            {
                Response.Write("<script>alert('Error: Please type a positive number')</script>");
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            int weight = int.Parse(weight1_A.Text) + int.Parse(weight1_B.Text) + int.Parse(weight1_C.Text);
            if (weight != 100)
            {
                Response.Write("<script>alert('Error: Please equate your weights to 100')</script>");
            }
            
        }
    }
}