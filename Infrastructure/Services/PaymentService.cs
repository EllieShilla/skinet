using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.OrderAggregate;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Infrastructure.LiqPay;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Product = Core.Entities.Product;

namespace Infrastructure.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBasketRepository _basketRepository;
        private readonly IConfiguration _config;
        private readonly ILogger<PaymentService> _logger;
        public PaymentService(IBasketRepository basketRepository, IUnitOfWork unitOfWork,
        IConfiguration config, ILogger<PaymentService> logger)
        {
            _config = config;
            _basketRepository = basketRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<CustomerBasket> CreateOrUpdatePaymentIntent(string basketId, string card, string cvv, string month, string year)
        {
            LiqPayKeys.PrivateKey = _config["LiqPaySettings:SecretKey"];

            var basket = await _basketRepository.GetBascketAsync(basketId);

            if (basket == null)
            {
                return null;
            }

            decimal shippingPrice = 0;

            if (basket.DeliveryMethodId.HasValue)
            {
                var deliveryMethod = await _unitOfWork.Repository<DeliveryMethod>()
                    .GetByIdAsync((int)basket.DeliveryMethodId);
                shippingPrice = deliveryMethod.Price;
            }

            foreach (var item in basket.Items)
            {
                var productItem = await _unitOfWork.Repository<Product>().GetByIdAsync(item.Id);
                if (item.Price != productItem.Price)
                    item.Price = productItem.Price;
            }

            var liqPayData = new LiqPayData
            {
                public_key = _config["LiqPaySettings:PublishibleKey"],
                version = 3,
                action = "pay",
                amount = basket.Items.Sum(i => i.Quantity * i.Price) + shippingPrice,
                currency = "UAH",
                description = "test",
                order_id = basket.Id.ToString(),
                result_url = "https://localhost:7178/api/webhook",
                card = card,
                card_cvv = cvv,
                card_exp_month = month,
                card_exp_year = year
            };

            var payProces = new LiqPayPayProces();
            var result = await payProces.PayAsync(liqPayData);
            basket.PaymentIntentId = result.payment_id.ToString();
            basket.Status = result.status;

            return await _basketRepository.UpdateBascketAsync(basket);
        }
    }
}