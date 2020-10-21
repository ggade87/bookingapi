using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookingapi.Models
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("userid")]
        public string userid { get; set; }

        [BsonElement("seatid")]
        public string seatid { get; set; }

        [BsonElement("starttime")] // <-- this errors out
        public string starttime { get; set; }

        [BsonElement("endtime")]
        public string endtime { get; set; }
    }
}
