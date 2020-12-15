using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_4_Repository {
    public class OutingsRepo {

        private List<Outings> _ListOfOutings = new List<Outings>();

        //Create
        public void AddListingToList(Outings newOuting) {
            _ListOfOutings.Add(newOuting);
        }
        public void AddListingToList(Outings one, Outings two) { //overload for two objects
            _ListOfOutings.Add(one);
            _ListOfOutings.Add(two);
        }
        public void AddListingToList(params Outings[] outings) { //overload for unlimited objects
            foreach (Outings occasion in outings) {
                _ListOfOutings.Add(occasion);
            }
        }
        //Read
        public List<Outings> ListOfOutings() {
            return _ListOfOutings;
        }

        //Update
        public void UpdateOuting(Outings oldOuting, Outings newOuting) {

            if (newOuting.Attendance != oldOuting.Attendance) { 
                oldOuting.Attendance = newOuting.Attendance;
            }
            if (newOuting.CostPerPerson != oldOuting.CostPerPerson) {
                oldOuting.CostPerPerson = newOuting.CostPerPerson;
            }
            if (newOuting.DateOfEvent != oldOuting.DateOfEvent) {
                oldOuting.DateOfEvent = newOuting.DateOfEvent;
            }
            if (newOuting.TypeOfOuting != oldOuting.TypeOfOuting) {
                oldOuting.TypeOfOuting = newOuting.TypeOfOuting;
            }
        }
        //Delete
        public bool DeleteOuting(Outings outingToRemove) {
            int count =_ListOfOutings.Count();
            _ListOfOutings.Remove(outingToRemove);
            if (count > _ListOfOutings.Count()) {
                return true;
            }
            else return false;
        }

        //Helper Method
        public Outings GetOutingByDate(DateTime date) {
            foreach (var outing in _ListOfOutings) {
                if (date == outing.DateOfEvent) {
                    return outing;
                }
             
            }return null;
        }






    }
}