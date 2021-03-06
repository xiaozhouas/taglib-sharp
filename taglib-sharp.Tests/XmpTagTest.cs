// <copyright file="XmpTagTest.cs">Copyright (c) 2006-2007 Brian Nickel.  Copyright (c) 2009-2010 Other contributors</copyright>
using System;
using System.Xml;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TagLib;
using TagLib.Image;
using TagLib.Xmp;
using System.Linq;

namespace TagLib.Xmp.Tests
{
    /// <summary>This class contains parameterized unit tests for XmpTag</summary>
    [PexClass(typeof(XmpTag))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class XmpTagTest
    {
        /// <summary>Test stub for get_Altitude()</summary>
        [PexMethod]
        public double? AltitudeGetTest([PexAssumeUnderTest]XmpTag target)
        {
            double? result = target.Altitude;
			PexAssert.AreEqual(target.Altitude, null);
			return result;
            // TODO: add assertions to method XmpTagTest.AltitudeGetTest(XmpTag)
        }

        /// <summary>Test stub for set_Altitude(Nullable`1&lt;Double&gt;)</summary>
        [PexMethod]
        public void AltitudeSetTest([PexAssumeUnderTest]XmpTag target, double? value)
        {
            target.Altitude = value;
			PexAssert.AreEqual(target.Altitude, null);

            // TODO: add assertions to method XmpTagTest.AltitudeSetTest(XmpTag, Nullable`1<Double>)
        }

		/// <summary>Test stub for Clear()</summary>
		[PexMethod]
		[PexAllowedException(typeof(NotImplementedException))]
		public void ClearTest([PexAssumeUnderTest]XmpTag target) => target.Clear();// TODO: add assertions to method XmpTagTest.ClearTest(XmpTag)

		/// <summary>Test stub for get_Comment()</summary>
		[PexMethod]
        public string CommentGetDescriptionTest([PexAssumeUnderTest]XmpTag target, string value)
        {
			PexAssume.IsNotNull(value);
			target.SetLangAltNode(XmpTag.DC_NS, "description", value);
            string result = target.Comment;
            PexAssert.AreEqual(result, target.GetLangAltNode(XmpTag.DC_NS, "description"));
			return result;
            // TODO: add assertions to method XmpTagTest.CommentGetTest(XmpTag)
        }

		[PexMethod]
		public string CommentGetUserCommentTest([PexAssumeUnderTest]XmpTag target, string value)
		{
			PexAssume.IsNotNull(value);
			PexAssume.IsNull(target.GetLangAltNode(XmpTag.DC_NS, "description"));
			target.SetLangAltNode(XmpTag.EXIF_NS, "UserComment", value); ;
			string result = target.Comment;
			PexAssert.AreEqual(result, target.GetLangAltNode(XmpTag.EXIF_NS, "UserComment"));
			return result;
			// TODO: add assertions to method XmpTagTest.CommentGetTest(XmpTag)
		}


		/// <summary>Test stub for set_Comment(String)</summary>
		[PexMethod]
        public void CommentSetTest([PexAssumeUnderTest]XmpTag target, string value)
        {
            target.Comment = value;
			PexAssert.AreEqual(target.GetLangAltNode(XmpTag.DC_NS, "description"), value);
			PexAssert.AreEqual(target.GetLangAltNode(XmpTag.EXIF_NS, "UserComment"), value);
			// TODO: add assertions to method XmpTagTest.CommentSetTest(XmpTag, String)
		}

        /// <summary>Test stub for get_Copyright()</summary>
        [PexMethod]
        public string CopyrightGetTest([PexAssumeUnderTest]XmpTag target, string copyright)
        {
			target.Copyright = copyright;
            string result = target.Copyright;
			PexAssert.AreEqual(target.GetLangAltNode(XmpTag.DC_NS, "rights"), result);
			return result;
            // TODO: add assertions to method XmpTagTest.CopyrightGetTest(XmpTag)
        }

        /// <summary>Test stub for set_Copyright(String)</summary>
        [PexMethod]
        public void CopyrightSetTest([PexAssumeUnderTest]XmpTag target, string value)
        {
            target.Copyright = value;
			PexAssert.AreEqual(target.GetLangAltNode(XmpTag.DC_NS, "rights"), value);
			// TODO: add assertions to method XmpTagTest.CopyrightSetTest(XmpTag, String)
		}

		/*
        /// <summary>Test stub for CreateAttribute(XmlDocument, String, String)</summary>
        [PexMethod]
        internal XmlAttribute CreateAttributeTest(
            XmlDocument doc,
            string name,
            string ns
        )
        {
            XmlAttribute result = XmpTag.CreateAttribute(doc, name, ns);
            return result;
            // TODO: add assertions to method XmpTagTest.CreateAttributeTest(XmlDocument, String, String)
        }

        /// <summary>Test stub for CreateNode(XmlDocument, String, String)</summary>
        [PexMethod]
        internal XmlNode CreateNodeTest(
            XmlDocument doc,
            string name,
            string ns
        )
        {
            XmlNode result = XmpTag.CreateNode(doc, name, ns);
            return result;
            // TODO: add assertions to method XmpTagTest.CreateNodeTest(XmlDocument, String, String)
        }
		*/

		/// <summary>Test stub for get_Creator()</summary>
		[PexMethod]
        public string CreatorGetTest([PexAssumeUnderTest]XmpTag target, string creator)
        {
			PexAssume.IsNotNull(creator);
			target.Creator = creator;
            string result = target.Creator;
			PexAssert.AreEqual(target.GetCollectionNode(XmpTag.DC_NS, "creator")[0], result);
            return result;
            // TODO: add assertions to method XmpTagTest.CreatorGetTest(XmpTag)
        }

        /// <summary>Test stub for set_Creator(String)</summary>
        [PexMethod]
        public void CreatorSetTest([PexAssumeUnderTest]XmpTag target, string value)
        {
			PexAssume.IsNotNull(value);
			target.Creator = value;
			PexAssert.AreEqual(target.GetCollectionNode(XmpTag.DC_NS, "creator")[0], value);
			// TODO: add assertions to method XmpTagTest.CreatorSetTest(XmpTag, String)
		}

		/// <summary>Test stub for get_DateTime()</summary>
		[PexMethod]
        public DateTime? DateTimeGetTest([PexAssumeUnderTest]XmpTag target, DateTime datetime)
        {
			PexAssume.IsNotNull(datetime);
			target.DateTime = datetime;
            DateTime? result = target.DateTime;
			PexAssert.AreEqual(result.ToString(), target.GetTextNode(XmpTag.XAP_NS, "CreateDate").ToString());
            return result;
            // TODO: add assertions to method XmpTagTest.DateTimeGetTest(XmpTag)
        }

        /// <summary>Test stub for set_DateTime(Nullable`1&lt;DateTime&gt;)</summary>
        [PexMethod]
        public void DateTimeSetTest([PexAssumeUnderTest]XmpTag target, DateTime? value)
        {
			PexAssume.IsNotNull(value);
            target.DateTime = value;
			PexAssert.AreEqual(value.ToString(), target.GetTextNode(XmpTag.XAP_NS, "CreateDate").ToString());
			// TODO: add assertions to method XmpTagTest.DateTimeSetTest(XmpTag, Nullable`1<DateTime>)
		}

		/// <summary>Test stub for get_ExposureTime()</summary>
		[PexMethod]
        public double? ExposureTimeGetTest([PexAssumeUnderTest]XmpTag target, double exposureTime)
        {
			target.ExposureTime = exposureTime;
            double? result = target.ExposureTime;
			PexAssert.AreEqual(result, target.GetRationalNode(XmpTag.EXIF_NS, "ExposureTime"));
            return result;
            // TODO: add assertions to method XmpTagTest.ExposureTimeGetTest(XmpTag)
        }

        /// <summary>Test stub for set_ExposureTime(Nullable`1&lt;Double&gt;)</summary>
        [PexMethod]
        public void ExposureTimeSetTest([PexAssumeUnderTest]XmpTag target, double value)
        {
            target.ExposureTime = value;
			PexAssert.AreEqual(value, target.GetRationalNode(XmpTag.EXIF_NS, "ExposureTime").Value, 0.001);
			// TODO: add assertions to method XmpTagTest.ExposureTimeSetTest(XmpTag, Nullable`1<Double>)
		}

		/// <summary>Test stub for get_FNumber()</summary>
		[PexMethod]
        public double? FNumberGetTest([PexAssumeUnderTest]XmpTag target, double fNumber)
        {
			target.FNumber = fNumber;
            double? result = target.FNumber;
			PexAssume.IsNotNull(result);
			PexAssert.AreEqual(result, target.GetRationalNode(XmpTag.EXIF_NS, "FNumber"));
			return result;
            // TODO: add assertions to method XmpTagTest.FNumberGetTest(XmpTag)
        }

        /// <summary>Test stub for set_FNumber(Nullable`1&lt;Double&gt;)</summary>
        [PexMethod]
        public void FNumberSetTest([PexAssumeUnderTest]XmpTag target, double value)
        {
			PexAssume.IsNotNull(value);
            target.FNumber = value;
			double result = target.GetRationalNode(XmpTag.EXIF_NS, "FNumber").Value;
			PexAssert.AreEqual(value, result, 0.001);
			// TODO: add assertions to method XmpTagTest.FNumberSetTest(XmpTag, Nullable`1<Double>)
		}

		/// <summary>Test stub for FindNode(String, String)</summary>
		[PexMethod]
        public XmpNode FindNodeTest([PexAssumeUnderTest]XmpTag target, string value)
        {
			PexAssume.IsNotNull(value);
			target.Copyright = value;
            XmpNode result = target.FindNode(XmpTag.DC_NS, "rights");
			PexAssert.AreEqual(result.Value, target.Copyright);
            return result;
            // TODO: add assertions to method XmpTagTest.FindNodeTest(XmpTag, String, String)
        }

        /// <summary>Test stub for get_FocalLength()</summary>
        [PexMethod]
        public double? FocalLengthGetTest([PexAssumeUnderTest]XmpTag target, double focalLength)
        {
			target.FocalLength = focalLength;
            double result = target.FocalLength.Value;
			PexAssert.AreEqual(result, target.GetRationalNode(XmpTag.EXIF_NS, "FocalLength").Value, 0.001);
            return result;
            // TODO: add assertions to method XmpTagTest.FocalLengthGetTest(XmpTag)
        }

        /// <summary>Test stub for get_FocalLengthIn35mmFilm()</summary>
        [PexMethod]
        public uint? FocalLengthIn35mmFilmGetTest([PexAssumeUnderTest]XmpTag target)
        {

            uint? result = target.FocalLengthIn35mmFilm;
			PexAssert.AreEqual(result, target.GetUIntNode(XmpTag.EXIF_NS, "FocalLengthIn35mmFilm"));
			return result;
            // TODO: add assertions to method XmpTagTest.FocalLengthIn35mmFilmGetTest(XmpTag)
        }

        /// <summary>Test stub for set_FocalLengthIn35mmFilm(Nullable`1&lt;UInt32&gt;)</summary>
        [PexMethod]
        public void FocalLengthIn35mmFilmSetTest([PexAssumeUnderTest]XmpTag target, uint? value)
        {
            target.FocalLengthIn35mmFilm = value;
			PexAssert.AreEqual(value, target.GetUIntNode(XmpTag.EXIF_NS, "FocalLengthIn35mmFilm"));
			// TODO: add assertions to method XmpTagTest.FocalLengthIn35mmFilmSetTest(XmpTag, Nullable`1<UInt32>)
		}

		/// <summary>Test stub for set_FocalLength(Nullable`1&lt;Double&gt;)</summary>
		[PexMethod]
        public void FocalLengthSetTest([PexAssumeUnderTest]XmpTag target, double value)
        {
			PexAssume.IsNotNull(value);
			PexAssume.IsTrue(value != 0);
            target.FocalLength = value;
			double result = target.GetRationalNode(XmpTag.EXIF_NS, "FocalLength").Value;
			PexAssert.AreEqual(result, value, 0.001);
			// TODO: add assertions to method XmpTagTest.FocalLengthSetTest(XmpTag, Nullable`1<Double>)
		}

		/// <summary>Test stub for GetCollectionNode(String, String)</summary>
		[PexMethod]
        public string[] GetCollectionNodeTest(
            [PexAssumeUnderTest]XmpTag target,
            string ns,
            string name,
			string[] values
        )
        {
			PexAssume.IsNotNull(ns);
			PexAssume.IsNotNull(name);
			PexAssume.IsNotNull(values);
			PexAssume.IsTrue(!values.Contains(null));
			target.SetCollectionNode(ns, name, values, XmpNodeType.Seq);
            string[] result = target.GetCollectionNode(ns, name);
			PexAssert.IsTrue(result.SequenceEqual(values));
			return result;
            // TODO: add assertions to method XmpTagTest.GetCollectionNodeTest(XmpTag, String, String)
        }

        /// <summary>Test stub for GetLangAltNode(String, String)</summary>
        [PexMethod]
        public string GetLangAltNodeTest(
            [PexAssumeUnderTest]XmpTag target,
            string ns,
            string name,
			string value
        )
        {
			PexAssume.IsNotNull(ns);
			PexAssume.IsNotNull(name);
			target.SetLangAltNode(ns, name, value);
			string result = target.GetLangAltNode(ns, name);
			PexAssert.AreEqual(result, value);
			return result;
            // TODO: add assertions to method XmpTagTest.GetLangAltNodeTest(XmpTag, String, String)
        }

        /// <summary>Test stub for GetRationalNode(String, String)</summary>
        [PexMethod]
        public double? GetRationalNodeTest(
            [PexAssumeUnderTest]XmpTag target,
            string ns,
            string name,
			double value

		)
		{
			PexAssume.IsNotNull(ns);
			PexAssume.IsNotNull(name);
			PexAssume.IsNotNull(value);
			target.SetRationalNode(ns, name, value);
			double result = target.GetRationalNode(ns, name).Value;
			PexAssert.AreEqual(result, value, 0.001);
			return result;
            // TODO: add assertions to method XmpTagTest.GetRationalNodeTest(XmpTag, String, String)
        }

        /// <summary>Test stub for GetTextNode(String, String)</summary>
        [PexMethod]
        public string GetTextNodeTest(
            [PexAssumeUnderTest]XmpTag target,
            string ns,
            string name,
			string value
		)
		{
			PexAssume.IsNotNull(ns);
			PexAssume.IsNotNull(name);
			PexAssume.IsNotNull(value);
			target.SetTextNode(ns, name, value);
			string result = target.GetTextNode(ns, name);
			PexAssert.AreEqual(result, value);
			return result;
            // TODO: add assertions to method XmpTagTest.GetTextNodeTest(XmpTag, String, String)
        }

        /// <summary>Test stub for GetUIntNode(String, String)</summary>
        [PexMethod]
        public uint? GetUIntNodeTest(
            [PexAssumeUnderTest]XmpTag target,
            string ns,
            string name,
			uint value
        )
        {
			PexAssume.IsNotNull(ns);
			PexAssume.IsNotNull(name);
			PexAssume.IsNotNull(value);
			target.SetTextNode(ns, name, value.ToString());
			uint? result = target.GetUIntNode(ns, name);
			PexAssert.AreEqual(result, value);
			return result;
            // TODO: add assertions to method XmpTagTest.GetUIntNodeTest(XmpTag, String, String)
        }

        /// <summary>Test stub for get_ISOSpeedRatings()</summary>
        [PexMethod]
        public uint? ISOSpeedRatingsGetTest([PexAssumeUnderTest]XmpTag target, uint value)
        {
			PexAssume.IsNotNull(value);
			target.ISOSpeedRatings = value;
            uint? result = target.ISOSpeedRatings;
			PexAssert.AreEqual(result.ToString(), target.GetCollectionNode(XmpTag.EXIF_NS, "ISOSpeedRatings")[0].ToString());
            return result;
            // TODO: add assertions to method XmpTagTest.ISOSpeedRatingsGetTest(XmpTag)
        }

        /// <summary>Test stub for set_ISOSpeedRatings(Nullable`1&lt;UInt32&gt;)</summary>
        [PexMethod]
        public void ISOSpeedRatingsSetTest([PexAssumeUnderTest]XmpTag target, uint? value)
        {
			PexAssume.IsNotNull(value);
			target.ISOSpeedRatings = value;
			PexAssert.AreEqual(value.ToString(), target.GetCollectionNode(XmpTag.EXIF_NS, "ISOSpeedRatings")[0].ToString());
			// TODO: add assertions to method XmpTagTest.ISOSpeedRatingsSetTest(XmpTag, Nullable`1<UInt32>)
		}

		/// <summary>Test stub for get_Keywords()</summary>
		[PexMethod]
        public string[] KeywordsGetTest([PexAssumeUnderTest]XmpTag target, string[] keywords)
        {
			PexAssume.IsNotNull(keywords);
			PexAssume.IsTrue(!keywords.Contains(null));
			target.Keywords = keywords;
			string[] result = target.Keywords;
			PexAssert.IsTrue(result.SequenceEqual(target.GetCollectionNode(XmpTag.DC_NS, "subject")));
            return result;
            // TODO: add assertions to method XmpTagTest.KeywordsGetTest(XmpTag)
        }

        /// <summary>Test stub for set_Keywords(String[])</summary>
        [PexMethod]
        public void KeywordsSetTest([PexAssumeUnderTest]XmpTag target, string[] value)
        {
			PexAssume.IsNotNull(value);
			PexAssume.IsTrue(!value.Contains(null));
			target.Keywords = value;
			PexAssert.IsTrue(value.SequenceEqual(target.GetCollectionNode(XmpTag.DC_NS, "subject")));
			// TODO: add assertions to method XmpTagTest.KeywordsSetTest(XmpTag, String[])
		}

		/// <summary>Test stub for get_Latitude()</summary>
		[PexMethod]
        public double? LatitudeGetTest([PexAssumeUnderTest]XmpTag target)
        {
            double? result = target.Latitude;
			PexAssert.IsNull(result);
            return result;
            // TODO: add assertions to method XmpTagTest.LatitudeGetTest(XmpTag)
        }

        /// <summary>Test stub for set_Latitude(Nullable`1&lt;Double&gt;)</summary>
        [PexMethod]
        public void LatitudeSetTest([PexAssumeUnderTest]XmpTag target, double? value)
        {
            target.Latitude = value;
			PexAssert.IsNull(target.Latitude);
			// TODO: add assertions to method XmpTagTest.LatitudeSetTest(XmpTag, Nullable`1<Double>)
		}

		/// <summary>Test stub for get_Longitude()</summary>
		[PexMethod]
        public double? LongitudeGetTest([PexAssumeUnderTest]XmpTag target)
        {
            double? result = target.Longitude;
			PexAssert.IsNull(result);
			return result;
            // TODO: add assertions to method XmpTagTest.LongitudeGetTest(XmpTag)
        }

        /// <summary>Test stub for set_Longitude(Nullable`1&lt;Double&gt;)</summary>
        [PexMethod]
        public void LongitudeSetTest([PexAssumeUnderTest]XmpTag target, double? value)
        {
            target.Longitude = value;
			PexAssert.IsNull(target.Longitude);
			// TODO: add assertions to method XmpTagTest.LongitudeSetTest(XmpTag, Nullable`1<Double>)
		}

		/// <summary>Test stub for get_Make()</summary>
		[PexMethod]
        public string MakeGetTest([PexAssumeUnderTest]XmpTag target, string value)
        {
			target.Make = value;
            string result = target.Make;
			PexAssert.AreEqual(result, target.GetTextNode(XmpTag.TIFF_NS, "Make"));
			return result;
            // TODO: add assertions to method XmpTagTest.MakeGetTest(XmpTag)
        }

        /// <summary>Test stub for set_Make(String)</summary>
        [PexMethod]
        public void MakeSetTest([PexAssumeUnderTest]XmpTag target, string value)
        {
            target.Make = value;
			PexAssert.AreEqual(value, target.GetTextNode(XmpTag.TIFF_NS, "Make"));
            // TODO: add assertions to method XmpTagTest.MakeSetTest(XmpTag, String)
        }

        /// <summary>Test stub for get_Model()</summary>
        [PexMethod]
        public string ModelGetTest([PexAssumeUnderTest]XmpTag target, string value)
        {
			target.Model = value;
			string result = target.Model;
			PexAssert.AreEqual(result, target.GetTextNode(XmpTag.TIFF_NS, "Model"));
			return result;
            // TODO: add assertions to method XmpTagTest.ModelGetTest(XmpTag)
        }

        /// <summary>Test stub for set_Model(String)</summary>
        [PexMethod]
        public void ModelSetTest([PexAssumeUnderTest]XmpTag target, string value)
        {
            target.Model = value;
			PexAssert.AreEqual(value, target.GetTextNode(XmpTag.TIFF_NS, "Model"));
			// TODO: add assertions to method XmpTagTest.ModelSetTest(XmpTag, String)
		}

		/// <summary>Test stub for get_Orientation()</summary>
		[PexMethod]
        public ImageOrientation OrientationGetTest([PexAssumeUnderTest]XmpTag target, ImageOrientation value)
        {
			PexAssume.IsNotNull(value);
			PexAssume.IsTrue((uint)value >= 1U && (uint)value <= 8U);
			target.Orientation = value;
			ImageOrientation result = target.Orientation;
			PexAssert.AreEqual(result, (ImageOrientation)target.GetUIntNode(XmpTag.TIFF_NS, "Orientation"));
            return result;
            // TODO: add assertions to method XmpTagTest.OrientationGetTest(XmpTag)
        }

        /// <summary>Test stub for set_Orientation(ImageOrientation)</summary>
        [PexMethod]
        public void OrientationSetTest([PexAssumeUnderTest]XmpTag target, ImageOrientation value)
        {
			PexAssume.IsTrue((uint)value >= 1U && (uint)value <= 8U);
			target.Orientation = value;
			PexAssert.AreEqual(target.Orientation, value);
            // TODO: add assertions to method XmpTagTest.OrientationSetTest(XmpTag, ImageOrientation)
        }

        /// <summary>Test stub for get_Rating()</summary>
        [PexMethod]
        public uint? RatingGetTest([PexAssumeUnderTest]XmpTag target, uint rating)
        {
			target.Rating = rating;
            uint? result = target.Rating;
			PexAssert.AreEqual(result, target.GetUIntNode(XmpTag.XAP_NS, "Rating"));
            return result;
            // TODO: add assertions to method XmpTagTest.RatingGetTest(XmpTag)
        }

        /// <summary>Test stub for set_Rating(Nullable`1&lt;UInt32&gt;)</summary>
        [PexMethod]
        public void RatingSetTest([PexAssumeUnderTest]XmpTag target, uint? value)
        {
            target.Rating = value;
			PexAssert.AreEqual(value, target.GetUIntNode(XmpTag.XAP_NS, "Rating"));
			// TODO: add assertions to method XmpTagTest.RatingSetTest(XmpTag, Nullable`1<UInt32>)
		}

		/*
		/// <summary>Test stub for Render()</summary>
		[PexMethod]
        public string RenderTest([PexAssumeUnderTest]XmpTag target)
        {
            string result = target.Render();
            return result;
            // TODO: add assertions to method XmpTagTest.RenderTest(XmpTag)
        }
		*/

        /// <summary>Test stub for ReplaceFrom(XmpTag)</summary>
        [PexMethod]
        public void ReplaceFromTest([PexAssumeUnderTest]XmpTag target, XmpTag tag, string ns, string name, string value)
        {
			PexAssume.IsNotNull(tag);
			PexAssume.IsNotNull(ns);
			PexAssume.IsNotNull(name);
			PexAssume.IsNotNull(value);
			tag.SetTextNode(ns, name, value);
			target.ReplaceFrom(tag);
			PexAssert.AreEqual(value, target.GetTextNode(ns, name));
            // TODO: add assertions to method XmpTagTest.ReplaceFromTest(XmpTag, XmpTag)
        }

        /// <summary>Test stub for SetCollectionNode(String, String, String[], XmpNodeType)</summary>
        [PexMethod]
        public void SetCollectionNodeTest(
            [PexAssumeUnderTest]XmpTag target,
            string ns,
            string name,
            string[] values,
            XmpNodeType type
        )
        {
			PexAssume.IsNotNull(ns);
			PexAssume.IsNotNull(name);
			PexAssume.IsNotNull(values);
			PexAssume.IsTrue(!values.Contains(null));
			PexAssume.IsTrue(type != XmpNodeType.Simple && type != XmpNodeType.Alt);
			target.SetCollectionNode(ns, name, values, type);
			PexAssert.IsTrue(values.SequenceEqual(target.GetCollectionNode(ns, name)));
            // TODO: add assertions to method XmpTagTest.SetCollectionNodeTest(XmpTag, String, String, String[], XmpNodeType)
        }

        /// <summary>Test stub for SetLangAltNode(String, String, String)</summary>
        [PexMethod]
        public void SetLangAltNodeTest(
            [PexAssumeUnderTest]XmpTag target,
            string ns,
            string name,
            string value
        )
        {
			PexAssume.IsNotNull(ns);
			PexAssume.IsNotNull(name);
			target.SetLangAltNode(ns, name, value);
			PexAssert.AreEqual(target.GetLangAltNode(ns, name), value);
            // TODO: add assertions to method XmpTagTest.SetLangAltNodeTest(XmpTag, String, String, String)
        }

        /// <summary>Test stub for SetRationalNode(String, String, Double)</summary>
        [PexMethod]
        public void SetRationalNodeTest(
            [PexAssumeUnderTest]XmpTag target,
            string ns,
            string name,
            double value
        )
        {
			PexAssume.IsNotNull(ns);
			PexAssume.IsNotNull(name);
			target.SetRationalNode(ns, name, value);
			double result = target.GetRationalNode(ns, name).Value;
			PexAssert.AreEqual(result, value, 0.001);
			// TODO: add assertions to method XmpTagTest.SetRationalNodeTest(XmpTag, String, String, Double)
		}

		/// <summary>Test stub for SetTextNode(String, String, String)</summary>
		[PexMethod]
        public void SetTextNodeTest(
            [PexAssumeUnderTest]XmpTag target,
            string ns,
            string name,
            string value
        )
        {
			PexAssume.IsNotNull(ns);
			PexAssume.IsNotNull(name);
			target.SetTextNode(ns, name, value);
			PexAssert.AreEqual(target.GetTextNode(ns, name), value);
			// TODO: add assertions to method XmpTagTest.SetTextNodeTest(XmpTag, String, String, String)
		}

		/// <summary>Test stub for get_Software()</summary>
		[PexMethod]
        public string SoftwareGetTest([PexAssumeUnderTest]XmpTag target)
        {
			PexAssert.AreEqual(target.Software, target.GetTextNode(XmpTag.XAP_NS, "CreatorTool"));
			return target.Software;
            // TODO: add assertions to method XmpTagTest.SoftwareGetTest(XmpTag)
        }

        /// <summary>Test stub for set_Software(String)</summary>
        [PexMethod]
        public void SoftwareSetTest([PexAssumeUnderTest]XmpTag target, string value)
        {
            target.Software = value;
			PexAssert.AreEqual(value, target.GetTextNode(XmpTag.XAP_NS, "CreatorTool"));
            // TODO: add assertions to method XmpTagTest.SoftwareSetTest(XmpTag, String)
        }

        /// <summary>Test stub for get_TagTypes()</summary>
        [PexMethod]
        public TagTypes TagTypesGetTest([PexAssumeUnderTest]XmpTag target)
        {
            TagTypes result = target.TagTypes;
			PexAssert.AreEqual(result, TagTypes.XMP);
            return result;
            // TODO: add assertions to method XmpTagTest.TagTypesGetTest(XmpTag)
        }

        /// <summary>Test stub for get_Title()</summary>
        [PexMethod]
        public string TitleGetTest([PexAssumeUnderTest]XmpTag target, string title)
        {
			target.Title = title;
            string result = target.Title;
			PexAssert.AreEqual(result, target.GetLangAltNode(XmpTag.DC_NS, "title"));
			return result;
            // TODO: add assertions to method XmpTagTest.TitleGetTest(XmpTag)
        }

        /// <summary>Test stub for set_Title(String)</summary>
        [PexMethod(MaxWorkingSet = 700)]
        public void TitleSetTest([PexAssumeUnderTest]XmpTag target, string value)
        {
            target.Title = value;
			PexAssert.AreEqual(value, target.GetLangAltNode(XmpTag.DC_NS, "title"));
            // TODO: add assertions to method XmpTagTest.TitleSetTest(XmpTag, String)
        }
    }
}
