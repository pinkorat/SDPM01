// Generated: Wed May 02, 2012 04:24:01

using System;
using System.Transactions;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using ASL;


namespace ASL.Forms
{
  public partial class DataStore
  {
#if false
    static public BindingList<DdChangeLogExt> GetChangeLogs()
    {
      BindingList<DdChangeLogExt> list = new BindingList<DdChangeLogExt>();
      DaChangeLog da = new DaChangeLog(DataStore.DbConnection);
      DnChangeLog dn = da.Fill();
      foreach (DdChangeLog dd in dn) list.Add(new DdChangeLogExt(dd));
      return list;
    }
#endif

#if false
    static public bool SaveChangeLog(ref DdChangeLogExt item)
    {
      DaChangeLog da = new DaChangeLog(DataStore.DbConnection);
      if (!da.GetById(item.Id)) return false;
      da.Comments = item.Comments;
      da.FsaRevisionLogREF = item.FsaRevisionLogREF;
      da.FsaStaffREF = item.FsaStaffREF;
      da.Function = item.Function;
      da.MachineName = item.MachineName;
      da.Reference = item.Reference;
      da.TargetTableName = item.TargetTableName;
      da.TargetTableREF = item.TargetTableREF;
      da.TargetTableTimestamp = item.TargetTableTimestamp;
      da.UserDomainName = item.UserDomainName;
      da.UserName = item.UserName;
      bool ok = true;
      if (da._IsModified)
      {
        ok = da.Save();
        if (ok) item = new DdChangeLogExt(da.GetBuffer());
      }
      return ok;
    }
#endif

    static public bool AddChangeLog(
      string targetTableName, int targetTableREF, byte[] targetTableTimestamp,
      RevisionInfo revisionInfo)
    {
      return AddChangeLog(
        targetTableName, targetTableREF, targetTableTimestamp,
        revisionInfo.Function, revisionInfo.Reference, revisionInfo.Comments);
    }

    static public bool AddChangeLog(
      string targetTableName, int targetTableREF, byte[] targetTableTimestamp,
      string function, string reference, string comments)
    {
#if false
      DaChangeLog da = new DaChangeLog(DataStore.DbConnection);
      da.Clear();
      da.Comments = comments;
      da.FsaRevisionLogREF = NullId;
      da.FsaStaffREF = DataStore.UserInfo.Id;
      da.Function = TruncateText(function, DdChangeLog.Function_L);
      da.MachineName = Environment.MachineName;
      da.Reference = reference;
      da.TargetTableName = TruncateText(targetTableName, DdChangeLog.TargetTableName_L);
      da.TargetTableREF = targetTableREF;
      da.TargetTableTimestamp = targetTableTimestamp;
      da.UserDomainName = Environment.UserDomainName;
      da.UserName = Environment.UserName;
      bool ok = da.Insert();
      return ok;
#else
      return true;
#endif
    }

    static public bool AddChangeLog(ref DdChangeLogExt item)
    {
#if false
      DaChangeLog da = new DaChangeLog(DataStore.DbConnection);
      da.Clear();
      da.Comments = item.Comments;
      da.FsaRevisionLogREF = item.FsaRevisionLogREF;
      da.FsaStaffREF = item.FsaStaffREF;
      da.Function = item.Function;
      da.MachineName = item.MachineName;
      da.Reference = item.Reference;
      da.TargetTableName = item.TargetTableName;
      da.TargetTableREF = item.TargetTableREF;
      da.TargetTableTimestamp = item.TargetTableTimestamp;
      da.UserDomainName = item.UserDomainName;
      da.UserName = item.UserName;
      bool ok = da.Insert();
      if (ok) item = new DdChangeLogExt(da.GetBuffer());
      return ok;
#else
      return true;
#endif
    }

#if false
    static public bool DeleteChangeLog(DdChangeLogExt item)
    {
      DaChangeLog da = new DaChangeLog(DataStore.DbConnection);
      return da.DeleteById(item.Id);
    }

    static public DdChangeLogExt GetChangeLogInfo(int ChangeLogREF)
    {
      DaChangeLog da = new DaChangeLog(DataStore.DbConnection);
      if (da.GetById(ChangeLogREF))
        return new DdChangeLogExt(da.GetBuffer());
      else
        return null;
    }

    static public DdChangeLogExt GetChangeLogInfo()
    {// most recent change
      DaChangeLog da = new DaChangeLog(DataStore.DbConnection);
      DsChangeLog ds = new DsChangeLog();
      if (da.GetBySql("Id =(select MAX(Id) from ChangeLog)", ref ds))
      {
        return new DdChangeLogExt(ds.Buffer);
      }
      else
        return null;
    }

    static public BindingList<DdChangeLogExt> GetChangeLogList()
    {
      DaChangeLog daChangeLog = new DaChangeLog(DataStore.DbConnection);
      DnChangeLog dn = daChangeLog.Fill();
      BindingList<DdChangeLogExt> list = new BindingList<DdChangeLogExt>();
      foreach (DdChangeLog dd in dn)
        list.Add(new DdChangeLogExt(dd));
      return list;
    }

    static public BindingList<DdChangeLogExt> GetChangeLogList(
      DateTime dateFrom, DateTime dateThru, bool includePreviousRevs, int maxCount = 1000)
    {
      try
      {
        string sqlOrder = "Id desc";
        string sqlWhere = string.Format("(Id != 1) and " + 
          "(Created >= '{0:MM/dd/yyyy}') and (Created <= '{1:MM/dd/yyyy}')",
          dateFrom.Date, dateThru.AddDays(1).Date);
        if (!includePreviousRevs) sqlWhere += " and (FsaRevisionLogREF = 1)";

        using (ASL.SQL.DBConnection cnx = DataStore.CloneDbConnection())
        {
          DaChangeLog daChangeLog = new DaChangeLog(cnx);
          using (SqlDataReader reader = daChangeLog.GetReader(sqlWhere, sqlOrder))
          {
            BindingList<DdChangeLogExt> list = new BindingList<DdChangeLogExt>();
            while (reader.Read() && list.Count < maxCount)
            {
              DdChangeLog dd = DaChangeLog.LoadRow(reader);
              list.Add(new DdChangeLogExt(dd));
            }
            return list;
          }
        }
      }
      catch (Exception exc)
      {
        System.Diagnostics.Debug.WriteLine(exc.ToString());
        throw;
      }
    }

    static public BindingList<DdChangeLogExt> GetChangeLogList(
      string targetTableName, int targetTableREF, int maxCount = 1000)
    {
      try
      {
        string sqlOrder = "Id desc";
        string sqlWhere = string.Format("(Id != 1) and (FsaRevisionLogREF = 1)" +
          " and (TargetTableName = '{0}') and (TargetTableREF = '{1}')",
          targetTableName, targetTableREF);

        using (ASL.SQL.DBConnection cnx = DataStore.CloneDbConnection())
        {
          DaChangeLog daChangeLog = new DaChangeLog(cnx);
          using (SqlDataReader reader = daChangeLog.GetReader(sqlWhere, sqlOrder))
          {
            BindingList<DdChangeLogExt> list = new BindingList<DdChangeLogExt>();
            while (reader.Read() && list.Count < maxCount)
            {
              DdChangeLog dd = DaChangeLog.LoadRow(reader);
              list.Add(new DdChangeLogExt(dd));
            }
            return list;
          }
        }
      }
      catch (Exception exc)
      {
        System.Diagnostics.Debug.WriteLine(exc.ToString());
        throw;
      }
    }

    static public int GetChangeLogCount(int fsaRevisionLogREF)
    {
      string sql = string.Format(
        "select count(*) from ChangeLog where FsaRevisionLogREF={0}",
        fsaRevisionLogREF);
      DataTable dt = DataStore.ExecuteQuery(sql);
      return (int)dt.Rows[0][0];
    }

    static public int GetChangeLogUpdateLevel(int fsaRevisionLogREF)
    {
      string sql = string.Format(
        "select max(Id) from ChangeLog where FsaRevisionLogREF={0}",
        fsaRevisionLogREF);
      DataTable dt = DataStore.ExecuteQuery(sql);
      object t = dt.Rows[0][0];
      return (t is System.DBNull) ? 0 : (int)t;
    }

    static public void SetChangeLogRevision(string tableName, int tableREF)
    {
      string sql = string.Format(@"update ChangeLog 
        set FsaRevisionLogREF = a.FsaRevisionLogREF
        from ChangeLog as c
        inner join FsaRevisionArchive as a 
          on a.SourceTableName = c.TargetTableName
          and a.SourceTableId = c.TargetTableREF 
          and a.SourceTableTimestamp >= c.TargetTableTimestamp
        where c.FsaRevisionLogREF = 1
        and c.TargetTableName = '{0}'
        and c.TargetTableREF = {1};"
        , tableName, tableREF);
      DataStore.ExecuteNonQuery(sql);
    }

    static public void ResetChangeLogRevision(int fsaRevisionLogREF)
    {
      string sql = string.Format(@"update ChangeLog 
        set FsaRevisionLogREF = 1
        where FsaRevisionLogREF = {0}"
        , fsaRevisionLogREF);
      DataStore.ExecuteNonQuery(sql);
    }

    static public void UpdateChangeLog(BindingSource binding, int parentREF)
    {
      DaChangeLog daChangeLog = new DaChangeLog(DataStore.DbConnection);
      BindingList<DdChangeLogExt> list = (BindingList<DdChangeLogExt>)binding.DataSource;
      try
      {
        using (TransactionScope scope = new TransactionScope())
        {
        foreach (DdChangeLogExt item in list)
        {// do deletes first
          bool existing = daChangeLog.GetById(item.Id);
          if (existing && item.DeleteFlag)
          {// delete here - avoid validation
            daChangeLog.DeleteById(item.Id);
          }
        }
        
        foreach (DdChangeLogExt item in list)
        {
          if (item.DeleteFlag) continue; // already done above
          //if (item.Id == string.Empty) continue; // already done above
          bool existing = daChangeLog.GetById(item.Id);
          if (!existing)
          {
            daChangeLog.Clear();
          }
          daChangeLog.Comments = item.Comments;
          daChangeLog.FsaRevisionLogREF = item.FsaRevisionLogREF;
          daChangeLog.FsaStaffREF = item.FsaStaffREF;
          daChangeLog.Function = item.Function;
          daChangeLog.MachineName = item.MachineName;
          daChangeLog.Reference = item.Reference;
          daChangeLog.TargetTableName = item.TargetTableName;
          daChangeLog.TargetTableREF = item.TargetTableREF;
          daChangeLog.TargetTableTimestamp = item.TargetTableTimestamp;
          daChangeLog.UserDomainName = item.UserDomainName;
          daChangeLog.UserName = item.UserName;
          if (!existing)
          {
            daChangeLog.Insert();
          }
          else
          {
            if (!daChangeLog._IsModified) continue;
            daChangeLog.Save();
          }
        }
          scope.Complete();
        }
        binding.DataSource = GetChangeLogList();
      }
      catch (AppEx)
      {
        throw;
      }
      catch (Exception exc)
      {
        throw new AppEx(exc, "Error updating ChangeLog");
      }
    }
#endif
  }
  
#if false
  public class DdChangeLogExt : DdChangeLog
  {
    public bool DeleteFlag { get; set; }
    public string StaffName { get; set; }
    public UInt64 TargetTableTimestampUInt64 { get; set; }
    public string RevisionNumber { get; set; }

    public DdChangeLogExt()
      : base()
    {
    }

    public DdChangeLogExt(DdChangeLog dd)
      : base(dd)
    {
      System.Diagnostics.Debug.Assert(DataStore.StaffList != null);
      DropDownItem ddi = DataStore.StaffList.GetItem(dd.FsaStaffREF);
      StaffName = (ddi != null) ? ddi.Description : "USER NOT DEFINED";
      TargetTableTimestampUInt64 = DataStore.ConvertTimestamp(dd.TargetTableTimestamp);
      DdFsaRevisionLogExt ddr = DataStore.GetFsaRevisionLogInfo(dd.FsaRevisionLogREF);
      RevisionNumber = (ddr != null) ? ddr.RevisionNumber : string.Empty;
    }
  }
#else
  public class DdChangeLogExt 
  {
    public bool DeleteFlag { get; set; }
    public string StaffName { get; set; }
    public UInt64 TargetTableTimestampUInt64 { get; set; }
    public string RevisionNumber { get; set; }
  }
#endif
}
