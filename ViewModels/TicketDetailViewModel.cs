using BugTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.ViewModels
{
    public class TicketDetailViewModel
    {
        public int Id { get; set; }
        public string TicketOwner { get; set; }
        public string Description { get; set; }
        public string TicketNumber { get; set; }

        public TicketDetailViewModel(Ticket theTicket)
        {
            Id = theTicket.Id;
            TicketOwner = theTicket.TicketOwner;
            Description = theTicket.Description;
            TicketNumber = theTicket.TicketNumber;
        }
    }
}

