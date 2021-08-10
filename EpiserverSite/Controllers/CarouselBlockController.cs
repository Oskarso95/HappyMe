using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core.Internal;
using EPiServer.Web.Mvc;
using EpiserverSite.Models.Blocks;
using EpiserverSite.Models.ViewModels;

namespace EpiserverSite.Controllers
{
    public class CarouselBlockController : BlockController<CarouselBlock>
    {
        private IContentLoader _contentLoader;


        public CarouselBlockController(IContentLoader contentLoader)
        {
            _contentLoader = contentLoader;
        }

        public override ActionResult Index(CarouselBlock currentBlock)
        {
            if (currentBlock.CarouselItemsArea != null)
            {
                var model = new CarouselViewModel
                {
                    CurrentBlock = currentBlock,
                    Items = currentBlock.CarouselItemsArea.Items
                        .Select(cai => _contentLoader.Get<CarouselItemBlock>(cai.ContentLink)).ToList()
                };

                return PartialView("Blocks/CarouselBlock", model);
            }

            return PartialView("Blocks/CarouselBlock", null);
        }
    }
}