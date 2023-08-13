using CitiesInfoAPIs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CitiesInfoAPIs.Controllers
{
    [Route("api/cities/{cityId}/pointsofinterest")]
    [ApiController]
    public class PointsOfInterestController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<PointOfInterstDto>> GetPointsOfInterested(int cityId)
        {
            var city = CitiesDataStore.current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null) return NotFound();

            return Ok(city.PointOfInterest);
        }

        [HttpGet("{pointofinterestid}", Name = "GetPointOfInterest")]
        public ActionResult<PointOfInterstDto> GetPointOfInterest(
            int cityId, int pointOfInterestId)
        {
            var city = CitiesDataStore.current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null) return NotFound();

            var pointOfInterest = city.PointOfInterest.FirstOrDefault(p => p.Id == pointOfInterestId);
            if (pointOfInterest == null) return NotFound();

            return Ok(pointOfInterest);
        }
        [HttpPost]
        public ActionResult AddPointOfInterest(
            int cityId, PointOfInterestToCreateDto pointOfInterestToCreateDto)
        {
            if(!ModelState.IsValid) return BadRequest();

            var city = CitiesDataStore.current.Cities.FirstOrDefault(c => c.Id == cityId);
            if(city is null) return NotFound();

            var maxId = CitiesDataStore.current.Cities.SelectMany(c => c.PointOfInterest).Max(p=>p.Id);

            var finalPointOfInterest = new PointOfInterstDto()
            {
                Id = ++maxId,
                Description = pointOfInterestToCreateDto.Discription,
                Name = pointOfInterestToCreateDto.Name
            };
            city.PointOfInterest.Add(finalPointOfInterest);
            return CreatedAtAction("GetPointOfInterest", new { cityId = cityId, pointOfInterestId = finalPointOfInterest.Id }, finalPointOfInterest);
        }
        [HttpPut("{pointofinterestid}")]
        public ActionResult UpdatePointOfInterest(
            int cityId, int pointOfInterestId, PointOfInterestToUpdate pointOfInterestToUpdateDto)
        {
            var city = CitiesDataStore.current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city is null) return NotFound();

            var oldPoint = city.PointOfInterest.FirstOrDefault(p => p.Id == pointOfInterestId);
            if(oldPoint is null) return NotFound();

            oldPoint.Name = pointOfInterestToUpdateDto.Name;
            oldPoint.Description = pointOfInterestToUpdateDto.Description;

            return NoContent();
        }
        [HttpDelete("{pointOfInterestId}")]
        public ActionResult DeletePointOfInstead(int cityId, int pointOfInterestId)
        {
            var city = CitiesDataStore.current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city is null) return NotFound();

            var point = city.PointOfInterest.FirstOrDefault(p=> p.Id == pointOfInterestId);
            if (point is null) return NotFound();

            city.PointOfInterest.Remove(point);

            return NoContent();
        }
    }
}
