using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using OG.CC.Client.Desktop.Messages;
using OG.CC.Client.Desktop.Model;
using System.Collections.ObjectModel;
using System.Linq;

namespace OG.CC.Client.Desktop.ViewModels
{
    /// <summary>
    /// View model for selection of currecies to be calcualte.
    /// The user can see all available currencies and to select the one he/she interested in.
    /// </summary>
    /// <remarks>
    /// Currencies which have been selected will be removed from list.
    /// </remarks>
    public class CurrencySelectionViewModel : ViewModelBase
    {
        private readonly IMessenger _messenger;
        private readonly IPersistencyManager _persistencyManager;
        private Currency _selectedCurrency;

        public CurrencySelectionViewModel(ICurrencyManager currencyManager, IPersistencyManager persistencyManager, IMessenger messenger)
        {
            Initialize(currencyManager, persistencyManager);

            _messenger = messenger;
            _persistencyManager = persistencyManager;
            _messenger.Register<CurrencyRemovedMessage>(this, OnCurrencyRemoved);
        }

        /// <summary>
        /// The currency which the user just now selected.
        /// This currency will be removed from this Selection-View and move to the
        /// output panel <see cref="OutputViewModel"/>
        /// </summary>
        public Currency SelectedCurrency
        {
            get { return _selectedCurrency; }
            set
            {
                Set(ref _selectedCurrency, value);
                if (value != null)
                {
                    OnCurrencyAdded(_selectedCurrency);
                }
            }
        }

        /// <summary>
        /// All currencies that the user can select to show rates for.
        /// Note: This include only those who are not currently been selected.
        /// </summary>
        public ObservableCollection<Currency> Currencies { get; set; }

        /// <summary>
        /// If the user remove a currency from the list of currencies he/she likes to see
        /// then the currency need to be desplayed again in the selection view
        /// (So the user can re-select it if he/she likes to)
        /// </summary>
        private void OnCurrencyRemoved(CurrencyRemovedMessage message)
        {
            Currencies.Add(message.Currency);
        }

        /// <summary>
        /// If User select a currency (i.e want to add it to the list of currecies he/she want to
        /// see the conversion rates for), then we need to remove it from the selection list -
        /// So it will not be selected twice.
        /// Opposite of <see cref="OnCurrencyRemoved(CurrencyRemovedMessage)"/>
        /// </summary>
        private void OnCurrencyAdded(Currency currency)
        {
            Currencies.Remove(currency);
            _messenger.Send(new CurrencyAddedMessage(currency));
        }

        private void Initialize(ICurrencyManager currencyManager, IPersistencyManager persistencyManager)
        {
            var selectedCurrencies = persistencyManager.GetSelectedCurrencies();
            var allCurrencies = currencyManager.Currencies;

            Currencies = new ObservableCollection<Currency>(allCurrencies.Except(selectedCurrencies));
        }
    }
}