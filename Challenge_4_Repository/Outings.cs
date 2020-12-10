using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_4_Repository {

    public enum OutingType {
        Amusement_Park = 1, //enum must be one word like variable names
        Bowling,
        Concert,
        Golf


    }

    public class Outings {

       
        public int Attendance { get; set; }
        public DateTime DateOfEvent { get; set; }
        public double CostPerPerson { get; set; }
        public double EventCost  { get { return CostPerPerson * Attendance; }  } //
        public OutingType TypeOfOuting { get; set; }

        public Outings() { }
        public Outings(int att, DateTime date, double costPerPerson, OutingType typeOfOuting) {
            Attendance = att;
            DateOfEvent = date;
            CostPerPerson = costPerPerson;
           
        }

    }
}
