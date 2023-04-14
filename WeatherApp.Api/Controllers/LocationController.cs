using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.Dto;
using WeatherApp.Interfaces;
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocationController : Controller
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;

        public LocationController(ILocationRepository locationRepository, IMapper mapper)
        {
            _locationRepository = locationRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Location>))]
        public IActionResult GetLocations()
        {
            var locations = _mapper.Map<List<LocationDto>>(_locationRepository.GetLocations());

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(locations);
        }

        [HttpGet("{locationId}")]
        [ProducesResponseType(200, Type = typeof(Location))]
        [ProducesResponseType(400)]
        public IActionResult GetLocation(int locationId)
        {
            if (!_locationRepository.LocationExists(locationId))
                return NotFound();

            var location = _mapper.Map<LocationDto>(_locationRepository.GetLocation(locationId));

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(location);
        }

        [HttpGet("region")]
        [ProducesResponseType(200, Type = typeof(Location))]
        [ProducesResponseType(400)]
        public IActionResult GetLocationByRegion(string region)
        {
            if (!_locationRepository.LocationExists(region))
                return NotFound();

            var location = _locationRepository.GetLocationByRegion(region);

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(location);
        }

        [HttpGet("coordinates")]
        [ProducesResponseType(200, Type = typeof(Location))]
        [ProducesResponseType(400)]
        public IActionResult GetLocationByGeo(double lat, double lon)
        {
            if (!_locationRepository.LocationExists(lat, lon))
                return NotFound();

            var location = _locationRepository.GetLocationByGeo(lat, lon);

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(location);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateLocation([FromBody] LocationDto locationCreate)
        {
            if (locationCreate == null)
                return BadRequest(ModelState);

            var location = _locationRepository.GetLocations()
                .Where(l => l.Region.Trim().ToUpper() == locationCreate.Region.Trim().ToUpper()).FirstOrDefault();

            if (location != null)
            {
                ModelState.AddModelError("", "Location already exists");
                return StatusCode(422, ModelState);
            }
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var locationMap = _mapper.Map<Location>(locationCreate);
            
            if (!_locationRepository.CreateLocation(locationMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Succesfully created location");
        }

        [HttpPut("{locationId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateLocation(int locationId, [FromBody] LocationDto updatedLocation)
        {
            if (updatedLocation == null)
                return BadRequest(ModelState);

            if (locationId != updatedLocation.Id)
                return BadRequest(ModelState);

            if (!_locationRepository.LocationExists(locationId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var locationMap = _mapper.Map<Location>(updatedLocation);

            if (!_locationRepository.UpdateLocation(locationMap))
            {
                ModelState.AddModelError("", "Something went wrong updating location");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{locationId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteLocation(int locationId)
        {
            if (!_locationRepository.LocationExists(locationId))
                return NotFound();
            
            var locationToDelete = _locationRepository.GetLocation(locationId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_locationRepository.DeleteLocation(locationToDelete))
                ModelState.AddModelError("", "Something went wrong deleting location");

            return NoContent();
        }
    }
}
