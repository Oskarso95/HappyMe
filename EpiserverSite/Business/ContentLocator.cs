using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPiServer;
using EPiServer.Core;

namespace EpiserverSite.Business
{
    class ContentLocator
    {
        private readonly IContentLoader _contentLoader;

        public ContentLocator(IContentLoader contentLoader)
        {
            _contentLoader = contentLoader;
        }
    }
}