using System.Web.Mvc;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using EPiServer.Web;

namespace EpiserverSite.Business.Initialization
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class DisplayRegistryInitialization : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            if (context.HostType == HostType.WebApplication)
            {
                var options = ServiceLocator.Current.GetInstance<DisplayOptions>();

                options
                    .Add("full", "displayoptions/full", Global.ContentAreaTags.FullWidth, "", "epi-icon__layout--full")
                    .Add("TwoThirds", "displayoptions/wide", Global.ContentAreaTags.TwoThirdsWidth, "",
                        "epi-icon__layout--two--thirds")
                    .Add("half", "displayoptions/half", Global.ContentAreaTags.HalfWidth, "", "epi-icon__layout--half")
                    .Add("onethird", "displayoptions/one-third", Global.ContentAreaTags.OneThirdWidth, "",
                        "epi-icon__layout-one-third")
                    .Add("onefourth", "displayoptions/one-fourth", Global.ContentAreaTags.OneFourthWidth, "",
                        "epi-icon__layout--one-third");

                AreaRegistration.RegisterAllAreas();
            }
        }

        public void Uninitialize(InitializationEngine context)
        {
            throw new System.NotImplementedException();
        }
    }
}