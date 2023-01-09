using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.LiqPay
{
    public class CardData
    {
        public string Card { get; set; }
        public string CardCvv { get; set; }
        public string CardExpMonth { get; set; }
        public string CardExpYear { get; set; }
    }
}