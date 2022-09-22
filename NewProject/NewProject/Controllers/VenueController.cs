using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewProject.Models;
using NewProject.Services;

namespace NewProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VenueController : ControllerBase
    {
        private readonly ivenueser venueservice;

        public VenueController(ivenueser venueservice)
        {
            this.venueservice = venueservice;
        }
        //GET: api/<VenueController>
        [HttpGet]
        public ActionResult<List<Venue>> Get()
        {
            return venueservice.Get();
        }


        // GET api/<VenueController>/5
        [HttpGet("{id}")]
        public ActionResult<Venue> Get(string id)
        {
            var venue = venueservice.Get(id);

            if (venue == null)
            {
                return NotFound($"venue with Id = {id} not found");
            }
            return venue;
        }

        // POST api/<VenueController>
        [HttpPost]
        public ActionResult<Venue> Post([FromBody] Venue venue)
        {

            var venueexist = venueservice.Create(venue);

            return CreatedAtAction(nameof(Get), new { id = venue.Id }, venue);
        }

        // PUT api/<VenueController>/5
        [HttpPut("{id}")]
        public ActionResult<Venue> Put(string id, [FromBody] Venue venue)
        {
            var venueExist = venueservice.Get(id);

            if (venueExist == null)
            {
                return NotFound($"employee with Id = {id} not found");
            }

            venueservice.Update(id, venue);

            return NoContent();
        }

        // DELETE api/<VenueController>/5
        [HttpDelete("{id}")]
        public ActionResult<Venue> Delete(string id)
        {
            var venue = venueservice.Get(id);

            if (venue == null)
            {
                return NotFound($"employee with Id = {id} not found");
            }
            venueservice.Remove(venue.Id);

            return Ok($"Student with Id = {id} deleted");
        }
    }
}

