using BLL;
using DAL;
using Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingSystem.BLL
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepo;

        public BookingService(IBookingRepository bookingRepo)
        {
            _bookingRepo = bookingRepo;
        }

        public async Task<IEnumerable<Booking>> GetAllBookings()
        {
            return await _bookingRepo.GetAllAsync();
        }

        public async Task<string> CreateBooking(Booking booking)
        {
            var allBookings = await _bookingRepo.GetAllAsync();
            var isSlotBusy = allBookings.Any(b =>
                b.SlotId == booking.SlotId &&
                booking.StartTime <= b.EndTime &&
                booking.EndTime >= b.StartTime);

            if (isSlotBusy)
                return "This slot is already booked!";

            await _bookingRepo.AddAsync(booking);
            return "Booking created successfully!";
        }

        public async Task<string> UpdateBooking(Booking booking)
        {
            var allBookings = await _bookingRepo.GetAllAsync();
            var isSlotBusy = allBookings.Any(b =>
                b.Id != booking.Id &&  // exclude current booking
                b.SlotId == booking.SlotId &&
                booking.StartTime <= b.EndTime &&
                booking.EndTime >= b.StartTime);

            if (isSlotBusy)
                return "This slot is already booked!";

            await _bookingRepo.UpdateAsync(booking);
            return "Booking updated successfully!";
        }

        public async Task<string> DeleteBooking(int bookingId)
        {
            var booking = await _bookingRepo.GetByIdAsync(bookingId);
            if (booking == null)
                return "Booking not found!";

            await _bookingRepo.UpdateAsync(booking);
            return "Booking deleted successfully!";
        }
    }

}
