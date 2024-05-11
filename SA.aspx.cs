using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class AgreementStaff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            ((Child)Page.Master).opt2class = "active";
            Page.MaintainScrollPositionOnPostBack = true;

            Session["Process"] = "Submission";
            string[] sessionInfo = Child.InitializeAgreement(Session["RateeID"].ToString(), Session["EmpType"].ToString());

            if (sessionInfo != null)
            {
                Session["PAValDone"] = sessionInfo[0];
                Session["StaffFormID"] = sessionInfo[1];
                EvaluateBtn.Visible = false;
                EvaluateBtn.Enabled = false;
                View.Visible = true;
                View.Enabled = true;
            }
            using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=1234;Database=EmployeeEval;"))
            {
                connection.Open();
                string query = @"SELECT e.""EmpName"", e.""EmpPos"", e.""EmpDept"", (SELECT s.""EmpName"" FROM ""Employee"" s WHERE s.""EmpID"" = e.""SupID"") FROM ""Employee"" e WHERE e.""EmpID"" = @empID";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@empID", Session["EmpID"].ToString());

                NpgsqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    lblEmpName.Text = reader.GetString(0);
                    lblPos.Text = reader.GetString(1);
                    lblDept.Text = reader.GetString(2);
                    if (reader.IsDBNull(3) == false)
                        lblRaterName.Text = reader.GetString(3);
                    else
                        lblRaterName.Text = "N/A";

                }
                reader.Close();
            }
        }

        protected void EvaluateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string[] sessionInfo = Child.CreateAgreementForm(Session["RateeID"].ToString(), Session["EmpType"].ToString());
                Session["FormID"] = sessionInfo[0];
                Session["StaffFormID"] = sessionInfo[1];
                Session["ReportID"] = sessionInfo[2];
                //Response.Write($"<script>alert('Error: {sessionInfo}')</script>");
            }
            catch (Exception ex)
            {

                Response.Write($"<script>alert('Error: {ex.Message}')</script>");
            }
            Response.Redirect("SAS1.aspx");
        }

        protected void ViewBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("SAS1.aspx");
        }
    }
}