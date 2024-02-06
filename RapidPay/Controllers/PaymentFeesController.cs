using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RapidPay.Controllers
{
    // Create a controller for the payment fees module
    [ApiController]
    [Route("api/paymentfees")]
    public class PaymentFeesController : ControllerBase
    {
        // GET: api/paymentfees
        [HttpGet]
        public ActionResult<decimal> GetPaymentFee()
        {
            UniversalFeesExchange ufe = UniversalFeesExchange.Instance;
            decimal fee = ufe.GetFee();
            return Ok(fee);
        }
    }
}
