using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.Context;
using EPiServer.ServiceLocation;

namespace EpiserverSite.Business
{
    class ServiceLocatorDependencyResolver : System.Web.Mvc.IDependencyResolver
    {
        private readonly IServiceLocator _serviceLocator;

        public ServiceLocatorDependencyResolver(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType.IsInterface || serviceType.IsAbstract)
            {
                GetInterfaceService(serviceType);
            }

            return GetConcreteService(serviceType);
        }

        private object GetConcreteService(Type serviceType)
        {
            try
            {
                return _serviceLocator.GetInstance(serviceType);
            }
            catch (ActivationException)
            {
                return null;
            }
        }

        private object GetInterfaceService(Type serviceType)
        {
            return _serviceLocator.TryGetExistingInstance(serviceType, out object instance) ? instance : null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _serviceLocator.GetAllInstances(serviceType).Cast<object>();
        }
    }
}