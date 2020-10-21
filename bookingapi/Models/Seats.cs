using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookingapi.Models
{
    public class Seats
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("seatname")]
        public string seatname { get; set; }

        [BsonElement("starttime")]
        public String starttime { get; set; }

        [BsonElement("bookflag")]
        public String bookflag { get; set; }

        [BsonElement("newuser")]
        public bool newuser { get; set; }

    }
}
