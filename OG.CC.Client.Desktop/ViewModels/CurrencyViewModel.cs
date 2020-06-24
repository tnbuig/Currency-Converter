using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using OG.CC.Client.Desktop.Messages;
using OG.CC.Client.Desktop.Model;
using System;

namespace OG.CC.Client.Desktop.ViewModels
{
    /// <summary>
    /// View Model of a singel currency this will keep the info which relevant to a singal
    /// currency.
    /// </summary>
    public class CurrencyViewModel : ViewModelBase
    {
        private decimal _rate = 1;
        private decimal _amount = 1;
        private decimal _value = 1;

        public CurrencyViewModel(Currency currency, ICurrencyManager currencyManager,  IMessenger messanger)
        {
            Currency = currency;

            currencyManager.RatesUpdatedEvent += OnRatestChanged;

            messanger.Register<AmountChangedMessage>(this, OnAmountChanged);
            _rate = currencyManager.Calculate(currency.Ticker);
            Value = _rate * _amount;

        }

        /// <summary>
        /// The covnertion rate of this currency in compare to the base currency.
        /// </summary>
        public decimal Value
        {
            get
            {
                return _value;
            }
            set
            {
                Set(ref _value, value);
            }
        }

        /// <summary>
        /// The currency data (ticker and name).
        /// </summary>
        public Currency Currency { get; set; }


        private void OnAmountChanged(AmountChangedMessage message)
        {
            _amount = message.NewAmount;
            Value = _amount * _rate;
        }

        private void OnRatestChanged(object sender, RatesChangedEventArgs e)
        {
            _rate = e.ratesDic[Currency.Ticker];
            Value = _rate * _amount;
        }
    }
}