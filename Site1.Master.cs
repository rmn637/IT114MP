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

        public bool opt3enable { get { return opt3.Enabled; } set { opt3.Enabled = value; } }
        public bool opt3visible { get { return opt3.Visible; } set { opt3.Visible = value; } }
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

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=123456;Database=EmplyeeEval;"))
                {
                    connection.Open();

                    NpgsqlCommand command = new NpgsqlCommand(@"SELECT * FROM ""Employee"" INNER JOIN ""EmployeeAccount"" ON ""Employee"".""EmpID"" = ""EmployeeAccount"".""EmpID"" WHERE ""Employee"".""EmpID"" = @empID", connection);
                    command.Parameters.AddWithValue("@empID", storedEmpID);
                    

                    NpgsqlDataReader reader = command.ExecuteReader();
                    
                    while (reader.Read())
                    {
                        string storedEmpType = reader.GetString(4);
                        string storedEmpName = reader.GetString(1);
                        if (storedAccType == "Supervisor")
                        {
                            opt3visible = true;
                            opt3enable = true;
                        }
                        else if (storedAccType != "Supervisor")
                        {
                            opt3visible = false;
                            opt3enable = false;
                            if (storedEmpType == "Faculty")
                            {
                                opt2url = "~/AgreementFaculty.aspx";
                            }
                            else if (storedEmpType == "Staff")
                            {
                                opt2url = "~/AgreementStaff.aspx";
                            }
                            else
                            {
                                opt2url = "~/AgreementOfficers.aspx";
                            }
                        }
                        labelLogIDText = "Welcome, " + storedEmpType + " " + storedEmpName;
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }

        }
    }
}