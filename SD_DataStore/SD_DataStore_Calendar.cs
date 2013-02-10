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
    static public BindingList<DdCalendarExt> GetCalendars()
    {
      BindingList<DdCalendarExt> list = new BindingList<DdCalendarExt>();
      DaCalendar da = new DaCalendar(DataStore.DbConnection);
      DnCalendar dn = da.Fill();
      foreach (DdCalendar dd in dn) list.Add(new DdCalendarExt(dd));
      return list;
    }
#endif

    static public bool SaveCalendar(ref DdCalendarExt item, RevisionInfo revisionInfo)
    {
      DaCalendar da = new DaCalendar(DataStore.DbConnection);
      if (!da.GetById(item.Id)) return false;
      da.DayDate = item.DayDate;
      da.DayNumber = item.DayNumber;
      da.EndOfPeriod = item.EndOfPeriod;
      da.InvoiceDue = item.InvoiceDue;
      da.PeriodNumber = item.PeriodNumber;
      bool ok = true;
      if (da._IsModified)
      {
        da.Modified = DateTime.Now;
        da.ModifiedBy = Environment.UserName;
        ok = da.Save();
        if (ok) AddChangeLog(da.TableName, da.Id, da.Timestamp, revisionInfo);
        if (ok) item = new DdCalendarExt(da.GetBuffer());
      }
      return ok;
    }

    static public bool AddCalendar(ref DdCalendarExt item, RevisionInfo revisionInfo)
    {
      DaCalendar da = new DaCalendar(DataStore.DbConnection);
      da.Clear();
      da.DayDate = item.DayDate;
      da.DayNumber = item.DayNumber;
      da.EndOfPeriod = item.EndOfPeriod;
      da.InvoiceDue = item.InvoiceDue;
      da.Modified = item.Modified;
      da.ModifiedBy = item.ModifiedBy;
      da.PeriodNumber = item.PeriodNumber;
      bool ok = da.Insert();
      if (ok) AddChangeLog(da.TableName, da.Id, da.Timestamp, revisionInfo); //add
      if (ok) item = new DdCalendarExt(da.GetBuffer());
      return ok;
    }

    static public bool DeleteCalendar(DdCalendarExt item, RevisionInfo revisionInfo)
    {
      DaCalendar da = new DaCalendar(DataStore.DbConnection);
      bool ok = da.DeleteById(item.Id);
      if (ok) AddChangeLog(da.TableName, item.Id, item.Timestamp, revisionInfo); //delete
	  return ok;
    }

    static public DdCalendarExt GetCalendarInfo(int calendarREF)
    {
      DaCalendar da = new DaCalendar(DataStore.DbConnection);
      if (da.GetById(calendarREF))
        return new DdCalendarExt(da.GetBuffer());
      else
        return null;
    }

    static public BindingList<DdCalendarExt> GetCalendarList()
    {
      DaCalendar daCalendar = new DaCalendar(DataStore.DbConnection);
      DnCalendar dn = daCalendar.Fill();
      BindingList<DdCalendarExt> list = new BindingList<DdCalendarExt>();
      foreach (DdCalendar dd in dn)
        list.Add(new DdCalendarExt(dd));
      return list;
    }

    static public void UpdateCalendar(BindingSource binding, RevisionInfo revInfo)
    {
      BindingList<DdCalendarExt> list = (BindingList<DdCalendarExt>)binding.DataSource;
      try
      {
        using (TransactionScope scope = new TransactionScope())
        {
        DaCalendar da = new DaCalendar(DataStore.CloneDbConnection());
        foreach (DdCalendarExt item in list)
        {// do deletes first
          bool existing = da.GetById(item.Id);
          if (existing && item.DeleteFlag)
          {// delete here - avoid validation
            da.DeleteById(item.Id);
            AddChangeLog(da.TableName, item.Id, da.Timestamp, revInfo);  
          }
        }
        
        foreach (DdCalendarExt item in list)
        {
          if (item.DeleteFlag) continue; // already done above
          //if (item.DayDate == string.Empty) continue; // already done above
          bool existing = da.GetById(item.Id);
          if (!existing)
          {
            da.Clear();
          }
          da.DayDate = item.DayDate;
          da.DayNumber = item.DayNumber;
          da.EndOfPeriod = item.EndOfPeriod;
          da.InvoiceDue = item.InvoiceDue;
          da.PeriodNumber = item.PeriodNumber;
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
        binding.DataSource = GetCalendarList();
      }
      catch (AppEx)
      {
        throw;
      }
      catch (Exception exc)
      {
        throw new AppEx(exc, "Error updating Calendar");
      }
    }
  }
  
  public class DdCalendarExt : DdCalendar
  {
    public bool DeleteFlag { get; set; }

    public DdCalendarExt()
      : base()
    {
    }

    public DdCalendarExt(DdCalendar dd)
      : base(dd)
    {
    }
  }

}
