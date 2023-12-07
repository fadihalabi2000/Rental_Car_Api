using Rental_Car_Domin.Abstraction.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_Car_Domin.Model
{
    public class Customer:BaseNormalEntity
    {
        public Customer()
        {
            DeniedEndDate  = DateTime.MinValue;
        } 
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string? NationalID { get; set; }
        public DateTime DeniedEndDate { get; set; }

    }
}
