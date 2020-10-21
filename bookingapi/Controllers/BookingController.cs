using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using bookingapi.Classes;
using bookingapi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.Logging;
namespace bookingapi.Controllers
{
    //[Authorize]
   // [EnableCors("_myAllowSpecificOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        [HttpGet("GetSeats")]
        public async Task<IEnumerable<Seats>> GetSeats(string token)
        {
            var authenticationHeaderValue = AuthenticationHeaderValue.Parse("Basic " + token);
            var bytes = Convert.FromBase64String(authenticationHeaderValue.Parameter);
            string[] credentials = Encoding.UTF8.GetString(bytes).Split(":");
            string username = credentials[0];
            string password = credentials[1];
            Users users = Security.getUser(username, password);
            string userid = users.Id;
            List<Seats> seats = DAL.getSeats(userid);
            return  seats;
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpPost("PostBook")]
        public async Task<IEnumerable<Book>> PostBook(Book bookingRequest)
        {
            var authenticationHeaderValue = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
            var bytes = Convert.FromBase64String(authenticationHeaderValue.Parameter);
            string[] credentials = Encoding.UTF8.GetString(bytes).Split(":");
            string username = credentials[0];
            string password = credentials[1];
            Users users = Security.getUser(username, password);
            bookingRequest.userid = users.Id;
            List<Book> seats = new List<Book>();
            List<Book> books = DAL.saveBooking(bookingRequest);
            return books;
        }
    }
}
