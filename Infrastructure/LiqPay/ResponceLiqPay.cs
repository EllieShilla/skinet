using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.LiqPay
{
    public class ResponceLiqPay
    {
        public string result { get; set; }
        public long payment_id { get; set; }
        public string action { get; set; }
        public string status { get; set; }
        public string err_code { get; set; }
        public string err_description { get; set; }
        public int version { get; set; }
        public string type { get; set; }
        public string public_key { get; set; }
        public int acq_id { get; set; }
        public string order_id { get; set; }
        public string liqpay_order_id { get; set; }
        public string description { get; set; }
        public double amount { get; set; }
        public string currency { get; set; }
        public string mpi_eci { get; set; }
        public bool is_3ds { get; set; }
        public long create_date { get; set; }
        public long end_date { get; set; }
        public long transaction_id { get; set; }
        public string key { get; set; }
        public string code { get; set; }
    }
}