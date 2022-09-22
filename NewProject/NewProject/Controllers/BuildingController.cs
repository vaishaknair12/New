using Microsoft.AspNetCore.Mvc;
using NewProject.Models;
using NewProject.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NewProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        private readonly IBuildingService employeeService;

        public BuildingController(IBuildingService employeeService)
        {
            this.employeeService = employeeService;
        }
         //GET: api/<EmployeeController>
        [HttpGet]
        public ActionResult<List<Building>> Get()
        {
            return employeeService.Get();
        }
       
     
            // GET api/<EmployeeController>/5
            [HttpGet("{id}")]
        public ActionResult<Building> Get(string id)
        {
            var employee = employeeService.Get(id);

            if (employee == null)
            {
                return NotFound($"employee with Id = {id} not found");
            }
            return employee;
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public ActionResult<Building> Post([FromBody] Building building)
        {
        
              var exestingEmployee = employeeService.Create(building);

           return CreatedAtAction(nameof(Get), new { id = building.Id }, building);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public ActionResult<Building> Put(string  id, [FromBody] Building building)
        {
            var buildingparam = employeeService.Get(id);

            if(buildingparam == null)
            {
                return NotFound($"building with Id = {id} not found");
            }

            employeeService.Update(id, building);

            return NoContent();
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public ActionResult<Building> Delete(string id)
        {
            var building = employeeService.Get(id);

            if(building == null)
            {
                return NotFound($"building with Id = {id} not found");
            }
            employeeService.Remove(building.Id);

            return Ok($"building with Id = {id} deleted");
        }
    }
}



