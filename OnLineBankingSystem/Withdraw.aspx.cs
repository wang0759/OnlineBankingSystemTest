using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static test1.Enums; 

namespace test1
{
    public partial class Withdraw : Page
    {
        List<Customer> customers;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)//not postback. initial load state
            {
                customers = Session["customers"] as List<Customer>;
                if (customers == null) customers = new List<Customer>();

                drpCustomers.Items.Clear();
                drpCustomers.Items.Add(new ListItem("Select...", "-1"));
                foreach (Customer customer in customers)
                {
                    drpCustomers.Items.Add(new ListItem(customer.Name, customer.Id + ""));//customer.Id.toString();
                }
            }
        }

        protected void drpCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblChecking.Text = "";
            lblSaving.Text = "";
            txtWithdrawAmount.Text = "";
            // check if selected value is not "-1"
            if (drpCustomers.SelectedValue != "-1")
            {
                // get customer list
                customers = (List<Customer>)Session["customers"];
                if (customers == null) customers = new List<Customer>();

                // loop through the list
                foreach (Customer customer in customers)
                {
                    // check if the customer.Id is the selected value
                    if (drpCustomers.SelectedValue == customer.Id.ToString())
                    {
                        Session["selected_customer"] = customer;

                        // display accounts balances
                        lblChecking.Text = string.Format("${0}", customer.Checking.Balance);// checking account balance to string
                        lblSaving.Text = string.Format("${0}", customer.Saving.Balance);//saving account balance to string

                        updateMaximumAmount();
                        lblResult.Text = "";

                        break;
                    }
                }
            }
        
        }

        protected void btnWithdraw_Click(object sender, EventArgs e)
        {
            Customer selected_customer = Session["selected_customer"] as Customer;

            if (selected_customer == null) return;

            double amount = double.Parse(txtWithdrawAmount.Text);//amount to withdraw
            Transaction transaction = new Transaction(amount, Enums.TransactionType.WITHDRAW);

            TransactionResult result = TransactionResult.INSUFFICIENT_FUND;//?
            //TransactionResult result;
            if (rbtDepositTo.SelectedValue == "checking")
            {
                result = selected_customer.Checking.Withdraw(transaction);
            }
            else if (rbtDepositTo.SelectedValue == "saving")
            {
                result = selected_customer.Saving.Withdraw(transaction);
            }
            Session["selected_customer"] = selected_customer;
            // display accounts balances
            lblChecking.Text = string.Format("${0}", selected_customer.Checking.Balance);// checking account balance to string
            lblSaving.Text = string.Format("${0}", selected_customer.Saving.Balance);//saving account balance to string


            //lblResult.Text = result.ToString();
            updateMaximumAmount();
            customers = (List<Customer>)Session["customers"];
            if (customers == null) customers = new List<Customer>();

            // loop through the list
            for (int i = 0; i < customers.Count; i++)
            {
                // check if the customer is the selected_customer
                if (selected_customer.Id == customers[i].Id)
                {
                    // save the new values to the customers list
                    customers[i] = selected_customer;

                    break;
                }
            }

            Session["customers"] = customers;
            txtWithdrawAmount.Text = "";
        }

        protected void rblDepositTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateMaximumAmount();
        }

        protected void updateMaximumAmount()
        {
            Customer customer = Session["selected_customer"] as Customer;
            //one instance of Customer

            if (customer == null) return;

            if (rbtDepositTo.SelectedValue == "checking")
            {
                amountValidator.MaximumValue = customer.Checking.Balance.ToString();
            }
            //to apply penalty if it's from saving account
            else if (rbtDepositTo.SelectedValue == "saving")
            {
                if (customer.Saving.Balance > SavingAccount.WithdrawPenaltyAmount)
                    amountValidator.MaximumValue = (customer.Saving.Balance - SavingAccount.WithdrawPenaltyAmount).ToString();
                else
                    amountValidator.MaximumValue = "0";
            }
        }
    }
}