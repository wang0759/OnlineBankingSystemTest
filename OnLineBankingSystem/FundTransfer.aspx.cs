using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static test1.Enums;

namespace test1
{
    public partial class FundTransfer : Page
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
            //1.make everything empty
            lblResult.Text = "";
            lblChecking.Text = "";
            lblSaving.Text = "";
            txtDepositAmount.Text = "";
            
            //2. check if selected value is not "-1" and change value accordingly
            if (drpCustomers.SelectedValue != "-1")
            {
                //1) get customer list
                customers = (List<Customer>)Session["customers"];
                if (customers == null) customers = new List<Customer>();

                //2) loop through the list
                foreach (Customer customer in customers)
                {
                    //3) check if the customer.Id is the selected value
                    if (drpCustomers.SelectedValue == customer.Id.ToString())
                    {
                        Session["selected_customer"] = customer;
                        updateMaximumAmount();

                        //4) display accounts balances
                        lblChecking.Text = string.Format("${0}", customer.Checking.Balance);// checking account balance to string
                        lblSaving.Text = string.Format("${0}", customer.Saving.Balance); ;//saving account balance to string
                        lblResult.Text = "";
                        break;
                    }
                }
            }
        }

       

       

        protected void rblDepositTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateMaximumAmount();
        }


        protected void updateMaximumAmount()
        {
            Customer customer = Session["selected_customer"] as Customer;

            if (customer == null) return;

            if (rblDepositTo.SelectedValue == "checking")
            {
                amountValidator.MaximumValue = customer.Checking.Balance.ToString();
            }
            else if (rblDepositTo.SelectedValue == "saving")
            {
                amountValidator.MaximumValue = customer.Saving.Balance.ToString();
            }
        }
        protected void txtDepositAmount_TextChanged(object sender, EventArgs e)
        {
            lblResult.Text = "";
        } 
        
        protected void btnTransfer_Click(object sender, EventArgs e)
        {        
            //1.create a selected_customer session       
            Customer selected_customer = Session["selected_customer"] as Customer;
            if (selected_customer == null) return;
            double amount = double.Parse(txtDepositAmount.Text); //transfer amount
            Transaction transactionIn = new Transaction(amount, Enums.TransactionType.TRANSFER_IN);
            Transaction transactionOut = new Transaction(amount, Enums.TransactionType.TRANSFER_OUT);
            
            //2.get transaction result
            TransactionResult result;
            if (rblDepositTo.SelectedValue == "checking")
            {
                result = selected_customer.Checking.Withdraw(transactionOut);
                if (result != TransactionResult.INSUFFICIENT_FUND 
                    && result != TransactionResult.EXCEED_MAX_WITHDRAW_AMOUNT)
                {
                    result = selected_customer.Saving.Deposit(transactionIn);
                }
            }
            else
            {
                result = selected_customer.Saving.Withdraw(transactionOut);
                if (result != TransactionResult.INSUFFICIENT_FUND)
                {
                    result = selected_customer.Checking.Deposit(transactionIn);
                }
            }
            Session["selected_customer"] = selected_customer;

            //3. display accounts balances
            lblChecking.Text = string.Format("${0}", selected_customer.Checking.Balance);// checking account balance to string
            lblSaving.Text = string.Format("${0}", selected_customer.Saving.Balance);//saving account balance to string
            amountValidator.Validate();
            if (amountValidator.IsValid)
            {
                lblResult.Text = result.ToString();
            }
            else
            {
                lblResult.Text = "screw me";
            }

            updateMaximumAmount();
            txtDepositAmount.Text = "";


            //4.create a customers session, save the new values to the customers list
            customers = (List<Customer>)Session["customers"];
            if (customers == null) customers = new List<Customer>();
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
        }
    }
}