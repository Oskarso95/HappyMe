using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EPiServer.Shell.ObjectEditing;

namespace EpiserverSite.Business
{
    public class ThemeDropDownSelectionFactory : ISelectionFactory
    {
        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            return new List<ISelectItem>
            {
                new SelectItem {Text = "Light-pink", Value = "bg-light-pink"},
                new SelectItem {Text = "Light-blue", Value = "bg-light-blue"},
                new SelectItem {Text = "Light-beige", Value = "bg-light-beige"},
            };
        }
    }
}