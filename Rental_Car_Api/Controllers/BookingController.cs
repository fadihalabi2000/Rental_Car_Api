using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rental_Car_DataAccess;
using Rental_Car_Domin.Abstraction.Enum;
using Rental_Car_Domin.Model;
using Rental_Car_Domin.View;
using System.Xml.Linq;

namespace Rental_Car_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly CarRentalDbContext _context;
        public BookingController(CarRentalDbContext context)
        {
            _context = context;
        }

        [HttpPost(Name = "Booking Request"),]
        public async Task<IActionResult> BookCar(int carId, int customerId)
        {
            try
            {
                var customer = await _context.Customers.FindAsync(customerId);


                var car = await _context.Cars.FindAsync(carId);

                if (car == null)
                {
                    return NotFound("Car not found");
                }

                else if (car.IsReserved)
                {
                    return Conflict("Car is already reserved");
                }



                if (customer == null)
                {
                    return NotFound("Customer not found");
                }
                else {
                    using var transaction = await _context.Database.BeginTransactionAsync();

                    try
                    {
                        car.IsReserved = true;
                        _context.Update(car);

                        await _context.SaveChangesAsync();

                        var booking = new Booking
                        {
                            CarID = carId,
                            CustomerID = customerId,
                            reservationStatus = ReservationStatus.Reservation,
                            ReservationDateTime = DateTime.Now, // تعيين وقت الحجز
                            PickupDateTime = DateTime.Now.AddDays(1) // تعيين وقت الاستلام بعد يوم واحد مثلًا
                        };

                        _context.Bookings.Add(booking);
                        await _context.SaveChangesAsync();

                        await transaction.CommitAsync();
                        return Ok("Car booked successfully");
                    }
                    catch (DbUpdateException)
                    {
                        await transaction.RollbackAsync();
                        return Conflict("filed to rental");
                    }


                }
                } 
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            } 
        }
       
    }
}
    

