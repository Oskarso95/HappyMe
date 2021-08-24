using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Web;

namespace EpiserverSite.Models
{
    public class CustomerStory
    {
        [Display(Name = "Image")]
        [Required]
        [UIHint(UIHint.Image)]
        public virtual ContentReference Image { get; set; }

        [Display(Name = "Heading")] public virtual string Heading { get; set; }

        [Display(Name = "Story")] public virtual XhtmlString Story { get; set; }

        [Display(Name = "Author")] public virtual string Author { get; set; }
    }
}