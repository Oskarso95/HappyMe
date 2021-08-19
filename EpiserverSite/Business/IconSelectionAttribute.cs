using System;
using System.Runtime.Remoting.MetadataServices;
using System.Web.Mvc;
using EPiServer.Shell;
using EPiServer.Shell.ObjectEditing;

namespace EpiserverSite.Business
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class IconSelectionAttribute : Attribute, IMetadataAware
    {
        public void OnMetadataCreated(ModelMetadata metadata)
        {
            var extendedMetaData = metadata as ExtendedMetadata;

            if (extendedMetaData == null)
            {
                return;
            }

            extendedMetaData.ClientEditingClass = "geta-epi-cms/editors/IconAutoSuggestEditor";
            extendedMetaData.CustomEditorSettings["uiWrapperType"] = UiWrapperType.Floating;
        }
    }
}