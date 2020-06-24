using CommonServiceLocator;
using System;
using System.Collections.Generic;
using Unity;

namespace OG.CC.Client.Desktop.Bootstrapper
{
    /// <summary>
    /// Service locator implemented using unity container.
    /// </summary>
    /// <seealso cref="Microsoft.Practices.ServiceLocation.IServiceLocator" />
    public class UnityServiceLocator : IServiceLocator
    {
        private readonly IUnityContainer unityContainer;

        public UnityServiceLocator(IUnityContainer unityContainer)
        {
            this.unityContainer = unityContainer;
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <returns></returns>
        public object GetInstance(Type serviceType)
        {
            return unityContainer.Resolve(serviceType);
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public object GetInstance(Type serviceType, string key)
        {
            return unityContainer.Resolve(serviceType, key);
        }

        /// <summary>
        /// Gets all instances.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <returns></returns>
        public IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return unityContainer.ResolveAll(serviceType);
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <returns></returns>
        public TService GetInstance<TService>()
        {
            return unityContainer.Resolve<TService>();
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public TService GetInstance<TService>(string key)
        {
            return unityContainer.Resolve<TService>(key);
        }

        /// <summary>
        /// Gets all instances.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <returns></returns>
        public IEnumerable<TService> GetAllInstances<TService>()
        {
            return unityContainer.ResolveAll<TService>();
        }

        /// <summary>
        /// Gets the service.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <returns></returns>
        public object GetService(Type serviceType)
        {
            return unityContainer.Resolve(serviceType);
        }
    }
}