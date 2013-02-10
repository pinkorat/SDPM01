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
    static public BindingList<DdApplicationExt> GetApplications()
    {
      BindingList<DdApplicationExt> list = new BindingList<DdApplicationExt>();
      DaApplication da = new DaApplication(DataStore.DbConnection);
      DnApplication dn = da.Fill();
      foreach (DdApplication dd in dn) list.Add(new DdApplicationExt(dd));
      return list;
    }
#endif

    static public bool SaveApplication(ref DdApplicationExt item, RevisionInfo revisionInfo)
    {
      DaApplication da = new DaApplication(DataStore.DbConnection);
      if (!da.GetById(item.Id)) return false;
      da.ApplicationID = item.ApplicationID;
      da.ApplicationName = item.ApplicationName;
      da.Comment = item.Comment;
      bool ok = true;
      if (da._IsModified)
      {
        da.Modified = DateTime.Now;
        da.ModifiedBy = Environment.UserName;
        ok = da.Save();
        if (ok) AddChangeLog(da.TableName, da.Id, da.Timestamp, revisionInfo);
        if (ok) item = new DdApplicationExt(da.GetBuffer());
      }
      return ok;
    }

    static public bool AddApplication(ref DdApplicationExt item, RevisionInfo revisionInfo)
    {
      DaApplication da = new DaApplication(DataStore.DbConnection);
      da.Clear();
      da.ApplicationID = item.ApplicationID;
      da.ApplicationName = item.ApplicationName;
      da.Comment = item.Comment;
      da.Modified = item.Modified;
      da.ModifiedBy = item.ModifiedBy;
      bool ok = da.Insert();
      if (ok) AddChangeLog(da.TableName, da.Id, da.Timestamp, revisionInfo); //add
      if (ok) item = new DdApplicationExt(da.GetBuffer());
      return ok;
    }

    static public bool DeleteApplication(DdApplicationExt item, RevisionInfo revisionInfo)
    {
      DaApplication da = new DaApplication(DataStore.DbConnection);
      bool ok = da.DeleteById(item.Id);
      if (ok) AddChangeLog(da.TableName, item.Id, item.Timestamp, revisionInfo); //delete
	  return ok;
    }

    static public DdApplicationExt GetApplicationInfo(int applicationREF)
    {
      DaApplication da = new DaApplication(DataStore.DbConnection);
      if (da.GetById(applicationREF))
        return new DdApplicationExt(da.GetBuffer());
      else
        return null;
    }

    static public BindingList<DdApplicationExt> GetApplicationList()
    {
      DaApplication daApplication = new DaApplication(DataStore.DbConnection);
      DnApplication dn = daApplication.Fill();
      BindingList<DdApplicationExt> list = new BindingList<DdApplicationExt>();
      foreach (DdApplication dd in dn)
        list.Add(new DdApplicationExt(dd));
      return list;
    }

    static public void UpdateApplication(BindingSource binding, RevisionInfo revInfo)
    {
      BindingList<DdApplicationExt> list = (BindingList<DdApplicationExt>)binding.DataSource;
      try
      {
        using (TransactionScope scope = new TransactionScope())
        {
        DaApplication da = new DaApplication(DataStore.CloneDbConnection());
        foreach (DdApplicationExt item in list)
        {// do deletes first
          bool existing = da.GetById(item.Id);
          if (existing && item.DeleteFlag)
          {// delete here - avoid validation
            da.DeleteById(item.Id);
            AddChangeLog(da.TableName, item.Id, da.Timestamp, revInfo);  
          }
        }
        
        foreach (DdApplicationExt item in list)
        {
          if (item.DeleteFlag) continue; // already done above
          //if (item.ApplicationID == string.Empty) continue; // already done above
          bool existing = da.GetById(item.Id);
          if (!existing)
          {
            da.Clear();
          }
          da.ApplicationID = item.ApplicationID;
          da.ApplicationName = item.ApplicationName;
          da.Comment = item.Comment;
          if (!existing)
          {
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
        binding.DataSource = GetApplicationList();
      }
      catch (AppEx)
      {
        throw;
      }
      catch (Exception exc)
      {
        throw new AppEx(exc, "Error updating Application");
      }
    }
  }
  
  public class DdApplicationExt : DdApplication
  {
    public bool DeleteFlag { get; set; }

    public DdApplicationExt()
      : base()
    {
    }

    public DdApplicationExt(DdApplication dd)
      : base(dd)
    {
    }
  }

}
