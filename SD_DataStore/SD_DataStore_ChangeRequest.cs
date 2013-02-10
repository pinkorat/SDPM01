// Generated: Sun Jan 27, 2013 11:01:56

using System;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;
using System.Windows.Forms;
using System.ComponentModel;
using ASL;
using ASL.Forms;

namespace SD
{
  public partial class DataStore
  {
#if false
    static public BindingList<DdChangeRequestExt> GetChangeRequests()
    {
      BindingList<DdChangeRequestExt> list = new BindingList<DdChangeRequestExt>();
      DaChangeRequest da = new DaChangeRequest(DataStore.DbConnection);
      DnChangeRequest dn = da.Fill();
      foreach (DdChangeRequest dd in dn) list.Add(new DdChangeRequestExt(dd));
      return list;
    }
#endif

    static public bool SaveChangeRequest(ref DdChangeRequestExt item, RevisionInfo revisionInfo)
    {
      DaChangeRequest da = new DaChangeRequest(DataStore.DbConnection);
      if (!da.GetById(item.Id)) return false;
      da.ApplicationREF = item.ApplicationREF;
      da.Comment = item.Comment;
      da.RequestID = item.RequestID;
      da.Title = item.Title;
      bool ok = true;
      if (da._IsModified)
      {
        da.Modified = DateTime.Now;
        da.ModifiedBy = Environment.UserName;
        ok = da.Save();
        if (ok) AddChangeLog(da.TableName, da.Id, da.Timestamp, revisionInfo);
        if (ok) item = new DdChangeRequestExt(da.GetBuffer());
      }
      return ok;
    }

    static public bool AddChangeRequest(ref DdChangeRequestExt item, RevisionInfo revisionInfo)
    {
      DaChangeRequest da = new DaChangeRequest(DataStore.DbConnection);
      da.Clear();
      da.ApplicationREF = item.ApplicationREF;
      da.Comment = item.Comment;
      da.Modified = item.Modified;
      da.ModifiedBy = item.ModifiedBy;
      da.RequestID = item.RequestID;
      da.Title = item.Title;
      bool ok = da.Insert();
      if (ok) AddChangeLog(da.TableName, da.Id, da.Timestamp, revisionInfo); //add
      if (ok) item = new DdChangeRequestExt(da.GetBuffer());
      return ok;
    }

    static public bool DeleteChangeRequest(DdChangeRequestExt item, RevisionInfo revisionInfo)
    {
      DaChangeRequest da = new DaChangeRequest(DataStore.DbConnection);
      bool ok = da.DeleteById(item.Id);
      if (ok) AddChangeLog(da.TableName, item.Id, item.Timestamp, revisionInfo); //delete
	  return ok;
    }

    static public DdChangeRequestExt GetChangeRequestInfo(int changeRequestREF)
    {
      DaChangeRequest da = new DaChangeRequest(DataStore.DbConnection);
      if (da.GetById(changeRequestREF))
        return new DdChangeRequestExt(da.GetBuffer());
      else
        return null;
    }

    static public BindingList<DdChangeRequestExt> GetChangeRequestList(int applicationREF)
    {
      DaChangeRequest daChangeRequest = new DaChangeRequest(DataStore.DbConnection);
      DnChangeRequest dn = daChangeRequest.FillByApplication(applicationREF);
      BindingList<DdChangeRequestExt> list = new BindingList<DdChangeRequestExt>();
      foreach (DdChangeRequest dd in dn)
        list.Add(new DdChangeRequestExt(dd));
      return list;
    }

    static public void UpdateChangeRequest(BindingSource binding, int applicationREF, RevisionInfo revInfo)
    {
      BindingList<DdChangeRequestExt> list = (BindingList<DdChangeRequestExt>)binding.DataSource;
      try
      {
        using (TransactionScope scope = new TransactionScope())
        {
        DaChangeRequest da = new DaChangeRequest(DataStore.CloneDbConnection());
        foreach (DdChangeRequestExt item in list)
        {// do deletes first
          bool existing = da.GetById(item.Id);
          if (existing && item.DeleteFlag)
          {// delete here - avoid validation
            da.DeleteById(item.Id);
            AddChangeLog(da.TableName, item.Id, da.Timestamp, revInfo);  
          }
        }
        
        foreach (DdChangeRequestExt item in list)
        {
          if (item.DeleteFlag) continue; // already done above
          //if (item.ChangeRequestID == string.Empty) continue; // already done above
          bool existing = da.GetById(item.Id);
          if (!existing)
          {
            da.Clear();
          }
          da.ApplicationREF = item.ApplicationREF;
          da.Comment = item.Comment;
          da.RequestID = item.RequestID;
          da.Title = item.Title;
          if (!existing)
          {
            da.ApplicationREF = applicationREF;
            da.Insert();
            AddChangeLog(da.TableName, da.Id, da.Timestamp, revInfo); 
          }
          else
          {
            if (!da._IsModified) continue;
            da.Modified = DateTime.Now;
            da.ModifiedBy = Environment.UserName;
            da.Save();
            AddChangeLog(da.TableName, da.Id, da.Timestamp, revInfo);           }
        }
          scope.Complete();
        }
        binding.DataSource = GetChangeRequestList(applicationREF);
      }
      catch (AppEx)
      {
        throw;
      }
      catch (Exception exc)
      {
        throw new AppEx(exc, "Error updating ChangeRequest");
      }
    }
  }
  
  public class DdChangeRequestExt : DdChangeRequest
  {
    public bool DeleteFlag { get; set; }

    public DdChangeRequestExt()
      : base()
    {
    }

    public DdChangeRequestExt(DdChangeRequest dd)
      : base(dd)
    {
    }
  }

}
