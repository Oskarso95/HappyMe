using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Web.Mvc;
using EPiServer.Shell.ObjectEditing;


namespace EpiserverSite.Business
{
    public class ArticleDropdownSelectionFactory : ISelectionFactory
    {
        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            return new[]
            {
                new SelectItem {Text = "Alphabetically", Value = "ALPHABETICALLY"},
                new SelectItem {Text = "Creation date old to new", Value = "CREATION_OLD_TO_NEW"},
                new SelectItem {Text = "Creation date new to old", Value = "CREATION_NEW_TO_OLD"},
            };
        }
    }
}