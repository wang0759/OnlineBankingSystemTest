using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static test1.Enums;

namespace test1
{
    public partial class Deposit : System.Web.UI.Page
    {
        List<Customer> customers;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
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
            lblChecking.Text = "";
            lblSaving.Text = "";
            txtDepositAmount.Text = "";
            // check if selected value is not "-1"
            if (drpCustomers.SelectedValue !="-1" ) {
                // get customer list
                customers = (List<Customer>)Session["customers"];
                if (customers == null) customers = new List<Customer>();

                // loop through the list
                foreach (Customer customer in customers)
                { 
                    // check if the customer.Id is the selected value
                    if (drpCustomers.SelectedValue == customer.Id.ToString() )
                    {
                        Session["selected_customer"] = customer;//add customer to Session

                        // display accounts balances
                        lblChecking.Text = string.Format("${0}", customer.Checking.Balance);// checking account balance to string
                        lblSaving.Text = string.Format("${0}", customer.Saving.Balance);//saving account balance to string

                        break;
                    }
                }
            }
        }

        protected void BtnDeposit_Click(object sender, EventArgs e)
        {
            //1.create a selected_customer session initialize the first deposit amount
            Customer selected_customer = Session["selected_customer"] as Customer;
            if (selected_customer == null) return;
            double amount = double.Parse(txtDepositAmount.Text);//initial deposit
            Transaction transaction = new Transaction(amount, Enums.TransactionType.DEPOSIT);
             TransactionResult result = TransactionResult.EXCEED_MAX_WITHDRAW_AMOUNT;

            //2.depoisit to checking or saving account
            if (rblDepositTo.SelectedValue == "checking")
            {
                result = selected_customer.Checking.Deposit(transaction);
            }
            else if (rblDepositTo.SelectedValue == "saving")
            {
                result = selected_customer.Saving.Deposit(transaction);
            }
            Session["selected_customer"] = selected_customer;//add to session


            // 3.display accounts balances
            lblChecking.Text = string.Format("${0}", selected_customer.Checking.Balance);// checking account balance to string
            lblSaving.Text = string.Format("${0}", selected_customer.Saving.Balance);//saving account balance to string

            lblResult.Text = result.ToString();
            txtDepositAmount.Text = "";

            //4. create customers session to hold all customers
            customers = (List<Customer>)Session["customers"];
            if (customers == null) customers = new List<Customer>();            
            for (int i = 0; i < customers.Count; i++)// loop through the customers list
            {            
                if (selected_customer.Id == customers[i].Id) // check if the customer is the selected_customer
                {
                    // save the new values to the customers list
                    customers[i] = selected_customer;

                    break;
                }
            }

            Session["customers"] = customers;
        }
    }
}