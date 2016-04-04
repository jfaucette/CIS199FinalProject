using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavoniFaucette_FinalProject
{
    class Customer
    {
        private string SSN;
        private string customerName;
        private string customerAddress;
        private string customerCity;
        private string customerState;
        private string customerZIP;
        private string customerPhoneNumber;
        private string customerEmail;

        public Customer(string aSSN, string aCustomerName,string aCustomerAddress, string aCustomerCity, 
            string aCustomerState, string aCustomerZIP, string aCustomerPhoneNumber, string aCustomerEmail)
        {
            SSN = aSSN;
            customerName = aCustomerName;
            customerAddress = aCustomerAddress;
            customerCity = aCustomerCity;
            customerState = aCustomerState;
            customerZIP = aCustomerZIP;
            customerPhoneNumber = aCustomerPhoneNumber;
            customerEmail = aCustomerEmail;
        }

        public string SSNumber
        {
            set { SSN = value; }
            get { return SSN; }
        }

        public string CustomerName
        {
            set { customerName = value; }
            get { return customerName; }
        }

        public string CustomerAddress
        {
            set { customerAddress = value; }
            get { return customerAddress; }
        }

        public string CustomerCity
        {
            set { customerCity = value; }
            get { return customerCity; }
        }

        public string CustomerState
        {
            set { customerState = value; }
            get { return customerState; }
        }

        public string CustomerZIP
        {
            set { customerZIP = value; }
            get { return customerZIP; }
        }

        public string CustomerPhoneNumber
        {
            set { customerPhoneNumber = value; }
            get { return customerPhoneNumber;}
        }

        public string CustomerEmail
        {
            set { customerEmail = value; }
            get { return customerEmail; }
        }
    }
}
