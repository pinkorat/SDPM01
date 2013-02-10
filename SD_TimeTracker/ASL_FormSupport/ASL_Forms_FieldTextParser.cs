using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ASL;
using DD = ASL.GEN.DD;

namespace ASL.Forms
{
  static public class FieldTextParser
  {
    static public string GetControlTagValue(Control ctl)
    {
      ControlTag tag = ctl.Tag as ControlTag;
      if (tag == null) return string.Empty;
      return tag.Text;
    }

    static public object Parse(string text, ControlTag ctag, out Result result)
    {
      DD.FieldDef fdef = ctag.FieldDef;
      result = Result.Success;

      if (fdef.IsLIST)
      {
        string[] k = text.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < k.Length; i++) k[i] = k[i].Trim();
        return string.Join(", ", k);
      }

      if (fdef.IsHTML)
      {
        if (ctag.Text == string.Empty) return ctag.Text;
        if (DataStore.GetTextFromHtml(ctag.Text) == string.Empty) return string.Empty;
        return ctag.Text;
      }

      text = text.Trim();

      if (fdef.Required && text == string.Empty)
        result = new Result("Input required");
      else if (fdef.MaximumLength != 0 && text.Length > fdef.MaximumLength)
        result = new Result("Input too long");
      else if (text.Length < fdef.MinimumLength)
        result = new Result("Input too short");
      else if (fdef.Pattern != string.Empty)
      {
        Regex re = new Regex(fdef.Pattern);
        if (!re.IsMatch(text)) result = new Result("Input does not match required pattern");
      }
      else if (fdef.ValidValues != null && fdef.ValidValues.Length > 0)
      {
        if (!fdef.ValidValues.Contains(text)) result = new Result("Value must be in specified list");
      }

      if (fdef.CsType.Name == DD.CsTypeName.String)
      {
        string v = string.Empty;
        if (!result.Equals(Result.Success)) return v;
        if (text == string.Empty) return v;
        v = text;
        if (fdef.MinimumValue != string.Empty)
        {
          if (string.Compare(v, fdef.MinimumValue) < 0)
          {
            result = new Result("Must not be less than " + fdef.MinimumValue);
            return v;
          }
        }
        if (fdef.MaximumValue != string.Empty)
        {
          if (string.Compare(v, fdef.MaximumValue) > 0)
          {
            result = new Result("Must not be more than " + fdef.MaximumValue);
            return v;
          }
        }

        return text;
      }

      else if (fdef.CsType.Name == DD.CsTypeName.Int32)
      {
        Int32 v = 0;
        if (result != Result.Success) return v;
        if (text == string.Empty) return v;
        if (!Int32.TryParse(text, out v)) result = Result.InvalidEntry;

        if (fdef.MinimumValue != string.Empty)
        {
          Int32 min;
          if (Int32.TryParse(fdef.MinimumValue, out min))
            if (v < min)
            {
              result = new Result("Must not be less than " + fdef.MinimumValue);
              return v;
            }
        }
        if (fdef.MaximumValue != string.Empty)
        {
          Int32 max;
          if (Int32.TryParse(fdef.MaximumValue, out max))
            if (v > max)
            {
              result = new Result("Must not be more than " + fdef.MaximumValue);
              return v;
            }
        }

        return v;
      }

      else if (fdef.CsType.Name == DD.CsTypeName.Double)
      {
        Double v = 0;
        if (result != Result.Success) return v;
        //if (text == string.Empty) return v;
        if (text == string.Empty) text = "0.0";

        if (fdef.UnitType != string.Empty)
        {
          if (!UnitConvertor.TryParse(fdef.UnitType, text, out v)) result = Result.InvalidEntry;
        }
        else
        {
          if (!Double.TryParse(text, out v)) result = Result.InvalidEntry;
        }

        if (fdef.MinimumValue != string.Empty)
        {
          double min;
          if (double.TryParse(fdef.MinimumValue, out min))
            if (v < min)
            {
              result = new Result("Must not be less than " + fdef.MinimumValue);
              return v;
            }
        }
        if (fdef.MaximumValue != string.Empty)
        {
          double max;
          if (double.TryParse(fdef.MaximumValue, out max))
            if (v > max)
            {
              result = new Result("Must not be more than " + fdef.MaximumValue);
              return v;
            }
        }

        return v;
      }

      else if (fdef.CsType.Name == DD.CsTypeName.DateTime)
      {
        DateTime v = ASL.Run.Config.EMPTYDATE;
        if (result != Result.Success) return v;
        if (text == string.Empty) return v;
        if (!DateTime.TryParse(text, out v)) result = Result.InvalidEntry;

        if (fdef.MinimumValue != string.Empty)
        {
          DateTime min;
          if (DateTime.TryParse(fdef.MinimumValue, out min))
            if (v < min)
            {
              result = new Result("Must not be less than " + fdef.MinimumValue);
              return v;
            }
        }
        if (fdef.MaximumValue != string.Empty)
        {
          DateTime max;
          if (DateTime.TryParse(fdef.MaximumValue, out max))
            if (v > max)
            {
              result = new Result("Must not be more than " + fdef.MaximumValue);
              return v;
            }
        }

        return v;
      }

      else if (fdef.CsType.Name == DD.CsTypeName.Boolean)
      {
        Boolean v = false;
        if (result != Result.Success) return v;
        if (text == string.Empty) return v;
        if (!Boolean.TryParse(text, out v)) result = Result.InvalidEntry;
        return v;
      }

      else if (fdef.CsType.Name == DD.CsTypeName.Decimal)
      {
        Decimal v = 0;
        if (result != Result.Success) return v;
        if (text == string.Empty) return v;
        if (!Decimal.TryParse(text, out v)) result = Result.InvalidEntry;

        if (fdef.MinimumValue != string.Empty)
        {
          Decimal min;
          if (Decimal.TryParse(fdef.MinimumValue, out min))
            if (v < min)
            {
              result = new Result("Must not be less than " + fdef.MinimumValue);
              return v;
            }
        }
        if (fdef.MaximumValue != string.Empty)
        {
          Decimal max;
          if (Decimal.TryParse(fdef.MaximumValue, out max))
            if (v > max)
            {
              result = new Result("Must not be more than " + fdef.MaximumValue);
              return v;
            }
        }

        return v;
      }

      else if (fdef.CsType.Name == DD.CsTypeName.Byte)
      {
        Byte v = 0;
        if (result != Result.Success) return v;
        if (text == string.Empty) return v;
        if (!Byte.TryParse(text, out v)) result = Result.InvalidEntry;

        if (fdef.MinimumValue != string.Empty)
        {
          Byte min;
          if (Byte.TryParse(fdef.MinimumValue, out min))
            if (v < min)
            {
              result = new Result("Must not be less than " + fdef.MinimumValue);
              return v;
            }
        }
        if (fdef.MaximumValue != string.Empty)
        {
          Byte max;
          if (Byte.TryParse(fdef.MaximumValue, out max))
            if (v > max)
            {
              result = new Result("Must not be more than " + fdef.MaximumValue);
              return v;
            }
        }
        
        return v;
      }

      else if (fdef.CsType.Name == DD.CsTypeName.Char)
      {
        Char v = ' ';
        if (result != Result.Success) return v;
        if (text == string.Empty) return v;
        if (!Char.TryParse(text, out v)) result = Result.InvalidEntry;
        return v;
      }

      else if (fdef.CsType.Name == DD.CsTypeName.Int16)
      {
        Int16 v = 0;
        if (result != Result.Success) return v;
        if (text == string.Empty) return v;
        if (!Int16.TryParse(text, out v)) result = Result.InvalidEntry;

        if (fdef.MinimumValue != string.Empty)
        {
          Int16 min;
          if (Int16.TryParse(fdef.MinimumValue, out min))
            if (v < min)
            {
              result = new Result("Must not be less than " + fdef.MinimumValue);
              return v;
            }
        }
        if (fdef.MaximumValue != string.Empty)
        {
          Int16 max;
          if (Int16.TryParse(fdef.MaximumValue, out max))
            if (v > max)
            {
              result = new Result("Must not be more than " + fdef.MaximumValue);
              return v;
            }
        }
        
        return v;
      }

      else if (fdef.CsType.Name == DD.CsTypeName.Int64)
      {
        Int64 v = 0;
        if (result != Result.Success) return v;
        if (text == string.Empty) return v;
        if (!Int64.TryParse(text, out v)) result = Result.InvalidEntry;

        if (fdef.MinimumValue != string.Empty)
        {
          Int64 min;
          if (Int64.TryParse(fdef.MinimumValue, out min))
            if (v < min)
            {
              result = new Result("Must not be less than " + fdef.MinimumValue);
              return v;
            }
        }
        if (fdef.MaximumValue != string.Empty)
        {
          Int64 max;
          if (Int64.TryParse(fdef.MaximumValue, out max))
            if (v > max)
            {
              result = new Result("Must not be more than " + fdef.MaximumValue);
              return v;
            }
        }
        
        return v;
      }

      else if (fdef.CsType.Name == DD.CsTypeName.SByte)
      {
        SByte v = 0;
        if (result != Result.Success) return v;
        if (text == string.Empty) return v;
        if (!SByte.TryParse(text, out v)) result = Result.InvalidEntry;
        
        if (fdef.MinimumValue != string.Empty)
        {
          SByte min;
          if (SByte.TryParse(fdef.MinimumValue, out min))
            if (v < min)
            {
              result = new Result("Must not be less than " + fdef.MinimumValue);
              return v;
            }
        }
        if (fdef.MaximumValue != string.Empty)
        {
          SByte max;
          if (SByte.TryParse(fdef.MaximumValue, out max))
            if (v > max)
            {
              result = new Result("Must not be more than " + fdef.MaximumValue);
              return v;
            }
        }

        return v;
      }

      else if (fdef.CsType.Name == DD.CsTypeName.Single)
      {
        Single v = 0;
        if (result != Result.Success) return v;
        if (text == string.Empty) return v;
        if (!Single.TryParse(text, out v)) result = Result.InvalidEntry;

        if (fdef.MinimumValue != string.Empty)
        {
          Single min;
          if (Single.TryParse(fdef.MinimumValue, out min))
            if (v < min)
            {
              result = new Result("Must not be less than " + fdef.MinimumValue);
              return v;
            }
        }
        if (fdef.MaximumValue != string.Empty)
        {
          Single max;
          if (Single.TryParse(fdef.MaximumValue, out max))
            if (v > max)
            {
              result = new Result("Must not be more than " + fdef.MaximumValue);
              return v;
            }
        }

        return v;
      }

      else if (fdef.CsType.Name == DD.CsTypeName.UInt16)
      {
        UInt16 v = 0;
        if (result != Result.Success) return v;
        if (text == string.Empty) return v;
        if (!UInt16.TryParse(text, out v)) result = Result.InvalidEntry;
        
        if (fdef.MinimumValue != string.Empty)
        {
          UInt16 min;
          if (UInt16.TryParse(fdef.MinimumValue, out min))
            if (v < min)
            {
              result = new Result("Must not be less than " + fdef.MinimumValue);
              return v;
            }
        }
        if (fdef.MaximumValue != string.Empty)
        {
          UInt16 max;
          if (UInt16.TryParse(fdef.MaximumValue, out max))
            if (v > max)
            {
              result = new Result("Must not be more than " + fdef.MaximumValue);
              return v;
            }
        }

        return v;
      }

      else if (fdef.CsType.Name == DD.CsTypeName.UInt32)
      {
        UInt32 v = 0;
        if (result != Result.Success) return v;
        if (text == string.Empty) return v;
        if (!UInt32.TryParse(text, out v)) result = Result.InvalidEntry;
        
        if (fdef.MinimumValue != string.Empty)
        {
          UInt32 min;
          if (UInt32.TryParse(fdef.MinimumValue, out min))
            if (v < min)
            {
              result = new Result("Must not be less than " + fdef.MinimumValue);
              return v;
            }
        }
        if (fdef.MaximumValue != string.Empty)
        {
          UInt32 max;
          if (UInt32.TryParse(fdef.MaximumValue, out max))
            if (v > max)
            {
              result = new Result("Must not be more than " + fdef.MaximumValue);
              return v;
            }
        }

        return v;
      }

      else if (fdef.CsType.Name == DD.CsTypeName.UInt64)
      {
        UInt64 v = 0;
        if (result != Result.Success) return v;
        if (text == string.Empty) return v;
        if (!UInt64.TryParse(text, out v)) result = Result.InvalidEntry;
        
        if (fdef.MinimumValue != string.Empty)
        {
          UInt64 min;
          if (UInt64.TryParse(fdef.MinimumValue, out min))
            if (v < min)
            {
              result = new Result("Must not be less than " + fdef.MinimumValue);
              return v;
            }
        }
        if (fdef.MaximumValue != string.Empty)
        {
          UInt64 max;
          if (UInt64.TryParse(fdef.MaximumValue, out max))
            if (v > max)
            {
              result = new Result("Must not be more than " + fdef.MaximumValue);
              return v;
            }
        }

        return v;
      }

      else
      {
        result = new Result("Unrecognized type: " + fdef.CsType.ToString());
        return text;
      }
    }

  }
}
