using Rental_Car_Domin.Abstraction.Interfacess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_Car_Domin.Abstraction.Classes
{
    public abstract class BaseEntity
    {
        public bool IsAvilaple { get ; set; }=false;   
    }
}
