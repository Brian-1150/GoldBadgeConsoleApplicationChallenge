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
                //cuts off a long description to not disrupt the table.  But accounts for a small description so we don't get out of range exception
                if (claim.Description.Length < 15) {
                    Console.WriteLine($"{claim.ClaimID}\t{claim.ClaimType}\t{claim.Description}...\t\t${claim.ClaimAmount}" +
                                      $"\t{claim.DateOfIncident:M/d/yyyy}\t{claim.DateOfClaim:M/d/yyyy}\t{claim.isValid}"); //DateOfClaim: instead of .ToString()
                }
                else {
                    Console.WriteLine($"{claim.ClaimID}\t{claim.ClaimType}\t{claim.Description.Remove(15)}...\t${claim.ClaimAmount}" +
                                      $"\t{claim.DateOfIncident:M/d/yyyy}\t{claim.DateOfClaim:M/d/yyyy}\t{claim.isValid}");
                }
            }
        }

        //Update
        public void NextItemInQueue() {
            var claim = _ClaimsQueue.Peek();
            Console.Clear();
            Console.WriteLine($"ClaimID:  {claim.ClaimID}\n" +
                              $"Type:  {claim.ClaimType}\n" +
                              $"Description:{claim.Description}\n" +
                              $"Amount:  ${claim.ClaimAmount}\n" +
                              $"Date Of Incident:  {claim.DateOfIncident:M/d/yyyy}\n" +
                              $"Date of Claim:  {claim.DateOfClaim:M/d/yyyy}\n" +
                              $"Valid Claim:  {claim.isValid}\n");

        }

        public bool Dequeue() {
            int x = _ClaimsQueue.Count;
            _ClaimsQueue.Dequeue();
            if (x > _ClaimsQueue.Count) {
                return true;
            }
            else return false;

        }

        
        //Helper method

    }
}
