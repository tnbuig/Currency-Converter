using GalaSoft.MvvmLight.Messaging;
using OG.CC.Client.Desktop.Model;

namespace OG.CC.Client.Desktop.Messages
{
    /// <summary>
    /// Message to notify all listeners that a currency has been selected.
    /// That mean that the rates will be caluclated and displayed to the user.
    /// </summary>
    public class CurrencyAddedMessage : MessageBase
    {
        public CurrencyAddedMessage(Currency addedCurrency)
        {
            Currency = addedCurrency;
        }

        /// <summary>
        /// The currency that has been added (selected).
        /// </summary>
        public Currency Currency { get; private set; }
    }
}