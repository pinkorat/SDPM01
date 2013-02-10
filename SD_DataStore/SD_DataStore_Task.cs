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
    static public BindingList<DdTaskExt> GetTasks()
    {
      BindingList<DdTaskExt> list = new BindingList<DdTaskExt>();
      DaTask da = new DaTask(DataStore.DbConnection);
      DnTask dn = da.Fill();
      foreach (DdTask dd in dn) list.Add(new DdTaskExt(dd));
      return list;
    }
#endif

    static public bool SaveTask(ref DdTaskExt item, RevisionInfo revisionInfo)
    {
      DaTask da = new DaTask(DataStore.DbConnection);
      if (!da.GetById(item.Id)) return false;
      da.Description = item.Description;
      da.DueDate = item.DueDate;
      da.EstHours = item.EstHours;
      da.TaskHeadingREF = item.TaskHeadingREF;
      da.TaskID = item.TaskID;
      da.Title = item.Title;
      bool ok = true;
      if (da._IsModified)
      {
        da.Modified = DateTime.Now;
        da.ModifiedBy = Environment.UserName;
        ok = da.Save();
        if (ok) AddChangeLog(da.TableName, da.Id, da.Timestamp, revisionInfo);
        if (ok) item = new DdTaskExt(da.GetBuffer());
      }
      return ok;
    }

    static public bool AddTask(ref DdTaskExt item, RevisionInfo revisionInfo)
    {
      DaTask da = new DaTask(DataStore.DbConnection);
      da.Clear();
      da.Description = item.Description;
      da.DueDate = item.DueDate;
      da.EstHours = item.EstHours;
      da.Modified = item.Modified;
      da.ModifiedBy = item.ModifiedBy;
      da.TaskHeadingREF = item.TaskHeadingREF;
      da.TaskID = item.TaskID;
      da.Title = item.Title;
      bool ok = da.Insert();
      if (ok) AddChangeLog(da.TableName, da.Id, da.Timestamp, revisionInfo); //add
      if (ok) item = new DdTaskExt(da.GetBuffer());
      return ok;
    }

    static public bool DeleteTask(DdTaskExt item, RevisionInfo revisionInfo)
    {
      DaTask da = new DaTask(DataStore.DbConnection);
      bool ok = da.DeleteById(item.Id);
      if (ok) AddChangeLog(da.TableName, item.Id, item.Timestamp, revisionInfo); //delete
	  return ok;
    }

    static public DdTaskExt GetTaskInfo(int taskREF)
    {
      DaTask da = new DaTask(DataStore.DbConnection);
      if (da.GetById(taskREF))
        return new DdTaskExt(da.GetBuffer());
      else
        return null;
    }

    static public BindingList<DdTaskExt> GetTaskList(int taskHeadingREF)
    {
      DaTask daTask = new DaTask(DataStore.DbConnection);
      DnTask dn = daTask.FillByTaskHeading(taskHeadingREF);
      BindingList<DdTaskExt> list = new BindingList<DdTaskExt>();
      foreach (DdTask dd in dn)
        list.Add(new DdTaskExt(dd));
      return list;
    }

    static public void UpdateTask(BindingSource binding, int taskHeadingREF, RevisionInfo revInfo)
    {
      BindingList<DdTaskExt> list = (BindingList<DdTaskExt>)binding.DataSource;
      try
      {
        using (TransactionScope scope = new TransactionScope())
        {
        DaTask da = new DaTask(DataStore.CloneDbConnection());
        foreach (DdTaskExt item in list)
        {// do deletes first
          bool existing = da.GetById(item.Id);
          if (existing && item.DeleteFlag)
          {// delete here - avoid validation
            da.DeleteById(item.Id);
            AddChangeLog(da.TableName, item.Id, da.Timestamp, revInfo);  
          }
        }
        
        foreach (DdTaskExt item in list)
        {
          if (item.DeleteFlag) continue; // already done above
          //if (item.TaskID == string.Empty) continue; // already done above
          bool existing = da.GetById(item.Id);
          if (!existing)
          {
            da.Clear();
          }
          da.Description = item.Description;
          da.DueDate = item.DueDate;
          da.EstHours = item.EstHours;
          da.TaskHeadingREF = item.TaskHeadingREF;
          da.TaskID = item.TaskID;
          da.Title = item.Title;
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
        binding.DataSource = GetTaskList(taskHeadingREF);
      }
      catch (AppEx)
      {
        throw;
      }
      catch (Exception exc)
      {
        throw new AppEx(exc, "Error updating Task");
      }
    }
  }
  
  public class DdTaskExt : DdTask
  {
    public bool DeleteFlag { get; set; }

    public DdTaskExt()
      : base()
    {
    }

    public DdTaskExt(DdTask dd)
      : base(dd)
    {
    }
  }

}
