﻿using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class EvaluationCommentsOfficers : System.Web.UI.Page
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
                using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=12345;Database=postgres;"))
                //using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=12345;Database=postgres;"))
                {
                    connection.Open();
                    string storedOfficerFormID = Session["OfficerFormID"].ToString();

                    string sqlCode = @"SELECT ""Strength"", ""Improvement"", ""Development"", ""Acknowledgement"" FROM ""OfficerForm"" WHERE ""OfficerFormID"" = @OfficerFormID";
                    NpgsqlCommand command = new NpgsqlCommand(sqlCode, connection);
                    command.Parameters.AddWithValue("@OfficerFormID", storedOfficerFormID);

                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        strComment = reader.GetString(0);
                        impComment = reader.GetString(1);
                        devComment = reader.GetString(2);
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
                    Response.Redirect("~/EvaluationSection1Officers.aspx");
                }
                else if (link.ID == "btnSection2")
                {
                    //insert database commands here
                    Response.Redirect("~/EvaluationSection2Officers.aspx");
                }
                else if (link.ID == "btnSection3")
                {
                    //insert database commands here
                    Response.Redirect("~/EvaluationSection3Officers.aspx");
                }
                else if (link.ID == "btnSection4")
                {
                    //insert database commands here
                    Response.Redirect("~/EvaluationSection4Officers.aspx");
                }
                else if (link.ID == "btnSection5")
                {
                    //insert database commands here
                    Response.Redirect("~/EvaluationCommentsOfficers.aspx");
                }
                else if (link.ID == "btnOverall")
                {
                    //insert database commands here
                    Response.Redirect("~EvaluationOverallOfficers.aspx");
                }
            }

        }
        protected void UpdateCWR()
        {
            string storedStaffFormID = Session["OfficerFormID"].ToString();
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=12345;Database=postgres;"))
                //using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=12345;Database=postgres;"))
                {
                    connection.Open();

                    NpgsqlCommand command = new NpgsqlCommand(@"UPDATE ""OfficerForm"" SET ""Strength"" = @Strength, ""Improvement"" = @Improvement, ""Development"" = @Development, ""Acknowledgement"" = @Acknowledgement WHERE ""OfficerFormID"" = @OfficerFormID", connection);
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