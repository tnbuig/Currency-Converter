using OG.CC.Utils.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace OG.CC.Client.Desktop.Model
{
    /// <summary>
    /// Persistency manager manage the application state (the naming is confusing)
    /// this manager violate S.O.A.P as it does two things:
    /// 1. Tracking App state.
    /// 2. Persiste State.
    /// </summary>
    public class PersistencyManager : IPersistencyManager
    {
        private const string _defaultBaseTicker = "EUR";
        private const string _defaultSelectedCurrencies = "AUD,USD,CHF";
        private ICurrencyManager _currencyManager;
        private Currency _baseCurrency;
        private List<Currency> _selectedCurrencies;

        public PersistencyManager(ICurrencyManager currencyManager)
        {
            _currencyManager = currencyManager;
            Initialize();
        }

        /// <summary>
        /// The base currency - as store in the settings file.
        /// </summary>
        public Currency BaseCurrency
        {
            get { return _baseCurrency; }
            set
            {
                if (value == null) return;

                _baseCurrency = value;
                Properties.Settings.Default.BaseCurrency = value.Ticker;
                Properties.Settings.Default.Save();
            }
        }

        /// <summary>
        /// Retrieve the currencies which were selcted by the user.
        /// </summary>
        public IEnumerable<Currency> GetSelectedCurrencies()
        {
            return _selectedCurrencies;
        }

        /// <summary>
        /// Add currency to the selected currencies list and persist the change.
        /// </summary>
        public void AddSelectedCurrency(Currency currency)
        {
            if (!_selectedCurrencies.Contains(currency))
            {
                _selectedCurrencies.Add(currency);
                Properties.Settings.Default.Currencies = string.Join(",", _selectedCurrencies.Select(c => c.Ticker));
                Properties.Settings.Default.Save();
            }
        }

        /// <summary>
        /// Remove currency to the selected currencies list and persist the change.
        /// </summary>
        public void RemoveSelectedCurrency(Currency currency)
        {
            if (_selectedCurrencies.Contains(currency))
            {
                _selectedCurrencies.Remove(currency);
                Properties.Settings.Default.Currencies = string.Join(",", _selectedCurrencies.Select(c => c.Ticker));
                Properties.Settings.Default.Save();
            }
        }

        private void Initialize()
        {
            string baseCurrencyTicker = Properties.Settings.Default.BaseCurrency;
            baseCurrencyTicker = baseCurrencyTicker.IsNullOrWhiteSpace() ? _defaultBaseTicker : baseCurrencyTicker;

            BaseCurrency = _currencyManager.GetCurrencyByTicker(baseCurrencyTicker);

            var selectedCurrencies = Properties.Settings.Default.Currencies;
            selectedCurrencies = selectedCurrencies.IsNullOrWhiteSpace() ?
                _defaultSelectedCurrencies : selectedCurrencies;

            var currenciesTickers = selectedCurrencies.Split(',');
            _selectedCurrencies = new List<Currency>();
            foreach (var ticker in currenciesTickers)
            {
                _selectedCurrencies.Add(_currencyManager.GetCurrencyByTicker(ticker));
            }
        }
    }
}