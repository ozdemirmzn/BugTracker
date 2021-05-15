using BugTracker.Data;
using BugTracker.Models;
using BugTracker.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> ProcessAddTicketAsync(AddTicketViewModel addTicketViewModel)
        {
            if (ModelState.IsValid)
            {
                /*string uniqueFileName1 = null;
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
                }*/

                if (Request.Form.Files.Count == 1)
                {

                    IFormFile file = Request.Form.Files.FirstOrDefault();
                    using (var dataStream = new MemoryStream())
                    {
                        await file.CopyToAsync(dataStream);
                        addTicketViewModel.Picture1 = dataStream.ToArray();
                    }
                    
                }
                else if (Request.Form.Files.Count == 2)
                {

                    IFormFile[] file = new IFormFile[2];
                    file[0] = Request.Form.Files[0];
                    using (var dataStream1 = new MemoryStream())
                    {
                        await file[0].CopyToAsync(dataStream1);
                        addTicketViewModel.Picture1 = dataStream1.ToArray();
                    }
                    file[1] = Request.Form.Files[1];
                    using (var dataStream2 = new MemoryStream())
                    {
                        await file[1].CopyToAsync(dataStream2);
                        addTicketViewModel.Picture2 = dataStream2.ToArray();
                    }

                }
                else if (Request.Form.Files.Count == 3)
                {

                    IFormFile[] file = new IFormFile[3];
                    file[0] = Request.Form.Files[0];
                    using (var dataStream1 = new MemoryStream())
                    {
                        await file[0].CopyToAsync(dataStream1);
                        addTicketViewModel.Picture1 = dataStream1.ToArray();
                    }
                    file[1] = Request.Form.Files[1];
                    using (var dataStream2 = new MemoryStream())
                    {
                        await file[1].CopyToAsync(dataStream2);
                        addTicketViewModel.Picture2 = dataStream2.ToArray();
                    }
                    file[2] = Request.Form.Files[2];
                    using (var dataStream3 = new MemoryStream())
                    {
                        await file[2].CopyToAsync(dataStream3);
                        addTicketViewModel.Picture3 = dataStream3.ToArray();
                    }

                }


                ApplicationUser NewApplicationUser = context.Users.Find(addTicketViewModel.UserId);

                Ticket newTicket = new Ticket
                {

                    Description = addTicketViewModel.Description,
                    User = NewApplicationUser,
                    /*PhotoPath1 = uniqueFileName1,
                    PhotoPath2 = uniqueFileName2,
                    PhotoPath3 = uniqueFileName3,*/
                    Picture1 = addTicketViewModel.Picture1,
                    Picture2 = addTicketViewModel.Picture2,
                    Picture3 = addTicketViewModel.Picture3

                };

                
                context.Tickets.Add(newTicket);
                context.SaveChanges();

                return Redirect("/ticket");
            }
            return View("Add", addTicketViewModel);
        }

        
        public IActionResult Detail(int id)
        {
            Ticket theTicket = context.Tickets
                .Single(e => e.Id == id);

            return View(theTicket);
        }



        [Authorize(Roles = "SuperAdmin, Admin, Moderator")]
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
