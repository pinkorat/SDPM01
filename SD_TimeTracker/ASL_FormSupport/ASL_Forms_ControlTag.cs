using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ASL;
using DD = ASL.GEN.DD;

namespace ASL.Forms
{
  public class ControlTag
  {
    public DD.FieldDef FieldDef { get; set; }
    public object Content { get; set; }
    public CheckBox EnableCheck { get; set; }
    public Control CheckEnabledControl { get; set; }
    public bool IsValueChanged { get; set; }

    public string Text
    {
      get
      {
        return (Content == null) ? string.Empty : Content.ToString();
      }
      set
      {
        Content = value;
      }
    }

    public ControlTag() { }

    public ControlTag(DD.FieldDef fdef)
    {
      FieldDef = fdef;
      Clear();
    }

    public void Clear()
    {
      IsValueChanged = false;

      if (FieldDef.CsType == typeof(string))
        Content = string.Empty;
      else if (FieldDef.CsType == typeof(bool))
        Content = false;
      else if (FieldDef.CsType == typeof(DateTime))
        Content = ASL.Run.Config.EMPTYDATE;
      //else if (FieldDef.CsType == typeof(int) || 
      //  FieldDef.CsType == typeof(decimal) || 
      //  FieldDef.CsType == typeof(float) || 
      //  FieldDef.CsType == typeof(double))
      //  Content = Convert.ChangeType(0, FieldDef.CsType);

    }
  }
}
