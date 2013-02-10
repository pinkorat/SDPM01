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
    static public BindingList<DdProjectExt> GetProjects()
    {
      BindingList<DdProjectExt> list = new BindingList<DdProjectExt>();
      DaProject da = new DaProject(DataStore.DbConnection);
      DnProject dn = da.Fill();
      foreach (DdProject dd in dn) list.Add(new DdProjectExt(dd));
      return list;
    }
#endif

    static public bool SaveProject(ref DdProjectExt item, RevisionInfo revisionInfo)
    {
      DaProject da = new DaProject(DataStore.DbConnection);
      if (!da.GetById(item.Id)) return false;
      da.ClientREF = item.ClientREF;
      da.Description = item.Description;
      da.ProjectID = item.ProjectID;
      da.TaskHeadingREF = item.TaskHeadingREF;
      da.Title = item.Title;
      bool ok = true;
      if (da._IsModified)
      {
        da.Modified = DateTime.Now;
        da.ModifiedBy = Environment.UserName;
        ok = da.Save();
        if (ok) AddChangeLog(da.TableName, da.Id, da.Timestamp, revisionInfo);
        if (ok) item = new DdProjectExt(da.GetBuffer());
      }
      return ok;
    }

    static public bool AddProject(ref DdProjectExt item, RevisionInfo revisionInfo)
    {
      DaProject da = new DaProject(DataStore.DbConnection);
      da.Clear();
      da.ClientREF = item.ClientREF;
      da.Description = item.Description;
      da.Modified = item.Modified;
      da.ModifiedBy = item.ModifiedBy;
      da.ProjectID = item.ProjectID;
      da.TaskHeadingREF = item.TaskHeadingREF;
      da.Title = item.Title;
      bool ok = da.Insert();
      if (ok) AddChangeLog(da.TableName, da.Id, da.Timestamp, revisionInfo); //add
      if (ok) item = new DdProjectExt(da.GetBuffer());
      return ok;
    }

    static public bool DeleteProject(DdProjectExt item, RevisionInfo revisionInfo)
    {
      DaProject da = new DaProject(DataStore.DbConnection);
      bool ok = da.DeleteById(item.Id);
      if (ok) AddChangeLog(da.TableName, item.Id, item.Timestamp, revisionInfo); //delete
	  return ok;
    }

    static public DdProjectExt GetProjectInfo(int projectREF)
    {
      DaProject da = new DaProject(DataStore.DbConnection);
      if (da.GetById(projectREF))
        return new DdProjectExt(da.GetBuffer());
      else
        return null;
    }

    static public BindingList<DdProjectExt> GetProjectList(int clientREF)
    {
      DaProject daProject = new DaProject(DataStore.DbConnection);
      DnProject dn = daProject.FillByClient(clientREF);
      BindingList<DdProjectExt> list = new BindingList<DdProjectExt>();
      foreach (DdProject dd in dn)
        list.Add(new DdProjectExt(dd));
      return list;
    }

    static public void UpdateProject(BindingSource binding, int clientREF, RevisionInfo revInfo)
    {
      BindingList<DdProjectExt> list = (BindingList<DdProjectExt>)binding.DataSource;
      try
      {
        using (TransactionScope scope = new TransactionScope())
        {
        DaProject da = new DaProject(DataStore.CloneDbConnection());
        foreach (DdProjectExt item in list)
        {// do deletes first
          bool existing = da.GetById(item.Id);
          if (existing && item.DeleteFlag)
          {// delete here - avoid validation
            da.DeleteById(item.Id);
            AddChangeLog(da.TableName, item.Id, da.Timestamp, revInfo);  
          }
        }
        
        foreach (DdProjectExt item in list)
        {
          if (item.DeleteFlag) continue; // already done above
          //if (item.ProjectID == string.Empty) continue; // already done above
          bool existing = da.GetById(item.Id);
          if (!existing)
          {
            da.Clear();
          }
          da.ClientREF = item.ClientREF;
          da.Description = item.Description;
          da.ProjectID = item.ProjectID;
          da.TaskHeadingREF = item.TaskHeadingREF;
          da.Title = item.Title;
          if (!existing)
          {
            da.ClientREF = clientREF;
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
        binding.DataSource = GetProjectList(clientREF);
      }
      catch (AppEx)
      {
        throw;
      }
      catch (Exception exc)
      {
        throw new AppEx(exc, "Error updating Project");
      }
    }
  }
  
  public class DdProjectExt : DdProject
  {
    public bool DeleteFlag { get; set; }

    public DdProjectExt()
      : base()
    {
    }

    public DdProjectExt(DdProject dd)
      : base(dd)
    {
    }
  }

}
