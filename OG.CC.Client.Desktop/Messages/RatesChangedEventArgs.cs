using System.Collections.Generic;

namespace OG.CC.Client.Desktop.Messages
{
    /// <summary>
    /// EventArgs to be passed when Rates has changed (maybe due to change of base rate).
    /// </summary>
    public class RatesChangedEventArgs
    {
        public RatesChangedEventArgs(Dictionary<string, decimal> ratesDic)
        {
            this.ratesDic = ratesDic;
        }

        /// <summary>
        /// Dictionary of ticker to rates.
        /// </summary>
        public Dictionary<string, decimal> ratesDic;
    }
}