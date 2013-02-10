// Generated: Sun Jan 27, 2013 10:54:31
#define __REALCHANGE__
//#define __FETCHCACHE__
//#define __FORMINTERFACE__

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using ASL;
using TXT = ASL.Text.Text;
using SQL = ASL.SQL;

namespace SD
{
#if __FORMINTERFACE__
  public class DaTimeReport : DbTimeReport, ASL.ApplicatFieldType.IDaForm_I
#else
  public class DaTimeReport : DbTimeReport
#endif
  {
		#region fetch cache
#if __FETCHCACHE__
		private Hashtable fetchTable;
		private Hashtable missTable;
		public int _hitCount, _ioCount;
		public int _maxNumEnt = 100;
		public int _minNumEnt = 70;
		public int _maxMissEnt = 10;
			
		private struct FetchKey
		{
      public int Id;
		}
		public class FetchEntry
		{
			public int hitCount = 1;
			public DdTimeReport ddTimeReport;
			public FetchEntry(DdTimeReport ddTimeReport) { this.ddTimeReport = ddTimeReport; }
		}
#endif
		#endregion fetch cache
    #region fields
//??Expand _DaFields
    private void InvalidateField(string message, string fieldName)
    {
      AppEx aex = new AppEx(message);
      aex["FieldName"] = fieldName;
      throw aex;
    }

    public int CalendarREF
    {
      get { return store.Buffer.CalendarREF; }

      set 
      { 
#if __REALCHANGE__
        if (store.Buffer.CalendarREF != value)
        {
          store.Buffer.CalendarREF = value; 
          store.modCalendarREF = true;
        }
#else
        store.Buffer.CalendarREF = value; 
        store.modCalendarREF = true;
#endif
      }
    }
    public DateTime Created
    {
      get { return store.Buffer.Created; }

    }
    public string Description
    {
      get { return store.Buffer.Description; }

      set 
      { 
#if __REALCHANGE__
        if (store.Buffer.Description != value)
        {
          store.Buffer.Description = value; 
          store.modDescription = true;
        }
#else
        store.Buffer.Description = value; 
        store.modDescription = true;
#endif
      }
    }
    public DateTime EffectiveDate
    {
      get { return store.Buffer.EffectiveDate; }

      set 
      { 
#if __REALCHANGE__
        if (store.Buffer.EffectiveDate != value)
        {
          store.Buffer.EffectiveDate = value; 
          store.modEffectiveDate = true;
        }
#else
        store.Buffer.EffectiveDate = value; 
        store.modEffectiveDate = true;
#endif
      }
    }
    public decimal Hours
    {
      get { return store.Buffer.Hours; }

      set 
      { 
#if __REALCHANGE__
        if (store.Buffer.Hours != value)
        {
          store.Buffer.Hours = value; 
          store.modHours = true;
        }
#else
        store.Buffer.Hours = value; 
        store.modHours = true;
#endif
      }
    }
    public int Id
    {
      get { return store.Buffer.Id; }

    }
    public DateTime Modified
    {
      get { return store.Buffer.Modified; }

      set 
      { 
#if __REALCHANGE__
        if (store.Buffer.Modified != value)
        {
          store.Buffer.Modified = value; 
          store.modModified = true;
        }
#else
        store.Buffer.Modified = value; 
        store.modModified = true;
#endif
      }
    }
    public string ModifiedBy
    {
      get { return store.Buffer.ModifiedBy; }

      set 
      { 
        if (value.Length > 50) InvalidateField("Too long", "TimeReport.ModifiedBy");
#if __REALCHANGE__
        if (store.Buffer.ModifiedBy != value)
        {
          store.Buffer.ModifiedBy = value; 
          store.modModifiedBy = true;
        }
#else
        store.Buffer.ModifiedBy = value; 
        store.modModifiedBy = true;
#endif
      }
    }
    public int PersonREF
    {
      get { return store.Buffer.PersonREF; }

      set 
      { 
#if __REALCHANGE__
        if (store.Buffer.PersonREF != value)
        {
          store.Buffer.PersonREF = value; 
          store.modPersonREF = true;
        }
#else
        store.Buffer.PersonREF = value; 
        store.modPersonREF = true;
#endif
      }
    }
    public int TaskChargeCodeREF
    {
      get { return store.Buffer.TaskChargeCodeREF; }

      set 
      { 
#if __REALCHANGE__
        if (store.Buffer.TaskChargeCodeREF != value)
        {
          store.Buffer.TaskChargeCodeREF = value; 
          store.modTaskChargeCodeREF = true;
        }
#else
        store.Buffer.TaskChargeCodeREF = value; 
        store.modTaskChargeCodeREF = true;
#endif
      }
    }
    public byte[] Timestamp
    {
      get { return store.Buffer.Timestamp; }

    }

#if __FIELDLIST__
    public SortedList<string, object> GetAsList()
    {
      SortedList<string, object> items = new SortedList<string, object>();
      items["CalendarREF"] = CalendarREF;
      items["Created"] = Created;
      items["Description"] = Description;
      items["EffectiveDate"] = EffectiveDate;
      items["Hours"] = Hours;
      items["Id"] = Id;
      items["Modified"] = Modified;
      items["ModifiedBy"] = ModifiedBy;
      items["PersonREF"] = PersonREF;
      items["TaskChargeCodeREF"] = TaskChargeCodeREF;
      return items;
    }

    public void SetFromList(SortedList<string, object> items)
    {
      if (items.ContainsKey("CalendarREF")) CalendarREF= (int)items["CalendarREF"];
      if (items.ContainsKey("Description")) Description= (string)items["Description"];
      if (items.ContainsKey("EffectiveDate")) EffectiveDate= (DateTime)items["EffectiveDate"];
      if (items.ContainsKey("Hours")) Hours= (decimal)items["Hours"];
      if (items.ContainsKey("Modified")) Modified= (DateTime)items["Modified"];
      if (items.ContainsKey("ModifiedBy")) ModifiedBy= (string)items["ModifiedBy"];
      if (items.ContainsKey("PersonREF")) PersonREF= (int)items["PersonREF"];
      if (items.ContainsKey("TaskChargeCodeREF")) TaskChargeCodeREF= (int)items["TaskChargeCodeREF"];
    }
#endif
//??EndExpand 1/27/2013 10:54:31 AM
    #endregion fields
    #region form interface
#if __FORMINTERFACE__
		public bool GetDescription(int Id, out string description)
		{
			bool found = GetById(Id);
			if (found) description = this.Description ; else description = "";
			return found;
		}
		
		public bool GetCode(int Id, out string code)
		{
			bool found = GetById(Id);
			if (found) code = this.Code; else code = "";
			return found;
		}

		public bool GetReference(string code, int parentREF, out int Id)
		{
			bool found = GetByPK(parentREF, code);
			if (found) Id = this.Id; else Id = 0;
			return found;
		}

		public System.Collections.ArrayList GetChoices(int parentREF, string attributes)
		{
			DnTimeReport dnTimeReport = FillByParent(parentREF);
			ArrayList choices = new ArrayList();
			IEnumerator en = dnTimeReport.GetEnumerator();
			DdTimeReport ddTimeReport;
			while (en.MoveNext())
			{
				ddTimeReport = (DdTimeReport)en.Current;
				choices.Add(ddTimeReport.Id.ToString() + "," + ddTimeReport.Description);
			}
			return choices;
		}

    public int Id { get { return store.Buffer.Id; } }
		public DateTime Modified { get { return DateTime.MinValue; } set {} }
		public string ModifiedBy { get { return ""; } set {} }
		public int PropertyBagREF{ get { return 0; } set {} }
		public bool IsModified { get { return store.Modified(); } }
#endif
    #endregion form interface

    private DsTimeReport store = new DsTimeReport();

    public DaTimeReport(SQL.DBConnection dbConnection) : base(dbConnection)
    {
      store.ClearAll();
    }

    public void Clear()
    {
      store.ClearAll();
    }

    public bool GetByPK(int Id)
    {
      store.Buffer.Id = Id;
      bool found = GetByPK(ref store);
      return found;
    }

    public bool GetById(int Id)
    {
      store.Buffer.Id = Id;
      bool found = GetById(ref store);
      return found;
    }

    public bool Insert()
    {
      return Insert(ref store);
    }

    public bool Save()
    {
      return UpdateById(ref store);
    }

    public void SetBuffer(DdTimeReport buffer)
    {
      store.Buffer = buffer;
    }

    public bool _IsModified
    {
      get { return store.Modified(); }
    }

    public DdTimeReport GetBuffer()
    {
      return store.Buffer; 
    }

    public void SetModFlags() { store.SetModFlags(); }
    public void ClearModFlags() { store.ClearModFlags(); }
    public void SetDefaults() { store.Buffer.SetDefaults(); }

    #region fetch cache
#if __FETCHCACHE__
		public bool FetchByPK(int Id)
		{
			if (fetchTable == null)
			{
				missTable = new Hashtable(_maxMissEnt);
				fetchTable = new Hashtable(_maxNumEnt);
				_hitCount = 0;
				_ioCount = 0;
			}
			
			FetchEntry ent;
			FetchKey key;
      key.Id = Id;
			if (fetchTable.Contains(key))
			{
				_hitCount++;
				ent = (FetchEntry)fetchTable[key];
				SetBuffer(ent.ddTimeReport);
				if (ent.hitCount < int.MaxValue) ent.hitCount++;
				return true;
			}
			if (missTable.Contains(key)) return false;
			
			_ioCount++;
      store.Buffer.Id = Id;
			bool found = GetByPK(ref store);
			// if not found remember as miss, clear miss table when full
			if (!found)
			{
				if (missTable.Count >= _maxMissEnt) missTable.Clear();
				missTable.Add(key, null);
				return false;
			}
			
			ent = new FetchEntry(store.Buffer);
			fetchTable.Add(key, ent);
			
			if (fetchTable.Count < _maxNumEnt) return true;
			
			// remove least used entries from table
			Stack ks = new Stack();
			for(int b = 0; b < 32; b++) //in 32 passes all 32 bit integers will be zeroed.
			{
				foreach(System.Collections.DictionaryEntry de in fetchTable)
				{
					ent = (FetchEntry)de.Value;
					ent.hitCount /= 2;
					if (ent.hitCount == 0)
					{
						ks.Push(de.Key);
						if (ks.Count >= _maxNumEnt - _minNumEnt) break;
					}
				}
				if (ks.Count >= _maxNumEnt - _minNumEnt) break;
			}
			while(ks.Count > 0)
			{
				key = (FetchKey)ks.Pop();
				fetchTable.Remove(key);
			}
			return true;
		}
#endif
    #endregion fetch cache

		#region extend
		public DnTimeReport Fill()
		{
			string sqlWhere = "Id >= 100";
			return Fill(sqlWhere, "Id", 0, true);
		}
		public DnTimeReport FillByPerson(int parentREF)
		{
			string sqlWhere = string.Format("PersonREF={0}", parentREF);
			return Fill(sqlWhere, "Id", 0, true);
		}
		#endregion extend
  }


  public class DbTimeReport : ASL.SQL.TableDataObject
  {
    private const int idxCalendarREF = 0;
    private const int idxCreated = 1;
    private const int idxDescription = 2;
    private const int idxEffectiveDate = 3;
    private const int idxHours = 4;
    private const int idxId = 5;
    private const int idxModified = 6;
    private const int idxModifiedBy = 7;
    private const int idxPersonREF = 8;
    private const int idxTaskChargeCodeREF = 9;
    private const int idxTimestamp = 10;
    private const int idxNUMCOLS = 11;
    // Column names
    static readonly protected string[] sqlCols =
    {
     "[CalendarREF]", "[Created]", "[Description]", "[EffectiveDate]", "[Hours]"
     , "[Id]", "[Modified]", "[ModifiedBy]", "[PersonREF]", "[TaskChargeCodeREF]"
     , "[Timestamp]"
    };
    static public string SqlColumnList { get { return string.Join(",", sqlCols); } }
    static public string[] SqlCols { get { return sqlCols; } }

    // set database connection and other initial values
    public DbTimeReport(SQL.DBConnection dbConnection)
    {
      base.dbConnection = dbConnection;
      tableName = "TimeReport";
      identityColumnName = "Id";
      sqlColumns = string.Join(",",  sqlCols);
    }

		public string TableName { get { return tableName; } set { tableName = value; } }

    public bool GetById(int Id, out DdTimeReport buffer)
    {
      DsTimeReport dsTimeReport = new DsTimeReport();
      dsTimeReport.Buffer.Id = Id;
      if (!GetById(ref dsTimeReport)) 
      {
        buffer = new DdTimeReport();
        return false;
      }
      buffer = dsTimeReport.Buffer;
      return true;
    }

    public bool GetById(ref DsTimeReport xStr)
    {
      string sql = "SELECT " + sqlColumns 
        + " FROM " + tableName + NOLOCKSQL
        + " WHERE Id = " + xStr.Buffer.Id.ToString();
      System.Data.DataRow dr;
      if (GetSQL(sql, out dr))
      {
        xStr = Load(dr);
        xStr.ResultCode = SUCCESS;
        return true;
      }
      else
      {
        xStr.ClearAll();
        xStr.ResultCode = "NOTFND";
        xStr.ResultMessage = "Row not found";
        return false;
      }
    }

    public bool GetByPK(
        int Id
      , out DdTimeReport buffer)
    {
      DsTimeReport dsTimeReport = new DsTimeReport();
      dsTimeReport.Buffer.Id = Id;
      if (!GetByPK(ref dsTimeReport))
      {
        buffer = new DdTimeReport();
        return false;
      }
      buffer = dsTimeReport.Buffer;
      return true;
    }

    public bool GetByPK(ref DsTimeReport xStr)
    {
      string sql = "SELECT " + sqlColumns
      + " FROM " + tableName + NOLOCKSQL
      + " WHERE Id = " + xStr.Buffer.Id.ToString();
      System.Data.DataRow dr;
      if (GetSQL(sql, out dr))
      {
        xStr = Load(dr);
        xStr.ResultCode = SUCCESS;
        return true;
      }
      else
      {
        xStr.ClearAll();
        xStr.ResultCode = "NOTFND";
        xStr.ResultMessage = "Row not found";
        return false;
      }
    }

    public bool UpdateById(ref DsTimeReport xStr)
    {
      int rowsUpdated = 0;
      if (xStr.Modified())
      {
        string sql = "UPDATE " + tableName + " SET " + BuildUpdateSQL(xStr) + " WHERE"
          + " Id = " + xStr.Buffer.Id.ToString();
        if(!UpdateSQL(sql)) return false;
        rowsUpdated = _rowsAffected;
      }
      bool ok = GetById(ref xStr);
      _rowsAffected = rowsUpdated;
      return ok;
    }

    public bool DeleteById(int Id)
    {
      string sql = "DELETE FROM " + tableName + " WHERE Id = " + Id.ToString();
      return DeleteSQL(sql);
    }

    public bool UpdateByPK(ref DsTimeReport xStr)
    {
      int rowsUpdated = 0;
      if (xStr.Modified())
      {
        string sql = "UPDATE " + tableName + " SET " + BuildUpdateSQL(xStr) + " WHERE"
      + " Id = " + xStr.Buffer.Id.ToString();
        if(!UpdateSQL(sql)) return false;
        rowsUpdated = _rowsAffected;
      }
      bool ok = GetByPK(ref xStr);
      _rowsAffected = rowsUpdated;
      return ok;
    }

    public bool DeleteByPK(
        int Id)
    {
      string sql = "DELETE FROM " + tableName + " WHERE"
      + " Id = " + Id.ToString();
      return DeleteSQL(sql);
    }

    public bool DeleteByPK(ref DsTimeReport xStr)
    {
      string sql = "DELETE FROM " + tableName + " WHERE"
      + " Id = " + xStr.Buffer.Id.ToString();
      return DeleteSQL(sql);
    }
    public bool Insert(ref DsTimeReport xStr)
    {
      int Id;
      string sql = BuildInsertSQL(xStr);
      if (!InsertIdSQL(sql, out Id)) return false;
      xStr.Buffer.Id = Id;
      return GetById(ref xStr);
    }

    public bool GetBySql(string sqlWhere, ref DsTimeReport xStr)
    {
      string sql = "SELECT " + sqlColumns
      + " FROM " + tableName + NOLOCKSQL + " WHERE (" + sqlWhere + ")";
      System.Data.DataRow dr;
      if (GetSQL(sql, out dr))
      {
        xStr = Load(dr);
        xStr.ResultCode = SUCCESS;
        return true;
      }
      else
      {
        xStr.ClearAll();
        xStr.ResultCode = "NOTFND";
        xStr.ResultMessage = "Row not found";
        return false;
      }
    }


    public DnTimeReport Fill(string xWhere, string xOrder, int xTop, bool xNoLock)
    {
      System.Data.DataTable dt = FillDataTable(xWhere, xOrder, xTop, xNoLock);
      DnTimeReport TimeReportList = new DnTimeReport(dt.Rows.Count);
      foreach(System.Data.DataRow adr in dt.Rows)
      {
        TimeReportList.Add(Load(adr).Buffer);
      }
      return TimeReportList;
    }

    static public DsTimeReport Load(System.Data.DataRow dr)
    {
      DsTimeReport tStr = new DsTimeReport();
      tStr.ClearBuffer();
      if (dr[idxCalendarREF] != System.DBNull.Value) tStr.Buffer.CalendarREF = (int)dr[idxCalendarREF];
      if (dr[idxCreated] != System.DBNull.Value) tStr.Buffer.Created = (DateTime)dr[idxCreated];
      if (dr[idxDescription] != System.DBNull.Value) tStr.Buffer.Description = (string)dr[idxDescription];
      if (dr[idxEffectiveDate] != System.DBNull.Value) tStr.Buffer.EffectiveDate = (DateTime)dr[idxEffectiveDate];
      if (dr[idxHours] != System.DBNull.Value) tStr.Buffer.Hours = (decimal)dr[idxHours];
      if (dr[idxId] != System.DBNull.Value) tStr.Buffer.Id = (int)dr[idxId];
      if (dr[idxModified] != System.DBNull.Value) tStr.Buffer.Modified = (DateTime)dr[idxModified];
      if (dr[idxModifiedBy] != System.DBNull.Value) tStr.Buffer.ModifiedBy = (string)dr[idxModifiedBy];
      if (dr[idxPersonREF] != System.DBNull.Value) tStr.Buffer.PersonREF = (int)dr[idxPersonREF];
      if (dr[idxTaskChargeCodeREF] != System.DBNull.Value) tStr.Buffer.TaskChargeCodeREF = (int)dr[idxTaskChargeCodeREF];
      if (dr[idxTimestamp] != System.DBNull.Value) tStr.Buffer.Timestamp = (byte[])dr[idxTimestamp];
      return tStr;
    }

    public string BuildInsertSQL(DsTimeReport xStr)
    {
      SQL.SqlCommandBuilder sc = new SQL.SqlCommandBuilder(
        SQL.sqlVerb.Insert, tableName);
      if (xStr.modCalendarREF)
        sc.AddColumn(sqlCols[idxCalendarREF], xStr.Buffer.CalendarREF);
      if (xStr.modDescription)
        sc.AddColumn(sqlCols[idxDescription], xStr.Buffer.Description);
      if (xStr.modEffectiveDate)
        sc.AddColumn(sqlCols[idxEffectiveDate], xStr.Buffer.EffectiveDate);
      if (xStr.modHours)
        sc.AddColumn(sqlCols[idxHours], xStr.Buffer.Hours);
      if (xStr.modModified)
        sc.AddColumn(sqlCols[idxModified], xStr.Buffer.Modified);
      if (xStr.modModifiedBy)
        sc.AddColumn(sqlCols[idxModifiedBy], xStr.Buffer.ModifiedBy);
      if (xStr.modPersonREF)
        sc.AddColumn(sqlCols[idxPersonREF], xStr.Buffer.PersonREF);
      if (xStr.modTaskChargeCodeREF)
        sc.AddColumn(sqlCols[idxTaskChargeCodeREF], xStr.Buffer.TaskChargeCodeREF);
      return sc.CommandText;
    }

    public string BuildUpdateSQL(DsTimeReport xStr)
    {
      SQL.SqlCommandBuilder sc = new SQL.SqlCommandBuilder(SQL.sqlVerb.Update);
      if (xStr.modCalendarREF)
        sc.AddColumn(sqlCols[idxCalendarREF], xStr.Buffer.CalendarREF);
      if (xStr.modDescription)
        sc.AddColumn(sqlCols[idxDescription], xStr.Buffer.Description);
      if (xStr.modEffectiveDate)
        sc.AddColumn(sqlCols[idxEffectiveDate], xStr.Buffer.EffectiveDate);
      if (xStr.modHours)
        sc.AddColumn(sqlCols[idxHours], xStr.Buffer.Hours);
      if (xStr.modModified)
        sc.AddColumn(sqlCols[idxModified], xStr.Buffer.Modified);
      if (xStr.modModifiedBy)
        sc.AddColumn(sqlCols[idxModifiedBy], xStr.Buffer.ModifiedBy);
      if (xStr.modPersonREF)
        sc.AddColumn(sqlCols[idxPersonREF], xStr.Buffer.PersonREF);
      if (xStr.modTaskChargeCodeREF)
        sc.AddColumn(sqlCols[idxTaskChargeCodeREF], xStr.Buffer.TaskChargeCodeREF);
      return sc.ColumnList;
    }

    // Reader
		public System.Data.SqlClient.SqlDataReader GetReader(string sqlWhere, string sqlOrder)
		{
			string sql = "SELECT " + sqlColumns + " FROM " + tableName;
			if (sqlWhere != string.Empty) sql += " WHERE " + sqlWhere;
			if (sqlOrder != string.Empty) sql += " ORDER BY " + sqlOrder;
			System.Data.SqlClient.SqlCommand cd1 = new System.Data.SqlClient.SqlCommand(sql);
			cd1.Connection =  dbConnection.Connection;
			cd1.CommandTimeout = 300;
			System.Data.SqlClient.SqlDataReader reader;
			reader = cd1.ExecuteReader();
			return reader;
		}
		
		static public DdTimeReport LoadRow(System.Data.SqlClient.SqlDataReader reader)
		{
			DdTimeReport rowBuffer = new DdTimeReport();
			rowBuffer.Clear();
			if (!reader.IsDBNull(idxCalendarREF)) rowBuffer.CalendarREF = reader.GetInt32(idxCalendarREF);
			if (!reader.IsDBNull(idxCreated)) rowBuffer.Created = reader.GetDateTime(idxCreated);
			if (!reader.IsDBNull(idxDescription)) rowBuffer.Description = reader.GetString(idxDescription);
			if (!reader.IsDBNull(idxEffectiveDate)) rowBuffer.EffectiveDate = reader.GetDateTime(idxEffectiveDate);
			if (!reader.IsDBNull(idxHours)) rowBuffer.Hours = reader.GetDecimal(idxHours);
			if (!reader.IsDBNull(idxId)) rowBuffer.Id = reader.GetInt32(idxId);
			if (!reader.IsDBNull(idxModified)) rowBuffer.Modified = reader.GetDateTime(idxModified);
			if (!reader.IsDBNull(idxModifiedBy)) rowBuffer.ModifiedBy = reader.GetString(idxModifiedBy);
			if (!reader.IsDBNull(idxPersonREF)) rowBuffer.PersonREF = reader.GetInt32(idxPersonREF);
			if (!reader.IsDBNull(idxTaskChargeCodeREF)) rowBuffer.TaskChargeCodeREF = reader.GetInt32(idxTaskChargeCodeREF);
			if (!reader.IsDBNull(idxTimestamp)) rowBuffer.Timestamp = GetTimestamp(idxTimestamp, reader);
			return rowBuffer;
		}
  }
  [Serializable]
  public class DsTimeReport
  {
    public DdTimeReport Buffer = new DdTimeReport();

    public bool IsNew;
    public bool IsDeleted;

    public bool modCalendarREF;
    public bool modDescription;
    public bool modEffectiveDate;
    public bool modHours;
    public bool modModified;
    public bool modModifiedBy;
    public bool modPersonREF;
    public bool modTaskChargeCodeREF;

    public object Tag;
    public int RowsAffected;
    public string ResultCode;
    public string ResultMessage;

    public bool Modified()
    {
      return
        modCalendarREF
     || modDescription
     || modEffectiveDate
     || modHours
     || modModified
     || modModifiedBy
     || modPersonREF
     || modTaskChargeCodeREF;
    }

    public void ClearAll() 
    { 
      Buffer.Clear(); 
      ClearModFlags();
      ClearControl();
    }

    public void ClearBuffer() { Buffer.Clear(); }

    public void ClearControl()
    {
      IsNew = false;
      IsDeleted = false;
      Tag = null;
      RowsAffected = 0;
      ResultCode = "";
      ResultMessage = "";
    }

    public void ClearModFlags()
    {
      modCalendarREF = false;
      modDescription = false;
      modEffectiveDate = false;
      modHours = false;
      modModified = false;
      modModifiedBy = false;
      modPersonREF = false;
      modTaskChargeCodeREF = false;
    }

    public void SetModFlags()
    {
      modCalendarREF = true;
      modDescription = true;
      modEffectiveDate = true;
      modHours = true;
      modModified = true;
      modModifiedBy = true;
      modPersonREF = true;
      modTaskChargeCodeREF = true;
    }
  }

  [Serializable]
  public class DdTimeReport : ASL.Forms.DdBase
  {
    public int CalendarREF { get; set; }
    public string Description { get; set; }
    public DateTime EffectiveDate { get; set; }
    public decimal Hours { get; set; }
    public int PersonREF { get; set; }
    public int TaskChargeCodeREF { get; set; }

    public const string CalendarREF_N = "CalendarREF";
    public const string Description_N = "Description";
    public const string EffectiveDate_N = "EffectiveDate";
    public const string Hours_N = "Hours";
    public const string PersonREF_N = "PersonREF";
    public const string TaskChargeCodeREF_N = "TaskChargeCodeREF";

    public const int Description_L = -1;

    public DdTimeReport()
	  : base()
    {
      Clear();
    }

    public DdTimeReport(DdTimeReport original)
	  : base(original)
    {
      CalendarREF = original.CalendarREF;
      Description = original.Description;
      EffectiveDate = original.EffectiveDate;
      Hours = original.Hours;
      PersonREF = original.PersonREF;
      TaskChargeCodeREF = original.TaskChargeCodeREF;
    }

    public override void Clear()
    {
      base.Clear();
      CalendarREF = 0;
      Description = "";
      EffectiveDate = DateTime.MinValue;
      Hours = 0;
      PersonREF = 0;
      TaskChargeCodeREF = 0;
    }

    public override void SetDefaults()
    {
      base.SetDefaults();
      CalendarREF = (1);
      Description = string.Empty;
      EffectiveDate = ASL.Run.Config.EMPTYDATE;
      Hours = (0);
      PersonREF = (1);
      TaskChargeCodeREF = (1);
    }
  }

  [Serializable]
  public class DnTimeReport : System.Collections.Generic.List<DdTimeReport>
  {
    public DnTimeReport() : base() {}
    public DnTimeReport(int xCapacity) : base(xCapacity) {}

    public new DdTimeReport this[int xIndex]
    {
      get { return (DdTimeReport) base[xIndex]; }
      set { base[xIndex] = value; }
    }
  }


}
