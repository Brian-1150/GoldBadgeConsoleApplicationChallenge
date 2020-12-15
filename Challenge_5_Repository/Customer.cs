using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_5_Repository {
    public class Customer {

        abstract class Person {                                      //this is called the base class
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string PhoneNumber { get; set; }
            public string Email { get; set; }

            public Person() { }
            public Person(string firstName, string lastName, string phoneNumber, string email) {
                FirstName = firstName;
                LastName = lastName;
                PhoneNumber = phoneNumber;
                Email = email;
            }
        }
        class Customer : Person {
            public bool IsPremium { get; set; }

            public Customer() { }
            public Customer(bool isPremium, string firstName, string lastName, string phoneNumber, string email)
                : base(firstName, lastName, phoneNumber, email) {
                IsPremium = isPremium;
            }

        }


    

