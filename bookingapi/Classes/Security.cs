using bookingapi.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookingapi.Classes
{
    public class Security
    {
        public static bool Login(string username,string password)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("booking");

            IMongoCollection<Users> _users = database.GetCollection<Users>("users");
            Users users   = _users.Find<Users>(book => book.username == username && book.password == password).FirstOrDefault();
            if(users != null)
            {
                return true;
            }
            return false;
        }

        public static string generateAuthToken(string username, string password)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(username + ":" + password);
            string token = System.Convert.ToBase64String(plainTextBytes);
            return token;
        }

        public static Users getUser(string username, string password)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("booking");

            IMongoCollection<Users> _users = database.GetCollection<Users>("users");
            Users users = _users.Find<Users>(book => book.username == username && book.password == password).FirstOrDefault();
            if (users != null)
            {
                return users;
            }
            return users;
        }
    }
}
