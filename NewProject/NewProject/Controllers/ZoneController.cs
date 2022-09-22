using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewProject.Models;
using NewProject.Services;

namespace NewProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZoneController : ControllerBase
    {
        private readonly iZonesInterface zoneService;

        public ZoneController(iZonesInterface zoneService)
        {
            this.zoneService = zoneService;
        }
        //GET: api/<ZoneController>
        [HttpGet]
        public ActionResult<List<Zones>> Get()
        {
            return zoneService.Get();
        }


        // GET api/<ZoneController>/5
        [HttpGet("{id}")]
        public ActionResult<Zones> Get(string id)
        {
            var zone = zoneService.Get(id);

            if (zone == null)
            {
                return NotFound($"employee with Id = {id} not found");
            }
            return zone;
        }

        // POST api/<ZoneController>
        [HttpPost]
        public ActionResult<Zones> Post([FromBody] Zones zone)
        {

            var zoneexist = zoneService.Create(zone);

            return CreatedAtAction(nameof(Get), new { id = zone.Id }, zone);
        }

        // PUT api/<ZoneController>/5
        [HttpPut("{id}")]
        public ActionResult<Zones> Put(string id, [FromBody] Building building)
        {
            var zoneparam = zoneService.Get(id);

            if (zoneparam == null)
            {
                return NotFound($"building with Id = {id} not found");
            }

            zoneService.Update(id, zoneparam);

            return NoContent();
        }

        // DELETE api/<ZoneController>/5
        [HttpDelete("{id}")]
        public ActionResult<Zones> Delete(string id)
        {
            var zone = zoneService.Get(id);

            if (zone == null)
            {
                return NotFound($"building with Id = {id} not found");
            }
            zoneService.Remove(zone.Id);

            return Ok($"building with Id = {id} deleted");
        }
    }
}

