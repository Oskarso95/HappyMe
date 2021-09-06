using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPiServer.Core;
using EPiServer.Web;
using EpiserverSite.Business;

namespace EpiserverSite.Models
{
    public class ProductUSP
    {
        [Display(Name = "Icon")]
        [IconSelection]
        public virtual string IconCssClass { get; set; }

        [Display(Name = "Heading")] public virtual string Heading { get; set; }

        [Display(Name = "Content")] public virtual string TextContent { get; set; }

        [Display(Name = "USP link")] public virtual string USPLink { get; set; }
    }
}