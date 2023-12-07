using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rental_Car_DataAccess;
using Rental_Car_Domin.Model;
using Rental_Car_Domin.View;

namespace Rental_Car_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CarRentalDbContext _context;
        public CustomerController(CarRentalDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCars()
        {

            return await _context.Customers.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCar(int id)
        {
            var Customer = await _context.Customers.FindAsync(id);

            if (Customer == null)
            {
                return NotFound();
            }

            return Customer;
        }

        // POST: api/Car
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCar(CustomerView customerview)
        {
            Customer customer  = new Customer
            {
                FirstName= customerview.FirstName,
                LastName= customerview.LastName,
                MiddleName= customerview.MiddleName,
                BirthDate= customerview.BirthDate,
                NationalID = customerview.NationalID
            };
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // PUT: api/Car/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCar(int id, Customer customer)
        {
            if (id != customer.ID)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Car/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarExists(int id)
        {
            return _context.Cars.Any(e => e.ID == id);
        }
    }
}
