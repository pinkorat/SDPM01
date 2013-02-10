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
    static public BindingList<DdClientExt> GetClients()
    {
      BindingList<DdClientExt> list = new BindingList<DdClientExt>();
      DaClient da = new DaClient(DataStore.DbConnection);
      DnClient dn = da.Fill();
      foreach (DdClient dd in dn) list.Add(new DdClientExt(dd));
      return list;
    }
#endif

    static public bool SaveClient(ref DdClientExt item, RevisionInfo revisionInfo)
    {
      DaClient da = new DaClient(DataStore.DbConnection);
      if (!da.GetById(item.Id)) return false;
      da.ClientID = item.ClientID;
      da.Comment = item.Comment;
      da.FullName = item.FullName;
      bool ok = true;
      if (da._IsModified)
      {
        da.Modified = DateTime.Now;
        da.ModifiedBy = Environment.UserName;
        ok = da.Save();
        if (ok) AddChangeLog(da.TableName, da.Id, da.Timestamp, revisionInfo);
        if (ok) item = new DdClientExt(da.GetBuffer());
      }
      return ok;
    }

    static public bool AddClient(ref DdClientExt item, RevisionInfo revisionInfo)
    {
      DaClient da = new DaClient(DataStore.DbConnection);
      da.Clear();
      da.ClientID = item.ClientID;
      da.Comment = item.Comment;
      da.FullName = item.FullName;
      da.Modified = item.Modified;
      da.ModifiedBy = item.ModifiedBy;
      bool ok = da.Insert();
      if (ok) AddChangeLog(da.TableName, da.Id, da.Timestamp, revisionInfo); //add
      if (ok) item = new DdClientExt(da.GetBuffer());
      return ok;
    }

    static public bool DeleteClient(DdClientExt item, RevisionInfo revisionInfo)
    {
      DaClient da = new DaClient(DataStore.DbConnection);
      bool ok = da.DeleteById(item.Id);
      if (ok) AddChangeLog(da.TableName, item.Id, item.Timestamp, revisionInfo); //delete
	  return ok;
    }

    static public DdClientExt GetClientInfo(int clientREF)
    {
      DaClient da = new DaClient(DataStore.DbConnection);
      if (da.GetById(clientREF))
        return new DdClientExt(da.GetBuffer());
      else
        return null;
    }

    static public DdClientExt GetClientInfo(string clientID)
    {
      DaClient da = new DaClient(DataStore.DbConnection);
      if (da.GetByPK(clientID))
        return new DdClientExt(da.GetBuffer());
      else
        return null;
    }

    static public BindingList<DdClientExt> GetClientList()
    {
      DaClient daClient = new DaClient(DataStore.DbConnection);
      DnClient dn = daClient.Fill();
      BindingList<DdClientExt> list = new BindingList<DdClientExt>();
      foreach (DdClient dd in dn)
        list.Add(new DdClientExt(dd));
      return list;
    }

    static public void UpdateClient(BindingSource binding, RevisionInfo revInfo)
    {
      BindingList<DdClientExt> list = (BindingList<DdClientExt>)binding.DataSource;
      try
      {
        using (TransactionScope scope = new TransactionScope())
        {
        DaClient da = new DaClient(DataStore.CloneDbConnection());
        foreach (DdClientExt item in list)
        {// do deletes first
          bool existing = da.GetById(item.Id);
          if (existing && item.DeleteFlag)
          {// delete here - avoid validation
            da.DeleteById(item.Id);
            AddChangeLog(da.TableName, item.Id, da.Timestamp, revInfo);  
          }
        }
        
        foreach (DdClientExt item in list)
        {
          if (item.DeleteFlag) continue; // already done above
          //if (item.ClientID == string.Empty) continue; // already done above
          bool existing = da.GetById(item.Id);
          if (!existing)
          {
            da.Clear();
          }
          da.ClientID = item.ClientID;
          da.Comment = item.Comment;
          da.FullName = item.FullName;
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
        binding.DataSource = GetClientList();
      }
      catch (AppEx)
      {
        throw;
      }
      catch (Exception exc)
      {
        throw new AppEx(exc, "Error updating Client");
      }
    }
  }
  
  public class DdClientExt : DdClient
  {
    public bool DeleteFlag { get; set; }

    public DdClientExt()
      : base()
    {
    }

    public DdClientExt(DdClient dd)
      : base(dd)
    {
    }
  }

}
