using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPiServer.Core;
using EPiServer.PlugIn;
using Newtonsoft.Json;

namespace EpiserverSite.Models
{
    [PropertyDefinitionTypePlugIn]
    public class ProductUSPProperty : PropertyList<ProductUSP>
    {
        protected override ProductUSP ParseItem(string value)
        {
            return JsonConvert.DeserializeObject<ProductUSP>(value);
        }

        public override PropertyData ParseToObject(string value)
        {
            ParseToSelf(value);
            return this;
        }
    }
}