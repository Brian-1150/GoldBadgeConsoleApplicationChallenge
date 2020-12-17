using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_6_Repository {
    public class Vehicle {

        public enum VehicleType {
            Sedan = 1,
            Van,
            Truck,
            Coupe,
            Other

        }
        public string Make_Model { get; set; }
        public double RetailCost { get; set; }
        public VehicleType TypeOfVehicle { get; set; }

        public Vehicle() { }
        public Vehicle(string makeModel, double retailCost, VehicleType typeOfVehicle) {
            Make_Model = makeModel;
            RetailCost = retailCost;
            TypeOfVehicle = typeOfVehicle;
        }
    }
    public class GasVehicle : Vehicle {
        public double FuelEconomy { get; set; }

        public GasVehicle() { }
        public GasVehicle(double fuelEconomy, string makeModel, double retailCost, VehicleType typeOfVehicle) 
            : base (makeModel, retailCost, typeOfVehicle) {
            FuelEconomy = fuelEconomy;
        }
        
    }
    public class ElectricVehcile : Vehicle {
        public double PowerRating { get; set; }

        public ElectricVehcile() { }
        public ElectricVehcile(double powerRating, string makeModel, double retailCost, VehicleType typeOfVehicle)
            : base(makeModel, retailCost, typeOfVehicle) {
            PowerRating = powerRating;
        }
    }
    public class HybridVehcile : GasVehicle  {
        public double PowerRating { get; set; }

        public HybridVehcile() { }
        public HybridVehcile(double powerRating, double fuelEconomy, string makeModel, double retailCost, VehicleType typeOfVehicle)
            : base(fuelEconomy, makeModel, retailCost, typeOfVehicle) {
            PowerRating = powerRating;
        }
    }
}
