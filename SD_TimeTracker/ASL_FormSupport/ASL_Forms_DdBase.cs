using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASL.Forms
{
  [Serializable]
  public class DdBase
  {
    public DateTime Created { get; set; }
    public int Id { get; set; }
    public DateTime Modified { get; set; }
    public string ModifiedBy { get; set; }
    public byte[] Timestamp { get; set; }

    public string _Code { get; set; }
    public string _Description { get;  set; }

    public const string Created_N = "Created";
    public const string Id_N = "Id";
    public const string Modified_N = "Modified";
    public const string ModifiedBy_N = "ModifiedBy";
    public const string Timestamp_N = "Timestamp";

    public const int ModifiedBy_L = 50;

    public DdBase()
    {
      Clear();
    }

    public DdBase(DdBase original)
    {
      Created = original.Created;
      Id = original.Id;
      Modified = original.Modified;
      ModifiedBy = original.ModifiedBy;
      Timestamp = original.Timestamp;
    }

    public virtual void Clear()
    {
      Created = DateTime.MinValue;
      Id = 0;
      Modified = DateTime.MinValue;
      ModifiedBy = "";
      Timestamp = null;
    }

    public virtual void SetDefaults()
    {
      Modified = ASL.Run.Config.EMPTYDATE;
      ModifiedBy = string.Empty;
    }
  }


}
