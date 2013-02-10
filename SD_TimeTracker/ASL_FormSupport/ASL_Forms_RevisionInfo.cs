using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASL.Forms
{
  public class RevisionInfo
  {
    //public string TargetTableName { get; set; }
    //public int TargetTableREF { get; set; }
    public string Function { get; set; }
    public string Reference { get; set; }
    public string Comments { get; set; }

    public RevisionInfo() 
    {
      Function = string.Empty;
      Reference = string.Empty;
      Comments = string.Empty;
    }
  }
}
