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
    static public BindingList<DdTaskHeadingRoleExt> GetTaskHeadingRoles()
    {
      BindingList<DdTaskHeadingRoleExt> list = new BindingList<DdTaskHeadingRoleExt>();
      DaTaskHeadingRole da = new DaTaskHeadingRole(DataStore.DbConnection);
      DnTaskHeadingRole dn = da.Fill();
      foreach (DdTaskHeadingRole dd in dn) list.Add(new DdTaskHeadingRoleExt(dd));
      return list;
    }
#endif

    static public bool SaveTaskHeadingRole(ref DdTaskHeadingRoleExt item, RevisionInfo revisionInfo)
    {
      DaTaskHeadingRole da = new DaTaskHeadingRole(DataStore.DbConnection);
      if (!da.GetById(item.Id)) return false;
      da.PersonREF = item.PersonREF;
      da.TaskHeadingREF = item.TaskHeadingREF;
      da.TaskRoleREF = item.TaskRoleREF;
      bool ok = true;
      if (da._IsModified)
      {
        da.Modified = DateTime.Now;
        da.ModifiedBy = Environment.UserName;
        ok = da.Save();
        if (ok) AddChangeLog(da.TableName, da.Id, da.Timestamp, revisionInfo);
        if (ok) item = new DdTaskHeadingRoleExt(da.GetBuffer());
      }
      return ok;
    }

    static public bool AddTaskHeadingRole(ref DdTaskHeadingRoleExt item, RevisionInfo revisionInfo)
    {
      DaTaskHeadingRole da = new DaTaskHeadingRole(DataStore.DbConnection);
      da.Clear();
      da.Modified = item.Modified;
      da.ModifiedBy = item.ModifiedBy;
      da.PersonREF = item.PersonREF;
      da.TaskHeadingREF = item.TaskHeadingREF;
      da.TaskRoleREF = item.TaskRoleREF;
      bool ok = da.Insert();
      if (ok) AddChangeLog(da.TableName, da.Id, da.Timestamp, revisionInfo); //add
      if (ok) item = new DdTaskHeadingRoleExt(da.GetBuffer());
      return ok;
    }

    static public bool DeleteTaskHeadingRole(DdTaskHeadingRoleExt item, RevisionInfo revisionInfo)
    {
      DaTaskHeadingRole da = new DaTaskHeadingRole(DataStore.DbConnection);
      bool ok = da.DeleteById(item.Id);
      if (ok) AddChangeLog(da.TableName, item.Id, item.Timestamp, revisionInfo); //delete
	  return ok;
    }

    static public DdTaskHeadingRoleExt GetTaskHeadingRoleInfo(int taskHeadingRoleREF)
    {
      DaTaskHeadingRole da = new DaTaskHeadingRole(DataStore.DbConnection);
      if (da.GetById(taskHeadingRoleREF))
        return new DdTaskHeadingRoleExt(da.GetBuffer());
      else
        return null;
    }

    static public BindingList<DdTaskHeadingRoleExt> GetTaskHeadingRoleList(int taskHeadingREF)
    {
      DaTaskHeadingRole daTaskHeadingRole = new DaTaskHeadingRole(DataStore.DbConnection);
      DnTaskHeadingRole dn = daTaskHeadingRole.FillByTaskHeading(taskHeadingREF);
      BindingList<DdTaskHeadingRoleExt> list = new BindingList<DdTaskHeadingRoleExt>();
      foreach (DdTaskHeadingRole dd in dn)
        list.Add(new DdTaskHeadingRoleExt(dd));
      return list;
    }

    static public void UpdateTaskHeadingRole(BindingSource binding, int taskHeadingREF, RevisionInfo revInfo)
    {
      BindingList<DdTaskHeadingRoleExt> list = (BindingList<DdTaskHeadingRoleExt>)binding.DataSource;
      try
      {
        using (TransactionScope scope = new TransactionScope())
        {
        DaTaskHeadingRole da = new DaTaskHeadingRole(DataStore.CloneDbConnection());
        foreach (DdTaskHeadingRoleExt item in list)
        {// do deletes first
          bool existing = da.GetById(item.Id);
          if (existing && item.DeleteFlag)
          {// delete here - avoid validation
            da.DeleteById(item.Id);
            AddChangeLog(da.TableName, item.Id, da.Timestamp, revInfo);  
          }
        }
        
        foreach (DdTaskHeadingRoleExt item in list)
        {
          if (item.DeleteFlag) continue; // already done above
          //if (item.Id == string.Empty) continue; // already done above
          bool existing = da.GetById(item.Id);
          if (!existing)
          {
            da.Clear();
          }
          da.PersonREF = item.PersonREF;
          da.TaskHeadingREF = item.TaskHeadingREF;
          da.TaskRoleREF = item.TaskRoleREF;
          if (!existing)
          {
            da.TaskHeadingREF = taskHeadingREF;
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
        binding.DataSource = GetTaskHeadingRoleList(taskHeadingREF);
      }
      catch (AppEx)
      {
        throw;
      }
      catch (Exception exc)
      {
        throw new AppEx(exc, "Error updating TaskHeadingRole");
      }
    }
  }
  
  public class DdTaskHeadingRoleExt : DdTaskHeadingRole
  {
    public bool DeleteFlag { get; set; }

    public DdTaskHeadingRoleExt()
      : base()
    {
    }

    public DdTaskHeadingRoleExt(DdTaskHeadingRole dd)
      : base(dd)
    {
    }
  }

}
