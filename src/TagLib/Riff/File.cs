using System.Collections;
using System.Collections.Generic;
using System;

namespace TagLib.Riff
{
   [SupportedMimeType("taglib/avi", "avi")]
   [SupportedMimeType("video/x-msvideo")]
   public class File : TagLib.File
   {
      //////////////////////////////////////////////////////////////////////////
      // private properties
      //////////////////////////////////////////////////////////////////////////
      private CombinedTag tag        = new CombinedTag ();
      private InfoTag     info_tag   = null;
      private MovieIdTag  mid_tag    = null;
      private DivXTag     divx_tag   = null;
      private Id3v2.Tag   id32_tag   = null;
      private Properties  properties = null;
      
      public static readonly ByteVector FileIdentifier = "RIFF";
      
      public File (string file, ReadStyle properties_style) : base (file)
      {
         long tag_start, tag_end;
         
         Mode = AccessMode.Read;
         Read (true, properties_style, out tag_start, out tag_end);
         Mode = AccessMode.Closed;
         
         GetTag (TagTypes.Id3v2, true);
         GetTag (TagTypes.RiffInfo, true);
         GetTag (TagTypes.MovieId, true);
         GetTag (TagTypes.DivX, true);
      }
      
      private void Read (bool read_tags, ReadStyle style, out long tag_start, out long tag_end)
      {
         Seek (0);
         if (ReadBlock (4) != FileIdentifier)
            throw new CorruptFileException ("File does not begin with RIFF identifier");
         
         ReadBlock (4);
         ByteVector stream_format = ReadBlock (4);
         tag_start = -1;
         tag_end   = -1;
         
         long position = 12;
         long length = Length;
         do
         {
            bool   tag_found = false;
            
            Seek (position);
            string fourcc = ReadBlock (4).ToString ();
            uint   size = ReadBlock (4).ToUInt (false);
            switch (fourcc)
            {
            case "LIST":
            {
               switch (ReadBlock (4).ToString ())
               {
               case "hdrl":
                  if (stream_format == "AVI " && style != ReadStyle.None && properties == null)
                     properties = new AviProperties (this, position + 12, (int) (size - 4), style);
                  break;
               case "INFO":
               {
                  if (read_tags && info_tag == null)
                     info_tag = new InfoTag (this, position + 12, (int) (size - 4));
                  tag_found = true;
                  break;
               }
               case "MID ":
                  if (read_tags && mid_tag == null)
                     mid_tag = new MovieIdTag (this, position + 12, (int) (size - 4));
                  tag_found = true;
                  break;
               }
               break;
            }
            case "ID32":
               if (read_tags && id32_tag == null)
                  id32_tag = new Id3v2.Tag (this, position + 8);
               tag_found = true;
               break;
            case "IDVX":
               if (read_tags && divx_tag == null)
                  divx_tag = new DivXTag (this, position + 8);
               tag_found = true;
               break;
            case "JUNK":
               if (tag_end == position)
                  tag_end = position + 8 + size;
               break;
            }
            
            if (tag_found)
            {
               if (tag_start == -1)
               {
                  tag_start = position;
                  tag_end = position + 8 + size;
               }
               else if (tag_end == position)
                  tag_end = position + 8 + size;
            }
            
            position += 8 + size;
         }
         while (position + 8 < length);
         
         if (read_tags)
            tag.SetTags (id32_tag, info_tag, mid_tag, divx_tag);
      }
      
      public override Tag Tag {get {return tag;}}
      
      public override TagLib.Properties Properties {get {return properties;}}
      public override TagLib.Tag GetTag (TagTypes type, bool create)
      {
         TagLib.Tag tag = null;
         
         switch (type)
         {
         case TagTypes.Id3v2:
            if (id32_tag == null && create)
            {
               id32_tag = new Id3v2.Tag ();
               id32_tag.Header.FooterPresent = true;
               TagLib.Tag.Duplicate (this.tag, id32_tag, true);
            }
            tag = id32_tag;
            break;
         case TagTypes.RiffInfo:
            if (info_tag == null && create)
            {
               info_tag = new InfoTag ();
               TagLib.Tag.Duplicate (this.tag, info_tag, true);
            }
            tag = info_tag;
            break;
         case TagTypes.MovieId:
            if (mid_tag == null && create)
            {
               mid_tag = new MovieIdTag ();
               TagLib.Tag.Duplicate (this.tag, mid_tag, true);
            }
            tag = mid_tag;
            break;
         case TagTypes.DivX:
            if (divx_tag == null && create)
            {
               divx_tag = new DivXTag ();
               TagLib.Tag.Duplicate (this.tag, divx_tag, true);
            }
            tag = divx_tag;
            break;
         }
         
         this.tag.SetTags (id32_tag, info_tag, mid_tag, divx_tag);
         return tag;
      }
      
      public override void RemoveTags (TagTypes types)
      {
         if ((types & TagLib.TagTypes.Id3v2) != TagLib.TagTypes.NoTags)
            id32_tag = null;
         if ((types & TagLib.TagTypes.RiffInfo) != TagLib.TagTypes.NoTags)
            info_tag = null;
         if ((types & TagLib.TagTypes.MovieId) != TagLib.TagTypes.NoTags)
            mid_tag  = null;
         if ((types & TagLib.TagTypes.DivX) != TagLib.TagTypes.NoTags)
            divx_tag = null;
         
         tag.SetTags (id32_tag, info_tag, mid_tag, divx_tag);
      }
      
      public override void Save ()
      {
         Mode = AccessMode.Write;
         
         ByteVector data = new ByteVector ();
         
         if (id32_tag != null)
         {
            ByteVector tag_data = id32_tag.Render ();
            if (tag_data.Count > 10)
            {
               data.Add ("ID32");
               data.Add (ByteVector.FromUInt ((uint) tag_data.Count, false));
               data.Add (tag_data);
            }
         }
         
         if (info_tag != null)
            data.Add (info_tag.RenderEnclosed ());
         
         if (mid_tag != null)
            data.Add (mid_tag.RenderEnclosed ());
         
         if (divx_tag != null && !divx_tag.IsEmpty)
         {
            ByteVector tag_data = divx_tag.Render ();
            data.Add ("IDVX");
            data.Add (ByteVector.FromUInt ((uint) tag_data.Count, false));
            data.Add (tag_data);
         }
         
         long tag_start, tag_end;
         Read (false, ReadStyle.None, out tag_start, out tag_end);
         
         if (tag_start >= 12 && tag_end > tag_start)
         {
            int length = (int)(tag_end - tag_start);
            int difference = length - data.Count - 8;
            if (difference < 0)
               difference = 1024;
            
            data.Add ("JUNK");
            data.Add (ByteVector.FromUInt ((uint)difference, false));
            data.Add (new ByteVector (difference));
            
            Insert (data, tag_start, length);
         }
         else
            Insert (data, Length);
         
         Mode = AccessMode.Closed;
      }
   }
}
