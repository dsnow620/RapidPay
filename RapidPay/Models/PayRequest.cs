using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapidPay.Models
{
    // Create a model class for the pay request
    public class PayRequest
    {
        public string CardNumber { get; set; }
        public decimal Amount { get; set; }
    }

}
