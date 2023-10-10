using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TicketBooking.Models
{
    [BsonIgnoreExtraElements]
    public class Train
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("trainNumber")]
        public string TrainNumber { get; set; } = string.Empty;

        [BsonElement("departureStation")]
        public string DepartureStation { get; set; } = string.Empty;

        [BsonElement("arrivalStation")]
        public string ArrivalStation { get; set; } = string.Empty;

        [BsonElement("departureTime")]
        public DateTime DepartureTime { get; set; } = DateTime.MinValue;

        [BsonElement("arrivalTime")]
        public DateTime ArrivalTime { get; set; } = DateTime.MinValue;

        [BsonElement("ticketPrice")]
        public decimal TicketPrice { get; set; } = 0.0m;
    }
}
