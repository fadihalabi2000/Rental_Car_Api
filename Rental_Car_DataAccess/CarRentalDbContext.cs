using Microsoft.EntityFrameworkCore;
using Rental_Car_Domin.Model;

namespace Rental_Car_DataAccess
{
    public class CarRentalDbContext: DbContext
    {
        public CarRentalDbContext(DbContextOptions<CarRentalDbContext> options) : base(options)
        {

        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<FinancialTransaction> FinancialTransactions { get; set; }
        public DbSet<Manager> Managers { get; set; }

     
    
        }
}

