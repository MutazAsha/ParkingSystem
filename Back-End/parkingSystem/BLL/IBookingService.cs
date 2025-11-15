using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IBookingService
    {
        Task<IEnumerable<Booking>> GetAllBookings();
        Task<string> CreateBooking(Booking booking);
        Task<string> UpdateBooking(Booking booking);
        Task<string> DeleteBooking(int bookingId);
    }

}
