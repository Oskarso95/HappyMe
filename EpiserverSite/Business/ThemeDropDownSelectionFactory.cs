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
                new SelectItem {Text = "Pink", Value = "theme-pink"},
                new SelectItem {Text = "Blue", Value = "theme-blue"},
                new SelectItem {Text = "Beige", Value = "theme-beige"},
                new SelectItem {Text = "Orange", Value = "theme-orange"},
                new SelectItem {Text = "Green", Value = "theme-green"},
            };
        }
    }
}