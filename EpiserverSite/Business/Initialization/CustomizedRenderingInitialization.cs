using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.Web;
using EpiserverSite.Business.Rendering;

namespace EpiserverSite.Business.Initialization
{
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    class CustomizedRenderingInitialization : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            ViewEngines.Engines.Insert(0, new SiteViewEngine());
        }

        public void Uninitialize(InitializationEngine context)
        {
        }
    }
}