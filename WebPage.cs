using Microsoft.SqlServer.Server;
using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml;
using static System.Collections.Specialized.BitVector32;

namespace WebApplication1
{
    public class WebPage
    {
        static TextBox[] weightArrA, weightArrB, weightArrC;

        public static string[] CreateAgreementForm(string rateeID, string empType)
        {
            string supID, formID;
            supID = GetSupervisorID(rateeID);

            return new string[]
            {
                formID = InsertEmpPerfInfo(rateeID, supID),
                InsertEmpFormInfo(formID, empType),
                InsertStatRepInfo(rateeID)
            };
        }

        protected static string InsertStatRepInfo(string empID)
        {
            string query, reportID;
            long counnt = 6000000001;

            using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=1234;Database=EmployeeEval;"))
            {
                connection.Open();

                query = @"SELECT COUNT(*) FROM ""StatusReport""";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                reportID = (counnt + Convert.ToInt32(command.ExecuteScalar())).ToString();

                query = @"INSERT INTO ""StatusReport"" VALUES (@ReportID, @EmpID, 0, 0, 0, 0)";
                command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@ReportID", reportID);
                command.Parameters.AddWithValue("@EmpID", empID);
                command.ExecuteNonQuery();
            }
            return reportID;
        }

        protected static string InsertEmpPerfInfo(string empID, string supID)
        {
            string query, formID;
            long counnt = 2000000001;

            using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=1234;Database=EmployeeEval;"))
            {
                connection.Open();

                query = @"SELECT COUNT(*) FROM ""EmployeePerformance""";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                formID = (counnt + Convert.ToInt32(command.ExecuteScalar())).ToString();
                //Session["FormID"] = formID;

                query = @"INSERT INTO ""EmployeePerformance"" VALUES (@FormID , @EmpID , @SupID , 0)";
                command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@FormID", formID);
                command.Parameters.AddWithValue("@EmpID", empID);
                command.Parameters.AddWithValue("@SupID", supID);
                command.ExecuteNonQuery();

                connection.Close();
            }
            return formID;
        }

        protected static string InsertEmpFormInfo(string formID, string empType)
        {
            string empFormID, query, insertQuery = "";
            long counnt = 0;

            switch (empType)
            {
                case "Staff":
                    counnt = 3000000001;
                    insertQuery = $@"INSERT INTO ""StaffForm"" VALUES (@StaffFormID, @FormID , 0, 0, 0, 0, 0, 0, 0)";
                    break;
                case "Faculty":
                    counnt = 4000000001;
                    insertQuery = @"INSERT INTO ""FacultyForm"" VALUES (@FacultyFormID, @FormID , 0, 0, 0, 0, 0, 0, 0)";
                    break;
                case "Officer":
                    counnt = 5000000001;
                    insertQuery = @"INSERT INTO ""OfficerForm"" VALUES (@OfficerFormID, @FormID, 0, 0, 0, 0, 0, 0, 0, 0, 0)";
                    break;

                default:
                    break;
            }

            using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=1234;Database=EmployeeEval;"))
            {
                connection.Open();

                query = $@"SELECT COUNT(*) FROM ""{empType}Form""";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                empFormID = (counnt + Convert.ToInt32(command.ExecuteScalar())).ToString();

                command = new NpgsqlCommand(insertQuery, connection);
                command.Parameters.AddWithValue($"@{empType}FormID", empFormID);
                command.Parameters.AddWithValue("@FormID", formID);
                command.ExecuteNonQuery();

                connection.Close();
            }
            return empFormID;
        }

        protected static string GetSupervisorID(string empID)
        {
            string query, supID = "";

            using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=1234;Database=EmployeeEval;"))
            {
                connection.Open();

                query = @"SELECT ""SupID"" FROM ""Employee"" WHERE ""Employee"".""EmpID"" = @empID";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@EmpID", empID);
                NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    supID = reader.GetString(0);
                }
                reader.Close();

                connection.Close();
            }
            return supID;
        }

        public static string[] InitializeAgreement(string empID, string empType) 
        {
            string query, empFormID = "", PAVal = "";

            using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=1234;Database=EmployeeEval;"))
            {
                connection.Open();
                
                query = $@"SELECT SR.""PAValidation"", (SELECT ""{empType}FormID"" FROM ""{empType}Form"" SF WHERE SF.""FormID"" = EP.""FormID"") FROM ""EmployeePerformance"" EP INNER JOIN ""StatusReport"" SR ON EP.""EmpID"" = SR.""EmpID"" WHERE EP.""EmpID"" = @empID;";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@EmpID", empID);
                NpgsqlDataReader reader = command.ExecuteReader();

                if (!reader.HasRows)
                    return null;

                while (reader.Read())
                {
                    PAVal = reader.GetString(0);
                    empFormID = reader.GetString(1);
                }
                reader.Close();

                connection.Close();                
            }
            return new string[]
            {
                (PAVal != "0" && PAVal != null).ToString(), 
                empFormID
            };
        }


        public static string[] InitializeAgreementSection(ref TextBox[] weightArr, ref Label total, string empFormID, string field, string empType) 
        {
            string query, CWR = "", PAVal = "", reportID = "";
            bool PAValDone;

            using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=1234;Database=EmployeeEval;"))
            {
                connection.Open();

                query = $@"SELECT ""{field}"", ""ReportID"", ""PAValidation"" FROM ""{empType}Form"" INNER JOIN ""EmployeePerformance"" ON ""{empType}Form"".""FormID"" = ""EmployeePerformance"".""FormID"" INNER JOIN ""StatusReport"" ON ""EmployeePerformance"".""EmpID"" = ""StatusReport"".""EmpID"" WHERE ""{empType}FormID"" = @empFormID";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@empFormID", empFormID);

                NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    CWR = reader.GetString(0);
                    reportID = reader.GetString(1);
                    PAVal = reader.GetString(2);
                }
                reader.Close();

                connection.Close();
            }

            PAValDone = PAVal != "0" && PAVal != null;

            SetWeightText(ref weightArr, CWR);
            SetTotalWeight(ref weightArr, ref total);
            EnableTextBoxes(ref weightArr, PAValDone);

            return new string[]
            {
                reportID, 
                PAValDone.ToString()
            };
        }

        public static string[] InitializeAgreementSection(ref TextBox[] weightArr, ref TextBox[] weightArr2, ref TextBox[] weightArrCombined, ref Label total, ref Label total2, string empFormID, string field, string empType)
        {
            string query, CWR = "", PAVal = "", reportID = "";
            bool PAValDone;

            using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=1234;Database=EmployeeEval;"))
            {
                connection.Open();

                query = $@"SELECT ""{field}"", ""ReportID"", ""PAValidation"" FROM ""{empType}Form"" INNER JOIN ""EmployeePerformance"" ON ""{empType}Form"".""FormID"" = ""EmployeePerformance"".""FormID"" INNER JOIN ""StatusReport"" ON ""EmployeePerformance"".""EmpID"" = ""StatusReport"".""EmpID"" WHERE ""{empType}FormID"" = @empFormID";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@empFormID", empFormID);

                NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    CWR = reader.GetString(0);
                    reportID = reader.GetString(1);
                    PAVal = reader.GetString(2);
                }
                reader.Close();

                connection.Close();
            }

            PAValDone = PAVal != "0" && PAVal != null;

            SetWeightText(ref weightArrCombined, CWR);
            SetTotalWeight(ref weightArr, ref weightArr2, ref total, ref total2);
            EnableTextBoxes(ref weightArrCombined, PAValDone);

            return new string[]
            {
                reportID,
                PAValDone.ToString()
            };
        }
        protected static void SetWeightText(ref TextBox[] weightArr, string CWR)
        {
            if (CWR != "0")
            {
                string[] CWRArr = CWR.Split(';');
                for (int i = 0; i < CWRArr.Length; i++)
                {
                    string[] CWRValues = CWRArr[i].Split(',');
                    weightArr[i].Text = int.Parse(CWRValues[0]).ToString();
                }
            }
        }
        public static void SetTotalWeight(ref TextBox[] weightArr, ref Label total) 
        {
            double totalWeight = 0;

            foreach (TextBox weight in weightArr)
            {
                totalWeight += double.Parse(weight.Text);
            }

            total.Text = totalWeight.ToString("0.00");
        }

        public static void SetTotalWeight(ref TextBox[] weightArr, ref TextBox[] weightArr2, ref Label total, ref Label total2)
        {
            double totalWeight = 0, totalWeight2 = 0;

            foreach (TextBox weight in weightArr)
            {
                totalWeight += double.Parse(weight.Text);
            }
            foreach (TextBox weight in weightArr2)
            {
                totalWeight2 += double.Parse(weight.Text);
            }

            total.Text = totalWeight.ToString("0.00");
            total2.Text = totalWeight2.ToString("0.00");
        }

        protected static void EnableTextBoxes(ref TextBox[] weightArr, bool PAValDone) 
        {
            foreach (var item in weightArr)
            {
                item.Enabled = (!PAValDone);
            }
        }
        public static void AdjustWeight(ref TextBox[] weightArr, TextBox weight, ref Label total) 
        {
                if (double.Parse(weight.Text) > 100)
                    weight.Text = "100";
                else if (double.Parse(weight.Text) < 0)
                    weight.Text = "0";
                SetTotalWeight(ref weightArr, ref total);
        }
        protected static string CompileAnswers(ref TextBox[] weightArr)
        {
            string CWR = "";

            foreach (TextBox weight in weightArr)
            {
                CWR += $"{int.Parse(weight.Text)},0;";
            }

            return CWR.TrimEnd(';');
        }

        protected static string CompileAnswers(ref Label[] weightArr, ref TextBox[] ratingArr)
        {
            string CWR = "";

            for (int i = 0; i < weightArr.Length; i++)
            {
                CWR += $"{int.Parse(weightArr[i].Text)},{int.Parse(ratingArr[i].Text)};";
            }

            return CWR.TrimEnd(';');
        }
        public static void UpdateDatabase(ref TextBox[] weightArr, string empTypeID, string empType, string field)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=1234;Database=EmployeeEval;"))
                {
                    connection.Open();

                    NpgsqlCommand command = new NpgsqlCommand($@"UPDATE ""{empType}Form"" SET ""{field}"" = @CWR WHERE ""{empType}FormID"" = @{empType}FormID", connection);
                    command.Parameters.AddWithValue("@CWR", CompileAnswers(ref weightArr));
                    command.Parameters.AddWithValue($"@{empType}FormID", empTypeID);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

            }
        }

        public static void UpdateDatabase(ref Label[] weightArr, ref TextBox[] ratingArr, string empTypeID, string empType, string field)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=1234;Database=EmployeeEval;"))
                {
                    connection.Open();

                    NpgsqlCommand command = new NpgsqlCommand($@"UPDATE ""{empType}Form"" SET ""{field}"" = @CWR WHERE ""{empType}FormID"" = @{empType}FormID", connection);
                    command.Parameters.AddWithValue("@CWR", CompileAnswers(ref weightArr, ref ratingArr));
                    command.Parameters.AddWithValue($"@{empType}FormID", empTypeID);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

            }
        }

        public static void UpdateDatabase(TextBox[] commentArr, string empType, string empFormID)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=1234;Database=EmployeeEval;"))
                {
                    connection.Open();
                    NpgsqlCommand command = new NpgsqlCommand($@"UPDATE ""{empType}Form"" SET ""Strength"" = @Strength, ""Improvement"" = @Improvement, ""Development"" = @Development, ""Acknowledgement"" = @Acknowledgement WHERE ""{empType}FormID"" = @empFormID", connection);
                    command.Parameters.AddWithValue("@Strength", commentArr[0].Text);
                    command.Parameters.AddWithValue("@Improvement", commentArr[1].Text);
                    command.Parameters.AddWithValue("@Development", commentArr[2].Text);
                    command.Parameters.AddWithValue("@Acknowledgement", commentArr[3].Text);
                    command.Parameters.AddWithValue("@empFormID", empFormID);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

            }
        }


        public static string[] InitializeAgreementOverall(string empFormID, string empType, string fields) 
        {
            string query, alert, PAVal = "";
            bool PAValDone;
            List<int> secNum = new List<int>();

            int fieldCount = fields.Split(',').Length;
            string[] CWRArr = new string[fieldCount];

            using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=1234;Database=EmployeeEval;"))
            {
                connection.Open();
                query = $@"SELECT {fields}, ""ReportID"", ""PAValidation"" FROM ""{empType}Form"" INNER JOIN ""EmployeePerformance"" ON ""{empType}Form"".""FormID"" = ""EmployeePerformance"".""FormID"" INNER JOIN ""StatusReport"" ON ""EmployeePerformance"".""EmpID"" = ""StatusReport"".""EmpID"" WHERE ""{empType}FormID"" = @empFormID";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue($"@empFormID", empFormID);

                NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    for (int i = 0; i < fieldCount; i++)
                    {
                        CWRArr[i] = reader.GetString(i);
                    }
                    //Session["ReportID"] = reader.GetString(fieldCount);
                    PAVal = reader.GetString(fieldCount+1);
                }
                reader.Close();
                connection.Close();
            }

            for (int i = 0; i < CWRArr.Length; i++)
            {
                double total = 100;
                if (empType == "Faculty" && i == 0)
                    total = 200;
                if (empType == "Officer" && (i == 0 || i == 1))
                {
                    if (ValidateOfficer(CWRArr[i]) == false)
                        secNum.Add(i + 1);
                }
                else if (GetTotalWeight(CWRArr[i]) != total)
                {
                    secNum.Add(i + 1);
                }
            }


            if (secNum.Count == 0)
                alert = "";
            else if (secNum.Count == 1)
                alert = $"Section {secNum[0]} is incomplete.";
            else if (secNum.Count == 2)
                alert = $"Section {secNum[0]} and {secNum[1]} are incomplete.";
            else
            {
                alert = "Section ";
                for (int i = 0; i < secNum.Count - 1; i++)
                {
                    alert += $"{secNum[i]}, ";
                }
                alert += $"and {secNum[secNum.Count - 1]} are incomplete";
            }

            PAValDone = PAVal != "0" && PAVal != null;

            return new string[]
            {
                alert,
                PAValDone.ToString()
            };
        }

        protected static bool ValidateOfficer(string CWR) 
        {
            string[] CWRArr = new string[10], CWRArr2, initiative, weightArr, note;
            string[][] objective;
            int[] scopes;


            if (CWR != "0")
            {
                CWRArr = CWR.Split(';');
                CWRArr2 = new string[10];
                initiative = new string[CWRArr2.Length];
                objective = new string[CWRArr2.Length][];
                weightArr = new string[CWRArr2.Length];

                for (int i = 0; i < CWRArr.Length; i++)
                {
                    CWRArr2 = CWRArr[i].Split('|');
                    initiative[i] = CWRArr2[1];
                    objective[i] = CWRArr2[2].Split('_');
                    weightArr[i] = CWRArr2[3];
                }
                bool wordInputDone = false, weightDone = false;
                double totalWieght = 0;

                for (int i = 0; i < CWRArr.Length; i++)
                {
                    try
                    {
                        for (int k = 0; k < objective[i].Length; k++)
                        {
                            if (initiative[i] == "" || objective[i][k] == "" || double.Parse(weightArr[i]) == 0)
                            {
                                wordInputDone = false;
                                weightDone = false;
                            }

                            else
                            {
                                wordInputDone = true;
                                weightDone = true;
                            }
                                
                        }
                        totalWieght += double.Parse(weightArr[i]);

                    }
                    catch (Exception)
                    {
                        wordInputDone = false;
                        weightDone = true;
                        totalWieght += 0;
                    }
                }
                if (wordInputDone == true && weightDone == true)
                    return true;
            }
            return false;
        }

        protected static double GetTotalWeight(string CWR)
        {
            if (CWR != "0")
            {
                string[] splitCWR = CWR.Split(';');
                double weight = 0;
                foreach (string item in splitCWR)
                {
                    string[] textArr2 = item.Split(',');
                    weight += double.Parse(textArr2[0]);
                }
                return weight;
            }
            return 0;
        }

        protected static double GetTotalWeight(string CWR, string officer)
        {
            if (CWR != "0")
            {
                string[] splitCWR = CWR.Split(';');
                double weight = 0;
                foreach (string item in splitCWR)
                {
                    string[] textArr2 = item.Split('|');
                    weight += double.Parse(textArr2[3]);
                }
                return weight;
            }
            return 0;
        }

        public static void UpdateStatRep(string process, string reportID, string formType)
        {
            string field;

            if (process == "Validation")
                field = $"{formType}Validation";
            else
                field = $"{formType}Submission";

            using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=1234;Database=EmployeeEval;"))
            {
                connection.Open();
                string query = $@"UPDATE ""StatusReport"" SET ""{field}"" = @Time WHERE ""ReportID"" = @ReportID";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@Time", DateTime.Now.ToString());
                command.Parameters.AddWithValue("@ReportID", reportID);
                command.ExecuteNonQuery();
            }
        }

        public static string[] InitializeEvaluationSection(string accType, string empFormID, string empID, string empType, string field)
        {
            string CWR = "", query, PEVal = "";
            string[] sessionInfo;

            if (accType == "Supervisor")
            {
                sessionInfo = SupInitEvalSec(empFormID, empType, field);
            }
            else
            {
                sessionInfo = EmpInitEvalSec(empType, empID, field);
            }
            return sessionInfo;
        }

        public static string[] SupInitEvalSec(string empFormID, string empType, string field) 
        {
            string query, CWR = "", reportID = "", PEVal = "";
            using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=1234;Database=EmployeeEval;"))
            {
                connection.Open();

                query = $@"SELECT ""{field}"", ""ReportID"", ""PEValidation"" FROM ""{empType}Form"" INNER JOIN ""EmployeePerformance"" ON ""{empType}Form"".""FormID"" = ""EmployeePerformance"".""FormID"" INNER JOIN ""StatusReport"" ON ""EmployeePerformance"".""EmpID"" = ""StatusReport"".""EmpID"" WHERE ""{empType}FormID"" = @empFormID";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@empFormID", empFormID);
                NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    CWR = reader.GetString(0);
                    reportID = reader.GetString(1);
                    PEVal = reader.GetString(2);
                }
                reader.Close();

                connection.Close();
            }

            return new string[]
            {
                CWR, reportID, PEVal
            };
        }

        public static string[] EmpInitEvalSec(string empType, string empID, string field)
        {
            string query, CWR = "", PEVal = "", formID = "", empFormID = "", reportID = "", rateeID;

            using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=1234;Database=EmployeeEval;"))
            {
                connection.Open();

                query = $@"SELECT ""EmployeePerformance"".""FormID"", ""{empType}FormID"", ""{field}"", ""ReportID"", ""PEValidation"" FROM ""{empType}Form"" INNER JOIN ""EmployeePerformance"" ON ""{empType}Form"".""FormID"" = ""EmployeePerformance"".""FormID"" INNER JOIN ""StatusReport"" ON ""EmployeePerformance"".""EmpID"" = ""StatusReport"".""EmpID"" WHERE ""EmployeePerformance"".""EmpID"" = @EmpID";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@EmpID", empID);

                NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    formID = reader.GetString(0);
                    empFormID= reader.GetString(1);
                    CWR = reader.GetString(2);
                    reportID = reader.GetString(3);
                    PEVal = reader.GetString(4);
                }
                reader.Close();

                connection.Close();
            }
            rateeID = empID;

            bool PEValDone = PEVal != "0" && PEVal != null;

            return new string[]
            {
                formID, empFormID, reportID, rateeID, CWR, PEValDone.ToString()
            };
        }

        public static void SetPageInfo(ref TextBox[] ratingArr, ref Label[] weightArr, ref Label[] scoreArr, string CWR) 
        {
            if (CWR != "0")
            {
                string[] CWRArr = CWR.Split(';');
                for (int i = 0; i < CWRArr.Length; i++)
                {
                    string[] CWRValues = CWRArr[i].Split(',');
                    weightArr[i].Text = CWRValues[0];
                    ratingArr[i].Text = CWRValues[1];
                    scoreArr[i].Text = (double.Parse(CWRValues[0]) * double.Parse(CWRValues[1]) * 0.2).ToString("0.00");
                }
            }
        }
        public static void ComputeTotalScore(Label[] scoreArr, ref Label total)
        {
            double totalScore = 0;
            foreach (Label score in scoreArr)
            {
                try
                {
                    totalScore += double.Parse(score.Text);
                }
                catch (Exception)
                {

                    totalScore += 0;
                }
                
            }
            total.Text = (totalScore).ToString("0.00");
        }

        public static void AdjustRating(ref TextBox[] ratingArr, ref Label[] weightArr, ref Label[] scoreArr, TextBox rating, ref Label total) 
        {
            for (int i = 0; i < ratingArr.Length; i++)
            {
                if (rating.ID == ratingArr[i].ID)
                {
                    if (double.Parse(ratingArr[i].Text) > 5)
                        ratingArr[i].Text = "5";
                    else if (double.Parse(ratingArr[i].Text) < 0)
                        ratingArr[i].Text = "0";
                    scoreArr[i].Text = (double.Parse(ratingArr[i].Text) * double.Parse(weightArr[i].Text) * 0.2).ToString("0.00");
                    ComputeTotalScore(scoreArr, ref total);
                    return;
                }
            }
        }

        public static void InitializeComments(string empFormID, string empType, ref TextBox[] commentArr) 
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=1234;Database=EmployeeEval;"))
            {
                connection.Open();
                string query = $@"SELECT ""Strength"", ""Improvement"", ""Development"", ""Acknowledgement"", ""ReportID"" FROM ""{empType}Form"" INNER JOIN ""EmployeePerformance"" ON ""{empType}Form"".""FormID"" = ""EmployeePerformance"".""FormID"" INNER JOIN ""StatusReport"" ON ""EmployeePerformance"".""EmpID"" = ""StatusReport"".""EmpID"" WHERE ""{empType}FormID"" = @empFormID";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@empFormID", empFormID);

                NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.GetString(0) != "0")
                        commentArr[0].Text = reader.GetString(0);
                    if (reader.GetString(1) != "0")
                        commentArr[1].Text = reader.GetString(1);
                    if (reader.GetString(2) != "0")
                        commentArr[2].Text = reader.GetString(2);
                    if (reader.GetString(3) != "0")
                        commentArr[3].Text = reader.GetString(3);
                }
                reader.Close();
                connection.Close();
            }
        }

        public static string[] InitializeEvaluationOverall(string empFormID, string empType, string fields, string process)
        {
            string query, alert, PEVal = "";
            bool PEValDone;
            List<int> secNum = new List<int>();

            int fieldCount = fields.Split(',').Length;
            string[] CWRArr = new string[fieldCount];
            string[] commentArr = new string[4];

            using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=1234;Database=EmployeeEval;"))
            {
                connection.Open();

                query = $@"SELECT {fields}, ""Strength"", ""Improvement"", ""Development"", ""Acknowledgement"", ""ReportID"", ""PEValidation"" FROM ""{empType}Form"" INNER JOIN ""EmployeePerformance"" ON ""{empType}Form"".""FormID"" = ""EmployeePerformance"".""FormID"" INNER JOIN ""StatusReport"" ON ""EmployeePerformance"".""EmpID"" = ""StatusReport"".""EmpID"" WHERE ""{empType}FormID"" = @empFormID";

                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue($"@empFormID", empFormID);

                NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    for (int i = 0; i < fieldCount; i++)
                    {
                        CWRArr[i] = reader.GetString(i);
                    }
                    commentArr = new string[] 
                    { 
                        reader.GetString(fieldCount),
                        reader.GetString(fieldCount+1),
                        reader.GetString(fieldCount+2),
                        reader.GetString(fieldCount+3)
                    };
                    //Session["ReportID"] = reader.GetString(fieldCount);
                    PEVal = reader.GetString(fieldCount + 5);
                }
                reader.Close();
                connection.Close();
            }

            for (int i = 0; i < CWRArr.Length; i++)
            {
                if (empType == "Officer" && i == 0)
                { }
                else if (empType == "Officer" && i == 1)
                { }
                else if (CheckSection(CWRArr[i]) == false)
                {
                    secNum.Add(i + 1);
                }
            }
            
            if (process == "Validation")
                if (CheckComments(commentArr) == false)
                    secNum.Add(fieldCount + 1);


            if (secNum.Count == 0)
                alert = "";
            else if (secNum.Count == 1)
                alert = $"Section {secNum[0]} is incomplete.";
            else if (secNum.Count == 2)
                alert = $"Section {secNum[0]} and {secNum[1]} are incomplete.";
            else
            {
                alert = "Section ";
                for (int i = 0; i < secNum.Count - 1; i++)
                {
                    alert += $"{secNum[i]}, ";
                }
                alert += $"and {secNum[secNum.Count-1]} are incomplete";
            }

            PEValDone = PEVal != "0" && PEVal != null;

            string test = "";

            foreach (var item in CWRArr)
            {
                test += $"P{item}";
            }


            return new string[]
            {
                alert,
                PEValDone.ToString(), secNum.Count.ToString(),test
            };
        }

        protected static bool CheckComments(string[] commentArr)
        {
            foreach (string comment in commentArr)
            {
                if (comment == "")
                    return false;
            }
            return true;
        }

        protected static bool CheckSection(string CWR)
        {
            string[] CWRArr = CWR.Split(';');
            string[] CWRArr2;

            for (int i = 0; i < CWRArr.Length; i++)
            {
                CWRArr2 = CWRArr[i].Split(',');
                if (CWRArr2[1] == "0")
                    return false;
            }
            return true;
        }
    }
}