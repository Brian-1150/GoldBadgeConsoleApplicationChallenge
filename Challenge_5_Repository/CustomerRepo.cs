using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_5_Repository {
    public class CustomerRepo {
        private List<Customer> _ListOfCustomers = new List<Customer>();

        //Create
        public void AddToList(Customer newCustomer) {
            _ListOfCustomers.Add(newCustomer);
        }
        public void AddToList(Customer one, Customer two) {
            _ListOfCustomers.Add(one);
            _ListOfCustomers.Add(two);
        }
        //Read
        public List<Customer> ListOfCustomers(string x) {
            var tempList = new List<Customer>();
            foreach (var cust in _ListOfCustomers) {

                switch (x) {
                    case "1":
                        if (cust.StatusOfCustomer == CustomerStatus.Current) {
                            tempList.Add(cust);
                        }
                        return tempList;
                       
                    case "2":
                        if (cust.StatusOfCustomer == CustomerStatus.Past) {
                            tempList.Add(cust);
                        }
                        return tempList;
                       
                    case "3":
                        if (cust.StatusOfCustomer == CustomerStatus.Prospective) {
                            tempList.Add(cust);
                        }
                        return tempList;
                       
                    case "4":
                        return _ListOfCustomers;
                       
                    default:
                        return null;
                        
                }
            } return null;
        }
        public List<Customer> ListOfCustomers() {
            return _ListOfCustomers;
        }
            //Update

            //Delete





        }
}
