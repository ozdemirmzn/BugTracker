using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Models
{
    public class Ticket
    {
        public string TicketOwner { get; set; }

        public string Description { get; set; }

        public int Id { get; set; }

       

        public string TicketNumber { get; set; }

        public string PhotoPath1 { get; set; }
        public string PhotoPath2 { get; set; }
        public string PhotoPath3 { get; set; }



        public Ticket()
        {
            TicketNumber = GenerateTicketNumber();
        }

        public Ticket(string ticketOwner, string description) : this()
        {
            TicketOwner = ticketOwner;
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
