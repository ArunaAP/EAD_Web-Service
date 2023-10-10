using Microsoft.AspNetCore.Mvc;
using TicketBooking.Models;
using TicketBooking.Services;
using System.Collections.Generic;

namespace TicketBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketBookingController : ControllerBase
    {
        private readonly ITicketBookingService ticketBookingService;

        public TicketBookingController(ITicketBookingService ticketBookingService)
        {
            this.ticketBookingService = ticketBookingService;
        }

        // GET: api/TicketBooking
        [HttpGet]
        public ActionResult<List<TicketBookingManage>> Get()
        {
            var ticketBookings = ticketBookingService.GetTicketBookings();
            return Ok(ticketBookings);
        }

        // GET api/TicketBooking/5
        [HttpGet("{id}")]
        public ActionResult<TicketBookingManage> Get(string id)
        {
            var ticketBooking = ticketBookingService.GetTicketBooking(id);

            if (ticketBooking == null)
            {
                return NotFound($"TicketBooking with Id = {id} not found");
            }

            return Ok(ticketBooking);
        }

        // POST api/TicketBooking
        [HttpPost]
        public ActionResult<TicketBookingManage> Post([FromBody] TicketBookingManage ticketBooking)
        {
            var createdTicketBooking = ticketBookingService.CreateTicketBooking(ticketBooking);

            return CreatedAtAction(nameof(Get), new { id = createdTicketBooking.Id }, createdTicketBooking);
        }

        // PUT api/TicketBooking/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] TicketBookingManage ticketBooking)
        {
            var existingTicketBooking = ticketBookingService.GetTicketBooking(id);

            if (existingTicketBooking == null)
            {
                return NotFound($"TicketBooking with Id = {id} not found");
            }

            ticketBookingService.UpdateTicketBooking(id, ticketBooking);

            return NoContent();
        }

        // DELETE api/TicketBooking/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var ticketBooking = ticketBookingService.GetTicketBooking(id);

            if (ticketBooking == null)
            {
                return NotFound($"TicketBooking with Id = {id} not found");
            }

            ticketBookingService.RemoveTicketBooking(id);

            return Ok($"TicketBooking with Id = {id} deleted");
        }
    }
}
