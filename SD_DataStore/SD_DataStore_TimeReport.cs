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
    static public BindingList<DdTimeReportExt> GetTimeReports()
    {
      BindingList<DdTimeReportExt> list = new BindingList<DdTimeReportExt>();
      DaTimeReport da = new DaTimeReport(DataStore.DbConnection);
      DnTimeReport dn = da.Fill();
      foreach (DdTimeReport dd in dn) list.Add(new DdTimeReportExt(dd));
      return list;
    }
#endif

    static public bool SaveTimeReport(ref DdTimeReportExt item, RevisionInfo revisionInfo)
    {
      DaTimeReport da = new DaTimeReport(DataStore.DbConnection);
      if (!da.GetById(item.Id)) return false;
      da.CalendarREF = item.CalendarREF;
      da.Description = item.Description;
      da.EffectiveDate = item.EffectiveDate;
      da.Hours = item.Hours;
      da.PersonREF = item.PersonREF;
      da.TaskChargeCodeREF = item.TaskChargeCodeREF;
      bool ok = true;
      if (da._IsModified)
      {
        da.Modified = DateTime.Now;
        da.ModifiedBy = Environment.UserName;
        ok = da.Save();
        if (ok) AddChangeLog(da.TableName, da.Id, da.Timestamp, revisionInfo);
        if (ok) item = new DdTimeReportExt(da.GetBuffer());
      }
      return ok;
    }

    static public bool AddTimeReport(ref DdTimeReportExt item, RevisionInfo revisionInfo)
    {
      DaTimeReport da = new DaTimeReport(DataStore.DbConnection);
      da.Clear();
      da.CalendarREF = item.CalendarREF;
      da.Description = item.Description;
      da.EffectiveDate = item.EffectiveDate;
      da.Hours = item.Hours;
      da.Modified = item.Modified;
      da.ModifiedBy = item.ModifiedBy;
      da.PersonREF = item.PersonREF;
      da.TaskChargeCodeREF = item.TaskChargeCodeREF;
      bool ok = da.Insert();
      if (ok) AddChangeLog(da.TableName, da.Id, da.Timestamp, revisionInfo); //add
      if (ok) item = new DdTimeReportExt(da.GetBuffer());
      return ok;
    }

    static public bool DeleteTimeReport(DdTimeReportExt item, RevisionInfo revisionInfo)
    {
      DaTimeReport da = new DaTimeReport(DataStore.DbConnection);
      bool ok = da.DeleteById(item.Id);
      if (ok) AddChangeLog(da.TableName, item.Id, item.Timestamp, revisionInfo); //delete
	  return ok;
    }

    static public DdTimeReportExt GetTimeReportInfo(int timeReportREF)
    {
      DaTimeReport da = new DaTimeReport(DataStore.DbConnection);
      if (da.GetById(timeReportREF))
        return new DdTimeReportExt(da.GetBuffer());
      else
        return null;
    }

    static public BindingList<DdTimeReportExt> GetTimeReportList(int personREF)
    {
      DaTimeReport daTimeReport = new DaTimeReport(DataStore.DbConnection);
      DnTimeReport dn = daTimeReport.FillByPerson(personREF);
      BindingList<DdTimeReportExt> list = new BindingList<DdTimeReportExt>();
      foreach (DdTimeReport dd in dn)
        list.Add(new DdTimeReportExt(dd));
      return list;
    }

    static public void UpdateTimeReport(BindingSource binding, int personREF, RevisionInfo revInfo)
    {
      BindingList<DdTimeReportExt> list = (BindingList<DdTimeReportExt>)binding.DataSource;
      try
      {
        using (TransactionScope scope = new TransactionScope())
        {
        DaTimeReport da = new DaTimeReport(DataStore.CloneDbConnection());
        foreach (DdTimeReportExt item in list)
        {// do deletes first
          bool existing = da.GetById(item.Id);
          if (existing && item.DeleteFlag)
          {// delete here - avoid validation
            da.DeleteById(item.Id);
            AddChangeLog(da.TableName, item.Id, da.Timestamp, revInfo);  
          }
        }
        
        foreach (DdTimeReportExt item in list)
        {
          if (item.DeleteFlag) continue; // already done above
          //if (item.Id == string.Empty) continue; // already done above
          bool existing = da.GetById(item.Id);
          if (!existing)
          {
            da.Clear();
          }
          da.CalendarREF = item.CalendarREF;
          da.Description = item.Description;
          da.EffectiveDate = item.EffectiveDate;
          da.Hours = item.Hours;
          da.PersonREF = item.PersonREF;
          da.TaskChargeCodeREF = item.TaskChargeCodeREF;
          if (!existing)
          {
            da.PersonREF = personREF;
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
        binding.DataSource = GetTimeReportList(personREF);
      }
      catch (AppEx)
      {
        throw;
      }
      catch (Exception exc)
      {
        throw new AppEx(exc, "Error updating TimeReport");
      }
    }
  }
  
  public class DdTimeReportExt : DdTimeReport
  {
    public bool DeleteFlag { get; set; }

    public DdTimeReportExt()
      : base()
    {
    }

    public DdTimeReportExt(DdTimeReport dd)
      : base(dd)
    {
    }
  }

}
