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
    static public BindingList<DdTaskRoleExt> GetTaskRoles()
    {
      BindingList<DdTaskRoleExt> list = new BindingList<DdTaskRoleExt>();
      DaTaskRole da = new DaTaskRole(DataStore.DbConnection);
      DnTaskRole dn = da.Fill();
      foreach (DdTaskRole dd in dn) list.Add(new DdTaskRoleExt(dd));
      return list;
    }
#endif

    static public bool SaveTaskRole(ref DdTaskRoleExt item, RevisionInfo revisionInfo)
    {
      DaTaskRole da = new DaTaskRole(DataStore.DbConnection);
      if (!da.GetById(item.Id)) return false;
      da.Description = item.Description;
      da.OnlyOne = item.OnlyOne;
      da.ProjectLevel = item.ProjectLevel;
      da.TaskRoleID = item.TaskRoleID;
      da.Title = item.Title;
      bool ok = true;
      if (da._IsModified)
      {
        da.Modified = DateTime.Now;
        da.ModifiedBy = Environment.UserName;
        ok = da.Save();
        if (ok) AddChangeLog(da.TableName, da.Id, da.Timestamp, revisionInfo);
        if (ok) item = new DdTaskRoleExt(da.GetBuffer());
      }
      return ok;
    }

    static public bool AddTaskRole(ref DdTaskRoleExt item, RevisionInfo revisionInfo)
    {
      DaTaskRole da = new DaTaskRole(DataStore.DbConnection);
      da.Clear();
      da.Description = item.Description;
      da.Modified = item.Modified;
      da.ModifiedBy = item.ModifiedBy;
      da.OnlyOne = item.OnlyOne;
      da.ProjectLevel = item.ProjectLevel;
      da.TaskRoleID = item.TaskRoleID;
      da.Title = item.Title;
      bool ok = da.Insert();
      if (ok) AddChangeLog(da.TableName, da.Id, da.Timestamp, revisionInfo); //add
      if (ok) item = new DdTaskRoleExt(da.GetBuffer());
      return ok;
    }

    static public bool DeleteTaskRole(DdTaskRoleExt item, RevisionInfo revisionInfo)
    {
      DaTaskRole da = new DaTaskRole(DataStore.DbConnection);
      bool ok = da.DeleteById(item.Id);
      if (ok) AddChangeLog(da.TableName, item.Id, item.Timestamp, revisionInfo); //delete
	  return ok;
    }

    static public DdTaskRoleExt GetTaskRoleInfo(int taskRoleREF)
    {
      DaTaskRole da = new DaTaskRole(DataStore.DbConnection);
      if (da.GetById(taskRoleREF))
        return new DdTaskRoleExt(da.GetBuffer());
      else
        return null;
    }

    static public BindingList<DdTaskRoleExt> GetTaskRoleList()
    {
      DaTaskRole daTaskRole = new DaTaskRole(DataStore.DbConnection);
      DnTaskRole dn = daTaskRole.Fill();
      BindingList<DdTaskRoleExt> list = new BindingList<DdTaskRoleExt>();
      foreach (DdTaskRole dd in dn)
        list.Add(new DdTaskRoleExt(dd));
      return list;
    }

    static public void UpdateTaskRole(BindingSource binding, RevisionInfo revInfo)
    {
      BindingList<DdTaskRoleExt> list = (BindingList<DdTaskRoleExt>)binding.DataSource;
      try
      {
        using (TransactionScope scope = new TransactionScope())
        {
        DaTaskRole da = new DaTaskRole(DataStore.CloneDbConnection());
        foreach (DdTaskRoleExt item in list)
        {// do deletes first
          bool existing = da.GetById(item.Id);
          if (existing && item.DeleteFlag)
          {// delete here - avoid validation
            da.DeleteById(item.Id);
            AddChangeLog(da.TableName, item.Id, da.Timestamp, revInfo);  
          }
        }
        
        foreach (DdTaskRoleExt item in list)
        {
          if (item.DeleteFlag) continue; // already done above
          //if (item.TaskRoleID == string.Empty) continue; // already done above
          bool existing = da.GetById(item.Id);
          if (!existing)
          {
            da.Clear();
          }
          da.Description = item.Description;
          da.OnlyOne = item.OnlyOne;
          da.ProjectLevel = item.ProjectLevel;
          da.TaskRoleID = item.TaskRoleID;
          da.Title = item.Title;
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
        binding.DataSource = GetTaskRoleList();
      }
      catch (AppEx)
      {
        throw;
      }
      catch (Exception exc)
      {
        throw new AppEx(exc, "Error updating TaskRole");
      }
    }
  }
  
  public class DdTaskRoleExt : DdTaskRole
  {
    public bool DeleteFlag { get; set; }

    public DdTaskRoleExt()
      : base()
    {
    }

    public DdTaskRoleExt(DdTaskRole dd)
      : base(dd)
    {
    }
  }

}
