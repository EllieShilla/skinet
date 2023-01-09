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
        public async Task<ResponceLiqPay> PayAsync(LiqPayData data)
        {
            var url = "https://www.liqpay.ua/api/request";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "POST";

            httpRequest.ContentType = "application/x-www-form-urlencoded";

            string dataList = GetDataAndSignature(data);

            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                streamWriter.Write(dataList);
            }

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            string result;
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }

            var response = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponceLiqPay>(result);
            return await Task.FromResult(response);
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