using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using OG.CC.Client.Desktop.Messages;
using OG.CC.Client.Desktop.Model;
using System;
using System.Collections.ObjectModel;

namespace OG.CC.Client.Desktop.ViewModels
{
    /// <summary>
    /// View model for user input,
    /// 1. Base Currency - The currency which the user would like to convert from (e.g EUR)
    /// 2. Base currency amount - the sum which the user want to calculate convertion for.
    /// </summary>
    public class InputViewModel : ViewModelBase
    {
        private DateTime _lastUpdateDate;
        private decimal _baseCurrencyAmount = 1;
        private Currency _baseCurrency;
        private readonly ICurrencyManager _currencyManager;
        private readonly IMessenger _messanger;

        public InputViewModel(ICurrencyManager currencyManager, PersistencyManager persistencyManager, IMessenger messanger)
        {
            _currencyManager = currencyManager;
            Currencies = new ObservableCollection<Currency>(
                currencyManager.Currencies);
            _messanger = messanger;
            BaseCurrency = persistencyManager.BaseCurrency;
        }

        /// <summary>
        /// TODO: this should always show the last time an API Call been made to update the rates.
        /// </summary>
        public DateTime LastUpdateDate
        {
            get
            {
                return _lastUpdateDate;
            }
            set
            {
                Set(ref _lastUpdateDate, value);
            }
        }

        /// <summary>
        /// The amount the user want to convert.
        /// </summary>
        public Decimal BaseCurrencyAmount
        {
            get { return _baseCurrencyAmount; }
            set
            {
                if (_baseCurrencyAmount != value)
                {
                    Set(ref _baseCurrencyAmount, value);
                    _messanger.Send(new AmountChangedMessage(value));
                }
            }
        }

        /// <summary>
        /// The base currency the user want to convert from. (e.g EUR)
        /// </summary>
        public Currency BaseCurrency
        {
            get { return _baseCurrency; }
            set
            {
                if (_baseCurrency != value)
                {
                    Set(ref _baseCurrency, value);
                    _currencyManager.UpdateRates(_baseCurrency);
                }
            }
        }

        /// <summary>
        /// List of all currencies the user can choose to convert from.
        /// </summary>
        public ObservableCollection<Currency> Currencies { get; set; }
    }
}