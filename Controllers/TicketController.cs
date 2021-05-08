using BugTracker.Data;
using BugTracker.Models;
using BugTracker.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Controllers
{
    [Authorize]
    public class TicketController : Controller
    {

        private TicketDbContext context;
        private readonly IHostingEnvironment hostingEnvironment;

        public TicketController(TicketDbContext dbContext, IHostingEnvironment hostingEnvironment)
        {
            context = dbContext;
            this.hostingEnvironment = hostingEnvironment;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            List<Ticket> tickets = context.Tickets.ToList();
            return View(tickets);
        }

        public IActionResult Add()
        {
            AddTicketViewModel addTicketViewModel = new AddTicketViewModel();
            return View(addTicketViewModel);
        }

        [HttpPost("/Add")]
        public IActionResult ProcessAddTicket(AddTicketViewModel addTicketViewModel)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName1 = null;
                string uniqueFileName2 = null;
                string uniqueFileName3 = null;

                if (addTicketViewModel.Photo1 != null)
                {
                    // The image must be uploaded to the images folder in wwwroot
                    // To get the path of the wwwroot folder we are using the inject
                    // HostingEnvironment service provided by ASP.NET Core
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    // To make sure the file name is unique we are appending a new
                    // GUID value and and an underscore to the file name
                    uniqueFileName1 = Guid.NewGuid().ToString() + "_" + addTicketViewModel.Photo1.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName1);
                    // Use CopyTo() method provided by IFormFile interface to
                    // copy the file to wwwroot/images folder
                    addTicketViewModel.Photo1.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                if (addTicketViewModel.Photo2 != null)
                {
                    // The image must be uploaded to the images folder in wwwroot
                    // To get the path of the wwwroot folder we are using the inject
                    // HostingEnvironment service provided by ASP.NET Core
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    // To make sure the file name is unique we are appending a new
                    // GUID value and and an underscore to the file name
                    uniqueFileName2 = Guid.NewGuid().ToString() + "_" + addTicketViewModel.Photo2.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName2);
                    // Use CopyTo() method provided by IFormFile interface to
                    // copy the file to wwwroot/images folder
                    addTicketViewModel.Photo2.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                if (addTicketViewModel.Photo3 != null)
                {
                    // The image must be uploaded to the images folder in wwwroot
                    // To get the path of the wwwroot folder we are using the inject
                    // HostingEnvironment service provided by ASP.NET Core
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    // To make sure the file name is unique we are appending a new
                    // GUID value and and an underscore to the file name
                    uniqueFileName3 = Guid.NewGuid().ToString() + "_" + addTicketViewModel.Photo3.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName3);
                    // Use CopyTo() method provided by IFormFile interface to
                    // copy the file to wwwroot/images folder
                    addTicketViewModel.Photo3.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                ApplicationUser NewApplicationUser = context.Users.Find(addTicketViewModel.UserId);

                Ticket newTicket = new Ticket
                {

                    Description = addTicketViewModel.Description,
                    applicationUser = NewApplicationUser,
                    PhotoPath1 = uniqueFileName1,
                    PhotoPath2 = uniqueFileName2,
                    PhotoPath3 = uniqueFileName3

                };

                
                context.Tickets.Add(newTicket);
                context.SaveChanges();

                return Redirect("/ticket");
            }
            return View("Add", addTicketViewModel);
        }

        [Authorize]
        public IActionResult Detail(int id)
        {
            Ticket theTicket = context.Tickets
                .Single(e => e.Id == id);

            return View(theTicket);
        }




        public IActionResult Delete(int id)
        {
            Ticket theTicket = context.Tickets
                .Single(e => e.Id == id);

            context.Tickets.Remove(theTicket);
            context.SaveChanges();

            return Redirect("/ticket");


        }
    }
}
