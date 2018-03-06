using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LodestarHealthDataApi.Data;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace LodestarHealthDataApi.Controllers
{
    [Route("api/[controller]")]
    public class FacilityController : Controller
    {
        private readonly LodestarAPIContext _context;

        public FacilityController (LodestarAPIContext context) {
            _context = context;
        }
        // GET api/values/5
        [HttpGet]
        [DisableCors]
        public IEnumerable<string> Get(string latitude, string longitude)
        {
            return new string[] { latitude, longitude };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(string system)
        {
            return "value";
        }

    }
}