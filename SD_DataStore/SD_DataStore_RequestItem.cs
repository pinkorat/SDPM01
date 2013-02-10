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
    static public BindingList<DdRequestItemExt> GetRequestItems()
    {
      BindingList<DdRequestItemExt> list = new BindingList<DdRequestItemExt>();
      DaRequestItem da = new DaRequestItem(DataStore.DbConnection);
      DnRequestItem dn = da.Fill();
      foreach (DdRequestItem dd in dn) list.Add(new DdRequestItemExt(dd));
      return list;
    }
#endif

    static public bool SaveRequestItem(ref DdRequestItemExt item, RevisionInfo revisionInfo)
    {
      DaRequestItem da = new DaRequestItem(DataStore.DbConnection);
      if (!da.GetById(item.Id)) return false;
      da.ChangeRequestREF = item.ChangeRequestREF;
      da.Comment = item.Comment;
      da.Description = item.Description;
      da.EffectiveDate = item.EffectiveDate;
      da.ItemID = item.ItemID;
      bool ok = true;
      if (da._IsModified)
      {
        da.Modified = DateTime.Now;
        da.ModifiedBy = Environment.UserName;
        ok = da.Save();
        if (ok) AddChangeLog(da.TableName, da.Id, da.Timestamp, revisionInfo);
        if (ok) item = new DdRequestItemExt(da.GetBuffer());
      }
      return ok;
    }

    static public bool AddRequestItem(ref DdRequestItemExt item, RevisionInfo revisionInfo)
    {
      DaRequestItem da = new DaRequestItem(DataStore.DbConnection);
      da.Clear();
      da.ChangeRequestREF = item.ChangeRequestREF;
      da.Comment = item.Comment;
      da.Description = item.Description;
      da.EffectiveDate = item.EffectiveDate;
      da.ItemID = item.ItemID;
      da.Modified = item.Modified;
      da.ModifiedBy = item.ModifiedBy;
      bool ok = da.Insert();
      if (ok) AddChangeLog(da.TableName, da.Id, da.Timestamp, revisionInfo); //add
      if (ok) item = new DdRequestItemExt(da.GetBuffer());
      return ok;
    }

    static public bool DeleteRequestItem(DdRequestItemExt item, RevisionInfo revisionInfo)
    {
      DaRequestItem da = new DaRequestItem(DataStore.DbConnection);
      bool ok = da.DeleteById(item.Id);
      if (ok) AddChangeLog(da.TableName, item.Id, item.Timestamp, revisionInfo); //delete
	  return ok;
    }

    static public DdRequestItemExt GetRequestItemInfo(int requestItemREF)
    {
      DaRequestItem da = new DaRequestItem(DataStore.DbConnection);
      if (da.GetById(requestItemREF))
        return new DdRequestItemExt(da.GetBuffer());
      else
        return null;
    }

    static public BindingList<DdRequestItemExt> GetRequestItemList(int changeRequestREF)
    {
      DaRequestItem daRequestItem = new DaRequestItem(DataStore.DbConnection);
      DnRequestItem dn = daRequestItem.FillByChangeRequest(changeRequestREF);
      BindingList<DdRequestItemExt> list = new BindingList<DdRequestItemExt>();
      foreach (DdRequestItem dd in dn)
        list.Add(new DdRequestItemExt(dd));
      return list;
    }

    static public void UpdateRequestItem(BindingSource binding, int changeRequestREF, RevisionInfo revInfo)
    {
      BindingList<DdRequestItemExt> list = (BindingList<DdRequestItemExt>)binding.DataSource;
      try
      {
        using (TransactionScope scope = new TransactionScope())
        {
        DaRequestItem da = new DaRequestItem(DataStore.CloneDbConnection());
        foreach (DdRequestItemExt item in list)
        {// do deletes first
          bool existing = da.GetById(item.Id);
          if (existing && item.DeleteFlag)
          {// delete here - avoid validation
            da.DeleteById(item.Id);
            AddChangeLog(da.TableName, item.Id, da.Timestamp, revInfo);  
          }
        }
        
        foreach (DdRequestItemExt item in list)
        {
          if (item.DeleteFlag) continue; // already done above
          //if (item.RequestItemID == string.Empty) continue; // already done above
          bool existing = da.GetById(item.Id);
          if (!existing)
          {
            da.Clear();
          }
          da.ChangeRequestREF = item.ChangeRequestREF;
          da.Comment = item.Comment;
          da.Description = item.Description;
          da.EffectiveDate = item.EffectiveDate;
          da.ItemID = item.ItemID;
          if (!existing)
          {
            da.ChangeRequestREF = changeRequestREF;
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
        binding.DataSource = GetRequestItemList(changeRequestREF);
      }
      catch (AppEx)
      {
        throw;
      }
      catch (Exception exc)
      {
        throw new AppEx(exc, "Error updating RequestItem");
      }
    }
  }
  
  public class DdRequestItemExt : DdRequestItem
  {
    public bool DeleteFlag { get; set; }

    public DdRequestItemExt()
      : base()
    {
    }

    public DdRequestItemExt(DdRequestItem dd)
      : base(dd)
    {
    }
  }

}
