// Generated: Sun Jan 27, 2013 11:01:57

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
    static public BindingList<DdTaskChargeCodeExt> GetTaskChargeCodes()
    {
      BindingList<DdTaskChargeCodeExt> list = new BindingList<DdTaskChargeCodeExt>();
      DaTaskChargeCode da = new DaTaskChargeCode(DataStore.DbConnection);
      DnTaskChargeCode dn = da.Fill();
      foreach (DdTaskChargeCode dd in dn) list.Add(new DdTaskChargeCodeExt(dd));
      return list;
    }
#endif

    static public bool SaveTaskChargeCode(ref DdTaskChargeCodeExt item, RevisionInfo revisionInfo)
    {
      DaTaskChargeCode da = new DaTaskChargeCode(DataStore.DbConnection);
      if (!da.GetById(item.Id)) return false;
      da.Description = item.Description;
      da.TaskChargeCodeID = item.TaskChargeCodeID;
      da.TaskHeadingRoleREF = item.TaskHeadingRoleREF;
      da.Title = item.Title;
      bool ok = true;
      if (da._IsModified)
      {
        da.Modified = DateTime.Now;
        da.ModifiedBy = Environment.UserName;
        ok = da.Save();
        if (ok) AddChangeLog(da.TableName, da.Id, da.Timestamp, revisionInfo);
        if (ok) item = new DdTaskChargeCodeExt(da.GetBuffer());
      }
      return ok;
    }

    static public bool AddTaskChargeCode(ref DdTaskChargeCodeExt item, RevisionInfo revisionInfo)
    {
      DaTaskChargeCode da = new DaTaskChargeCode(DataStore.DbConnection);
      da.Clear();
      da.Description = item.Description;
      da.Modified = item.Modified;
      da.ModifiedBy = item.ModifiedBy;
      da.TaskChargeCodeID = item.TaskChargeCodeID;
      da.TaskHeadingRoleREF = item.TaskHeadingRoleREF;
      da.Title = item.Title;
      bool ok = da.Insert();
      if (ok) AddChangeLog(da.TableName, da.Id, da.Timestamp, revisionInfo); //add
      if (ok) item = new DdTaskChargeCodeExt(da.GetBuffer());
      return ok;
    }

    static public bool DeleteTaskChargeCode(DdTaskChargeCodeExt item, RevisionInfo revisionInfo)
    {
      DaTaskChargeCode da = new DaTaskChargeCode(DataStore.DbConnection);
      bool ok = da.DeleteById(item.Id);
      if (ok) AddChangeLog(da.TableName, item.Id, item.Timestamp, revisionInfo); //delete
	  return ok;
    }

    static public DdTaskChargeCodeExt GetTaskChargeCodeInfo(int taskChargeCodeREF)
    {
      DaTaskChargeCode da = new DaTaskChargeCode(DataStore.DbConnection);
      if (da.GetById(taskChargeCodeREF))
        return new DdTaskChargeCodeExt(da.GetBuffer());
      else
        return null;
    }

    static public BindingList<DdTaskChargeCodeExt> GetTaskChargeCodeList(int taskHeadingRoleREF)
    {
      DaTaskChargeCode daTaskChargeCode = new DaTaskChargeCode(DataStore.DbConnection);
      DnTaskChargeCode dn = daTaskChargeCode.FillByTaskHeadingRole(taskHeadingRoleREF);
      BindingList<DdTaskChargeCodeExt> list = new BindingList<DdTaskChargeCodeExt>();
      foreach (DdTaskChargeCode dd in dn)
        list.Add(new DdTaskChargeCodeExt(dd));
      return list;
    }

    static public void UpdateTaskChargeCode(BindingSource binding, int taskHeadingRoleREF, RevisionInfo revInfo)
    {
      BindingList<DdTaskChargeCodeExt> list = (BindingList<DdTaskChargeCodeExt>)binding.DataSource;
      try
      {
        using (TransactionScope scope = new TransactionScope())
        {
        DaTaskChargeCode da = new DaTaskChargeCode(DataStore.CloneDbConnection());
        foreach (DdTaskChargeCodeExt item in list)
        {// do deletes first
          bool existing = da.GetById(item.Id);
          if (existing && item.DeleteFlag)
          {// delete here - avoid validation
            da.DeleteById(item.Id);
            AddChangeLog(da.TableName, item.Id, da.Timestamp, revInfo);  
          }
        }
        
        foreach (DdTaskChargeCodeExt item in list)
        {
          if (item.DeleteFlag) continue; // already done above
          //if (item.Id == string.Empty) continue; // already done above
          bool existing = da.GetById(item.Id);
          if (!existing)
          {
            da.Clear();
          }
          da.Description = item.Description;
          da.TaskChargeCodeID = item.TaskChargeCodeID;
          da.TaskHeadingRoleREF = item.TaskHeadingRoleREF;
          da.Title = item.Title;
          if (!existing)
          {
            da.TaskHeadingRoleREF = taskHeadingRoleREF;
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
        binding.DataSource = GetTaskChargeCodeList(taskHeadingRoleREF);
      }
      catch (AppEx)
      {
        throw;
      }
      catch (Exception exc)
      {
        throw new AppEx(exc, "Error updating TaskChargeCode");
      }
    }
  }
  
  public class DdTaskChargeCodeExt : DdTaskChargeCode
  {
    public bool DeleteFlag { get; set; }

    public DdTaskChargeCodeExt()
      : base()
    {
    }

    public DdTaskChargeCodeExt(DdTaskChargeCode dd)
      : base(dd)
    {
    }
  }

}
