using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        public string labelLogIDText { get { return labelLogID.Text; } set { labelLogID.Text = value; } }
        public string opt1class { get { return opt1.CssClass; } set { opt1.CssClass = value; } }
        public string opt2class { get { return opt2.CssClass; } set { opt2.CssClass = value; } }
        public string opt2url { get { return opt2.PostBackUrl; } set { opt2.PostBackUrl = value; } }
        public string opt3class { get { return opt3.CssClass; } set { opt3.CssClass = value; } }
        public string opt3url { get { return opt3.PostBackUrl; } set { opt3.PostBackUrl = value; } }
        public bool opt2enable { get { return opt2.Enabled; } set { opt2.Enabled = value; } }
        public bool opt3enable { get { return opt3.Enabled; } set { opt3.Enabled = value; } }
        public bool opt4enable { get { return opt4.Enabled; } set { opt4.Enabled = value; } }
        public bool opt4visible { get { return opt4.Visible; } set { opt4.Visible = value; } }
        public bool opt5enable { get { return opt5.Enabled; } set { opt5.Enabled = value; } }
        public bool opt5visible { get { return opt5.Visible; } set { opt5.Visible = value; } }
        public string opt4class { get { return opt4.CssClass; } set { opt4.CssClass = value; } }
        public string opt5class { get { return opt5.CssClass; } set { opt5.CssClass = value; } }
        public void opt1_Click(Object sender, EventArgs e)
        {
            opt1.CssClass = "active";
            Response.Redirect("MyAccount.aspx");
        }

        public void opt2_Click(Object sender, EventArgs e)
        {
            opt2.CssClass = "active";
            Response.Redirect("Agreement.aspx");
        }

        public void opt3_Click(Object sender, EventArgs e)
        {
            opt3.CssClass = "active";
            Response.Redirect("Evaluation.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.MaintainScrollPositionOnPostBack = true;
            string storedEmpID = Session["EmpID"].ToString();
            string storedAccType = Session["AccType"].ToString();
            string storedEmpName = "", storedEmpType = "";
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=12345;Database=postgres;"))
                {
                    connection.Open();

                    NpgsqlCommand command = new NpgsqlCommand(@"SELECT ""EmpName"", ""EmpType"" FROM ""Employee"" WHERE ""EmpID"" = @empID", connection);
                    command.Parameters.AddWithValue("@empID", storedEmpID);

                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        storedEmpName = reader.GetString(0);
                        storedEmpType = reader.GetString(1);
                    }
                    reader.Close();


                    command = new NpgsqlCommand(@"SELECT ""PASubmission"", ""PAValidation"", ""PESubmission"", ""PEValidation"" FROM ""StatusReport"" WHERE ""EmpID"" = @empID", connection);
                    command.Parameters.AddWithValue("@empID", storedEmpID);

                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        CheckStatus(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
                    }
                    reader.Close();

                }

                if (storedAccType == "Supervisor")
                    {
                        opt4visible = true;
                        opt4enable = true;
                        opt5visible = true;
                        opt5enable = true;
                }
                else if (storedAccType != "Supervisor")
                {
                    opt4visible = false;
                    opt4enable = false;
                    opt5visible = false;
                    opt5enable = false;
                    if (storedEmpType == "Faculty")
                    {
                        opt2url = "~/AgreementFaculty.aspx";
                        opt3url = "~/EvaluationSection1Faculty.aspx";
                    }
                    else if (storedEmpType == "Staff")
                    {
                        opt2url = "~/AgreementStaff.aspx";
                        opt3url = "~/EvaluationSection1Staff.aspx";
                    }
                    else
                    {
                        opt2url = "~/AgreementOfficers.aspx";
                        opt3url = "~/EvaluationSection1Officers.aspx";
                    }
                }
                labelLogIDText = "Welcome, " + storedEmpType + " " + storedEmpName;               
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }

        protected void CheckStatus(string PASub, string PAVal, string PESub, string PEVal)
        {
            bool PASubDone = PASub != "0" && PASub != null;
            bool PAValDone = PAVal != "0" && PAVal != null;
            bool PESubDone = PESub != "0" && PESub != null;
            bool PEValDone = PEVal != "0" && PEVal != null;

            opt2.Enabled = !PASubDone || PAValDone;
            opt3.Enabled = (PAValDone && !PESubDone) || PEValDone;

            //Response.Write($"<script>alert('{PASubDone} {PAValDone} {PESubDone} {PEValDone}')</script>");
            //if (PASubDone && PAValDone && PESubDone && PEValDone) 
            //{
            //    opt2.Enabled = true;
            //    opt3.Enabled = true;
            //}
            //else if (PASubDone && PAValDone && PESubDone && !PEValDone)
            //{
            //    opt2.Enabled = true;
            //    opt3.Enabled = false;
            //}
            //else if (PASubDone && PAValDone && !PESubDone && !PEValDone)
            //{
            //    opt2.Enabled = true;
            //    opt3.Enabled = true;
            //}
            //else if (PASubDone && !PAValDone && !PESubDone && !PEValDone)
            //{
            //    opt2.Enabled = false;
            //    opt3.Enabled = false;
            //}
            //else if (!PASubDone && !PAValDone && !PESubDone && !PEValDone)
            //{
            //    opt2.Enabled = true;
            //    opt3.Enabled = false;
            //}
        }
    }
}