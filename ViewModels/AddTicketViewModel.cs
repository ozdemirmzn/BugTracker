using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.ViewModels
{
    public class AddTicketViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string TicketOwner { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        public IFormFile Photo1 { get; set; }
        public IFormFile Photo2 { get; set; }
        public IFormFile Photo3 { get; set; }

    }
}
