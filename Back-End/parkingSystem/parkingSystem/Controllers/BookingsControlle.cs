using BLL;
using Microsoft.AspNetCore.Mvc;
using Models;
using ParkingSystem.BLL;
using System.Threading.Tasks;

namespace ParkingSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _service;

        public BookingsController(IBookingService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _service.GetAllBookings();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Booking booking)
        {
            var result = await _service.CreateBooking(booking);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Booking booking)
        {
            booking.Id = id;

            var updated = await _service.UpdateBooking(booking);
            if (updated == null)
                return NotFound();

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteBooking(id);
            if (deleted == null)
                return NotFound();

            return Ok(deleted);
        }
    }
}
