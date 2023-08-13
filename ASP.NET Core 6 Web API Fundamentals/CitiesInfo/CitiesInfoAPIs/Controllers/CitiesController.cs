using CitiesInfoAPIs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CitiesInfoAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<CityDto>> Cities()
        {
            return Ok(CitiesDataStore.current.Cities);
        }

        [HttpGet("{id}")]
        public ActionResult GetCity(int id)
        {

            var city = CitiesDataStore.current.Cities.FirstOrDefault(c => c.Id == id);
            if(city == null) return NotFound();
            return Ok(city);  
        }
       
    }
}
