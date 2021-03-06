using TagLib.Xmp;
using System;
using Microsoft.Pex.Framework;

namespace TagLib.Xmp
{
	/// <summary>A factory for TagLib.Xmp.XmpTag instances</summary>
	public static partial class XmpTagFactory
	{
		/// <summary>A factory for TagLib.Xmp.XmpTag instances</summary>
		[PexFactoryMethod(typeof(XmpTag))]
		public static XmpTag Create
		(
			/*
			string copyright, string title, string model, string creator, 
			string make, double? focalLength, uint? focalLengthIn35mmFilm,
			string comment, string[] keywords, uint? rating, DateTime? dateTime,
			string software, double? ExposureTime, double? FNumber, uint? ISOSpeedRatings
			*/
		)
		{
			XmpTag xmpTag = new XmpTag();
			/*
			xmpTag.SetLangAltNode(XmpTag.DC_NS, "rights", copyright);
			xmpTag.SetLangAltNode(XmpTag.DC_NS, "title", title);
			xmpTag.SetTextNode(XmpTag.TIFF_NS, "Model", model);
			xmpTag.SetCollectionNode(XmpTag.DC_NS, "creator", new string[] { creator }, XmpNodeType.Seq);
			xmpTag.SetTextNode(XmpTag.TIFF_NS, "Make", make);
			xmpTag.SetRationalNode(XmpTag.EXIF_NS, "FocalLength", focalLength.HasValue ? (double)focalLength : 0);
			xmpTag.SetTextNode(XmpTag.EXIF_NS, "FocalLengthIn35mmFilm", focalLengthIn35mmFilm.HasValue ? focalLengthIn35mmFilm.Value.ToString() : String.Empty);
			xmpTag.SetLangAltNode(XmpTag.DC_NS, "description", comment);
			xmpTag.SetLangAltNode(XmpTag.EXIF_NS, "UserComment", comment);
			xmpTag.SetCollectionNode(XmpTag.DC_NS, "subject", keywords, XmpNodeType.Bag);
			xmpTag.SetTextNode(XmpTag.XAP_NS, "Rating", rating != null ? rating.ToString() : null);
			xmpTag.SetTextNode(XmpTag.XAP_NS, "CreateDate", dateTime != null ? dateTime.ToString() : null);
			xmpTag.SetTextNode (XmpTag.XAP_NS, "CreatorTool", software); 
			xmpTag.SetRationalNode(XmpTag.EXIF_NS, "ExposureTime", ExposureTime.HasValue ? (double)ExposureTime : 0);
			xmpTag.SetRationalNode(XmpTag.EXIF_NS, "FNumber", FNumber.HasValue ? (double)FNumber : 0);
			xmpTag.SetCollectionNode(XmpTag.EXIF_NS, "ISOSpeedRatings", new string[] { ISOSpeedRatings.ToString() }, XmpNodeType.Seq);
			*/
			return xmpTag;

			// TODO: Edit factory method of XmpTag
			// This method should be able to configure the object in all possible ways.
			// Add as many parameters as needed,
			// and assign their values to each field by using the API.
		}
	}
}
