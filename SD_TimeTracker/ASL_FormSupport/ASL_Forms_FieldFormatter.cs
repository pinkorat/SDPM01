using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ASL;
using DD = ASL.GEN.DD;

namespace ASL.Forms
{
  static public class FieldFormatter
  {
    static private RichTextBox rtf1 = new RichTextBox();
    //static private TextEditorForm tef = new TextEditorForm();
    public const string RtfCSI = @"{\rtf";

    static public string GetTextFromHtml(string htmlText)
    {
      string v;
      if (htmlText.StartsWith(RtfCSI))
      {
        rtf1.Rtf = htmlText;
        v = rtf1.Text;
      }
      else if (DataStore.IsHtml(htmlText))
      {
        //v = tef.GetText(htmlText);
        v = DataStore.GetTextFromHtml(htmlText);
      }
      else v = htmlText;

      return v;
    }

    static public string Format(object v, ControlTag ctag)
    {
      DD.FieldDef fdef = ctag.FieldDef;
      if (v is string)
      {
#if __USE_RTF__
#else
        string t = (string)v;
        if (t.StartsWith(RtfCSI))
        {
          rtf1.Rtf = t;
          v = rtf1.Text;
        }
        else if (DataStore.IsHtml(t))
        {
          //v = tef.GetText(t);
          v = DataStore.GetTextFromHtml(t);
        }
        else if (fdef.IsLIST)
        {
          string[] k = t.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
          for (int i = 0; i < k.Length; i++) k[i] = k[i].Trim();
          v = string.Join("," + Environment.NewLine, k);
        }
#endif
      }

      string format = fdef.Format;
      if (format != string.Empty) format = "{0:" + format + "}";

      if (v is String)
      {
        return v.ToString();
      }
      else if (v is Int32)
      {
        if (format != string.Empty)
          return string.Format(format, v);
        else
          return v.ToString();
      }
      else if (v is Double)
      {
        if (fdef.UnitType != string.Empty)
        {
          return UnitConvertor.Format(fdef.UnitType, fdef.Format, (double)v);
        }
        else if (format != string.Empty)
          return string.Format(format, v);
        else
          return v.ToString();
      }
      else if (v is DateTime)
      {
        if ((DateTime)v == ASL.Run.Config.EMPTYDATE) return string.Empty;
        if (format != string.Empty)
          return string.Format(format, v);
        else
          return string.Format("{0:MM/dd/yyyy}", v);
      }
      else if (v is Boolean)
      {
        return ((bool)v) ? "Yes" : "No";
      }
      else if (v is Decimal)
      {
        if (format != string.Empty)
          return string.Format(format, v);
        else
          return v.ToString();
      }
      else if (v is Byte)
      {
        if (format != string.Empty)
          return string.Format(format, v);
        else
          return v.ToString();
      }
      else if (v is Char)
      {
        if (format != string.Empty)
          return string.Format(format, v);
        else
          return v.ToString();
      }
      else if (v is Int16)
      {
        if (format != string.Empty)
          return string.Format(format, v);
        else
          return v.ToString();
      }
      else if (v is Int64)
      {
        if (format != string.Empty)
          return string.Format(format, v);
        else
          return v.ToString();
      }
      else if (v is SByte)
      {
        if (format != string.Empty)
          return string.Format(format, v);
        else
          return v.ToString();
      }
      else if (v is Single)
      {
        if (format != string.Empty)
          return string.Format(format, v);
        else
          return v.ToString();
      }
      else if (v is UInt16)
      {
        if (format != string.Empty)
          return string.Format(format, v);
        else
          return v.ToString();
      }
      else if (v is UInt32)
      {
        if (format != string.Empty)
          return string.Format(format, v);
        else
          return v.ToString();
      }
      else if (v is UInt64)
      {
        if (format != string.Empty)
          return string.Format(format, v);
        else
          return v.ToString();
      }
      else if (v == null)
      {
        return string.Empty;
      }
      else
      {
        if (format != string.Empty)
          return string.Format(format, v);
        else
          return v.ToString();
      }
    }
  }
}
