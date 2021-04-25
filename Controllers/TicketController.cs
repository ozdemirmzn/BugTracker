using BugTracker.Data;
using BugTracker.Models;
using BugTracker.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Controllers
{
    [Authorize]
    public class TicketController : Controller
    {

        private TicketDbContext context;

        public TicketController(TicketDbContext dbContext)
        {
            context = dbContext;
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
                Ticket newTicket = new Ticket
                {
                    TicketOwner = addTicketViewModel.TicketOwner,
                    Description = addTicketViewModel.Description
                  
                };

                // newBook.BarcodeNum = newBook.BarcodeNum;
                context.Tickets.Add(newTicket);
                context.SaveChanges();

                return Redirect("/ticket");
            }
            return View("Add", addTicketViewModel);
        }

        [AllowAnonymous]
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
