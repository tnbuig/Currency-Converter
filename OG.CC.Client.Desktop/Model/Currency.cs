using System;

namespace OG.CC.Client.Desktop.Model
{
    /// <summary>
    /// Model to represent a Currency.
    /// 1. Ticker - Short name which act as an identifier/key.
    /// 2. Name - Long name which describe the currency.
    /// </summary>
    public class Currency
    {
        public Currency(string ticker, string name)
        {
            Ticker = ticker;
            Name = name;
        }

        /// <summary>
        /// 3 letters key to indentify the currency
        /// (e.g. "EUR", "USD", "CHF" etc..)
        /// </summary>
        public string Ticker { get; set; }

        /// <summary>
        /// Descriptive name that provide context for the currency.
        /// (e.g. "United State Dollar", "Swiss Franc" etc..)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ToDo : This is a dirty hack and should be handeld differently.
        /// The flag should be identified by the TICKER only!!! no need to provide the full path.
        /// </summary>
        [Obsolete("This should be removed")]
        public string Flag => $"/Resources/Images/Flags/{Ticker ?? string.Empty}.png"; // <-- Dirty hack - temporary workaround

        public override string ToString()
        {
            return $"{Ticker} - {Name}";
        }
    }
}