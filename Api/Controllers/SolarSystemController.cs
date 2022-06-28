using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SolarSystemController : ControllerBase
    {
        private readonly ISolarSystemRepository _repository;

        public SolarSystemController(ISolarSystemRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SolarSystem[]))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get(string search = null)
        {
            try
            {
                return Ok(_repository.GetSolarSystems(search));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SolarSystem))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Post(SolarSystem solarSystem)
        {
            try
            {
                return CreatedAtAction("Post", _repository.InsertSolarSystem(solarSystem));
            }
            catch (FormatException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SolarSystem))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_repository.GetSolarSystemById(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SolarSystem))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Put(Guid id, SolarSystem solarSystem)
        {
            try
            {
                return CreatedAtAction("Put", _repository.UpdateSolarSystem(id, solarSystem));
            }
            catch (FormatException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _repository.DeleteSolarSystem(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}/planet")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Planet[]))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetPlanets(Guid id, string search = null)
        {
            try
            {
                return Ok(_repository.GetPlanetsBySolarSystemId(id, search));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("{id}/planet")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Planet))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult PostPlanet(Guid id, Planet planet)
        {
            try
            {
                return CreatedAtAction("PostPlanet", _repository.InsertPlanet(id, planet));
            }
            catch (FormatException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}/planet")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeletePlanets(Guid id)
        {
            try
            {
                _repository.DeletePlanets(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("{id}/planet/{planetId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Planet))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult PutPlanet(Guid id, Guid planetId, Planet planet)
        {
            try
            {
                return CreatedAtAction("PutPlanet", _repository.UpdatePlanet(id, planetId, planet));
            }
            catch (FormatException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}/planet/{planetId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Planet))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeletePlanet(Guid id, Guid planetId)
        {
            try
            {
                _repository.DeletePlanet(id, planetId);
                return NoContent();
            }
            catch (FormatException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
