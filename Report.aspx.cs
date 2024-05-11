using Npgsql;
using System;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((Child)Page.Master).opt6class = "active";
            try
            {
                string query = @"SELECT ""EmpID"" AS ""EmployeeID""," +
                    @" ""EmpName"" AS ""Employee Name""," +
                    @" ""SupID"" AS ""SupervisorID"", " +
                    @" ""PASubmission"" AS ""Agreement Submission""," +
                    @" ""PAValidation"" AS ""Agreement Validation""," +
                    @" ""PESubmission"" AS ""Evaluation Submission""," +
                    @" ""PEValidation"" AS ""Evaluation Validation""" +
                    "FROM GetSubordinates(@EmpID)" +
                    @"ORDER BY ""PESubmission"" DESC , ""PEValidation"" DESC, ""PAValidation"" DESC, ""PASubmission"" DESC;";
                string empID = Session["EmpID"].ToString(); ;
                using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=1234;Database=EmployeeEval;"))
                {
                    connection.Open();
                    NpgsqlCommand command = new NpgsqlCommand(query, connection);
                    command.Parameters.AddWithValue("@EmpID", empID);
                    NpgsqlDataReader reader = command.ExecuteReader();

                    TableHeaderRow headerRow = new TableHeaderRow();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        TableHeaderCell headerCell = new TableHeaderCell();
                        headerCell.Text = reader.GetName(i);
                        headerCell.CssClass = "headerCellClass";
                        headerRow.Cells.Add(headerCell);
                    }
                    reportTable.Rows.Add(headerRow);

                    while (reader.Read())
                    {
                        TableRow dataRow = new TableRow();

                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            TableCell cell = new TableCell();
                            if (reader[i].ToString() == "0")
                            {
                                cell.Text = "-";
                                dataRow.Cells.Add(cell);
                            }
                            else
                            {
                                cell.Text = reader[i].ToString();
                                dataRow.Cells.Add(cell);
                            }
                        }

                        reportTable.Rows.Add(dataRow);
                    }
                    reader.Close();

                    connection.Close();
                }
            }
            catch (Exception ex)
            {

            }
            //StringBuilder Table = new StringBuilder();

            //Table.Append("<table border=1><tr>");
            //Table.Append("<th>Employee ID</th><th>Name</th><th>Supervisor ID</th><th>Agreement Submission</th><th>Agreement Validation</th><th>Evaluation Submission</th><th>Evaluation Validation</th>");

            //Table.Append("</table>");

            //PlaceHolder1.Controls.Add(new Literal { Text = Table.ToString() });
        }
    }
}