using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.LiqPay
{
    public class LiqPayPayProces
    {
        private readonly HttpClient httpClient;

        public LiqPayPayProces()
        {
            //Create the request sender object
            httpClient = new HttpClient();

            //Set the headers
            // httpClient.DefaultRequestHeaders.UserAgent.TryParseAdd("MessageService/3.1");

        }
        public async Task<ResponceLiqPay> PayAsync(LiqPayData data)
        {
            var url = "https://www.liqpay.ua/api/request";

            string message = GetDataAndSignature(data);

            var response = await httpClient.PostAsync(url, new StringContent(message, Encoding.UTF8, "application/x-www-form-urlencoded"));

            //Check for error status
            response.EnsureSuccessStatusCode();

            var tmp=await response.Content.ReadAsStringAsync();
            var liqpayRespose=Newtonsoft.Json.JsonConvert.DeserializeObject<ResponceLiqPay>(tmp);

            //Get the response content
            return liqpayRespose;
        }

        private string GetDataAndSignature(LiqPayData liqPayData)
        {
            var data = Newtonsoft.Json.JsonConvert.SerializeObject(liqPayData);
            var base_data = Convert.ToBase64String(Encoding.UTF8.GetBytes(data));
            var sign_string = LiqPayKeys.PrivateKey + base_data + LiqPayKeys.PrivateKey;

            var signature = Convert.ToBase64String(SHA1.Create().ComputeHash(Encoding.UTF8.GetBytes(sign_string)));

            var dataList = new Dictionary<string, string>()
            {
                {"data", base_data}, {"signature", signature}
            };

            var dataString = $"data={base_data}&signature={signature}";

            return dataString;
        }
    }
}