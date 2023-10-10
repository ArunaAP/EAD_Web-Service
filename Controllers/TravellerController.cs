using Microsoft.AspNetCore.Mvc;
using TicketBooking.Models;
using TicketBooking.Services;
using System;
using System.Collections.Generic;

namespace TicketBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelerController : ControllerBase
    {
        private readonly ITravelerService travelerService;

        public TravelerController(ITravelerService travelerService)
        {
            this.travelerService = travelerService;
        }

        // GET: api/Traveler
        [HttpGet]
        public ActionResult<List<TravelerProfile>> Get()
        {
            return travelerService.GetTravelers();
        }

        // GET: api/Traveler/NIC
        [HttpGet("{nic}")]
        public ActionResult<TravelerProfile> Get(string nic)
        {
            var traveler = travelerService.GetTravelerByNIC(nic);

            if (traveler == null)
            {
                return NotFound($"Traveler with NIC = {nic} not found");
            }

            return traveler;
        }

        // POST: api/Traveler
        [HttpPost]
        public ActionResult<TravelerProfile> Post([FromBody] TravelerProfile traveler)
        {
            if (traveler == null)
            {
                return BadRequest("Invalid traveler data");
            }

            // You may want to validate NIC uniqueness or other business logic here

            travelerService.CreateTraveler(traveler);

            return CreatedAtAction(nameof(Get), new { nic = traveler.NIC }, traveler);
        }

        // PUT: api/Traveler/NIC
        [HttpPut("{nic}")]
        public ActionResult Put(string nic, [FromBody] TravelerProfile traveler)
        {
            var existingTraveler = travelerService.GetTravelerByNIC(nic);

            if (existingTraveler == null)
            {
                return NotFound($"Traveler with NIC = {nic} not found");
            }

            travelerService.UpdateTraveler(nic, traveler);

            return NoContent();
        }

        // DELETE: api/Traveler/NIC
        [HttpDelete("{nic}")]
        public ActionResult Delete(string nic)
        {
            var traveler = travelerService.GetTravelerByNIC(nic);

            if (traveler == null)
            {
                return NotFound($"Traveler with NIC = {nic} not found");
            }

            travelerService.RemoveTraveler(nic);

            return Ok($"Traveler with NIC = {nic} deleted");
        }
    }
}
