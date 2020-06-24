using GalaSoft.MvvmLight.Messaging;
using OG.CC.Client.Desktop.Model;

namespace OG.CC.Client.Desktop.Messages
{
    /// <summary>
    /// Message to notify all listeners that a currency has been un-selected.
    /// That mean that the rates will no longer be caluclated and displayed to the user.
    /// </summary>
    public class CurrencyRemovedMessage : MessageBase
    {
        public CurrencyRemovedMessage(Currency removedCurrency)
        {
            Currency = removedCurrency;
        }

        /// <summary>
        /// The currency that has been removed (un-selected).
        /// </summary>
        public Currency Currency { get; private set; }
    }
}