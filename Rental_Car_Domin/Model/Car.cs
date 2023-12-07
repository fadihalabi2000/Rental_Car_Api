using Rental_Car_Domin.Abstraction.Classes;
using Rental_Car_Domin.Abstraction.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_Car_Domin.Model
{
   public  class Car: BaseNormalEntity
    {
        
    
        public string ?CarNumber { get; set; }
        public string ?EngineNumber { get; set; }
        public string ?Manufacturer { get; set; }
        public DateTime ManufacturingDate { get; set; }
        public bool IsAvilaple { get; set; } = false;
        public bool IsReserved { get; set; }
        public string ?FuelType { get; set; }
        public string ?Color { get; set; }
        public string ?Notes { get; set; }
    }

}

