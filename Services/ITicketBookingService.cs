using TicketBooking.Models;

namespace TicketBooking.Services
{
    public interface ITicketBookingService
    {
        List<TicketBookingManage> GetTicketBookings();
        TicketBookingManage GetTicketBooking(string id);
        TicketBookingManage CreateTicketBooking(TicketBookingManage ticketBooking);
        void UpdateTicketBooking(string id, TicketBookingManage ticketBooking);
        void RemoveTicketBooking(string id);
    }
}
