using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_5_Repository {
    public class CustomerRepo {
        private List<Customer> _ListOfCustomers = new List<Customer>();
        private Dictionary<string, string> _DictionaryOfEmails = new Dictionary<string, string>();
        //Create
        public void AddToList(Customer newCustomer) {
            _ListOfCustomers.Add(newCustomer);
        }
        public void AddToList(Customer one, Customer two) {
            _ListOfCustomers.Add(one);
            _ListOfCustomers.Add(two);
        }
        public void AddToList(params Customer[] customerArray) { //overload for unlimited objects
            foreach (Customer customer in customerArray) {
                _ListOfCustomers.Add(customer);
            }
        }

        public void AddEmails(KeyValuePair<string, string> email) {
            _DictionaryOfEmails.Add(email.Key, email.Value);
        }
        //Read
        public List<Customer> ListOfCustomers(int x) {
            var tempList = new List<Customer>();
           // foreach (var cust in _ListOfCustomers) does not work outside of switch
           //must be recoded inside each case

                switch (x) {
                    case 1:
                    foreach (var cust in _ListOfCustomers) {
                        if (cust.StatusOfCustomer == CustomerStatus.Current) {
                            tempList.Add(cust);
                        }                      }
                        return tempList;
                       
                    case 2:
                    foreach (var cust in _ListOfCustomers) {
                        if (cust.StatusOfCustomer == CustomerStatus.Past) {
                            tempList.Add(cust);
                        }   }
                        return tempList;
                       
                    case 3:
                    foreach (var cust in _ListOfCustomers) {
                        if (cust.StatusOfCustomer == CustomerStatus.Prospective) {
                            tempList.Add(cust);
                        }
                    }
                        return tempList;
                       
                    case 4:
                        return _ListOfCustomers;
                       
                    default:
                        return null;
                        
                }
            
        } 
         public Dictionary<string, string> EmailDictionary () {
            return _DictionaryOfEmails;
        }
        
        public List<Customer> ListOfCustomers() {
            return _ListOfCustomers;
        }
            //Update
            public void EditCustomer(Customer old, Customer replacement) {
            if (replacement.FirstName != "")
                old.FirstName = replacement.FirstName;
            if (replacement.LastName != "")
                old.LastName = replacement.LastName;
            if (replacement.Email != "")
                old.Email = replacement.Email;
            if (replacement.PhoneNumber != "")
                old.PhoneNumber = replacement.PhoneNumber;
            old.StatusOfCustomer = replacement.StatusOfCustomer;

        }
        
            //Delete
            public void DeleteCustomer(Customer toDelete) {
            _ListOfCustomers.Remove(toDelete); 
        }




        }
}
