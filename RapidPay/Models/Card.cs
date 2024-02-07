using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapidPay.Models
{
    // Create a model class for the card
    public class Card
    {
        public string Number { get; set; }
        public decimal Balance { get; set; }
    }
}
