using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugTracker.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTracker.Data
{
    public class TicketDbContext : DbContext
    {
        public DbSet<Ticket> Tickets { get; set; }


        public TicketDbContext(DbContextOptions<TicketDbContext> options)
              : base(options)
        {
        }


    }
}
