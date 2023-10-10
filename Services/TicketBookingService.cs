using TicketBooking.Models;
using MongoDB.Driver;
using System.Collections.Generic;

namespace TicketBooking.Services
{
    public class TicketBookingService : ITicketBookingService
    {
        private readonly IMongoCollection<TicketBookingManage> _ticketBookings;

        public TicketBookingService(ITicketBookingStoreDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _ticketBookings = database.GetCollection<TicketBookingManage>(settings.TicketBookingCollectionName);
        }

        public TicketBookingManage CreateTicketBooking(TicketBookingManage ticketBooking)
        {
            _ticketBookings.InsertOne(ticketBooking);
            return ticketBooking;
        }

        public List<TicketBookingManage> GetTicketBookings()
        {
            return _ticketBookings.Find(ticketBooking => true).ToList();
        }

        public TicketBookingManage GetTicketBooking(string id)
        {
            return _ticketBookings.Find(ticketBooking => ticketBooking.Id == id).FirstOrDefault();
        }

        public void RemoveTicketBooking(string id)
        {
            _ticketBookings.DeleteOne(ticketBooking => ticketBooking.Id == id);
        }

        public void UpdateTicketBooking(string id, TicketBookingManage ticketBooking)
        {
            _ticketBookings.ReplaceOne(existingTicketBooking => existingTicketBooking.Id == id, ticketBooking);
        }
    }
}
