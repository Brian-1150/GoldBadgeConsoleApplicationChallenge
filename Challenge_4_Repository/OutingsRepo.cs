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
        public void AddListingToList(Outings one, Outings two) {
            _ListOfOutings.Add(one);
            _ListOfOutings.Add(two);
        }
        public void AddListingToList(params Outings[] outings) {
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

            oldOuting.Attendance = newOuting.Attendance;
            oldOuting.CostPerPerson = newOuting.CostPerPerson;
            oldOuting.DateOfEvent = newOuting.DateOfEvent;
            oldOuting.TypeOfOuting = newOuting.TypeOfOuting;
        }
        //Delete


        //Helper Method
        private Outings GetOutingByOuting(Outings outingToGet) {
            foreach (var outing in _ListOfOutings) {

            }
        }






    }
}