using Microsoft.SqlServer.Server;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using System.IO;
using System.Text.RegularExpressions;
using iTextSharp.text.html.simpleparser;
using iTextSharp.xmp.impl.xpath;
using System.Runtime.ConstrainedExecution;
using Org.BouncyCastle.Ocsp;
using static Org.BouncyCastle.Bcpg.Attr.ImageAttrib;
using static System.Collections.Specialized.BitVector32;

namespace WebApplication1
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        public string labelLogIDText { get { return labelLogID.Text; } set { labelLogID.Text = value; } }
        public string opt1class { get { return opt1.CssClass; } set { opt1.CssClass = value; } }
        public bool opt1enable { get { return opt1.Enabled; } set { opt1.Enabled = value; } }
        public bool opt1visible { get { return opt1.Visible; } set { opt1.Visible = value; } }
        public string opt2class { get { return opt2.CssClass; } set { opt2.CssClass = value; } }
        public bool opt2visible { get { return opt2.Visible; } set { opt2.Visible = value; } }
        public bool opt3visible { get { return opt3.Visible; } set { opt3.Visible = value; } }
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

        public string optadminclass { get { return optadmin.CssClass; } set { optadmin.CssClass = value; } }
        public bool optadminenable { get { return optadmin.Enabled; } set { optadmin.Enabled = value; } }
        public bool optadminvisible { get { return optadmin.Visible; } set { optadmin.Visible = value; } }
        public bool optcreateenable { get { return optcreate.Enabled; } set { optcreate.Enabled = value; } }
        public bool optcreatevisible { get { return optcreate.Visible; } set { optcreate.Visible = value; } }
        public bool opt6enable { get { return opt6.Enabled; } set { opt6.Enabled = value; } }
        public bool opt6visible { get { return opt6.Visible; } set { opt6.Visible = value; } }

        public bool optdownloadenable { get { return optdownload.Enabled; } set { optdownload.Enabled = value; } }
        public bool optdownloadvisible { get { return optdownload.Visible; } set { optdownload.Visible = value; } }





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
                using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=1234;Database=EmployeeEval;"))
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


                if (storedAccType == "Admin")
                {
                    opt2enable = false;
                    opt2visible = false;
                    opt3enable = false;
                    opt3visible = false;
                    opt4visible = false;
                    opt4enable = false;
                    opt5visible = false;
                    opt5enable = false;
                    opt1enable = true;
                    opt1visible = true;
                    optadminenable = true;
                    optadminvisible = true;
                    optcreateenable = true;
                    optcreatevisible = true;
                    optdownloadenable = false;
                    optdownloadenable = false;
                    optdownloadvisible = false;
                }
                else if (storedAccType == "Supervisor")
                {
                    opt4visible = true;
                    opt4enable = true;
                    opt5visible = true;
                    opt5enable = true;
                    opt6visible = true;
                    opt6enable = true;
                    optadminenable = false;
                    optadminvisible = false;
                    optcreateenable = false;
                    optcreatevisible = false;
                    optdownloadenable = false;
                    optdownloadvisible = false;
                }
                else if (storedAccType != "Supervisor")
                {
                    opt4visible = false;
                    opt4enable = false;
                    opt5visible = false;
                    opt5enable = false;
                    opt4visible = false;
                    opt4enable = false;
                    opt5visible = false;
                    opt5enable = false;
                    optadminenable = false;
                    optadminvisible = false;
                    optcreateenable = false;
                    optcreatevisible = false;
                    optdownloadenable = false;
                    optdownloadvisible = false;
                }
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
            optdownload.Visible = PEValDone;
            optdownload.Enabled = PEValDone;
        }

        public static void a() 
        {

        }

        protected void optdownload_Click(object sender, EventArgs e)
        {
            if (Session["AccType"].ToString() == "Faculty")
            {
                byte[] pdfbyte = GeneratePdf("Faculty", Session["EmpID"].ToString());
                Response.Clear();
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=Faculty.pdf");
                Response.BinaryWrite(pdfbyte);
                Response.End();
            }
            else if (Session["AccType"].ToString() == "Staff")
            {
                byte[] pdfbyte = GeneratePdf("Staff", Session["EmpID"].ToString());
                Response.Clear();
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=Staff.pdf");
                Response.BinaryWrite(pdfbyte);
                Response.End();
            }
            else if (Session["AccType"].ToString() == "Officer")
            {
                byte[] pdfbyte = GeneratePdf("Officer", Session["EmpID"].ToString());
                Response.Clear();
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=Officer.pdf");
                Response.BinaryWrite(pdfbyte);
                Response.End();
            }
        }
        protected static byte[] GeneratePdf(string type, string empID)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                // Create a new Document
                using (iTextSharp.text.Document document = new iTextSharp.text.Document())
                {
                    // Create a PdfWriter that writes to the MemoryStream
                    PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);

                    // Open the Document
                    document.Open();
                    iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance("~\\images\\MMCL Logo.png");
                    logo.SetAbsolutePosition(50, 750);
                    logo.ScaleAbsolute(160, 50);
                    document.Add(logo);

                    if (type == "Faculty")
                    {
                        faculty(document, empID);
                    }
                    else if (type == "Staff")
                    {
                        staff(document, empID);
                    }
                    else if (type == "Officer")
                    {
                        officer(document, empID);
                    }


                    // Close the Document
                    document.Close();
                }

                byte[] pdfBytes = memoryStream.ToArray();

                return pdfBytes;
            }
        }
        protected static void officer(Document document, string empID)
        {
            string storedEmpID = empID;
            string storedEmpName = "", storedEmpType = "", storedEmpPos = "", storedEmpDept = "", storedEmpSup = "", storedEmpDate = DateTime.Now.ToShortDateString(), storedEmpForm = "";
            using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=1234;Database=EmployeeEval;"))
            {
                connection.Open();

                NpgsqlCommand command = new NpgsqlCommand(@"SELECT ""EmpName"", ""EmpType"", ""EmpPos"",""EmpDept"", (SELECT ""EmpName"" FROM ""Employee"" WHERE ""EmpID"" = ""Employee"".""SupervisorID""), ""EmployeePerformance"".""FormID""  FROM ""Employee"" INNER JOIN ""EmployeePerformance"" ON ""Employee"".""EmpID"" = ""EmployeePerformance"".""EmpID"" WHERE ""EmpID"" = @empID", connection);
                command.Parameters.AddWithValue("@empID", storedEmpID);


                NpgsqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    storedEmpName = reader.GetString(0);
                    storedEmpType = reader.GetString(1);
                    storedEmpPos = reader.GetString(2);
                    storedEmpDept = reader.GetString(3);
                    storedEmpSup = reader.GetString(4);
                    storedEmpForm = reader.GetString(4);
                }
                reader.Close();
            }
            Paragraph title = new Paragraph();
            title.PaddingTop = 100;
            title.SpacingBefore = 50;
            title.Alignment = Element.ALIGN_CENTER;
            title.Font = FontFactory.GetFont("Arial", 18);
            title.Add("\nPERFORMANCE EVALUATION FOR OFFICERS\n\n");
            document.Add(title);

            PdfPTable table = new PdfPTable(3);
            table.TotalWidth = 510f;
            table.HorizontalAlignment = Element.ALIGN_CENTER;
            table.SpacingAfter = 10;

            float[] sglTblHdWidths = new float[3];
            sglTblHdWidths[0] = 170f;
            sglTblHdWidths[1] = 170f;
            sglTblHdWidths[2] = 170f;

            table.SetWidths(sglTblHdWidths);
            table.LockedWidth = true;
            addCell(table, "NAME OF EMPLOYEE", 1);
            addCell(table, "POSITION", 1);
            addCell(table, "COLLEGE/DEPARTMENT", 1);
            addCell(table, $"{storedEmpName}", 1);
            addCell(table, $"{storedEmpPos}", 1);
            addCell(table, $"{storedEmpDept}", 1);
            addCell(table, "NAME OF RATER", 1);
            addCell(table, "APPRAISAL PERIOD", 1);
            addCell(table, "DATE PREPARED", 1);
            addCell(table, $"{storedEmpSup}", 1);
            addCell(table, $"January - April 2024", 1);
            addCell(table, $"{storedEmpDate}", 1);

            document.Add(table);

            PdfPTable table1 = new PdfPTable(5);
            table1.TotalWidth = 510f;
            table1.HorizontalAlignment = Element.ALIGN_CENTER;
            table1.SpacingAfter = 10;
            float[] sglTblHdWidths1 = new float[5];
            sglTblHdWidths1[0] = 102f;
            sglTblHdWidths1[1] = 255f;
            sglTblHdWidths1[2] = 51f;
            sglTblHdWidths1[3] = 51f;
            sglTblHdWidths1[4] = 51f;
            table1.SetWidths(sglTblHdWidths1);
            table1.LockedWidth = true;

            addCell(table1, "SECTION 1: INSTITUTIONAL OBJECTIVES", 5);
            addCell(table1, "KRA 1", 5);
            addCell(table1, "KEY INITIATIVE", 1);
            addCell(table1, "", 1); //key initiative
            addCell(table1, "W", 1);
            addCell(table1, "R", 1);
            addCell(table1, "WS", 1);
            addCellLeft(table1, "SPECIFIC OBJECTIVES", 1);
            addCell(table1, "", 1); //specific objective
            addCell(table1, "", 1); //weight
            addCell(table1, "", 1); //rating
            addCell(table1, "", 1); //weighted score
            addCell(table1, "  ", 5); //addtl spec 
            addCell(table1, "  ", 5); //addtl spec 
            addCell(table1, "KRA 2", 5);
            addCell(table1, "KEY INITIATIVE", 1);
            addCell(table1, "", 1); //key initiative
            addCell(table1, "W", 1);
            addCell(table1, "R", 1);
            addCell(table1, "WS", 1);
            addCellLeft(table1, "SPECIFIC OBJECTIVES", 1);
            addCell(table1, "", 1); //specific objective
            addCell(table1, "", 1); //weight
            addCell(table1, "", 1); //rating
            addCell(table1, "", 1); //weighted score
            addCell(table1, "  ", 5); //addtl spec 
            addCell(table1, "  ", 5); //addtl spec 
            addCell(table1, "Total", 2);
            addCell(table1, "100", 1);
            addCell(table1, "", 1);
            addCell(table1, "", 1);

            document.Add(table1);

            PdfPTable table2 = new PdfPTable(4);
            table2.TotalWidth = 510f;
            table2.HorizontalAlignment = Element.ALIGN_CENTER;
            table2.SpacingAfter = 10;
            float[] sglTblHdWidths2 = new float[4];
            sglTblHdWidths2[0] = 357f;
            sglTblHdWidths2[1] = 51f;
            sglTblHdWidths2[2] = 51f;
            sglTblHdWidths2[3] = 51f;
            table2.SetWidths(sglTblHdWidths2);
            table2.LockedWidth = true;

            addCell(table2, "SECTION 2: GOVERNANCE, RISK MANAGEMENT AND CONTROL (GRC): Adherence to governance principles to ensure the continuing effectiveness of governance arrangements and take opportunities and counter threats through effective risk management and internal control. To be able to contribute strongly to meeting organizational objectives in respective assigned areas.", 4);
            addCell(table2, "<Scope 1>", 1);
            addCell(table2, "W", 1);
            addCell(table2, "R", 1);
            addCell(table2, "WS", 1);
            addCellLeft(table2, "Notes/Critical Incidents: ", 1);
            addCell(table2, "", 1); //weight
            addCell(table1, "", 1); //rate
            addCell(table2, "", 1); //weighted score
            addCell(table2, "  ", 4); //addtl notes
            addCell(table2, "  ", 4); //addtl notes
            addCell(table2, "<Scope 2>", 1);
            addCell(table2, "W", 1);
            addCell(table2, "R", 1);
            addCell(table2, "WS", 1);
            addCellLeft(table2, "Notes/Critical Incidents: ", 1);
            addCell(table2, "", 1); //weight
            addCell(table2, "", 1); //rate
            addCell(table2, "", 1); //weighted score
            addCell(table2, "  ", 4); //addtl notes
            addCell(table2, "  ", 4); //addtl notes
            addCell(table2, "Total", 1);
            addCell(table2, "100", 1);
            addCell(table2, "", 1);
            addCell(table2, "", 1);

            document.Add(table2);

            document.NewPage();
            Proficiency(document, "Officer", "3", storedEmpForm);

            document.NewPage();
            YGCValues(document, "Officer", "4", storedEmpForm);

            document.NewPage();
            Summary(document, "Officer", storedEmpForm);
        }

        protected static void staff(Document document, string empID)
        {
            string storedEmpID = empID;
            string storedEmpName = "", storedEmpType = "", storedEmpPos = "", storedEmpDept = "", storedEmpSup = "", storedEmpDate = DateTime.Now.ToShortDateString(), storedEmpForm = "";
            using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=1234;Database=EmployeeEval;"))
            {
                connection.Open();

                NpgsqlCommand command = new NpgsqlCommand(@"SELECT ""EmpName"", ""EmpType"", ""EmpPos"",""EmpDept"", (SELECT ""EmpName"" FROM ""Employee"" WHERE ""EmpID"" = ""Employee"".""SupervisorID""), ""EmployeePerformance"".""FormID""  FROM ""Employee"" INNER JOIN ""EmployeePerformance"" ON ""Employee"".""EmpID"" = ""EmployeePerformance"".""EmpID"" WHERE ""EmpID"" = @empID", connection);
                command.Parameters.AddWithValue("@empID", storedEmpID);


                NpgsqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    storedEmpName = reader.GetString(0);
                    storedEmpType = reader.GetString(1);
                    storedEmpPos = reader.GetString(2);
                    storedEmpDept = reader.GetString(3);
                    storedEmpSup = reader.GetString(4);
                    storedEmpForm = reader.GetString(4);
                }
                reader.Close();
            }
            Paragraph title = new Paragraph();
            title.PaddingTop = 100;
            title.SpacingBefore = 50;
            title.Alignment = Element.ALIGN_CENTER;
            title.Font = FontFactory.GetFont("Arial", 18);
            title.Add("\nPERFORMANCE EVALUATION FOR STAFF\n\n");
            document.Add(title);

            PdfPTable table = new PdfPTable(3);
            table.TotalWidth = 510f;
            table.HorizontalAlignment = Element.ALIGN_CENTER;
            table.SpacingAfter = 10;

            float[] sglTblHdWidths = new float[3];
            sglTblHdWidths[0] = 170f;
            sglTblHdWidths[1] = 170f;
            sglTblHdWidths[2] = 170f;

            table.SetWidths(sglTblHdWidths);
            table.LockedWidth = true;
            addCell(table, "NAME OF EMPLOYEE", 1);
            addCell(table, "POSITION", 1);
            addCell(table, "COLLEGE/DEPARTMENT", 1);
            addCell(table, $"{storedEmpName}", 1);
            addCell(table, $"{storedEmpPos}", 1);
            addCell(table, $"{storedEmpDept}", 1);
            addCell(table, "NAME OF RATER", 1);
            addCell(table, "APPRAISAL PERIOD", 1);
            addCell(table, "DATE PREPARED", 1);
            addCell(table, $"{storedEmpSup}", 1);
            addCell(table, $"January - April 2024", 1);
            addCell(table, $"{storedEmpDate}", 1);

            document.Add(table);

            Proficiency(document, "Staff", "1", storedEmpForm);

            document.NewPage();
            YGCValues(document, "Staff", "2", storedEmpForm);

            document.NewPage();
            Summary(document, "Staff", storedEmpForm);
        }

        public static void faculty(Document document, string empID)
        {
            string storedEmpID = empID;
            string storedEmpName = "", storedEmpType = "", storedEmpPos = "", storedEmpDept = "", storedEmpSup = "", storedEmpDate = DateTime.Now.ToShortDateString(), storedEmpForm = "";
            using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=1234;Database=EmployeeEval;"))
            {
                connection.Open();

                NpgsqlCommand command = new NpgsqlCommand(@"SELECT ""EmpName"", ""EmpType"", ""EmpPos"",""EmpDept"", (SELECT ""EmpName"" FROM ""Employee"" WHERE ""EmpID"" = ""Employee"".""SupervisorID""), ""EmployeePerformance"".""FormID""  FROM ""Employee"" INNER JOIN ""EmployeePerformance"" ON ""Employee"".""EmpID"" = ""EmployeePerformance"".""EmpID"" WHERE ""EmpID"" = @empID", connection);
                command.Parameters.AddWithValue("@empID", storedEmpID);


                NpgsqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    storedEmpName = reader.GetString(0);
                    storedEmpType = reader.GetString(1);
                    storedEmpPos = reader.GetString(2);
                    storedEmpDept = reader.GetString(3);
                    storedEmpSup = reader.GetString(4);
                    storedEmpForm = reader.GetString(4);
                }
                reader.Close();
            }
            Paragraph title = new Paragraph();
            title.PaddingTop = 100;
            title.SpacingBefore = 50;
            title.Alignment = Element.ALIGN_CENTER;
            title.Font = FontFactory.GetFont("Arial", 18);
            title.Add("\nPERFORMANCE EVALUATION FOR FACULTY MEMBERS\n\n");
            document.Add(title);

            PdfPTable table = new PdfPTable(3);
            table.TotalWidth = 510f;
            table.HorizontalAlignment = Element.ALIGN_CENTER;
            table.SpacingAfter = 10;

            float[] sglTblHdWidths = new float[3];
            sglTblHdWidths[0] = 170f;
            sglTblHdWidths[1] = 170f;
            sglTblHdWidths[2] = 170f;

            table.SetWidths(sglTblHdWidths);
            table.LockedWidth = true;
            addCell(table, "NAME OF EMPLOYEE", 1);
            addCell(table, "POSITION", 1);
            addCell(table, "COLLEGE/DEPARTMENT", 1);
            addCell(table, $"{storedEmpName}", 1);
            addCell(table, $"{storedEmpPos}", 1);
            addCell(table, $"{storedEmpDept}", 1);
            addCell(table, "NAME OF RATER", 1);
            addCell(table, "APPRAISAL PERIOD", 1);
            addCell(table, "DATE PREPARED", 1);
            addCell(table, $"{storedEmpSup}", 1);
            addCell(table, $"January - April 2024", 1);
            addCell(table, $"{storedEmpDate}", 1);

            document.Add(table);

            PdfPTable table1 = new PdfPTable(4);
            table1.TotalWidth = 510f;
            table1.HorizontalAlignment = Element.ALIGN_CENTER;
            table1.SpacingAfter = 10;
            float[] sglTblHdWidths1 = new float[4];
            sglTblHdWidths1[0] = 357f;
            sglTblHdWidths1[1] = 51f;
            sglTblHdWidths1[2] = 51f;
            sglTblHdWidths1[3] = 51f;
            table1.SetWidths(sglTblHdWidths1);
            table1.LockedWidth = true;

            string storedEmpSection = "";
            string[] weights = new string[8], ratings = new string[8];
            double[] weightedScore = new double[8];
            using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=1234;Database=EmployeeEval;"))
            {
                connection.Open();

                NpgsqlCommand command = new NpgsqlCommand($@"SELECT ""Section1CWR"" FROM ""FacultyForm"" WHERE ""FacultyFormID"" = @FacultyFormID", connection);
                command.Parameters.AddWithValue($"@FacultyFormID", storedEmpForm);

                NpgsqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    storedEmpSection = reader.GetString(0);
                }
                reader.Close();
            }
            string[] CWRArr = storedEmpSection.Split(';');
            for (int i = 0; i < CWRArr.Length; i++)
            {
                string[] CWRValues = CWRArr[i].Split(',');
                weights[i] = CWRValues[1];
                ratings[i] = CWRValues[2];
                weightedScore[i] = int.Parse(weights[i]) * 0.01 * int.Parse(ratings[i]);
            }

            addCell(table1, "SECTION 1 - A: ACADEMIC PERFORMANCE", 4);
            addCell(table1, "", 1);
            addCell(table1, "W", 1);
            addCell(table1, "R", 1);
            addCell(table1, "WS", 1);
            addCellLeft(table1, "A.  Faculty Evaluation", 1);
            addCell(table1, $"{weights[0]}", 1);
            addCell(table1, $"{ratings[0]}", 1);
            addCell(table1, $"{weightedScore[0].ToString("N2")}", 1);
            addCellLeft(table1, "B. Classroom Teaching Observation by Peers", 1);
            addCell(table1, $"{weights[1]}", 1);
            addCell(table1, $"{ratings[1]}", 1);
            addCell(table1, $"{weightedScore[1].ToString("N2")}", 1);
            addCellLeft(table1, "C. Classroom Teaching Observation by Dean/Chair", 1);
            addCell(table1, $"{weights[2]}", 1);
            addCell(table1, $"{ratings[2]}", 1);
            addCell(table1, $"{weightedScore[2].ToString("N2")}", 1);
            addCell(table1, "Total", 1);
            addCell(table1, "100", 1);
            addCell(table1, "", 1);
            addCell(table1, $"{(weightedScore[0] + weightedScore[1] + weightedScore[2]).ToString("N2")}", 1);

            document.Add(table1);

            PdfPTable table2 = new PdfPTable(4);
            table2.TotalWidth = 510f;
            table2.HorizontalAlignment = Element.ALIGN_CENTER;
            table2.SpacingAfter = 10;
            float[] sglTblHdWidths2 = new float[4];
            sglTblHdWidths2[0] = 357f;
            sglTblHdWidths2[1] = 51f;
            sglTblHdWidths2[2] = 51f;
            sglTblHdWidths2[3] = 51f;
            table2.SetWidths(sglTblHdWidths2);
            table2.LockedWidth = true;
            addCell(table2, "SECTION 1 - B: PROFESSIONAL ETHICS AND ADMINISTRATIVE COMPLIANCE", 4);
            addCell(table2, "", 1);
            addCell(table2, "W", 1);
            addCell(table2, "R", 1);
            addCell(table2, "WS", 1);
            addCellLeft(table2, "1.  Timely Submission of Required Documents", 1);
            addCell(table1, $"{weights[3]}", 1);
            addCell(table1, $"{ratings[3]}", 1);
            addCell(table1, $"{weightedScore[3].ToString("N2")}", 1);
            addCellLeft(table2, "The faculty member promptly submits his/her class records, final grades for printing, syllabus, other reports required by the chair/dean.", 4);
            addCellLeft(table2, "2.  Participation in Official Mapua MCL Functions, Events, and Activities", 1);
            addCell(table1, $"{weights[4]}", 1);
            addCell(table1, $"{ratings[4]}", 1);
            addCell(table1, $"{weightedScore[4].ToString("N2")}", 1);
            addCellLeft(table2, "The faculty member attends institutional activities, functions and events as well as, all faculty and employee meetings.", 4);
            addCellLeft(table2, "3.  Support for Quality Instruction", 1);
            addCell(table1, $"{weights[5]}", 1);
            addCell(table1, $"{ratings[5]}", 1);
            addCell(table1, $"{weightedScore[5].ToString("N2")}", 1);
            addCellLeft(table2, "The faculty member assists the program for the attainment of its objectives for quality output.", 4);
            addCellLeft(table2, "4.  Research Initiatives", 1);
            addCell(table1, $"{weights[6]}", 1);
            addCell(table1, $"{ratings[6]}", 1);
            addCell(table1, $"{weightedScore[6].ToString("N2")}", 1);
            addCellLeft(table2, "The faculty member contributes to the research undertaking of the college.", 4);
            addCellLeft(table2, "5.  Extension Services", 1);
            addCell(table1, $"{weights[7]}", 1);
            addCell(table1, $"{ratings[7]}", 1);
            addCell(table1, $"{weightedScore[7].ToString("N2")}", 1);
            addCellLeft(table2, "The faculty member initiates, attends, and participates in community engagements of the college.", 4);
            addCell(table2, "Total", 1);
            addCell(table2, "100", 1);
            addCell(table2, "", 1);
            addCell(table1, $"{(weightedScore[3] + weightedScore[4] + weightedScore[5] + weightedScore[6] + weightedScore[7]).ToString("N2")}", 1);

            document.Add(table2);

            document.NewPage();
            YGCValues(document, "Faculty", "2", storedEmpForm);

            document.NewPage();
            Summary(document, "Faculty", storedEmpForm);
        }

        public static void Proficiency(Document document, string type, string section, string FormID)
        {
            string storedEmpSection = "";
            string[] weights = new string[8], ratings = new string[8];
            double[] weightedScore = new double[8];
            using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=1234;Database=EmployeeEval;"))
            {
                connection.Open();

                NpgsqlCommand command = new NpgsqlCommand($@"SELECT ""Section{section}CWR"" FROM ""{type}Form"" WHERE ""{type}FormID"" = @{type}FormID", connection);
                command.Parameters.AddWithValue($"@{type}FormID", FormID);

                NpgsqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    storedEmpSection = reader.GetString(0);
                }
                reader.Close();
            }
            string[] CWRArr = storedEmpSection.Split(';');
            for (int i = 0; i < CWRArr.Length; i++)
            {
                string[] CWRValues = CWRArr[i].Split(',');
                weights[i] = CWRValues[1];
                ratings[i] = CWRValues[2];
                weightedScore[i] = int.Parse(weights[i]) * 0.01 * int.Parse(ratings[i]);
            }
            PdfPTable table2 = new PdfPTable(4);
            table2.TotalWidth = 510f;
            table2.HorizontalAlignment = Element.ALIGN_CENTER;
            table2.SpacingAfter = 10;
            float[] sglTblHdWidths2 = new float[4];
            sglTblHdWidths2[0] = 357f;
            sglTblHdWidths2[1] = 51f;
            sglTblHdWidths2[2] = 51f;
            sglTblHdWidths2[3] = 51f;
            table2.SetWidths(sglTblHdWidths2);
            table2.LockedWidth = true;
            addCell(table2, $"SECTION {section}: PROFICIENCY / BEHAVIORAL-BASED PERFORMANCE", 4);
            addCellRow(table2, "JOB KNOWLEDGE", 2);
            addCell(table2, "W", 1);
            addCell(table2, "R", 1);
            addCell(table2, "WS", 1);
            addCell(table2, $"{weights[0]}", 1);
            addCell(table2, $"{ratings[0]}", 1);
            addCell(table2, $"{weightedScore[0].ToString("N2")}", 1);
            addCellLeft(table2, "1 - Consistently not meeting Job requirements and needing substantially more supervision than should be required of someone with similar job functions and  responsibilities. Typically the employee with an I rating has continued not to.", 4);
            addCellLeft(table2, "2 - Successfully achieving SOME aspects of the job requirements and expectations and requiring substantial supervision for 2 his/her experlence level and grade.  Overall, performance level is below others with similar job functions and responsibilities.", 4);
            addCellLeft(table2, "3 - Making a solid contribution In key areas of responsibility with reasonable guidance and supervision. Performance level is at par with others with similar job  functions and responsibilities.", 4);
            addCellLeft(table2, "4 - Achieving results which exceeds the requirements and expectations of the job in all key areas of responsibility.", 4);
            addCellLeft(table2, "5 - Role modeling, very high achievement for his or her experience level and grade.", 4);
            addCellRow(table2, "JOB MANAGEMENT", 2);
            addCell(table2, "W", 1);
            addCell(table2, "R", 1);
            addCell(table2, "WS", 1);
            addCell(table2, $"{weights[1]}", 1);
            addCell(table2, $"{ratings[1]}", 1);
            addCell(table2, $"{weightedScore[1].ToString("N2")}", 1);
            addCellLeft(table2, "1 - Consistently performing one or more aspects of the job below expectations for his/her experience level and grade.", 4);
            addCellLeft(table2, "2 - Performing below expectations in one or more aspects of the job for his/her experience level and grade.", 4);
            addCellLeft(table2, "3 - Performing major aspects of the job well. May at times exceed the standard scope of the job's requirements/expectations.", 4);
            addCellLeft(table2, "4 - Performing all aspects of the job well and often exceeding the standard scope of job requirements/expectations.", 4);
            addCellLeft(table2, "5 - Consistently exceeding the standard scope of all job requirements/expectations.", 4);
            addCellRow(table2, "WORK DELIVERY", 2);
            addCell(table2, "W", 1);
            addCell(table2, "R", 1);
            addCell(table2, "WS", 1);
            addCell(table2, $"{weights[2]}", 1);
            addCell(table2, $"{ratings[2]}", 1);
            addCell(table2, $"{weightedScore[2].ToString("N2")}", 1);
            addCellLeft(table2, "1 - Requiring repeated intervention or coaching by manager.", 4);
            addCellLeft(table2, "2 - Requiring substantial supervisory or managerial follow-up commensurate with the employee's experience level and ability to assume responsibility.", 4);
            addCellLeft(table2, "3 - Fulfilling assigned tasks within the required turn-around time.", 4);
            addCellLeft(table2, "4 - Working independently in a highly competent and reliable manner, requiring no supervision.", 4);
            addCellLeft(table2, "5 - Anticipating potential issues and problems that may arise and working independently in a highly competent and reliable.", 4);
            addCellRow(table2, "CREATIVITY", 2);
            addCell(table2, "W", 1);
            addCell(table2, "R", 1);
            addCell(table2, "WS", 1);
            addCell(table2, $"{weights[3]}", 1);
            addCell(table2, $"{ratings[3]}", 1);
            addCell(table2, $"{weightedScore[3].ToString("N2")}", 1);
            addCellLeft(table2, "1 - Consistently falling to apply appropriate problem solving techniques to issues or problems.", 4);
            addCellLeft(table2, "2 - Inconsistently applying appropriate problem solving/technical improvements to identified issue.", 4);
            addCellLeft(table2, "3 - Able to generate ideas that address existing needs or gaps.", 4);
            addCellLeft(table2, "4 - Ability to look beyond the present demands of the job in order to improve work plans, methods or results.", 4);
            addCellLeft(table2, "5 - Able to think out of the box and generate ideas to make existing process more efficient.", 4);
            addCellRow(table2, "COMMUNICATION WITH OTHERS", 2);
            addCell(table2, "W", 1);
            addCell(table2, "R", 1);
            addCell(table2, "WS", 1);
            addCell(table2, $"{weights[4]}", 1);
            addCell(table2, $"{ratings[4]}", 1);
            addCell(table2, $"{weightedScore[4].ToString("N2")}", 1);
            addCellLeft(table2, "1 - Selecting the \"right\" words and usage for the context of the conversation (including moral, ethnic and religious differences). Being clear and concise. Formulates thoughts to avoid rambling.", 4);
            addCellLeft(table2, "2 - Physically align with others, connecting with them in form and movement. Mindful of posture, facial expressions, and hand gestures.", 4);
            addCellLeft(table2, "3 - Is aware of various auditory cues, speaking to others in a manner more akin to their own ways (another form of \"matching and mirroring\").", 4);
            addCellLeft(table2, "4 - Is aware of the emotional state, learning to pause and release negative emotions before attempting to connect with others. Words delivered with pride, anger or fear are rarely well received.", 4);
            addCellLeft(table2, "5 - Hold the highest intention for the other person's wellbeing. This requires a unique level of mindfulness generally cultivated through compassion practices. When we are centered in a state of mastery, we're more likely to access this psychic dimension that holds great treasures of Insights into others, helping us communicate with greater ease.", 4);
            addCellRow(table2, "INITIATIVE", 2);
            addCell(table2, "W", 1);
            addCell(table2, "R", 1);
            addCell(table2, "WS", 1);
            addCell(table2, $"{weights[5]}", 1);
            addCell(table2, $"{ratings[5]}", 1);
            addCell(table2, $"{weightedScore[5].ToString("N2")}", 1);
            addCellLeft(table2, "1 - Inability or unwillingness to work as part of the team or group and not viewed as a role model.", 4);
            addCellLeft(table2, "2 - Difficulty working as part of the team or group and is not viewed as a role model.", 4);
            addCellLeft(table2, "3 - Comprehensively doing his work unpromted.", 4);
            addCellLeft(table2, "4 - Inspires and encourages co-employees to go the extra mile.", 4);
            addCellLeft(table2, "5 - Taking on supplementary responsibilities, and willingly participating in and contributing to highly successful teams, typically becoming the formal or informal team leader.", 4);
            addCellRow(table2, "WORK DRIVE", 2);
            addCell(table2, "W", 1);
            addCell(table2, "R", 1);
            addCell(table2, "WS", 1);
            addCell(table2, $"{weights[6]}", 1);
            addCell(table2, $"{ratings[6]}", 1);
            addCell(table2, $"{weightedScore[6].ToString("N2")}", 1);
            addCellLeft(table2, "1 - Consistently late in completing assigned tasks.", 4);
            addCellLeft(table2, "2 - Occasionally late in competing assigned tasks.", 4);
            addCellLeft(table2, "3 - Completes the assigned tasks within the agreed turn-around time.", 4);
            addCellLeft(table2, "4 - Tasks are occasionally completed ahead of greed turn- around time.", 4);
            addCellLeft(table2, "5 - Consistently completes the assigned tasks ahead of the agreed turn-around time.", 4);
            addCellRow(table2, "OBSERVANCE OF RULES AND REGULATIONS", 2);
            addCell(table2, "W", 1);
            addCell(table2, "R", 1);
            addCell(table2, "WS", 1);
            addCell(table2, $"{weights[7]}", 1);
            addCell(table2, $"{ratings[7]}", 1);
            addCell(table2, $"{weightedScore[7].ToString("N2")}", 1);
            addCellLeft(table2, "1 - Observes rules and regulations when an officer is around.", 4);
            addCellLeft(table2, "2 - Shows interest in organizational values, and use it to regulate personal behavior.", 4);
            addCellLeft(table2, "3 - Behaves broadly in line general organizational values.", 4);
            addCellLeft(table2, "4 - Ensures all action are taken in the Organization's best interests. ", 4);
            addCellLeft(table2, "5 - consistently exceeding the standard scope of all job requirements/expectations.", 4);
            addCell(table2, "Total", 2);
            addCell(table2, "100", 1);
            addCell(table2, "", 1);
            addCell(table2, $"{weightedScore.Sum().ToString("N2")}", 1);

            document.Add(table2);
        }

        public static void YGCValues(Document document, string type, string section, string storedEmpForm)
        {
            string storedEmpSection = "";
            string[] weights = new string[5], ratings = new string[5];
            double[] weightedScore = new double[5];
            string storedFormID = storedEmpForm;
            using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=1234;Database=EmployeeEval;"))
            {
                connection.Open();

                NpgsqlCommand command = new NpgsqlCommand($@"SELECT ""Section{section}CWR"" FROM ""{type}Form"" WHERE ""{type}FormID"" = @{type}FormID", connection);
                command.Parameters.AddWithValue($"@{type}FormID", storedFormID);

                NpgsqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    storedEmpSection = reader.GetString(0);
                }
                reader.Close();
            }
            string[] CWRArr = storedEmpSection.Split(';');
            for (int i = 0; i < CWRArr.Length; i++)
            {
                string[] CWRValues = CWRArr[i].Split(',');
                weights[i] = CWRValues[1];
                ratings[i] = CWRValues[2];
                weightedScore[i] = int.Parse(weights[i]) * 0.01 * int.Parse(ratings[i]);
            }
            PdfPTable table2 = new PdfPTable(4);
            table2.TotalWidth = 510f;
            table2.HorizontalAlignment = Element.ALIGN_CENTER;
            table2.SpacingAfter = 10;
            float[] sglTblHdWidths2 = new float[4];
            sglTblHdWidths2[0] = 357f;
            sglTblHdWidths2[1] = 51f;
            sglTblHdWidths2[2] = 51f;
            sglTblHdWidths2[3] = 51f;
            table2.SetWidths(sglTblHdWidths2);
            table2.LockedWidth = true;
            addCell(table2, $"SECTION {section}: DEMONSTRATION OF YGC CORE VALUES", 4);
            addCell(table2, "PASSION FOR EXCELLENCE", 1);
            addCell(table2, "W", 1);
            addCell(table2, "R", 1);
            addCell(table2, "WS", 1);
            addCellLeft(table2, "Stiving to be great and not just good. Continuously improving our results.", 1);
            addCell(table2, $"{weights[0]}", 1);
            addCell(table2, $"{ratings[0]}", 1);
            addCell(table2, $"{weightedScore[0].ToString("N2")}", 1);
            addCellLeft(table2, "1 - Does not meet deadlines and standards. Displays low level of effort towards work. Has no concern for quality of products and services and commits numerous mistakes when working.", 4);
            addCellLeft(table2, "2 - Works to meet performance standards but standards but sometimes completes tasks beyond deadline or at an unacceptable level.", 4);
            addCellLeft(table2, "3 - Meets targets/objectives within set deadlines and at an acceptable level. Keep track of work progress and in cases of deviations, promptly takes corrective actions. Thinks of customer interest and business goals  and finds, if not makes a way to fulfill, or even exceed these.", 4);
            addCellLeft(table2, "4 - Works to exceed set targets and persists in achieving a standard of excellence that goes beyond expectations. Makes specific changes in work methods or operations to improve performance.", 4);
            addCellLeft(table2, "5 - Leads/motivates teammates in attaining or exceeding targets/objectives. Analyzes performance information to predict emerging issues and patterns. Takes calculated risks.", 4);
            addCell(table2, "SENSE OF URGENCY", 1);
            addCell(table2, "W", 1);
            addCell(table2, "R", 1);
            addCell(table2, "WS", 1);
            addCellLeft(table2, "Doing things fast. Taking initiative to respond to needs of various stakeholders.", 1);
            addCell(table2, $"{weights[1]}", 1);
            addCell(table2, $"{ratings[1]}", 1);
            addCell(table2, $"{weightedScore[1].ToString("N2")}", 1);
            addCellLeft(table2, "1 - Works at his own pace. Requires prodding and requires constant reminder for tasks to be completed.", 4);
            addCellLeft(table2, "2 - Responds to internal/external customer requests/complaints but may require regular monitoring of work by superior.", 4);
            addCellLeft(table2, "3 - Responds/reacts immediately to internal/external customer requests/complaints without being reminded by superior re: deliverables. Prioritizes activities purposively. Does not procrastinate on things that need to  be done today.", 4);
            addCellLeft(table2, "4 - Acts independently to bring issues to closure. Performs tasks at a fast pace without sacrificing quality. With \"fire in the belly\": energetic and enthusiastic in meeting work requirements.", 4);
            addCellLeft(table2, "5 - Motivates and enables teammates to bring issues to prompt closure. Anticipates hindrances and plans alternative courses of action by encouraging and/or enabling others to support the plan.", 4);
            addCell(table2, "PROFESSIONAL DISCIPLINE", 1);
            addCell(table2, "W", 1);
            addCell(table2, "R", 1);
            addCell(table2, "WS", 1);
            addCellLeft(table2, "Strong work ethic. Deserving of trust and respect. Prudent use of company resources, including time. Acting with fairness and objectivity.", 1);
            addCell(table2, $"{weights[2]}", 1);
            addCell(table2, $"{ratings[2]}", 1);
            addCell(table2, $"{weightedScore[2].ToString("N2")}", 1);
            addCellLeft(table2, "1 - Dishonest and/or wasteful. Authorities of others are frequently undermined. Makes decisions in a self-serving fashion.", 4);
            addCellLeft(table2, "2 - Provides questionable excuses/xeplanations when confronted. Has a problem with maintaining confidentiality. Often observed to prioritize personal convenience over organization/work requirements.", 4);
            addCellLeft(table2, "3 - Trustworthy with information and use of resources. Uses good judgement in maintaining confidentiality. Refrains from gossip/rumor-mill. Keeps well within company policies.", 4);
            addCellLeft(table2, "4 - Trusted to hold highly confidential information and manage contentious resources. When confronted with Issues , chooses ethical course in the face of pressure. Able to take unpopular stands when needed. Does what he says and says what he does.", 4);
            addCellLeft(table2, "5 - Proactively takes extraordinary steps to ensure personal and organizational integrity. Has an impeccable track record of ethical conduct.Takes responsibility for his decisions, irrespective of consequences. Prudent and judicious in handling information and managing organizational resources under his care.", 4);
            addCell(table2, "TEAMWORK", 1);
            addCell(table2, "W", 1);
            addCell(table2, "R", 1);
            addCell(table2, "WS", 1);
            addCellLeft(table2, "Actively tapping areas of synergy. Communicating and collaborating towards common goals.", 1);
            addCell(table2, $"{weights[3]}", 1);
            addCell(table2, $"{ratings[3]}", 1);
            addCell(table2, $"{weightedScore[3].ToString("N2")}", 1);
            addCellLeft(table2, "1 - Withdrawn. Openly critical of other's suggestions Does not freely cooperate with others.", 4);
            addCellLeft(table2, "2 - Communicates limitedly. Has the tendency to prefer warking alone rather than in a group setting. Cooperates w/ others but w/ reservation.", 4);
            addCellLeft(table2, "3 - Works well in a team environment. Open to, or seeks out, opportunities for synergy. Willingly takes on whatever team role he is called upon to play. Actively  participates in group deliberations and supports group decision even when this is not his original choice.", 4);
            addCellLeft(table2, "4 - Strengthens team spirit by encouraging everyone to contribute. Focuses on the strengths & not the weakness of others. Speaks highly of team members to promote  a friendly climate and strong morale. Shows confidence in others, recognizes their ability to meet expectations and to contribute effectively to the team's duties.", 4);
            addCellLeft(table2, "5 - Acts as a catalyst in the team's vibrancy. Freely shares his expertise with his teammates. Carries his own load while helping others with theirs, as needed. Is not  bothered as to who gets the credit, so long as things are done also respects & appreciates the similarities & differences among co-workers and demonstrates model  behavior for working with diverse populations.", 4);
            addCell(table2, "LOYALTY", 1);
            addCell(table2, "W", 1);
            addCell(table2, "R", 1);
            addCell(table2, "WS", 1);
            addCellLeft(table2, "Being good corporate citizens. Pursuing corporate interests as his own. Speaking well of the company and taking pride of its achievements.", 1);
            addCell(table2, $"{weights[4]}", 1);
            addCell(table2, $"{ratings[4]}", 1);
            addCell(table2, $"{weightedScore[4].ToString("N2")}", 1);
            addCellLeft(table2, "1 - Doesn't attempt to understand mission, direction, or goals of the organization. Or simply doesn't care where the organization is headed. Observed to be antagonistic toward the organization and/or its officers.", 4);
            addCellLeft(table2, "2 - Has basic understanding of organizational goals and directions but requires guidance or regular reminders regarding personal alignment. When issues involving the company arise, takes a passive stance.", 4);
            addCellLeft(table2, "3 - Understands organizational goals and directions and supports these. Defends corporate actions to others.", 4);
            addCellLeft(table2, "4 - Identifies with organization goals and directions. Willing to make personal sacrifices for the greater good.", 4);
            addCellLeft(table2, "5 - Rallies others towards supporting the organization, even when it is not personally convenient to do so. Willing to take tough stance in behalf of the organization.", 4);
            addCell(table2, "Total", 1);
            addCell(table2, "100", 1);
            addCell(table2, "", 1);
            addCell(table2, $"{weightedScore.Sum().ToString("N2")}", 1);

            document.Add(table2);
        }

        public static void Summary(Document document, string type, string FormID)
        {
            string strength = "", improvement = "", development = "", acknowledgement = "";
            string[] weights = new string[5], ratings = new string[5];
            double[] weightedScore = new double[5];
            string storedFormID = FormID;
            using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=1234;Database=EmployeeEval;"))
            {
                connection.Open();

                NpgsqlCommand command = new NpgsqlCommand($@"SELECT ""Strength"",  ""Improvement"",  ""Development"", ""Acknowledgement"" FROM ""{type}Form"" WHERE ""{type}FormID"" = @{type}FormID", connection);
                command.Parameters.AddWithValue($"@{type}FormID", storedFormID);

                NpgsqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    strength = reader.GetString(0);
                    improvement = reader.GetString(1);
                    development = reader.GetString(2);
                    acknowledgement = reader.GetString(3);
                }
                reader.Close();
            }
            PdfPTable table2 = new PdfPTable(4);
            PdfPTable table1 = new PdfPTable(1);
            table1.TotalWidth = 501f;
            table1.HorizontalAlignment = Element.ALIGN_CENTER;
            table1.SpacingAfter = 10;
            table1.LockedWidth = true;
            addCell(table1, "SECTION 3 - Summary", 1);
            addCellLeft(table1, "STRENGTH", 1);
            addCell(table1, $"{strength}", 1); //lagay mo dito STRENGTH
            addCellLeft(table1, "AREAS OF IMPROVEMENT", 1);
            addCell(table1, $"{improvement}", 1); //lagay mo dito IMPROVEMENT
            addCellLeft(table1, "DEVELOPMENT PLANS (PLEASE SPECIFY TARGET DATE)", 1);
            addCell(table1, $"{development}", 1); //lagay mo dito DEVELOPMENT
            addCellLeft(table1, "EMPLOYEE'S COMMENTS/ACKNOWLEDGEMENT", 1);
            addCell(table1, $"{acknowledgement}", 1); //lagay mo dito ACKNOWLEDGEMENT
            addCellLeft(table1, "To indicate that the employee was advised of the results of the evaluation and does not necessarily mean that he/she is in agreement with the rating and/or remarks.", 1);
            addCell(table1, "\n\nEMPLOYEE'S SIGNATURE OVER PRINTED NAME", 1);


            if (type.ToLower() == "faculty")
            {
                table2.TotalWidth = 204f;
                table2.HorizontalAlignment = Element.ALIGN_CENTER;
                table2.SpacingAfter = 30;
                float[] sglTblHdWidths2 = new float[4];
                sglTblHdWidths2[0] = 51f;
                sglTblHdWidths2[1] = 51f;
                sglTblHdWidths2[2] = 51f;
                sglTblHdWidths2[3] = 51f;
                table2.SetWidths(sglTblHdWidths2);
                table2.LockedWidth = true;
                addCell(table2, "Section 1 - A", 1);
                addCell(table2, "", 1);//weighted score
                addCell(table2, "50%", 1);
                addCell(table2, "", 1);//computed
                addCell(table2, "Section 1 - B", 1);
                addCell(table2, "", 1);//weighted score
                addCell(table2, "20%", 1);
                addCell(table2, "", 1);//computed
                addCell(table2, "Section 2", 1);
                addCell(table2, "", 1);//weighted score
                addCell(table2, "30%", 1);
                addCell(table2, "", 1);//computed
                addCell(table2, "TOTAL PERFORMANCE POINTS", 2);
                addCell(table2, "100%", 1);
                addCell(table2, "", 1); //lagay mo dito computation total weighted score

                PdfPTable table3 = new PdfPTable(3);
                table3.TotalWidth = 501f;
                table3.HorizontalAlignment = Element.ALIGN_CENTER;
                float[] sglTblHdWidths3 = new float[3];
                sglTblHdWidths3[0] = 51f;
                sglTblHdWidths3[1] = 102f;
                sglTblHdWidths3[2] = 306f;
                table3.SetWidths(sglTblHdWidths3);
                table3.SpacingAfter = 30;
                table3.LockedWidth = true;

                addCell(table3, "RECOMMENDATIONS (For non Tenured Faculty Members Only)", 3);
                addCell(table3, "", 1);//weighted score
                addCell(table3, "Reaapoint for next academic year", 1);
                addCellLeft(table3, "Comments:                                                         ", 1);//computed
                addCell(table3, "", 1);
                addCell(table3, "Reaapoint for additional term", 1);//weighted score
                addCellLeft(table3, "Comments:                                                         ", 1);//computed
                addCell(table3, "", 1);
                addCell(table3, "Terminate", 1);//weighted score
                addCellLeft(table3, "Comments:                                                         ", 1);//computed
                addCell(table3, "", 1);
                addCell(table3, "Others, please specify", 1);//weighted score
                addCellLeft(table3, "Comments:                                                         ", 1);//computed
                document.Add(table1);
                document.Add(table2);
                document.Add(table3);
            }
            else if (type.ToLower() == "staff")
            {
                table2.TotalWidth = 204f;
                table2.HorizontalAlignment = Element.ALIGN_CENTER;
                table2.SpacingAfter = 30;
                float[] sglTblHdWidths2 = new float[4];
                sglTblHdWidths2[0] = 51f;
                sglTblHdWidths2[1] = 51f;
                sglTblHdWidths2[2] = 51f;
                sglTblHdWidths2[3] = 51f;
                table2.SetWidths(sglTblHdWidths2);
                table2.LockedWidth = true;
                addCell(table2, "Section 1", 1);
                addCell(table2, "", 1);//weighted score
                addCell(table2, "60%", 1);
                addCell(table2, "", 1);//computed
                addCell(table2, "Section 2", 1);
                addCell(table2, "", 1);//weighted score
                addCell(table2, "40%", 1);
                addCell(table2, "", 1);//computed
                addCell(table2, "TOTAL PERFORMANCE POINTS", 2);
                addCell(table2, "100%", 1);
                addCell(table2, "", 1); //lagay mo dito computation total weighted score

                document.Add(table1);
                document.Add(table2);
            }
            else if (type.ToLower() == "officer")
            {
                table2.TotalWidth = 204f;
                table2.HorizontalAlignment = Element.ALIGN_CENTER;
                table2.SpacingAfter = 30;
                float[] sglTblHdWidths2 = new float[4];
                sglTblHdWidths2[0] = 51f;
                sglTblHdWidths2[1] = 51f;
                sglTblHdWidths2[2] = 51f;
                sglTblHdWidths2[3] = 51f;
                table2.SetWidths(sglTblHdWidths2);
                table2.LockedWidth = true;
                addCell(table2, "Section 1", 1);
                addCell(table2, "", 1);//weighted score
                addCell(table2, "30%", 1);
                addCell(table2, "", 1);//computed
                addCell(table2, "Section 2", 1);
                addCell(table2, "", 1);//weighted score
                addCell(table2, "20%", 1);
                addCell(table2, "", 1);//computed
                addCell(table2, "Section 3", 1);
                addCell(table2, "", 1);//weighted score
                addCell(table2, "30%", 1);
                addCell(table2, "", 1);//computed
                addCell(table2, "Section 4", 1);
                addCell(table2, "", 1);//weighted score
                addCell(table2, "20%", 1);
                addCell(table2, "", 1);//computed
                addCell(table2, "TOTAL PERFORMANCE POINTS", 2);
                addCell(table2, "100%", 1);
                addCell(table2, "", 1); //lagay mo dito computation total weighted score

                document.Add(table1);
                document.Add(table2);
            }


            Paragraph line1 = new Paragraph();
            line1.PaddingTop = 100;
            line1.Alignment = Element.ALIGN_CENTER;
            line1.Font = FontFactory.GetFont("Arial", 12, Font.UNDERLINE);
            line1.Add("                                                         ");
            Paragraph sign1 = new Paragraph();
            sign1.Alignment = Element.ALIGN_CENTER;
            sign1.Font = FontFactory.GetFont("Arial", 12);
            sign1.Add("\nRATER'S SINGATURE OVER PRINTED NAME\n\n");
            Paragraph line2 = new Paragraph();
            line2.Alignment = Element.ALIGN_CENTER;
            line2.Font = FontFactory.GetFont("Arial", 12, Font.UNDERLINE);
            line2.Add("                                                         ");
            Paragraph sign2 = new Paragraph();
            sign2.Alignment = Element.ALIGN_CENTER;
            sign2.Font = FontFactory.GetFont("Arial", 12);
            sign2.Add("\nRATER'S IMMEDIATE SUPERIOR SINGATURE OVER PRINTED NAME\n\n");
            document.Add(line1);
            document.Add(sign1);
            document.Add(line2);
            document.Add(sign2);
        }

        private static void addCell(PdfPTable table, string text, int columnspan)
        {
            iTextSharp.text.Font times = new iTextSharp.text.Font(Font.FontFamily.UNDEFINED, 11, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);

            PdfPCell cell = new PdfPCell(new Phrase(text, times));
            if (int.TryParse(text, out int result))
            {
                cell = new PdfPCell(new Phrase(text));
            }
            cell.Colspan = columnspan;
            cell.Padding = 5;
            cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            if (text.ToUpper() == "TOTAL" && text.ToUpper() == "TOTAL PERFORMANCE POINTS")
            {
                cell.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
            }
            if (text.ToUpper() == "EMPLOYEE'S SIGNATURE OVER PRINTED NAME")
            {
                cell.Rowspan = 2;
                cell.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                cell.VerticalAlignment = PdfPCell.ALIGN_BOTTOM;
            }
            table.AddCell(cell);
        }

        private static void addCellRow(PdfPTable table, string text, int rowspan)
        {
            iTextSharp.text.Font times = new iTextSharp.text.Font(Font.FontFamily.UNDEFINED, 11, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);

            PdfPCell cell = new PdfPCell(new Phrase(text, times));
            if (int.TryParse(text, out int result))
            {
                cell = new PdfPCell(new Phrase(text));
            }
            cell.Rowspan = rowspan;
            cell.Colspan = 1;
            cell.Padding = 5;
            cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
            cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            table.AddCell(cell);
        }
        private static void addCellLeft(PdfPTable table, string text, int columnspan)
        {
            iTextSharp.text.Font times = new iTextSharp.text.Font(Font.FontFamily.UNDEFINED, 11, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);

            PdfPCell cell = new PdfPCell(new Phrase(text));
            cell.Colspan = columnspan;
            cell.Padding = 5;
            cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
            cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            if (text == "Comments:                                                         ")
            {
                cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
            }
            table.AddCell(cell);
        }

        public static double computesubtotal(string weight, string rating)
        {
            return (0.01 * double.Parse(weight) * double.Parse(rating));
        }

        public static double computetotal(string[] weights, string[] ratings)
        {
            double total = 0;
            for (int i = 0; i < weights.Length; i++)
            {
                total += (0.01 * double.Parse(weights[i]) * double.Parse(ratings[i]));
            }
            return total;
        }
    }
}