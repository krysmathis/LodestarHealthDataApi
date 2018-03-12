using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LodestarHealthDataApi.Data;
using LodestarHealthDataApi.Models;
using Microsoft.AspNetCore.Authorization;
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
        // TODO: add the [Authorize] attribute
        [HttpGet]
        public Facility[] Get()
        {
            return _context.Facility.ToArray();
        }

    }
}