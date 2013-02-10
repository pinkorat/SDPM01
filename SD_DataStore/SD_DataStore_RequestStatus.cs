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
    static public BindingList<DdRequestStatusExt> GetRequestStatus()
    {
      BindingList<DdRequestStatusExt> list = new BindingList<DdRequestStatusExt>();
      DaRequestStatus da = new DaRequestStatus(DataStore.DbConnection);
      DnRequestStatus dn = da.Fill();
      foreach (DdRequestStatus dd in dn) list.Add(new DdRequestStatusExt(dd));
      return list;
    }
#endif

    static public bool SaveRequestStatu(ref DdRequestStatusExt item, RevisionInfo revisionInfo)
    {
      DaRequestStatus da = new DaRequestStatus(DataStore.DbConnection);
      if (!da.GetById(item.Id)) return false;
      da.ChangeRequestREF = item.ChangeRequestREF;
      da.Comment = item.Comment;
      da.EffectiveDate = item.EffectiveDate;
      da.Hours = item.Hours;
      da.PersonREF = item.PersonREF;
      da.StatusID = item.StatusID;
      bool ok = true;
      if (da._IsModified)
      {
        da.Modified = DateTime.Now;
        da.ModifiedBy = Environment.UserName;
        ok = da.Save();
        if (ok) AddChangeLog(da.TableName, da.Id, da.Timestamp, revisionInfo);
        if (ok) item = new DdRequestStatusExt(da.GetBuffer());
      }
      return ok;
    }

    static public bool AddRequestStatu(ref DdRequestStatusExt item, RevisionInfo revisionInfo)
    {
      DaRequestStatus da = new DaRequestStatus(DataStore.DbConnection);
      da.Clear();
      da.ChangeRequestREF = item.ChangeRequestREF;
      da.Comment = item.Comment;
      da.EffectiveDate = item.EffectiveDate;
      da.Hours = item.Hours;
      da.Modified = item.Modified;
      da.ModifiedBy = item.ModifiedBy;
      da.PersonREF = item.PersonREF;
      da.StatusID = item.StatusID;
      bool ok = da.Insert();
      if (ok) AddChangeLog(da.TableName, da.Id, da.Timestamp, revisionInfo); //add
      if (ok) item = new DdRequestStatusExt(da.GetBuffer());
      return ok;
    }

    static public bool DeleteRequestStatu(DdRequestStatusExt item, RevisionInfo revisionInfo)
    {
      DaRequestStatus da = new DaRequestStatus(DataStore.DbConnection);
      bool ok = da.DeleteById(item.Id);
      if (ok) AddChangeLog(da.TableName, item.Id, item.Timestamp, revisionInfo); //delete
	  return ok;
    }

    static public DdRequestStatusExt GetRequestStatuInfo(int requestStatuREF)
    {
      DaRequestStatus da = new DaRequestStatus(DataStore.DbConnection);
      if (da.GetById(requestStatuREF))
        return new DdRequestStatusExt(da.GetBuffer());
      else
        return null;
    }

    static public BindingList<DdRequestStatusExt> GetRequestStatusList(int changeRequestREF)
    {
      DaRequestStatus daRequestStatus = new DaRequestStatus(DataStore.DbConnection);
      DnRequestStatus dn = daRequestStatus.FillByChangeRequest(changeRequestREF);
      BindingList<DdRequestStatusExt> list = new BindingList<DdRequestStatusExt>();
      foreach (DdRequestStatus dd in dn)
        list.Add(new DdRequestStatusExt(dd));
      return list;
    }

    static public void UpdateRequestStatus(BindingSource binding, int changeRequestREF, RevisionInfo revInfo)
    {
      BindingList<DdRequestStatusExt> list = (BindingList<DdRequestStatusExt>)binding.DataSource;
      try
      {
        using (TransactionScope scope = new TransactionScope())
        {
        DaRequestStatus da = new DaRequestStatus(DataStore.CloneDbConnection());
        foreach (DdRequestStatusExt item in list)
        {// do deletes first
          bool existing = da.GetById(item.Id);
          if (existing && item.DeleteFlag)
          {// delete here - avoid validation
            da.DeleteById(item.Id);
            AddChangeLog(da.TableName, item.Id, da.Timestamp, revInfo);  
          }
        }
        
        foreach (DdRequestStatusExt item in list)
        {
          if (item.DeleteFlag) continue; // already done above
          //if (item.RequestStatusID == string.Empty) continue; // already done above
          bool existing = da.GetById(item.Id);
          if (!existing)
          {
            da.Clear();
          }
          da.ChangeRequestREF = item.ChangeRequestREF;
          da.Comment = item.Comment;
          da.EffectiveDate = item.EffectiveDate;
          da.Hours = item.Hours;
          da.PersonREF = item.PersonREF;
          da.StatusID = item.StatusID;
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
        binding.DataSource = GetRequestStatusList(changeRequestREF);
      }
      catch (AppEx)
      {
        throw;
      }
      catch (Exception exc)
      {
        throw new AppEx(exc, "Error updating RequestStatus");
      }
    }
  }
  
  public class DdRequestStatusExt : DdRequestStatus
  {
    public bool DeleteFlag { get; set; }

    public DdRequestStatusExt()
      : base()
    {
    }

    public DdRequestStatusExt(DdRequestStatus dd)
      : base(dd)
    {
    }
  }

}
