using System.Collections.Generic;

namespace OG.CC.Logic.Services
{
    /// <summary>
    /// Simple service to get forex data:
    /// 1. conversoin rates.
    /// 2. Currencies data.
    /// </summary>
    public interface IForexService
    {
        /// <summary>
        /// Get data of currencies.
        /// </summary>
        Dictionary<string, string> GetCurrenciesData();

        /// <summary>
        /// Get rates for currencies for default base currency ("EUR")
        /// </summary>
        Dictionary<string, decimal> GetRates();

        Dictionary<string, decimal> GetRates(string defaultCurrency);
    }
}