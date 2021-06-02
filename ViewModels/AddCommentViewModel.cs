using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.ViewModels
{
    public class AddCommentViewModel
    {

        public int Id { get; set; }

        public string UserComment { get; set; }

        public string UserFirstName { get; set; }


       /* //foreign key relation btw user table and ticket table
        [Required(ErrorMessage = "Please Sign Out, clear cookies and Sign In Again")]
        public string UserId { get; set; }*/

        //public int TicketId { get; set; }

        public DateTime CommentDate { get; set; }
    }
}
