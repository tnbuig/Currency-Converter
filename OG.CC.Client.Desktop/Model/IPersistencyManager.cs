using System.Collections.Generic;

namespace OG.CC.Client.Desktop.Model
{
    /// <summary>
    /// Persistency manager manage the application state (the naming is confusing)
    /// this manager violate S.O.A.P as it does two things:
    /// 1. Tracking App state.
    /// 2. Persiste State.
    /// </summary>
    public interface IPersistencyManager
    {
        /// <summary>
        /// The base currency - as store in the settings file.
        /// </summary>
        Currency BaseCurrency { get; set; }

        /// <summary>
        /// Retrieve the currencies which were selcted by the user.
        /// </summary>
        IEnumerable<Currency> GetSelectedCurrencies();

        /// <summary>
        /// Add currency to the selected currencies list and persist the change.
        /// </summary>
        void AddSelectedCurrency(Currency currency);

        /// <summary>
        /// Remove currency to the selected currencies list and persist the change.
        /// </summary>
        void RemoveSelectedCurrency(Currency currency);
    }
}