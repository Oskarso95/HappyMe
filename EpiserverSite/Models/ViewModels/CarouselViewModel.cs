using System.Collections.Generic;
using EpiserverSite.Models.Blocks;

namespace EpiserverSite.Models.ViewModels
{
    public class CarouselViewModel
    {
        public CarouselBlock CurrentBlock { get; set; }
        public List<CarouselItemBlock> Items { get; set; }
    }
}