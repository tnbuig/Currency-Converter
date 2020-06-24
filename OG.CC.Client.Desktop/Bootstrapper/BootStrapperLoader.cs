using CommonServiceLocator;
using GalaSoft.MvvmLight.Messaging;
using OG.CC.Client.Desktop.Model;
using OG.CC.Logic.Services;
using OG.CC.Logic.Services.Persistence;
using Unity;

namespace OG.CC.Client.Desktop.Bootstrapper
{
    /// <summary>
    /// Follow MVVMLight pattern to bootstrap WPF app.
    /// </summary>
    public static class BootStrapperLoader
    {
        public static IServiceLocator Init()
        {
            return Init(new UnityContainer());
        }

        /// <summary>
        /// Register all nessary dependecies, so they can be injected whenever they needed.
        /// </summary>
        public static IServiceLocator Init(IUnityContainer container)
        {
            container.RegisterType<IForexService, ForexService>();

            container.RegisterSingleton<ICurrencyManager, CurrencyManager>();
            container.RegisterSingleton<IPersistencyManager, PersistencyManager>();

            container.RegisterInstance(Messenger.Default);
            container.RegisterType<IPersistenceService, PersistenceService>();
            return new UnityServiceLocator(container);
        }
    }
}