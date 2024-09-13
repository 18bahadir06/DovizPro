using BusinessLayer.Abstract;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CurrencyApiManager : ICurrencyService
    {
        private readonly string _apiKey = "c4ca4f6f2a55d89e3f34ce86cb862b30";
        private readonly string _baseApiUrl = "https://data.fixer.io/api/latest";
        private readonly HttpClient _httpClient = new HttpClient();
        public async Task<JObject> GetRatesAsync()
        {
            var apiUrl = $"{_baseApiUrl}?access_key={_apiKey}&symbols=USD,EUR,TRY";
            var response = await _httpClient.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            var currencyJson = JObject.Parse(responseBody);
            return currencyJson;
        }

        public decimal trytoeuro(JObject data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            decimal euroRate = (decimal)data["rates"]["TRY"] / (decimal)data["rates"]["EUR"];
            return euroRate;
        }

        public decimal trytousd(JObject data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }
            decimal usdRate = (decimal)data["rates"]["USD"];
            decimal tryRate = (decimal)data["rates"]["TRY"];
            decimal tryToUsd = tryRate / usdRate;
            return tryToUsd;
        }

    }
}
