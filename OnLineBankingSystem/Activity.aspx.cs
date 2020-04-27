using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace test1
{
    public partial class Activity : System.Web.UI.Page
    {
        List<Customer> customers;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                customers = (List<Customer>)Session["customers"];
                if (customers == null) customers = new List<Customer>();

                drpCustomers.Items.Clear();
                drpCustomers.Items.Add(new ListItem("Select...", "-1"));
                foreach (Customer customer in customers)
                {
                    drpCustomers.Items.Add(new ListItem(customer.Name, customer.Id + ""));
                }
            }
        }

        protected void drpCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            customers = (List<Customer>)Session["customers"];
            if (customers == null || drpCustomers.SelectedValue == "-1") return;
            
            foreach (Customer customer in customers)
            {
                if(drpCustomers.SelectedValue == customer.Id.ToString())
                {
                    displayList(tblCheckingActivity, customer.Checking);
                    displayList(tblSavingActivity, customer.Saving);
                }
            }
        }

        private void displayList(Table table, Account account)
        {
            List<Transaction> transactions = account.TransactionHistory;

            table.Rows.Clear();
            TableHeaderRow headerRow = new TableHeaderRow();
            TableHeaderCell headerCell = new TableHeaderCell();
            headerCell.Text = "Date";
            headerRow.Cells.Add(headerCell);

            headerCell = new TableHeaderCell();
            headerCell.Text = "Amount";
            headerRow.Cells.Add(headerCell);

            headerCell = new TableHeaderCell();
            headerCell.Text = "Transaction Type";
            headerRow.Cells.Add(headerCell);

            table.Rows.Add(headerRow);

            if (transactions.Count > 0)
            {
                foreach (Transaction transaction in transactions)
                {
                    TableRow row = new TableRow();
                    TableCell cell = new TableCell();
                    cell.Text = transaction.TransactionDate.ToString();
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = transaction.Amount.ToString();
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = transaction.Type.ToString();
                    row.Cells.Add(cell);


                    table.Rows.Add(row);
                }
            }
            else
            {
                TableRow row = new TableRow();
                TableCell cell = new TableCell();
                cell.Text = "No activity in the system yet";
                cell.ForeColor = Color.Red;
                cell.ColumnSpan = 3;
                row.Cells.Add(cell);
                table.Rows.Add(row);
            }
        }
    }
}