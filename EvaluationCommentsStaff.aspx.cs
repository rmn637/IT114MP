using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace WebApplication1
{
    public partial class EvaluationCommentsStaff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            ((Site1)Page.Master).opt3class = "active";
            Page.MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
                Initialize();
            }
        }

        protected void Initialize()
        {
            string strComment = "", impComment = "", devComment = "", ackComment = "";

            if (!IsPostBack)
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=123456;Database=EmplyeeEval;"))
                {
                    connection.Open();
                    string storedStaffFormID = Session["StaffFormID"].ToString();

                    string sqlCode = @"SELECT ""Strength"", ""Improvement"", ""Development"", ""Acknowledgement"" FROM ""StaffForm"" WHERE ""StaffFormID"" = @StaffFormID";
                    NpgsqlCommand command = new NpgsqlCommand(sqlCode, connection);
                    command.Parameters.AddWithValue("@StaffFormID", storedStaffFormID);

                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.GetString(0) != "0")
                            strComment = reader.GetString(0);
                        if (reader.GetString(1) != "0")
                            impComment = reader.GetString(1);
                        if (reader.GetString(2) != "0")
                            devComment = reader.GetString(2);
                        if (reader.GetString(3) != "0")
                            ackComment = reader.GetString(3);
                    }
                    reader.Close();

                    strength.Text = strComment;
                    improvement.Text = impComment;
                    development.Text = devComment;
                    acknowledgement.Text = ackComment;
                }
            }
        }

        protected void checkWeight(object sender, EventArgs e)
        {
            LinkButton link = sender as LinkButton;
            if (strength.Text == "" || development.Text == "" || improvement.Text == "" || acknowledgement.Text == "")
            {
                Response.Write("<script>alert('Please Type Comments.')</script>");
            }
            else 
            {
                UpdateCWR();
                if (link.ID == "btnSection1")
                {
                    //insert database commands here
                    Response.Redirect("~/EvaluationSection1Staff.aspx");
                }
                else if (link.ID == "btnSection2")
                {
                    //insert database commands here
                    Response.Redirect("~/EvaluationSection2Staff.aspx");
                }
                else if (link.ID == "btnSection3")
                {
                    //insert database commands here
                    Response.Redirect("~/EvaluationCommentsStaff.aspx");
                }
                else if (link.ID == "btnOverall")
                {
                    //insert database commands here
                    Response.Redirect("~/EvaluationOverallStaff.aspx");
                }
            }
            
        }
        protected void UpdateCWR()
        {
            string storedStaffFormID = Session["StaffFormID"].ToString();
            try
            {
                // reese: using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=12345;Database=postgres;"))
                using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=123456;Database=EmplyeeEval;"))
                {
                    connection.Open();

                    NpgsqlCommand command = new NpgsqlCommand(@"UPDATE ""StaffForm"" SET ""Strength"" = @Strength, ""Improvement"" = @Improvement, ""Development"" = @Development, ""Acknowledgement"" = @Acknowledgement WHERE ""StaffFormID"" = @StaffFormID", connection);
                    command.Parameters.AddWithValue("@Strength", strength.Text);
                    command.Parameters.AddWithValue("@Improvement", improvement.Text);
                    command.Parameters.AddWithValue("@Development", development.Text);
                    command.Parameters.AddWithValue("@Acknowledgement", acknowledgement.Text);
                    command.Parameters.AddWithValue("@StaffFormID", storedStaffFormID);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}