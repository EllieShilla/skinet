using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class CustomerBasket
    {
        public CustomerBasket()
        {
        }

        public CustomerBasket(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
        public List<BascketItem> Items { get; set; } = new List<BascketItem>();
        public int? DeliveryMethodId { get; set; }
        public string ClientSecret { get; set; }
        public string? PaymentIntentId { get; set; }
        public decimal ShippingPrice { get; set; }
        public string Status { get; set; }
    }
}