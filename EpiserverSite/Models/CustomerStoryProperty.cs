using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.PlugIn;
using Newtonsoft.Json;

namespace EpiserverSite.Models
{
    [PropertyDefinitionTypePlugIn]
    public class CustomerStoryProperty : PropertyList<CustomerStory>
    {
        protected override CustomerStory ParseItem(string value)
        {
            return JsonConvert.DeserializeObject<CustomerStory>(value);
        }

        public override PropertyData ParseToObject(string value)
        {
            ParseToSelf(value);
            return this;
        }
    }
}