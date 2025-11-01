using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MovieEventBooking.Models
{
    [BsonIgnoreExtraElements]
    public class Booking
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        public string MovieId { get; set; } = string.Empty;    // stores Movie._id (ObjectId as string)
        public string MovieTitle { get; set; } = string.Empty;

        public string UserEmail { get; set; } = string.Empty;
        public string SeatNumbers { get; set; } = string.Empty; // "A1,A2"
        public int Tickets { get; set; }
        public decimal TotalAmount { get; set; }               // use decimal for money

        public DateTime ShowDate { get; set; } = DateTime.Now;
        public DateTime BookingDate { get; set; } = DateTime.Now;
    }
}
