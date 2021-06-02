using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string UserComment { get; set; }

        

        public DateTime CommentDate { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }


        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }

        public Comment()
        {
        }
    }
}
