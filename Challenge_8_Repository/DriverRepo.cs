using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_8_Repository {
    public class DriverRepo {
        private Dictionary<int, Driver> _DictionaryOfDrivers = new Dictionary<int, Driver>();
        private List<Driver> _ListOfDriversAllTIme = new List<Driver>();
        private int driverKeyCount = 1;
        //Create
        public void AddDriver(Driver newDriver) {
            newDriver.CustomerID = driverKeyCount;
            _DictionaryOfDrivers.Add(driverKeyCount, newDriver);
            _ListOfDriversAllTIme.Add(newDriver);
            driverKeyCount++;
        }
        //Read
        public Dictionary<int, Driver> GetDictionaryOfDrivers() {
            return _DictionaryOfDrivers;
        }
        //Update
        public void UdateDriverInfo(Driver oldInfo, Driver newInfo) {
            oldInfo = newInfo;
        }
        //Delete
        public void DeactiveDriver(Driver deactivatedDriver) {
            _DictionaryOfDrivers.Remove(deactivatedDriver.CustomerID);
        }
    }
}
