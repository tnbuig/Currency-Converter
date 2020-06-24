using CommonServiceLocator;
using OG.CC.Client.Desktop.Bootstrapper;
using OG.CC.Client.Desktop.ViewModels;

namespace OG.CC.Client.Desktop
{
    /// <summary>
    /// Dependency injections of views-DataContext.
    /// For usage see Views (or the example below).
    /// </summary>
    /// <example>
    ///     DataContext="{Binding Input, Source={StaticResource ViewModelLocator}}"
    /// </example>
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            IServiceLocator serviceLocator = BootStrapperLoader.Init();
            ServiceLocator.SetLocatorProvider(() => serviceLocator);
        }

        /// <summary>
        /// Selction view model - the data context for <see cref="CurrencySelectionView"/>
        /// </summary>
        public CurrencySelectionViewModel Selection => ServiceLocator.Current.GetInstance<CurrencySelectionViewModel>();

        /// <summary>
        /// Input view model - the data context for <see cref="InputView"/>
        /// </summary>
        public InputViewModel Input => ServiceLocator.Current.GetInstance<InputViewModel>();

        /// <summary>
        /// Output view model - the data context for <see cref="OutputView"/>.
        /// </summary>
        public OutputViewModel Output => ServiceLocator.Current.GetInstance<OutputViewModel>();
    }
}