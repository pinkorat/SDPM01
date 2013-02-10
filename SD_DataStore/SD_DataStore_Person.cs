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
    static public BindingList<DdPersonExt> GetPersons()
    {
      BindingList<DdPersonExt> list = new BindingList<DdPersonExt>();
      DaPerson da = new DaPerson(DataStore.DbConnection);
      DnPerson dn = da.Fill();
      foreach (DdPerson dd in dn) list.Add(new DdPersonExt(dd));
      return list;
    }
#endif

    static public bool SavePerson(ref DdPersonExt item, RevisionInfo revisionInfo)
    {
      DaPerson da = new DaPerson(DataStore.DbConnection);
      if (!da.GetById(item.Id)) return false;
      da.Comment = item.Comment;
      da.Credentials = item.Credentials;
      da.FullName = item.FullName;
      da.Inactive = item.Inactive;
      da.PersonID = item.PersonID;
      da.Title = item.Title;
      bool ok = true;
      if (da._IsModified)
      {
        da.Modified = DateTime.Now;
        da.ModifiedBy = Environment.UserName;
        ok = da.Save();
        if (ok) AddChangeLog(da.TableName, da.Id, da.Timestamp, revisionInfo);
        if (ok) item = new DdPersonExt(da.GetBuffer());
      }
      return ok;
    }

    static public bool AddPerson(ref DdPersonExt item, RevisionInfo revisionInfo)
    {
      DaPerson da = new DaPerson(DataStore.DbConnection);
      da.Clear();
      da.Comment = item.Comment;
      da.Credentials = item.Credentials;
      da.FullName = item.FullName;
      da.Inactive = item.Inactive;
      da.Modified = item.Modified;
      da.ModifiedBy = item.ModifiedBy;
      da.PersonID = item.PersonID;
      da.Title = item.Title;
      bool ok = da.Insert();
      if (ok) AddChangeLog(da.TableName, da.Id, da.Timestamp, revisionInfo); //add
      if (ok) item = new DdPersonExt(da.GetBuffer());
      return ok;
    }

    static public bool DeletePerson(DdPersonExt item, RevisionInfo revisionInfo)
    {
      DaPerson da = new DaPerson(DataStore.DbConnection);
      bool ok = da.DeleteById(item.Id);
      if (ok) AddChangeLog(da.TableName, item.Id, item.Timestamp, revisionInfo); //delete
	  return ok;
    }

    static public DdPersonExt GetPersonInfo(int personREF)
    {
      DaPerson da = new DaPerson(DataStore.DbConnection);
      if (da.GetById(personREF))
        return new DdPersonExt(da.GetBuffer());
      else
        return null;
    }

    static public BindingList<DdPersonExt> GetPersonList()
    {
      DaPerson daPerson = new DaPerson(DataStore.DbConnection);
      DnPerson dn = daPerson.Fill();
      BindingList<DdPersonExt> list = new BindingList<DdPersonExt>();
      foreach (DdPerson dd in dn)
        list.Add(new DdPersonExt(dd));
      return list;
    }

    static public void UpdatePerson(BindingSource binding, RevisionInfo revInfo)
    {
      BindingList<DdPersonExt> list = (BindingList<DdPersonExt>)binding.DataSource;
      try
      {
        using (TransactionScope scope = new TransactionScope())
        {
        DaPerson da = new DaPerson(DataStore.CloneDbConnection());
        foreach (DdPersonExt item in list)
        {// do deletes first
          bool existing = da.GetById(item.Id);
          if (existing && item.DeleteFlag)
          {// delete here - avoid validation
            da.DeleteById(item.Id);
            AddChangeLog(da.TableName, item.Id, da.Timestamp, revInfo);  
          }
        }
        
        foreach (DdPersonExt item in list)
        {
          if (item.DeleteFlag) continue; // already done above
          //if (item.PersonID == string.Empty) continue; // already done above
          bool existing = da.GetById(item.Id);
          if (!existing)
          {
            da.Clear();
          }
          da.Comment = item.Comment;
          da.Credentials = item.Credentials;
          da.FullName = item.FullName;
          da.Inactive = item.Inactive;
          da.PersonID = item.PersonID;
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
        binding.DataSource = GetPersonList();
      }
      catch (AppEx)
      {
        throw;
      }
      catch (Exception exc)
      {
        throw new AppEx(exc, "Error updating Person");
      }
    }
  }
  
  public class DdPersonExt : DdPerson
  {
    public bool DeleteFlag { get; set; }

    public DdPersonExt()
      : base()
    {
    }

    public DdPersonExt(DdPerson dd)
      : base(dd)
    {
    }
  }

}
