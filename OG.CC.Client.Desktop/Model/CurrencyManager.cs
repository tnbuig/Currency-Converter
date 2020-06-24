using OG.CC.Client.Desktop.Messages;
using OG.CC.Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using WeakEvent;

namespace OG.CC.Client.Desktop.Model
{
    /// <summary>
    /// Manager all currencies and their rates.
    /// this is the core logic of this applicaion.
    /// </summary>
    public class CurrencyManager : ICurrencyManager
    {
        private IForexService _forexService;
        private Dictionary<string, decimal> _ratesDic;
        private Dictionary<string, Currency> _currenciesDic;
        private readonly WeakEventSource<RatesChangedEventArgs> _ratesUpdatedEventSource =
            new WeakEventSource<RatesChangedEventArgs>();

        public CurrencyManager(IForexService forexService)
        {
            _forexService = forexService;

            Initialize();
        }

        /// <summary>
        /// Event to notify listeners that rates have been updated
        /// Weak event to protect from memory leak.
        /// </summary>
        public event EventHandler<RatesChangedEventArgs> RatesUpdatedEvent
        {
            add { _ratesUpdatedEventSource.Subscribe(value); }
            remove { _ratesUpdatedEventSource.Unsubscribe(value); }
        }

        /// <summary>
        /// Calcualte the rate of a certain currency.
        /// </summary>
        public decimal Calculate(string ticker)
        {
            try
            {
                return _ratesDic[ticker];
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Return a <see cref="Currency"/> object by a given currency ticker (e.g. "EUR")
        /// </summary>
        public Currency GetCurrencyByTicker(string ticker)
        {
            return _currenciesDic[ticker];
        }

        /// <summary>
        /// Update the base rate and get a new mapping of converstion rates from 
        /// <see cref="ForexService"/>.
        /// </summary>
        public void UpdateRates(Currency baseCurrency)
        {
            if (baseCurrency?.Ticker != null)
            {
                _ratesDic = _forexService.GetRates(baseCurrency.Ticker);
                _ratesUpdatedEventSource.Raise(this, new RatesChangedEventArgs(_ratesDic));
            }
        }

        // <summary>
        /// Flag which indicate whether the pc is no longer connected to the internet,
        /// and the rates are not being updated.
        /// </summary>
        public bool IsOffline { get; private set; }

        /// <summary>
        /// Flag which indicate whether the manager has been initialize.
        /// </summary>
        public bool IsInitialized { get; private set; }

        /// <summary>
        /// All currencies that the app supports.
        /// </summary>
        public IEnumerable<Currency> Currencies => _currenciesDic.Values;

        /// <summary>
        /// The date of the last rates update, indicate how actual are the values.
        /// </summary>
        public DateTime LastUpdated { get; private set; }

        private void Initialize()
        {
            _ratesDic = _forexService.GetRates();

            var currenciesDic = _forexService.GetCurrenciesData();
            if (_ratesDic != null)
            {
                // Choose only currencies which we can get data for.
                _currenciesDic = currenciesDic.Where(r => _ratesDic.ContainsKey(r.Key) || r.Key == "EUR").
                    ToDictionary(t => t.Key, t => new Currency(t.Key, t.Value));
                IsOffline = false;
                IsInitialized = true;
            }
        }
    }
}