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
    static public BindingList<DdStepExt> GetSteps()
    {
      BindingList<DdStepExt> list = new BindingList<DdStepExt>();
      DaStep da = new DaStep(DataStore.DbConnection);
      DnStep dn = da.Fill();
      foreach (DdStep dd in dn) list.Add(new DdStepExt(dd));
      return list;
    }
#endif

    static public bool SaveStep(ref DdStepExt item, RevisionInfo revisionInfo)
    {
      DaStep da = new DaStep(DataStore.DbConnection);
      if (!da.GetById(item.Id)) return false;
      da.Description = item.Description;
      da.DueDate = item.DueDate;
      da.EstHours = item.EstHours;
      da.StepID = item.StepID;
      da.TaskREF = item.TaskREF;
      da.Title = item.Title;
      bool ok = true;
      if (da._IsModified)
      {
        da.Modified = DateTime.Now;
        da.ModifiedBy = Environment.UserName;
        ok = da.Save();
        if (ok) AddChangeLog(da.TableName, da.Id, da.Timestamp, revisionInfo);
        if (ok) item = new DdStepExt(da.GetBuffer());
      }
      return ok;
    }

    static public bool AddStep(ref DdStepExt item, RevisionInfo revisionInfo)
    {
      DaStep da = new DaStep(DataStore.DbConnection);
      da.Clear();
      da.Description = item.Description;
      da.DueDate = item.DueDate;
      da.EstHours = item.EstHours;
      da.Modified = item.Modified;
      da.ModifiedBy = item.ModifiedBy;
      da.StepID = item.StepID;
      da.TaskREF = item.TaskREF;
      da.Title = item.Title;
      bool ok = da.Insert();
      if (ok) AddChangeLog(da.TableName, da.Id, da.Timestamp, revisionInfo); //add
      if (ok) item = new DdStepExt(da.GetBuffer());
      return ok;
    }

    static public bool DeleteStep(DdStepExt item, RevisionInfo revisionInfo)
    {
      DaStep da = new DaStep(DataStore.DbConnection);
      bool ok = da.DeleteById(item.Id);
      if (ok) AddChangeLog(da.TableName, item.Id, item.Timestamp, revisionInfo); //delete
	  return ok;
    }

    static public DdStepExt GetStepInfo(int stepREF)
    {
      DaStep da = new DaStep(DataStore.DbConnection);
      if (da.GetById(stepREF))
        return new DdStepExt(da.GetBuffer());
      else
        return null;
    }

    static public BindingList<DdStepExt> GetStepList(int taskREF)
    {
      DaStep daStep = new DaStep(DataStore.DbConnection);
      DnStep dn = daStep.FillByTask(taskREF);
      BindingList<DdStepExt> list = new BindingList<DdStepExt>();
      foreach (DdStep dd in dn)
        list.Add(new DdStepExt(dd));
      return list;
    }

    static public void UpdateStep(BindingSource binding, int taskREF, RevisionInfo revInfo)
    {
      BindingList<DdStepExt> list = (BindingList<DdStepExt>)binding.DataSource;
      try
      {
        using (TransactionScope scope = new TransactionScope())
        {
        DaStep da = new DaStep(DataStore.CloneDbConnection());
        foreach (DdStepExt item in list)
        {// do deletes first
          bool existing = da.GetById(item.Id);
          if (existing && item.DeleteFlag)
          {// delete here - avoid validation
            da.DeleteById(item.Id);
            AddChangeLog(da.TableName, item.Id, da.Timestamp, revInfo);  
          }
        }
        
        foreach (DdStepExt item in list)
        {
          if (item.DeleteFlag) continue; // already done above
          //if (item.StepID == string.Empty) continue; // already done above
          bool existing = da.GetById(item.Id);
          if (!existing)
          {
            da.Clear();
          }
          da.Description = item.Description;
          da.DueDate = item.DueDate;
          da.EstHours = item.EstHours;
          da.StepID = item.StepID;
          da.TaskREF = item.TaskREF;
          da.Title = item.Title;
          if (!existing)
          {
            da.TaskREF = taskREF;
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
        binding.DataSource = GetStepList(taskREF);
      }
      catch (AppEx)
      {
        throw;
      }
      catch (Exception exc)
      {
        throw new AppEx(exc, "Error updating Step");
      }
    }
  }
  
  public class DdStepExt : DdStep
  {
    public bool DeleteFlag { get; set; }

    public DdStepExt()
      : base()
    {
    }

    public DdStepExt(DdStep dd)
      : base(dd)
    {
    }
  }

}
