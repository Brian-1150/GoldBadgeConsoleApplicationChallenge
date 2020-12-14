using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_4_Repository {

    public enum OutingType {
        Theme_Park = 1, //enum must be one word like variable names
        Bowling,
        Concert,
        Golf


    }

    public class Outings {


        public int Attendance { get; set; }
        public DateTime DateOfEvent { get; set; }
        public decimal CostPerPerson { get; set; }
        public decimal EventCost { get { return CostPerPerson * Attendance; } } //
        public OutingType TypeOfOuting { get; set; }

        public Outings() { }
        public Outings(int att, DateTime date, decimal costPerPerson, OutingType typeOfOuting) {
            Attendance = att;
            DateOfEvent = date;
            CostPerPerson = costPerPerson;
            TypeOfOuting = typeOfOuting;

        }
        public Outings(int att, decimal costPerPerson, OutingType typeOfOuting) {
            Attendance = att;
            CostPerPerson = costPerPerson;
            TypeOfOuting = typeOfOuting;
        }

    }
}
