using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_Car_Domin.View
{
    public class CustomerView
    {
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime DeniedEndDate { get; set; }= DateTime.MinValue;
        public string? NationalID { get; set; }
    }
}
