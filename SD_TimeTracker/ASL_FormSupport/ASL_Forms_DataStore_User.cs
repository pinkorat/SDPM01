// Generated: Sun Jan 27, 2013 11:01:56

using System;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;
using System.Windows.Forms;
using System.ComponentModel;
using ASL;


namespace ASL.Forms
{
  public partial class DataStore
  {
#if false
    static public BindingList<DdUserExt> GetUsers()
    {
      BindingList<DdUserExt> list = new BindingList<DdUserExt>();
      DaUser da = new DaUser(DataStore.DbConnection);
      DnUser dn = da.Fill();
      foreach (DdUser dd in dn) list.Add(new DdUserExt(dd));
      return list;
    }
#endif

    static public bool SaveUser(ref DdUserExt item, RevisionInfo revisionInfo)
    {
      DaUser da = new DaUser(DataStore.DbConnection);
      if (!da.GetById(item.Id)) return false;
      da.Comment = item.Comment;
      da.Credentials = item.Credentials;
      da.FullName = item.FullName;
      da.Inactive = item.Inactive;
      da.UserID = item.UserID;
      da.Title = item.Title;
      bool ok = true;
      if (da._IsModified)
      {
        da.Modified = DateTime.Now;
        da.ModifiedBy = Environment.UserName;
        ok = da.Save();
        if (ok) AddChangeLog(da.TableName, da.Id, da.Timestamp, revisionInfo);
        if (ok) item = new DdUserExt(da.GetBuffer());
      }
      return ok;
    }

    static public bool AddUser(ref DdUserExt item, RevisionInfo revisionInfo)
    {
      DaUser da = new DaUser(DataStore.DbConnection);
      da.Clear();
      da.Comment = item.Comment;
      da.Credentials = item.Credentials;
      da.FullName = item.FullName;
      da.Inactive = item.Inactive;
      da.Modified = item.Modified;
      da.ModifiedBy = item.ModifiedBy;
      da.UserID = item.UserID;
      da.Title = item.Title;
      bool ok = da.Insert();
      if (ok) AddChangeLog(da.TableName, da.Id, da.Timestamp, revisionInfo); //add
      if (ok) item = new DdUserExt(da.GetBuffer());
      return ok;
    }

    static public bool DeleteUser(DdUserExt item, RevisionInfo revisionInfo)
    {
      DaUser da = new DaUser(DataStore.DbConnection);
      bool ok = da.DeleteById(item.Id);
      if (ok) AddChangeLog(da.TableName, item.Id, item.Timestamp, revisionInfo); //delete
	  return ok;
    }

    static public DdUserExt GetUserInfo(int personREF)
    {
      DaUser da = new DaUser(DataStore.DbConnection);
      if (da.GetById(personREF))
        return new DdUserExt(da.GetBuffer());
      else
        return null;
    }

    static public BindingList<DdUserExt> GetUserList()
    {
      DaUser daUser = new DaUser(DataStore.DbConnection);
      DnUser dn = daUser.Fill();
      BindingList<DdUserExt> list = new BindingList<DdUserExt>();
      foreach (DdUser dd in dn)
        list.Add(new DdUserExt(dd));
      return list;
    }

    static public void UpdateUser(BindingSource binding, RevisionInfo revInfo)
    {
      BindingList<DdUserExt> list = (BindingList<DdUserExt>)binding.DataSource;
      try
      {
        using (TransactionScope scope = new TransactionScope())
        {
        DaUser da = new DaUser(DataStore.CloneDbConnection());
        foreach (DdUserExt item in list)
        {// do deletes first
          bool existing = da.GetById(item.Id);
          if (existing && item.DeleteFlag)
          {// delete here - avoid validation
            da.DeleteById(item.Id);
            AddChangeLog(da.TableName, item.Id, da.Timestamp, revInfo);  
          }
        }
        
        foreach (DdUserExt item in list)
        {
          if (item.DeleteFlag) continue; // already done above
          //if (item.UserID == string.Empty) continue; // already done above
          bool existing = da.GetById(item.Id);
          if (!existing)
          {
            da.Clear();
          }
          da.Comment = item.Comment;
          da.Credentials = item.Credentials;
          da.FullName = item.FullName;
          da.Inactive = item.Inactive;
          da.UserID = item.UserID;
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
        binding.DataSource = GetUserList();
      }
      catch (AppEx)
      {
        throw;
      }
      catch (Exception exc)
      {
        throw new AppEx(exc, "Error updating User");
      }
    }
  }
  
  public class DdUserExt : DdUser
  {
    public bool DeleteFlag { get; set; }

    public DdUserExt()
      : base()
    {
    }

    public DdUserExt(DdUser dd)
      : base(dd)
    {
    }
  }

}
