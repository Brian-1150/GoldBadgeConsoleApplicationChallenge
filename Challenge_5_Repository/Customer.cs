using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_5_Repository {

    abstract public class Person {
        public string FirstName { get; set; }= ""; //setting these equal to prevent null exception when searching
        public string LastName { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public string Email { get; set; } = "";

        public Person() { }// I could remove empty constructor  to require all info to also prevent null exception
        public Person(string firstName, string lastName, string phoneNumber, string email) {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }
   public enum CustomerStatus {
        Current = 1,
        Past,
        Prospective

    }

    public class Customer : Person {
        public CustomerStatus StatusOfCustomer { get; set; }
        public Customer() { }
        public Customer(CustomerStatus statusOfCustomer, string firstName, string lastName, string phoneNumber, string email)
            : base(firstName, lastName, phoneNumber, email) {
            StatusOfCustomer = statusOfCustomer;
        }

    }
}


    

