using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LodestarHealthDataApi.Data;
using LodestarHealthDataApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LodestarHealthDataApi.Controllers
{
    [Route("api/[controller]")]
    public class HomeLocationController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly LodestarAPIContext _ctx;
        public HomeLocationController(LodestarAPIContext ctx, UserManager<ApplicationUser> userManager) {
            _userManager = userManager;
            _ctx = ctx;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public string Post(string latitude, string longitude)
        {
            return "yes!";
            // ApplicationUser user = _userManager.Users.Where(u => u.UserName == "Test@Account.com").Single();

            // // create home location
            // HomeLocation home = new HomeLocation() {
            //     User = user,
            //     Lat = Convert.ToDouble(latitude),
            //     Lon = Convert.ToDouble(longitude)
            // };

            // _ctx.Add(home);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
