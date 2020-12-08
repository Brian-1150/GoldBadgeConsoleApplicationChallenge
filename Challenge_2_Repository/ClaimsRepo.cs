using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenge_1_Repository;


namespace Challenge_2_Repository {
    public class ClaimsRepo {
        public MenuItemRepo _accesssToChallenge1RepoMethods = new MenuItemRepo();
        public List<Claims> _ClaimsList = new List<Claims>();
        public Queue<Claims> _ClaimsQueue = new Queue<Claims>();


        //Create
        public void AddClaim(Claims newClaim) {
            _ClaimsQueue.Enqueue(newClaim);
        }


        //Read
        public void ViewQueue() {
            Console.WriteLine("ClaimID\tType\tDescription\t\tAmount\tDateOfIncident\tDateOfClaim\tFiledOnTime\n");
            foreach (var claim in _ClaimsQueue) {
                if (claim.Description.Length < 15) {

                    Console.WriteLine($"{claim.ClaimID}\t{claim.ClaimType}\t{claim.Description}...\t\t{claim.ClaimAmount}" +
                        $"\t{claim.DateOfIncident.ToString("M/d/yyyy")}\t{claim.DateOfClaim.ToString("M/d/yyyy")}\t{claim.isValid}");
                }
                else {
                    Console.WriteLine($"{claim.ClaimID}\t{claim.ClaimType}\t{claim.Description.Remove(15)}...\t{claim.ClaimAmount}" +
                   $"\t{claim.DateOfIncident.ToString("M/d/yyyy")}\t{claim.DateOfClaim.ToString("M/d/yyyy")}\t{claim.isValid}");
                }
            }
        }

        //Update

        //Delete

    }
}
