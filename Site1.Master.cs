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
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=12345;Database=postgres;"))
                {
                    connection.Open();
                    NpgsqlCommand command = new NpgsqlCommand(@"SELECT ""EmpType"" FROM ""Employee"" INNER JOIN ""EmployeeAccount"" ON ""EmployeeAccount.EmpID"" = ""Employee.EmpID""", connection);
                    command.Parameters.AddWithValue("@empID");
                    

                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string storedEmpType = reader.GetString(0);
                        if (storedEmpType == "Superviser")
                        {
                            opt3visible = true;
                            opt3enable = true;
                            
                        }
                        else
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