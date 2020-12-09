using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3_Repository
{
    public class Badges
    {
        public int BadgeID { get; set; }
        public string EmployeeName { get; set; }
        public List<string> HasAccessTo { get; set; } = new List<string>();

        public Badges() { }
        public Badges(int badgeID, List<string> HasAccessTo) {
            BadgeID = badgeID;
            this.HasAccessTo = HasAccessTo; // another way is to use keyword this
            
        }
        public Badges(int badgeId, string name, List<string> hasAccessTo) {
            BadgeID = badgeId;
            EmployeeName = name;
            HasAccessTo = hasAccessTo;
        }
    }
}
