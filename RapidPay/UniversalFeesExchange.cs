using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapidPay
{
    // Create a singleton service for the Universal Fees Exchange
    public class UniversalFeesExchange
    {
        private static UniversalFeesExchange instance;
        private decimal lastFeeAmount;

        private UniversalFeesExchange()
        {
            lastFeeAmount = 2;
        }

        public static UniversalFeesExchange Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UniversalFeesExchange();
                }
                return instance;
            }
        }

        public decimal GetFee()
        {
            Random random = new Random();
            decimal randomDecimal = (decimal)random.NextDouble() * 2;
            lastFeeAmount = lastFeeAmount * randomDecimal;
            return lastFeeAmount;
        }
    }
}
