using Rental_Car_Domin.Abstraction.Classes;
using Rental_Car_Domin.Abstraction.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_Car_Domin.Model
{
    public class FinancialTransaction : BaseNormalEntity
    {

        public int BookingID { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public TransactionType transaction { get; set; } // Enum (تأجير، إرجاع، حساب كلفة، إيداع في الصندوق)
        public Double Amount { get; set; }
        public DateTime ReturnDateTime { get; set; }=DateTime.Now;
        public double Total_Fund{get; set;}
    public virtual Booking? Booking { get; set; }
    }

}
