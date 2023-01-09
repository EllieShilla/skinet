using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Errors;
using Core.Entities;
using Core.Entities.OrderAggregate;
using Core.Interfaces;
using Infrastructure.LiqPay;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PaymentsController : BaseAPIController
    {
        private readonly IPaymentService _paymentService;
        private const string WhSecret = "";

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [Authorize]
        [HttpPost("{basketId}/{cardData}")]
        public async Task<ActionResult<CustomerBasket>> CreateOrUpdatePaymentIntent(string basketId, CardData cardData)
        {
            var basket = await _paymentService.CreateOrUpdatePaymentIntent(basketId, cardData.Card, cardData.CardCvv, cardData.CardExpMonth, cardData.CardExpYear);

            if (basket == null)
                return BadRequest(new APIResponse(400, "Problem with your basket"));

            return basket;
        }



    }
}