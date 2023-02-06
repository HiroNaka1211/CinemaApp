using System;
using static System.Console;
using System.Collections.Generic;
using System.Text;

namespace Cinema_app
{
    class Customer
    {
        private string firstname;
        private string lastname;
        private string mobile;
        private string payment;
        private int numberofvisit;
        private string fullname;

        public string FirstName
        {
            get { return firstname; }
        }
        public string LastName
        {
            get { return lastname; }
        }
        public string Mobile
        {
            get { return mobile; }
        }
        public string Payment
        {
            get { return payment; }
        }
        public int NumberOfVisit { get; set; }
        public string FullName
        {
            get { return fullname; }
        }

        public Customer(string firstname, string lastname, string mobileNumber, string payment, int numberofvisit) //This constructor was made to initial values. I will set some initial users to do test.
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.mobile = mobileNumber;
            this.payment = payment;
            this.NumberOfVisit = numberofvisit;
            this.fullname = firstname + "," + lastname;
            
        }



        public override string ToString() //This method show the customer information. 
        {
            return (FirstName + " " + LastName + " " + Mobile.ToString() + " " + Payment + " " + NumberOfVisit.ToString() + "\n");
        }
    }
}
