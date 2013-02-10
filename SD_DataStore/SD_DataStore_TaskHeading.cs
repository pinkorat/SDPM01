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
    static public BindingList<DdTaskHeadingExt> GetTaskHeadings()
    {
      BindingList<DdTaskHeadingExt> list = new BindingList<DdTaskHeadingExt>();
      DaTaskHeading da = new DaTaskHeading(DataStore.DbConnection);
      DnTaskHeading dn = da.Fill();
      foreach (DdTaskHeading dd in dn) list.Add(new DdTaskHeadingExt(dd));
      return list;
    }
#endif

    static public bool SaveTaskHeading(ref DdTaskHeadingExt item, RevisionInfo revisionInfo)
    {
      DaTaskHeading da = new DaTaskHeading(DataStore.DbConnection);
      if (!da.GetById(item.Id)) return false;
      da.Description = item.Description;
      da.ProjectREF = item.ProjectREF;
      da.TaskHeadingID = item.TaskHeadingID;
      da.TaskHeadingREF = item.TaskHeadingREF;
      da.Title = item.Title;
      bool ok = true;
      if (da._IsModified)
      {
        da.Modified = DateTime.Now;
        da.ModifiedBy = Environment.UserName;
        ok = da.Save();
        if (ok) AddChangeLog(da.TableName, da.Id, da.Timestamp, revisionInfo);
        if (ok) item = new DdTaskHeadingExt(da.GetBuffer());
      }
      return ok;
    }

    static public bool AddTaskHeading(ref DdTaskHeadingExt item, RevisionInfo revisionInfo)
    {
      DaTaskHeading da = new DaTaskHeading(DataStore.DbConnection);
      da.Clear();
      da.Description = item.Description;
      da.Modified = item.Modified;
      da.ModifiedBy = item.ModifiedBy;
      da.ProjectREF = item.ProjectREF;
      da.TaskHeadingID = item.TaskHeadingID;
      da.TaskHeadingREF = item.TaskHeadingREF;
      da.Title = item.Title;
      bool ok = da.Insert();
      if (ok) AddChangeLog(da.TableName, da.Id, da.Timestamp, revisionInfo); //add
      if (ok) item = new DdTaskHeadingExt(da.GetBuffer());
      return ok;
    }

    static public bool DeleteTaskHeading(DdTaskHeadingExt item, RevisionInfo revisionInfo)
    {
      DaTaskHeading da = new DaTaskHeading(DataStore.DbConnection);
      bool ok = da.DeleteById(item.Id);
      if (ok) AddChangeLog(da.TableName, item.Id, item.Timestamp, revisionInfo); //delete
	  return ok;
    }

    static public DdTaskHeadingExt GetTaskHeadingInfo(int taskHeadingREF)
    {
      DaTaskHeading da = new DaTaskHeading(DataStore.DbConnection);
      if (da.GetById(taskHeadingREF))
        return new DdTaskHeadingExt(da.GetBuffer());
      else
        return null;
    }

    static public BindingList<DdTaskHeadingExt> GetTaskHeadingList(int projectREF)
    {
      DaTaskHeading daTaskHeading = new DaTaskHeading(DataStore.DbConnection);
      DnTaskHeading dn = daTaskHeading.FillByProject(projectREF);
      BindingList<DdTaskHeadingExt> list = new BindingList<DdTaskHeadingExt>();
      foreach (DdTaskHeading dd in dn)
        list.Add(new DdTaskHeadingExt(dd));
      return list;
    }

    static public void UpdateTaskHeading(BindingSource binding, int projectREF, RevisionInfo revInfo)
    {
      BindingList<DdTaskHeadingExt> list = (BindingList<DdTaskHeadingExt>)binding.DataSource;
      try
      {
        using (TransactionScope scope = new TransactionScope())
        {
        DaTaskHeading da = new DaTaskHeading(DataStore.CloneDbConnection());
        foreach (DdTaskHeadingExt item in list)
        {// do deletes first
          bool existing = da.GetById(item.Id);
          if (existing && item.DeleteFlag)
          {// delete here - avoid validation
            da.DeleteById(item.Id);
            AddChangeLog(da.TableName, item.Id, da.Timestamp, revInfo);  
          }
        }
        
        foreach (DdTaskHeadingExt item in list)
        {
          if (item.DeleteFlag) continue; // already done above
          //if (item.TaskHeadingID == string.Empty) continue; // already done above
          bool existing = da.GetById(item.Id);
          if (!existing)
          {
            da.Clear();
          }
          da.Description = item.Description;
          da.ProjectREF = item.ProjectREF;
          da.TaskHeadingID = item.TaskHeadingID;
          da.TaskHeadingREF = item.TaskHeadingREF;
          da.Title = item.Title;
          if (!existing)
          {
            da.ProjectREF = projectREF;
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
        binding.DataSource = GetTaskHeadingList(projectREF);
      }
      catch (AppEx)
      {
        throw;
      }
      catch (Exception exc)
      {
        throw new AppEx(exc, "Error updating TaskHeading");
      }
    }
  }
  
  public class DdTaskHeadingExt : DdTaskHeading
  {
    public bool DeleteFlag { get; set; }

    public DdTaskHeadingExt()
      : base()
    {
    }

    public DdTaskHeadingExt(DdTaskHeading dd)
      : base(dd)
    {
    }
  }

}
