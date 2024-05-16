using BookingServiceAPI.Models.DTOs;
using BookingServiceAPI.Services.Interfaces;
using BookingServiceAPI.Utilities.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookingServiceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccommodationController : ControllerBase
    {
        private readonly IAccommodationService _accommodationService;

        public AccommodationController(IAccommodationService accommodationService)
        {
            _accommodationService = accommodationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccommodationDto>>> GetAllAccommodations()
        {
            try
            {
                var accommodations = await _accommodationService.GetAllAccommodationsAsync();
                return Ok(accommodations);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AccommodationDto>> GetAccommodationById(int id)
        {
            try
            {
                var accommodation = await _accommodationService.GetAccommodationByIdAsync(id);
                return Ok(accommodation);
            }
            catch (AccommodationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<AccommodationDto>> AddAccommodation(AccommodationDto accommodationDto)
        {
            try
            {
                var newAccommodation = await _accommodationService.AddAccommodationAsync(accommodationDto);
                return CreatedAtAction(nameof(GetAccommodationById), new { id = newAccommodation.Id }, newAccommodation);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccommodation(int id, AccommodationDto accommodationDto)
        {
            try
            {
                await _accommodationService.UpdateAccommodationAsync(id, accommodationDto);
                return NoContent();
            }
            catch (AccommodationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccommodation(int id)
        {
            try
            {
                var deletedAccommodation = await _accommodationService.DeleteAccommodationAsync(id);
                return Ok(deletedAccommodation);
            }
            catch (BookingException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
