using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rental_Car_DataAccess;
using Rental_Car_Domin.Abstraction.Enum;
using Rental_Car_Domin.Model;

namespace Rental_Car_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinancialTransactionController : ControllerBase
    {
        private readonly CarRentalDbContext _context;
        public FinancialTransactionController(CarRentalDbContext context)
        {
            _context = context;
        }
        //  FinancialTransaction

        [HttpPost]
        public async Task<IActionResult> ConfirmBooking(int bookingId, double piment)
        {
            try
            {
                var booking = await _context.Bookings.FindAsync(bookingId);
                var customerid = booking.CustomerID;
                var customer = await _context.Customers.FindAsync(customerid);

                if (booking == null)
                {
                    return NotFound("Booking not found");
                }

                var timeDifference = (DateTime.Now - booking.ReservationDateTime).TotalDays;
                var timeDenied = (DateTime.Now - customer.DeniedEndDate).TotalDays;
                if (timeDenied >= 1)//not denied
                {
                   // using var transaction = await _context.Database.BeginTransactionAsync();
                    if (timeDifference <= 1) //Confirm booking 24 hours in advance
                    {
                        
                        const double cost = 100.0;
                        double remainingAmount = 0.0;
                       
                        if (piment >= cost)
                        {
                            remainingAmount = piment - cost;
                            // إذا كان وقت الاستلام يومًا أو أقل، يتم الحجز والدفع
                            var transaction = new FinancialTransaction
                            {
                                BookingID = bookingId,
                                TransactionDateTime = DateTime.Now,
                                transaction = TransactionType.Rental,
                                Amount = cost/* قيمة الاستئجار */,
                                Total_Fund =cost /* المبلغ المدفوع */,
                                ReturnDateTime = booking.PickupDateTime
                            };

                            _context.FinancialTransactions.Add(transaction);
                            await _context.SaveChangesAsync();



                            booking.reservationStatus = ReservationStatus.Reservation;
                            _context.Update(booking);

                            customer.DeniedEndDate = DateTime.MinValue;
                            _context.Update(customer);
                            await _context.SaveChangesAsync();

                            return Ok($"Booking confirmed and payment completed" +
                                      "id boking is :{BookingID } " +
                                      "the  remainingAmount={remainingAmount}");

                        }
                        else { return Conflict($"the mony is not enaf"); }
                    }
                    else
                    {  // إذا كان وقت الاستلام أكثر من يوم واحد، يتم الإلغاء وحرمان المستخدم لمدة شهر
                        booking.reservationStatus = ReservationStatus.Cancellation;
                        _context.Update(booking);

                        //var customer = await _context.Customers.FindAsync(booking.CustomerID);

                        if (customer != null)
                        {

                            customer.DeniedEndDate = DateTime.Now.AddMonths(1);
                            _context.Update(customer);
                        }

                        await _context.SaveChangesAsync();

                        return Ok("Booking canceled and user is denied for a month");
                    }
                }
                else
                {
                    return Conflict($" the user is denied" +
                                          $"from rental");

                }
            }

            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
