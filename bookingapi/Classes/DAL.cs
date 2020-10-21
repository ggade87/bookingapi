using bookingapi.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookingapi.Classes
{
    public class DAL
    { 
        public static List<Seats> getSeats(string userid)
        {
            
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("booking");

            IMongoCollection<Seats> _seats = database.GetCollection<Seats>("seats");

            IMongoCollection<Book> _book = database.GetCollection<Book>("book");
            List<Book> books = _book.Find<Book>(book => book.userid == userid).ToList();

            if (books != null && books.Count > 0)
            {
                var query = from p in _seats.AsQueryable()
                        join o in _book.AsQueryable() on p.Id equals o.seatid into joineResult
                        //from r in joineResult
                        from r in joineResult.DefaultIfEmpty()
                        select new Seats()
                        {
                            Id = p.Id,
                            seatname = p.seatname,
                            starttime = r.starttime,
                            bookflag = r.endtime 
                        };
                var temp = query.ToList();
                return temp;
            }
            else
            {
              var  query = from p in _seats.AsQueryable()
                        join o in _book.AsQueryable() on p.Id equals o.seatid into joineResult
                        //from r in joineResult
                        from r in joineResult.DefaultIfEmpty()
                        select new Seats()
                        {
                            Id = p.Id,
                            seatname = p.seatname,
                            starttime = r.starttime,
                            bookflag = r.endtime,
                            newuser = true
                        };
                var temp = query.ToList();
                foreach (var tom in temp.Where(w => w.newuser == false))
                {
                    tom.newuser = true;
                }
                return temp;
            }
        }

        public static List<Book> saveBooking(Book bookingRequest)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("booking");

            IMongoCollection<Book> _book = database. GetCollection<Book>("book");
            _book.InsertOne(bookingRequest);
            List<Book> books = _book.Find<Book>(book => book.userid == bookingRequest.userid).ToList();
            if (books != null)
            {
                return books;
            }
            return books;
        }
    }
}
