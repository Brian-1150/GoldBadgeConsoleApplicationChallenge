using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3_Repository {
    public class BadgesRepo {
        private List<Badges> _ClaimsList = new List<Badges>();
        private Dictionary<int, Badges> _BadgeDictionary = new Dictionary<int, Badges>();
        private List<string> _Doors = new List<string>() { "A1", "A2", "A3", "A4", "A5", "A6", "A7", "A8", "A9" };

        //Create
        public void CreateNewBadge(int newKey, Badges newBadge) {
            _BadgeDictionary.Add(newKey, newBadge);
        }
        //Read
        public Dictionary<int, Badges> DisplayListOfBadges() {

            return _BadgeDictionary;
        }

        public List<string> ListOfDoors() {
            return _Doors;
        }


        //Update
        public void AddDoorsToBadge(int key, Badges updatedBadge) {
            var badgeToUpdate = GetBadgeByKey(key);
            badgeToUpdate.HasAccessTo.AddRange(updatedBadge.HasAccessTo);   // = updatedBadge.HasAccessTo;
        }

        public void RemoveDoorsFromBadge(int key, Badges updatedBadge) {

        }
        //Delete


        //Helper Methods
        public Badges GetBadgeByKey(int key) {
            foreach (KeyValuePair<int, Badges> badgeKey in _BadgeDictionary) {
                if (badgeKey.Key == key) {
                    return badgeKey.Value;  // if match is found, the correct badge is returned and method is finished
                }

            }
            return null; //will only come to null if key was not found
        }











    }
}
