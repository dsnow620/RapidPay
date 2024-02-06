using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RapidPay.Controllers
{
    // Create a controller for the card management module
    [ApiController]
    [Route("api/card")]
    public class CardController : ControllerBase
    {
        private static List<Card> cardList = new List<Card>();

        // POST: api/card/create
        [HttpPost("create")]
        public ActionResult<string> CreateCard()
        {
            // Generate a 15-digit card number
            Random random = new Random();
            string cardNumber = random.Next(100000000, 999999999).ToString() +
            random.Next(100000000, 999999999).ToString();

            // Create a new card with zero balance
            Card card = new Card
            {
                Number = cardNumber,
                Balance = 10
            };

            cardList.Add(card);

            return Ok(cardNumber);
        }

        // POST: api/card/pay
        [HttpPost("pay")]
        public ActionResult<string> Pay([FromBody] PayRequest payRequest)
        {
            // Find the card in the card list
            Card card = cardList.Find(c => c.Number == payRequest.CardNumber);

            if (card == null)
            {
                return NotFound();
            }

            // Get the payment fee
            UniversalFeesExchange ufe = UniversalFeesExchange.Instance;
            decimal fee = ufe.GetFee();
    

            // Calculate the payment amount after deducting the fee
            decimal paymentAmount = payRequest.Amount - fee;

            if (paymentAmount < 0.00M)
            {
                return BadRequest("Payment amount is less than the fee.");
            }

            // Update the card balance
            card.Balance -= paymentAmount;

            return Ok($"Payment of {paymentAmount} was made using card {payRequest.CardNumber}. Fee: {fee}");
        }

        // GET: api/card/balance/{cardNumber}
        [HttpGet("balance/{cardNumber}")]
        public ActionResult<decimal> GetCardBalance(string cardNumber)
        {
            // Find the card in the card list
            Card card = cardList.Find(c => c.Number == cardNumber);

            if (card == null)
            {
                return NotFound();
            }

            return Ok(card.Balance);
        }
    }
}
