using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Models
{
    public class Ticket
    {
        

        public string Description { get; set; }

        public int Id { get; set; }

        public string TicketNumber { get; set; }

        //https://stackoverflow.com/questions/48266241/how-can-i-get-the-current-date-in-asp-net-core-mvc
        public DateTime SubmissionDate { get; set; }

        public string PhotoPath1 { get; set; }
        public string PhotoPath2 { get; set; }
        public string PhotoPath3 { get; set; }

        /*public string UserId { get; set; }*/
        public ApplicationUser applicationUser { get; set; }

        public Ticket()
        {
            TicketNumber = GenerateTicketNumber();
            SubmissionDate = DateTime.Now;
        }

        public Ticket(string description) : this()
        {

            Description = description;
           

        }


        private String GenerateTicketNumber()
        {
            string generateBarcodeNum = "";
            Random rnd = new Random();
            int randomNum1 = rnd.Next(100, 9000);
            int randomNum2 = rnd.Next(100, 9000);
            return generateBarcodeNum + randomNum1 + randomNum2;
        }
    }
}
