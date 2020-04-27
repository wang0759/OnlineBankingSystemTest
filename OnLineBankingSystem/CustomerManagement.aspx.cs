using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace test1
{
    public partial class CustomerManagement : System.Web.UI.Page
    {
        List<Customer> customers=new List<Customer>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                displayList();
            }
        }

        protected void btnAddCustomer_Click(object sender, EventArgs e)
        {
            customers = (List<Customer>)Session["customers"];
            if (customers == null) customers = new List<Customer>();

            // new customer
            Customer customer = new Customer(txtName.Text);

            // create checking account 
            CheckingAccount checkingAccount = new CheckingAccount(customer);

            // new transaction
            double amount = double.Parse(initialDeposit.Text);//initial deposit
            Transaction transaction = new Transaction(amount, Enums.TransactionType.DEPOSIT);
            
            //add initial deposit to checkingAccount
            checkingAccount.Deposit(transaction);
            
            // create saving account
            SavingAccount savingAccount = new SavingAccount(customer);

            // add the accounts to the customer
            customer.Checking = checkingAccount;
            customer.Saving = savingAccount;
            // add to the list
            customers.Add(customer);
            // save to the session
            Session["customers"] = customers;

            displayList();
        }

        private void displayList()
        {
            customers = (List<Customer>)Session["customers"];
            if (customers == null) customers = new List<Customer>();

            tblCustomers.Rows.Clear();
            TableHeaderRow headerRow = new TableHeaderRow();
            TableHeaderCell headerCell = new TableHeaderCell();
            headerCell.Text = "Name";
            headerRow.Cells.Add(headerCell);

            headerCell = new TableHeaderCell();
            headerCell.Text = "Checking Account Balance";
            headerRow.Cells.Add(headerCell);

            headerCell = new TableHeaderCell();
            headerCell.Text = "Saving Account Balance";
            headerRow.Cells.Add(headerCell);

            headerCell = new TableHeaderCell();
            headerCell.Text = "Status";
            headerRow.Cells.Add(headerCell);

            tblCustomers.Rows.Add(headerRow);

            if (customers.Count > 0)
            {
                foreach (Customer customer in customers)
                {
                    TableRow row = new TableRow();
                    TableCell cell = new TableCell();
                    cell.Text = customer.Name;
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = customer.Checking.Balance.ToString();
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = customer.Saving.Balance.ToString();
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = customer.Status.ToString();
                    row.Cells.Add(cell);

                    tblCustomers.Rows.Add(row);
                }
            }
            else
            {
                TableRow row = new TableRow();
                TableCell cell = new TableCell();
                cell.Text = "No customer in the system yet!";
                cell.ForeColor = Color.Red;
                cell.ColumnSpan = 4;
                //cell.XXX = XXX.
                cell.HorizontalAlign = HorizontalAlign.Center;
                row.Cells.Add(cell);
                tblCustomers.Rows.Add(row);
            }
        }
    }
}