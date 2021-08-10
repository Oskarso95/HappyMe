using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc.Html;
using EpiserverSite.Business.Rendering;

namespace EpiserverSite.Business.Initialization
{
    [InitializableModule]
    class DependencyResolverInitialization : IConfigurableModule
    {
        public void Initialize(InitializationEngine context)
        {
            DependencyResolver.SetResolver(new ServiceLocatorDependencyResolver(context.Locate.Advanced));
        }

        public void Uninitialize(InitializationEngine context)
        {
        }

        public void ConfigureContainer(ServiceConfigurationContext context)
        {
            context.ConfigurationComplete += (o, e) =>
            {
                context.Services.AddTransient<ContentAreaRenderer, CustomContentAreaRenderer>();
            };
        }
    }
}