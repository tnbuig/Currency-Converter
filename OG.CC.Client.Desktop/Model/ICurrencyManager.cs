using OG.CC.Client.Desktop.Messages;
using System;
using System.Collections.Generic;

namespace OG.CC.Client.Desktop.Model
{
    /// <summary>
    /// Manager all currencies and their rates.
    /// this is the core logic of this applicaion.
    /// </summary>
    public interface ICurrencyManager
    {
        /// <summary>
        /// Event to notify listeners that rates have been updated
        /// Weak event to protect from memory leak.
        /// </summary>
        event EventHandler<RatesChangedEventArgs> RatesUpdatedEvent;

        /// <summary>
        /// All currencies that the app supports.
        /// </summary>
        IEnumerable<Currency> Currencies { get; }


        /// <summary>
        /// Return a <see cref="Currency"/> object by a given currency ticker (e.g. "EUR")
        /// </summary>
        Currency GetCurrencyByTicker(string ticker);

        /// <summary>
        /// Flag which indicate whether the manager has been initialize.
        /// </summary>
        bool IsInitialized { get; }

        /// <summary>
        /// Flag which indicate whether the pc is no longer connected to the internet,
        /// and the rates are not being updated.
        /// </summary>
        bool IsOffline { get; }

        /// <summary>
        /// The date of the last rates update, indicate how actual are the values.
        /// </summary>
        DateTime LastUpdated { get; }

        /// <summary>
        /// Calcualte the rate of a certain currency.
        /// </summary>
        decimal Calculate(string ticker);

        /// <summary>
        /// Update the base rate and get a new mapping of converstion rates from 
        /// <see cref="ForexService"/>.
        /// </summary>
        void UpdateRates(Currency baseCurrency);
    }
}