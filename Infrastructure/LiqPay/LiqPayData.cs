using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.LiqPay
{
    public class LiqPayData
    {
        public string public_key { get; set; }
        public string action { get; set; }
        public decimal amount { get; set; }
        public string currency { get; set; }
        public string description { get; set; }
        public string order_id { get; set; }
        public int version { get; set; }
        public string result_url { get; set; }
        public string card { get; set; }
        public string card_cvv { get; set; }
        public string card_exp_month { get; set; }
        public string card_exp_year { get; set; }
    }
}