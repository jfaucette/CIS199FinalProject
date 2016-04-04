//Final Project: This project allows the user to create an account, search based on criteria, edit information, and deposit, withdraw, process checks, and interest.
//Author: Javoni Faucette
//Created: April 14, 2014
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JavoniFaucette_FinalProject
{
    public partial class Form1 : Form
    {
        Customer aCustomer; //reference variable for a Customer
        List<Customer> theCustomer; //list to hold references to the Customer
        TextBox[] textBoxes; //list for txtboxes

        public Form1()
        {
            InitializeComponent();
            theCustomer = new List<Customer>(); //instantiate the List
            textBoxes = new TextBox[] { txtSSN, txtName, txtAddress, txtCity, txtState, txtZIP, txtPhone, txtEmail, txtActNumber, txtBalance, txtChecks,txtOpenDate };//txtbox list
        }

        double defaultBalance, accountBalance, deposit, withdrawal, checkCount, checks, checkAmount, newBalance; //field variables


        private void btnAdd_Click(object sender, EventArgs e)
        {
            defaultBalance = 100;//default balance variable to 100

            if (string.IsNullOrWhiteSpace(txtBalance.Text))//Overloaded constructors
            {
                txtBalance.Text = defaultBalance.ToString("c");//set default
            }
            else //Then...
            {
                //invoke 12-parameter constructor
                aCustomer = new Bank_Account(txtActNumber.Text, double.Parse(txtBalance.Text), DateTime.Parse(txtOpenDate.Text), int.Parse(txtChecks.Text),
                        txtSSN.Text, txtName.Text, txtAddress.Text, txtCity.Text, txtState.Text, txtZIP.Text, txtPhone.Text, txtEmail.Text);

                theCustomer.Add(aCustomer); //add the reference to this customer object to the List
                AddAccount(theCustomer, lstCustomerInfo); //populate the ListBox with the customer name of each customer in the List
                AddAccount(theCustomer, lstChange);//add to every list...
                AddAccount(theCustomer, lstManipulate);
                NewEntry(); //prepare the GUI for the next input
            }
        }

        private void AddAccount(List<Customer> aCustomerList, ListBox aListBox)
        {
            aListBox.Items.Clear(); //clear all contents of the ListBox

            //use the loop to display the name of each customer object in the ListBox
            foreach (Customer customers in aCustomerList)
            {
                aListBox.Items.Add(customers.CustomerName);
            }
        }

        private Customer GetAccounts(int index)
        {
            return theCustomer[index]; //return the customer object at index position index of the List
        }

        private void NewEntry()//After the Add button is clicked all of the fields empty
        {
            foreach (TextBox textbox in textBoxes)
            {
                textbox.Clear();//clear textboxes
            }

            tabControl1.SelectedIndex = 0;
            lblChecks.ResetText();
            txtSSN.Focus();
        }

        private void lstCustomerInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstCustomerInfo.SelectedIndex != -1) //When something on the ListBox is selected...
            {
                //display the information of the customer object at the index position of the List that corresponds to the selected index in the ListBox.
                lblSSN.Text = GetAccounts(lstCustomerInfo.SelectedIndex).SSNumber.ToString();
                lblName.Text = GetAccounts(lstCustomerInfo.SelectedIndex).CustomerName.ToString();
                lblAddress.Text = GetAccounts(lstCustomerInfo.SelectedIndex).CustomerAddress.ToString();
                lblCity.Text = GetAccounts(lstCustomerInfo.SelectedIndex).CustomerCity.ToString();
                lblState.Text = GetAccounts(lstCustomerInfo.SelectedIndex).CustomerState.ToString();
                lblZIP.Text = GetAccounts(lstCustomerInfo.SelectedIndex).CustomerZIP.ToString();
                lblPhone.Text = GetAccounts(lstCustomerInfo.SelectedIndex).CustomerPhoneNumber.ToString();
                lblEmail.Text = GetAccounts(lstCustomerInfo.SelectedIndex).CustomerEmail.ToString();

                if (theCustomer.ElementAt(lstCustomerInfo.SelectedIndex) is Bank_Account)//refer to the subclass if input was entered from there.
                {
                    lblActNumber.Text = ((Bank_Account)GetAccounts(lstCustomerInfo.SelectedIndex)).AccountNumber.ToString();
                    lblBalance.Text = ((Bank_Account)GetAccounts(lstCustomerInfo.SelectedIndex)).AccountBalance.ToString("c");
                    lblDate.Text = ((Bank_Account)GetAccounts(lstCustomerInfo.SelectedIndex)).DateOpened.Date.ToShortDateString();
                    lblNumberOfChecks.Text = ((Bank_Account)GetAccounts(lstCustomerInfo.SelectedIndex)).NumberOfChecks.ToString();
                    lblChecks.Text = ((Bank_Account)GetAccounts(lstCustomerInfo.SelectedIndex)).NumberOfChecks.ToString();
                }
            }

        }
        private void ExecuteSearch(int index, string aSearchTerm) //Search method
        {
            switch (index) //index containing each criteria
            {
                case 0:

                    foreach (Customer customer in theCustomer)
                    {
                        if (customer.CustomerZIP == aSearchTerm)//if what was searched for matched the inputted item
                        {
                            lstSearch.Items.Add(customer.CustomerName);//it will show the book title in the listbox
                        }
                    }
                    break;
                case 1:

                    foreach (Customer customer in theCustomer)
                    {
                        if (customer.CustomerCity == aSearchTerm)//if what was searched for matched the inputted item
                        {
                            lstSearch.Items.Add(customer.CustomerName);//it will show the book title in the listbox
                        }
                    }
                    break;
                case 2:

                    foreach (Customer customer in theCustomer)
                    {
                        if (customer.CustomerState == aSearchTerm)//if what was searched for matched the inputted item
                        {
                            lstSearch.Items.Add(customer.CustomerName);//it will show the book title in the listbox
                        }
                    }
                    break;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))//if there is nothing in the Search Bar...
            {
                MessageBox.Show("Please enter something into the search bar.");//Show this in a message box
            }
            else//otherwise
            {
                try
                {
                    ExecuteSearch(cboSearch.SelectedIndex, txtSearch.Text);//execute the search method
                }
                catch
                {
                    MessageBox.Show("Error");
                }

            }
        }

        private void lstSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            accountBalance = ((Bank_Account)GetAccounts(lstSearch.SelectedIndex)).AccountBalance;

            if (lstSearch.SelectedIndex != -1)//When something in the Results ListBox is selected...
            {
                //display the information of the customer object at the index position of the List that corresponds to the selected index in the ListBox.
                lblSearchName.Text = GetAccounts(lstSearch.SelectedIndex).CustomerName;
                lblSearchBalance.Text = ((Bank_Account)GetAccounts(lstSearch.SelectedIndex)).AccountBalance.ToString("c");      
                lblAverage.Text = (accountBalance/lstSearch.Items.Count).ToString("c");  
                
            }
        }

        private void lstChange_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstChange.SelectedIndex != -1) //if something is selected in the listbox
            {
                lblUneditAddress.Text = GetAccounts(lstChange.SelectedIndex).CustomerAddress.ToString(); //show in labels...
                lblUneditNumber.Text = GetAccounts(lstChange.SelectedIndex).CustomerPhoneNumber.ToString();
                lblUneditEmail.Text = GetAccounts(lstChange.SelectedIndex).CustomerEmail.ToString();
            }
        }
        private void btnChange_Click(object sender, EventArgs e)//when change button is selected
        {
            lblNewAddress.Text = txtEditAddress.Text;//add the changed text to the new label
            lblNewEmail.Text = txtEditEmail.Text;
            lblNewNumber.Text = txtEditNumber.Text;

        }

        private void lstManipulate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstManipulate.SelectedIndex != -1)//show these in the labels when a certain customer is selected.
            {
                lblCurrentBalance.Text = ((Bank_Account)GetAccounts(lstManipulate.SelectedIndex)).AccountBalance.ToString("c");
                lblChecks.Text = ((Bank_Account)GetAccounts(lstManipulate.SelectedIndex)).NumberOfChecks.ToString();
            }
        }


        private void btnDeposit_Click_1(object sender, EventArgs e)
        {
         
            deposit = double.Parse(txtDeposit.Text);
            accountBalance = ((Bank_Account)GetAccounts(lstManipulate.SelectedIndex)).AccountBalance;

            if (lstManipulate.SelectedIndex != -1) //assuming something on the ListBox is selected...
            {
                //update the output to reflect the balance.
                newBalance = (accountBalance + deposit);
                lblCurrentBalance.Text = newBalance.ToString("c");
            }

            txtDeposit.Clear(); //clear the TextBpx
        }

        private void btnWithdraw_Click_1(object sender, EventArgs e)
        {

            withdrawal = double.Parse(txtWithdrawal.Text);
            accountBalance = ((Bank_Account)GetAccounts(lstManipulate.SelectedIndex)).AccountBalance;

            if (lstManipulate.SelectedIndex != -1) //assuming something on the ListBox is selected...
            {
                //update the output to reflect the new balance
                newBalance = (newBalance - withdrawal);
                lblCurrentBalance.Text = newBalance.ToString("c");
            }
            if (accountBalance < 100)//if account balance goes under 100...
            {
                MessageBox.Show("Balance is going under $100.00", "Press Yes to proceed and No to cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Error);//display a warning message box to the user
            }
            else
            {
                txtWithdrawal.Focus();//return to text box
            }

            txtWithdrawal.Clear(); //clear the TextBox
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            checks = 1;
            checkAmount = double.Parse(txtProcessCheck.Text);
            checkCount = ((Bank_Account)GetAccounts(lstCustomerInfo.SelectedIndex)).NumberOfChecks;

            if (lstManipulate.SelectedIndex != -1) //assuming something on the ListBox is selected...
            {
                //update the output to reflect the new balance and decrease the number of checks by 1.
                newBalance = (newBalance - checkAmount);
                lblCurrentBalance.Text = newBalance.ToString("c");
                lblChecks.Text = (checkCount - checks).ToString();
            }

            txtProcessCheck.Clear(); //clear the TextBox
        
        }

        const double UNDER_999_RATE = .05;//establishing discount constants
        const double UNDER_9999_RATE = .08;
        const double UNDER_19999_RATE = .17;
        const double OVER_20000_RATE = .24;

        private void btnInterest_Click(object sender, EventArgs e)
        {
            if (newBalance >= 1 && newBalance <= 999)//if the balance is b/w these numbers
            {
                lblCurrentBalance.Text = (newBalance + (newBalance * UNDER_999_RATE)).ToString("c");//apply this discount
            }

            if (newBalance >= 1000 && newBalance <= 9999)//if the balance is b/w these numbers
            {
                lblCurrentBalance.Text = (newBalance + (newBalance * UNDER_9999_RATE)).ToString("c");//apply this discount
            }

            if (newBalance >= 10000 && newBalance <= 19999)//if the balance is b/w these numbers
            {
                lblCurrentBalance.Text = (newBalance + (newBalance * UNDER_19999_RATE)).ToString("c");//apply this discount
            }

            else
                if (newBalance >= 20000)//if the balance is b/w these numbers
                {
                    lblCurrentBalance.Text = (newBalance + (newBalance * OVER_20000_RATE)).ToString("c");//apply this discount
                }
        }

    }
}

             



