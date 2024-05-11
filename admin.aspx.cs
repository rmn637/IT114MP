using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            ((Child)Page.Master).optadminclass = "active";
            initialize();
        }

        protected void initialize()
        {
            try
            {
                string query = @"SELECT ""EmployeeAccount"".""EmpUser"" AS ""Username""," +
                    @" ""EmployeeAccount"".""EmpID"" AS ""Employee Name""," +
                    @" ""EmployeeAccount"".""Status"" AS ""Account Status"" " +
                    @"FROM ""EmployeeAccount"" ORDER BY ""Employee Name"" ASC;";
                using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=1234;Database=EmployeeEval;"))
                {
                    connection.Open();
                    NpgsqlCommand command = new NpgsqlCommand(query, connection);
                    NpgsqlDataReader reader = command.ExecuteReader();

                    TableHeaderRow headerRow = new TableHeaderRow();
                    for (int i = 0; i <= reader.FieldCount; i++)
                    {
                        if (i == reader.FieldCount)
                        {
                            TableHeaderCell headerCellLast = new TableHeaderCell();
                            headerCellLast.Text = "Enable?";
                            headerCellLast.CssClass = "headerCellClass";
                            headerRow.Cells.Add(headerCellLast);
                            break;
                        }
                        TableHeaderCell headerCell = new TableHeaderCell();
                        headerCell.Text = reader.GetName(i);
                        headerCell.CssClass = "headerCellClass";
                        headerRow.Cells.Add(headerCell);
                    }
                    
                    reportTable.Rows.Add(headerRow);

                    while (reader.Read())
                    {
                        TableRow dataRow = new TableRow();
                        int count = 0;
                        bool check = true;
                        for (int i = 0; i <= reader.FieldCount; i++)
                        {
                            if (reader[2].ToString() == "Inactive")
                            {
                                check = false;
                            }
                            if (i == reader.FieldCount)
                            {
                                addButton(reader[1].ToString(), dataRow, check);
                                break;
                            }
                            TableCell cell = new TableCell();
                            cell.Text = reader[i].ToString();
                            dataRow.Cells.Add(cell);

                        }

                        reportTable.Rows.Add(dataRow);
                    }
                    reader.Close();

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<scipt>alert('{ex.Message}')</script>");
            }
        }

        protected void addButton(string empNo, TableRow dataRow, bool check)
        {
            TableCell celllast = new TableCell { };
            CheckBox slider = new CheckBox { AutoPostBack = true, CssClass = "form-check-input", ID = $"flexSwitchCheckDefault" + empNo, Checked = check };
            Label toggle = new Label { AssociatedControlID = $"flexSwitchCheckDefault" + empNo, CssClass = "form-check-label"};
            slider.CheckedChanged += ChangeState;
            celllast.Controls.Add(slider);
            celllast.Controls.Add(toggle);
            dataRow.Cells.Add(celllast);
        }

        protected void ChangeState(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            string empID = checkBox.ID.Substring(22);
            string state = "Active";
            if (checkBox.Checked == false)
                state = "Inactive";
            try
            {
                string query = @"UPDATE ""EmployeeAccount"" " +
                    $@"SET ""Status"" = '{state}' WHERE ""EmpID"" = @EmpID;";
                using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=1234;Database=EmployeeEval;"))
                {
                    connection.Open();
                    NpgsqlCommand command = new NpgsqlCommand(query, connection);
                    command.Parameters.AddWithValue("@EmpID", empID);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                foreach(TableRow Row in reportTable.Rows)
                {
                    Row.Cells.Clear();
                }
                while (reportTable.Rows.Count > 1) reportTable.Rows.RemoveAt(1);
                initialize();
            }
            catch (Exception ex)
            {
                Response.Write($"<scipt>alert('{empID}')</script>");
            }
        }
        protected void btnEnable_Click(object sender, EventArgs e)
        {
            try
            {
                string query = @"UPDATE ""EmployeeAccount"" " +
                    @"SET ""Status"" = 'Active';";
                using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=1234;Database=EmployeeEval;"))
                {
                    connection.Open();
                    NpgsqlCommand command = new NpgsqlCommand(query, connection);
                    command.ExecuteNonQuery();

                    connection.Close();
                }
                foreach (TableRow Row in reportTable.Rows)
                {
                    Row.Cells.Clear();
                }
                while (reportTable.Rows.Count > 1) reportTable.Rows.RemoveAt(1);
                initialize();
            }
            catch (Exception ex)
            {
                Response.Write($"<scipt>alert('{ex.Message}')</script>");
            }
        }

        protected void btnDisable_Click(object sender, EventArgs e)
        {
            try
            {
                string empID = Session["EmpID"].ToString();
                string query = @"UPDATE ""EmployeeAccount"" " +
                    @"SET ""Status"" = 'Inactive' WHERE ""EmpID"" != @EmpID;";
                using (NpgsqlConnection connection = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=1234;Database=EmployeeEval;"))
                {
                    connection.Open();
                    NpgsqlCommand command = new NpgsqlCommand(query, connection);
                    command.Parameters.AddWithValue("@EmpID", empID);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                foreach (TableRow Row in reportTable.Rows)
                {
                    Row.Cells.Clear();
                }
                while (reportTable.Rows.Count > 1) reportTable.Rows.RemoveAt(1);
                initialize();
            }
            catch (Exception ex)
            {
                Response.Write($"<scipt>alert('{ex.Message}')</script>");
            }
        }
    }
}