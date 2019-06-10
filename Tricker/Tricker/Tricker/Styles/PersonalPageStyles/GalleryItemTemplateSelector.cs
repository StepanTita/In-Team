using System;
using System.Collections.Generic;
using System.Text;
using Tricker.Models;
using Xamarin.Forms;

namespace Tricker.Styles.PersonalPageStyles
{
	class GalleryItemTemplateSelector : DataTemplateSelector
	{
		public DataTemplate BigGalleryItemTemplate { get; set; }
		public DataTemplate MediumGalleryItemTemplate { get; set; }
		public DataTemplate GalleryItemTemplate { get; set; }

		protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
		{
			var galleryItemType = ((GalleryItem)item).GalleryItemType;

			switch (galleryItemType)
			{
				case GalleryItemType.Big:
					return BigGalleryItemTemplate;
				case GalleryItemType.Medium:
					return MediumGalleryItemTemplate;
				case GalleryItemType.Default:
					return GalleryItemTemplate;
				default:
					return GalleryItemTemplate;
			}
		}
	}
}
