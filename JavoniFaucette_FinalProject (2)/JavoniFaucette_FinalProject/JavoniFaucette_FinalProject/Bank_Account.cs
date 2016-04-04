using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavoniFaucette_FinalProject
{
    class Bank_Account : Customer
    {
        private string accountNumber;
        private double accountBalance;
        private DateTime dateAcctOpened;
        private int numberOfChecks;


        public Bank_Account(string aAccountNumber, double aAccountBalance, DateTime aDateAcctOpened, int aNumberOfChecks, 
            string aSSN, string aCustomerName, string aCustomerAddress, string aCustomerCity, string aCustomerState,
            string aCustomerZIP, string aCustomerPhoneNumber, string aCustomerEmail) :
            base(aSSN, aCustomerName, aCustomerAddress, aCustomerCity, aCustomerState, aCustomerZIP, aCustomerPhoneNumber, aCustomerEmail)
        {
            accountNumber = aAccountNumber;
            accountBalance = aAccountBalance;
            dateAcctOpened = aDateAcctOpened;
            numberOfChecks = aNumberOfChecks;

        }

        public string AccountNumber
        {
            set { accountNumber = value; }
            get { return accountNumber; }
        }

        public double AccountBalance
        {
            set { accountBalance = value; }
            get { return accountBalance; }
        }

        public DateTime DateOpened
        {
            set { dateAcctOpened = value; }
            get { return dateAcctOpened; }
        }

        public int NumberOfChecks
        {
            set { numberOfChecks = value; }
            get { return numberOfChecks; }
        }

    }

}