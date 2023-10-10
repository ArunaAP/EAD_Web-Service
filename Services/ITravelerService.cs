using System.Collections.Generic;
using TicketBooking.Models;

namespace TicketBooking.Services
{
    public interface ITravelerService
    {
        List<TravelerProfile> GetTravelers();
        TravelerProfile GetTravelerByNIC(string nic);
        TravelerProfile CreateTraveler(TravelerProfile traveler);
        void UpdateTraveler(string nic, TravelerProfile traveler);
        void RemoveTraveler(string nic);
    }
}
