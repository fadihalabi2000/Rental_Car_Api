using Rental_Car_Domin.Abstraction.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_Car_Domin.Model
{
   public class Booking:BaseNormalEntity
    {
        public int CarID { get; set; }
        public int CustomerID { get; set; }
        public DateTime ReservationDateTime { get; set; }
        public DateTime PickupDateTime { get; set; }
       
        public  ReservationStatus reservationStatus  { get; set; } // Enum (تأكيد، إلغاء، إتمام)
        

        public virtual Car ?Car { get; set; }
        public virtual Customer ?Customer { get; set; }
    }
    public enum ReservationStatus
    {
        Reservation,
        Cancellation
    }
}
