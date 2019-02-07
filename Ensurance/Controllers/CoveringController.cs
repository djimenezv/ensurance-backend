using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ensurance.Models;
using Ensurance.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ensurance.Controllers
{
    [Route("api/Covering")]
    public class CoveringController : Controller
    {
        private readonly IDataRepository<Covering> _dataRepository;

        public CoveringController(IDataRepository<Covering> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/Employee
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Covering> employees = _dataRepository.GetAll();
            return Ok(employees);
        }

    }
}