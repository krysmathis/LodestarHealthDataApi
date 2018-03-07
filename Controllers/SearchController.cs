using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LodestarHealthDataApi.Data;
using LodestarHealthDataApi.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace LodestarHealthDataApi.Controllers
{   
    [Route("api/[controller]")]
    public class SearchController : Controller
    {

        private readonly LodestarAPIContext _context;

        public SearchController (LodestarAPIContext context) {
            _context = context;
        }

         [HttpGet]
        public Facility[] Get(string long1, string lat1, string long2, string lat2)
        {
            // this will search within a range of lat/longs
            return _context.Facility.ToArray();
        }
    }
}