using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;

namespace OG.CC.Logic.Services
{
    /// <summary>
    /// Simple service to get forex data:
    /// 1. conversoin rates.
    /// 2. Currencies data.
    /// </summary>
    public class ForexService : IForexService
    {
        private const string exchangeratesApi = "https://api.exchangeratesapi.io/latest";
        private const string currenciessApi = "https://openexchangerates.org/api/currencies.json";

        /// <summary>
        /// Get rates for currencies for default base currency ("EUR")
        /// </summary>
        public Dictionary<string, decimal> GetRates()
        {
            return internalGetRates(exchangeratesApi);
        }

        /// <summary>
        /// Get rates for currencies in compare to specific currency.
        /// </summary>
        public Dictionary<string, decimal> GetRates(string baseCurrency)
        {
            var api = string.IsNullOrWhiteSpace(baseCurrency) ?
                exchangeratesApi : $"{exchangeratesApi}?base={baseCurrency.ToUpper().Trim()}";

            return internalGetRates(api);
        }

        /// <summary>
        /// Get data of currencies.
        /// </summary>
        public Dictionary<string, string> GetCurrenciesData()
        {
            try
            {
                var client = new RestClient(currenciessApi);
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Get(request);

                var result = JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Content);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private Dictionary<string, decimal> internalGetRates(string api)
        {
            try
            {
                var client = new RestClient(api);
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Get(request);
                var rates = JObject.Parse(response.Content)["rates"].ToString();
                var result = JsonConvert.DeserializeObject<Dictionary<string, decimal>>(rates);

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}