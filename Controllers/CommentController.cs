using BugTracker.Data;
using BugTracker.Models;
using BugTracker.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Controllers
{
    public class CommentController : Controller
    {
        private TicketDbContext context;
        

        public CommentController(TicketDbContext dbContext)
        {
            context = dbContext;
            
        }

        public ContentResult GetComment(int id)
        {

            string json = "";

            List<Comment> comments = context.Comments.Where(c => c.TicketId == id).ToList(); //get all ProductCategories
            List<AddCommentViewModel> updatedComments = new List<AddCommentViewModel>();
            
            

            if (comments.Count != 0)
            {

                foreach (var comment in comments)
                { //iterate through categories
                    AddCommentViewModel newComment = new AddCommentViewModel();

                    newComment.Id = comment.Id;
                    newComment.UserComment = comment.UserComment;
                    //newComment.TicketId = comment.TicketId;
                    //newComment.UserId = comment.UserId;
                    newComment.CommentDate = comment.CommentDate;

                    ApplicationUser NewApplicationUser = context.Users.Find(comment.UserId);

                    newComment.UserFirstName = NewApplicationUser.FirstName;


                    updatedComments.Add(newComment);
                }
                json = JsonConvert.SerializeObject(updatedComments);
            }
            return Content(json);
        }


        public ContentResult AddComment(string userComment, string ticketId, string userId)
        {
            Console.WriteLine("usercomment " + userComment);
            Console.WriteLine("ticketid " + ticketId);
            Console.WriteLine("userid " + userId);


            string response = $"AddComment() Error!!! Name: {userComment} Input is either null or empty!";



            if (!String.IsNullOrEmpty(userComment))
            {
                int ticketIdParsed;
                try
                {
                    ticketIdParsed = Int32.Parse(ticketId);

                    ApplicationUser NewApplicationUser = context.Users.Find(userId);
                    Ticket NewTicket = context.Tickets.Find(ticketIdParsed);

                    Comment comment = new Comment
                    {
                        UserComment = userComment,
                        Ticket = NewTicket,
                        User = NewApplicationUser,
                        CommentDate = DateTime.Now,
                        

                    };
                    Console.WriteLine("comment.UserComment: " + comment.UserComment);
                    Console.WriteLine("comment.TicketId) " + comment.TicketId);
                    Console.WriteLine("comment.UserId " + comment.UserId);
                    Console.WriteLine("comment.CommentDate " + comment.CommentDate);
                    context.Comments.Add(comment);
                    context.SaveChanges();
                }
                catch (FormatException)
                {
                    response = ($"DeleteCategory() Error!!! Product Id: '{ticketId}' could not be parsed!");
                }
                response = userComment;


            }
            return Content(response);
        }
    }
}
