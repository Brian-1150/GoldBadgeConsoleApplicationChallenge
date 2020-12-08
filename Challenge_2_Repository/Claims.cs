using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2_Repository {
    public class Claims {
        public int ClaimID { get; set; }
        public string ClaimType { get; set; }
        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool isValid { get; set; }
        public string ShortDescription { get; set; }

        public Claims() { } // must always match name of class??

        public Claims(int claimId, string claimType, string description, double amount, DateTime incident, DateTime claimDate, bool valid) {
            ClaimID = claimId;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = amount;
            DateOfIncident = incident;
            DateOfClaim = claimDate;
            isValid = valid;

            

        }
    }
}
