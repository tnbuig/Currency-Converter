using GalaSoft.MvvmLight.Messaging;

namespace OG.CC.Client.Desktop.Messages
{
    /// <summary>
    /// Message to notify all listeners that the amount needed to convert has changed.
    /// That mean that the convertion will be re-caluclated.
    /// </summary>
    public class AmountChangedMessage : MessageBase
    {
        public AmountChangedMessage(decimal newAmount)
        {
            NewAmount = newAmount;
        }

        public decimal NewAmount { get; }
    }
}