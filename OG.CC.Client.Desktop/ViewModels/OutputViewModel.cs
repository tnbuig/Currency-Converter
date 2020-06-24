using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using OG.CC.Client.Desktop.Messages;
using OG.CC.Client.Desktop.Model;
using System;
using System.Collections.ObjectModel;

namespace OG.CC.Client.Desktop.ViewModels
{
    public class OutputViewModel : ViewModelBase
    {
        private readonly IMessenger _messenger;
        private readonly ICurrencyManager _currencyManager;
        private readonly IPersistencyManager _persistencyManager;
        private CurrencyViewModel _selectedCurrency;

        public OutputViewModel(ICurrencyManager currencyManager, IPersistencyManager persistencyManager, IMessenger messenger)
        {
            Currencies = new ObservableCollection<CurrencyViewModel>();
            _currencyManager = currencyManager;
            _persistencyManager = persistencyManager;
            _messenger = messenger;
            _messenger.Register<CurrencyAddedMessage>(this, OnCurrencyAdded);

            Initialize();
        }

        public CurrencyViewModel SelectedCurrency
        {
            get { return _selectedCurrency; }
            set
            {
                Set(ref _selectedCurrency, value);
                if (value != null)
                {
                    OnCurrencyRemoved(_selectedCurrency);
                }
            }
        }

        private void OnCurrencyAdded(CurrencyAddedMessage message)
        {
            Currencies.Add(new CurrencyViewModel(message.Currency, _currencyManager, _messenger));
            _persistencyManager.AddSelectedCurrency(message.Currency);
        }

        private void OnCurrencyRemoved(CurrencyViewModel currencyViewModel)
        {
            Currencies.Remove(currencyViewModel);
            _messenger.Send(new CurrencyRemovedMessage(currencyViewModel.Currency));
            _persistencyManager.RemoveSelectedCurrency(currencyViewModel.Currency);
        }

        public ObservableCollection<CurrencyViewModel> Currencies { get; set; }

        private void Initialize()
        {
            foreach (var cur in _persistencyManager.GetSelectedCurrencies())
            {
                Currencies.Add(new CurrencyViewModel(cur, _currencyManager, _messenger));
            }
        }

    }
}