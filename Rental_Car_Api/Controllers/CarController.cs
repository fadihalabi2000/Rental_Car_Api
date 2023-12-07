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
    public class CarController : ControllerBase
    {
        private readonly CarRentalDbContext _context;
        public CarController(CarRentalDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetCars()
        {
            
            return await  _context.Cars.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCar(int id)
        {
            var car = await _context.Cars.FindAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            return car;
        }

        // POST: api/Car
        [HttpPost]
        public async Task<ActionResult<CarView>> PostCar(CarView carview)
        {   Car car=new Car { CarNumber=carview.CarNumber 
                             ,EngineNumber=carview.EngineNumber,
                              Color=carview.Color,
                              FuelType=carview.FuelType
                              ,IsAvilaple=carview.IsAvilaple
                              ,IsReserved=carview.IsReserved,
                               Manufacturer= carview.Manufacturer,
                               ManufacturingDate= carview.ManufacturingDate,
                               Notes=carview.Notes
        };
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // PUT: api/Car/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCar(int id, Car car)
        {
            if (id != car.ID)
            {
                return BadRequest();
            }

            var existingCar = await _context.Cars.FindAsync(id);

            if (existingCar == null)
            {
                return NotFound();
            }

            existingCar.CarNumber = car.CarNumber;
            existingCar.EngineNumber = car.EngineNumber;
            existingCar.Manufacturer = car.Manufacturer;
            existingCar.ManufacturingDate = car.ManufacturingDate;
            existingCar.IsReserved = car.IsReserved;
            existingCar.FuelType = car.FuelType;
            existingCar.Color = car.Color;
            existingCar.IsAvilaple = car.IsAvilaple;
            existingCar.Notes = car.Notes;

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
        public async Task<IActionResult> DeleteCar(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarExists(int id)
        {
            return _context.Cars.Any(e => e.ID == id);
        }
    }


}

