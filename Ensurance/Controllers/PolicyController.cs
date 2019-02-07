using System.Collections.Generic;
using Ensurance.Models;
using Ensurance.Repository;
using Microsoft.AspNetCore.Mvc;
//using System.Web.Http;

namespace Ensurance.Controllers
{
    [Route("api/policy")]
    //[ApiController]
    public class PolicyController : Controller
    {
        private readonly IDataRepository<Policy> _dataRepository;

        public PolicyController(IDataRepository<Policy> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/Employee
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Policy> employees = _dataRepository.GetAll();
            return Ok(employees);
        }

        // GET: api/Employee/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(long id)
        {
            Policy policy = _dataRepository.Get(id);

            if (policy == null)
            {
                return NotFound("The Employee record couldn't be found.");
            }

            return Ok(policy);
        }

        // POST: api/Employee
        [HttpPost]
        public IActionResult Post([FromBody] Policy policy)
        {
            if (policy == null)
            {
                return BadRequest("Policy is null.");
            }

            _dataRepository.Add(policy);
            return CreatedAtRoute(
                  "Get",
                  new { Id = policy.PolicyNumber },
                  policy);
        }

        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Policy policy)
        {
            if (policy == null)
            {
                return BadRequest("Employee is null.");
            }

            Policy employeeToUpdate = _dataRepository.Get(id);
            if (employeeToUpdate == null)
            {
                return NotFound("The Employee record couldn't be found.");
            }

            _dataRepository.Update(employeeToUpdate, policy);
            return NoContent();
        }

        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            Policy policy = _dataRepository.Get(id);
            if (policy == null)
            {
                return NotFound("The Employee record couldn't be found.");
            }

            _dataRepository.Delete(policy);
            return NoContent();
        }
    }
}