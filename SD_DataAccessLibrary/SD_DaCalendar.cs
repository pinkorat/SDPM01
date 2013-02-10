// Generated: Sun Jan 27, 2013 10:54:07
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
  public class DaCalendar : DbCalendar, ASL.ApplicatFieldType.IDaForm_I
#else
  public class DaCalendar : DbCalendar
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
      public DateTime DayDate;
		}
		public class FetchEntry
		{
			public int hitCount = 1;
			public DdCalendar ddCalendar;
			public FetchEntry(DdCalendar ddCalendar) { this.ddCalendar = ddCalendar; }
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

    public DateTime Created
    {
      get { return store.Buffer.Created; }

    }
    public DateTime DayDate
    {
      get { return store.Buffer.DayDate; }

      set 
      { 
#if __REALCHANGE__
        if (store.Buffer.DayDate != value)
        {
          store.Buffer.DayDate = value; 
          store.modDayDate = true;
        }
#else
        store.Buffer.DayDate = value; 
        store.modDayDate = true;
#endif
      }
    }
    public int DayNumber
    {
      get { return store.Buffer.DayNumber; }

      set 
      { 
#if __REALCHANGE__
        if (store.Buffer.DayNumber != value)
        {
          store.Buffer.DayNumber = value; 
          store.modDayNumber = true;
        }
#else
        store.Buffer.DayNumber = value; 
        store.modDayNumber = true;
#endif
      }
    }
    public bool EndOfPeriod
    {
      get { return store.Buffer.EndOfPeriod; }

      set 
      { 
#if __REALCHANGE__
        if (store.Buffer.EndOfPeriod != value)
        {
          store.Buffer.EndOfPeriod = value; 
          store.modEndOfPeriod = true;
        }
#else
        store.Buffer.EndOfPeriod = value; 
        store.modEndOfPeriod = true;
#endif
      }
    }
    public int Id
    {
      get { return store.Buffer.Id; }

    }
    public bool InvoiceDue
    {
      get { return store.Buffer.InvoiceDue; }

      set 
      { 
#if __REALCHANGE__
        if (store.Buffer.InvoiceDue != value)
        {
          store.Buffer.InvoiceDue = value; 
          store.modInvoiceDue = true;
        }
#else
        store.Buffer.InvoiceDue = value; 
        store.modInvoiceDue = true;
#endif
      }
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
        if (value.Length > 50) InvalidateField("Too long", "Calendar.ModifiedBy");
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
    public int PeriodNumber
    {
      get { return store.Buffer.PeriodNumber; }

      set 
      { 
#if __REALCHANGE__
        if (store.Buffer.PeriodNumber != value)
        {
          store.Buffer.PeriodNumber = value; 
          store.modPeriodNumber = true;
        }
#else
        store.Buffer.PeriodNumber = value; 
        store.modPeriodNumber = true;
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
      items["Created"] = Created;
      items["DayDate"] = DayDate;
      items["DayNumber"] = DayNumber;
      items["EndOfPeriod"] = EndOfPeriod;
      items["Id"] = Id;
      items["InvoiceDue"] = InvoiceDue;
      items["Modified"] = Modified;
      items["ModifiedBy"] = ModifiedBy;
      items["PeriodNumber"] = PeriodNumber;
      return items;
    }

    public void SetFromList(SortedList<string, object> items)
    {
      if (items.ContainsKey("DayDate")) DayDate= (DateTime)items["DayDate"];
      if (items.ContainsKey("DayNumber")) DayNumber= (int)items["DayNumber"];
      if (items.ContainsKey("EndOfPeriod")) EndOfPeriod= (bool)items["EndOfPeriod"];
      if (items.ContainsKey("InvoiceDue")) InvoiceDue= (bool)items["InvoiceDue"];
      if (items.ContainsKey("Modified")) Modified= (DateTime)items["Modified"];
      if (items.ContainsKey("ModifiedBy")) ModifiedBy= (string)items["ModifiedBy"];
      if (items.ContainsKey("PeriodNumber")) PeriodNumber= (int)items["PeriodNumber"];
    }
#endif
//??EndExpand 1/27/2013 10:54:07 AM
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
			DnCalendar dnCalendar = FillByParent(parentREF);
			ArrayList choices = new ArrayList();
			IEnumerator en = dnCalendar.GetEnumerator();
			DdCalendar ddCalendar;
			while (en.MoveNext())
			{
				ddCalendar = (DdCalendar)en.Current;
				choices.Add(ddCalendar.Id.ToString() + "," + ddCalendar.Description);
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

    private DsCalendar store = new DsCalendar();

    public DaCalendar(SQL.DBConnection dbConnection) : base(dbConnection)
    {
      store.ClearAll();
    }

    public void Clear()
    {
      store.ClearAll();
    }

    public bool GetByPK(DateTime DayDate)
    {
      store.Buffer.DayDate = DayDate;
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

    public void SetBuffer(DdCalendar buffer)
    {
      store.Buffer = buffer;
    }

    public bool _IsModified
    {
      get { return store.Modified(); }
    }

    public DdCalendar GetBuffer()
    {
      return store.Buffer; 
    }

    public void SetModFlags() { store.SetModFlags(); }
    public void ClearModFlags() { store.ClearModFlags(); }
    public void SetDefaults() { store.Buffer.SetDefaults(); }

    #region fetch cache
#if __FETCHCACHE__
		public bool FetchByPK(DateTime DayDate)
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
      key.DayDate = DayDate;
			if (fetchTable.Contains(key))
			{
				_hitCount++;
				ent = (FetchEntry)fetchTable[key];
				SetBuffer(ent.ddCalendar);
				if (ent.hitCount < int.MaxValue) ent.hitCount++;
				return true;
			}
			if (missTable.Contains(key)) return false;
			
			_ioCount++;
      store.Buffer.DayDate = DayDate;
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
		public DnCalendar Fill()
		{
			string sqlWhere = "Id >= 100";
			return Fill(sqlWhere, "DayDate", 0, true);
		}
		#endregion extend
  }


  public class DbCalendar : ASL.SQL.TableDataObject
  {
    private const int idxCreated = 0;
    private const int idxDayDate = 1;
    private const int idxDayNumber = 2;
    private const int idxEndOfPeriod = 3;
    private const int idxId = 4;
    private const int idxInvoiceDue = 5;
    private const int idxModified = 6;
    private const int idxModifiedBy = 7;
    private const int idxPeriodNumber = 8;
    private const int idxTimestamp = 9;
    private const int idxNUMCOLS = 10;
    // Column names
    static readonly protected string[] sqlCols =
    {
     "[Created]", "[DayDate]", "[DayNumber]", "[EndOfPeriod]", "[Id]", "[InvoiceDue]"
     , "[Modified]", "[ModifiedBy]", "[PeriodNumber]", "[Timestamp]"
    };
    static public string SqlColumnList { get { return string.Join(",", sqlCols); } }
    static public string[] SqlCols { get { return sqlCols; } }

    // set database connection and other initial values
    public DbCalendar(SQL.DBConnection dbConnection)
    {
      base.dbConnection = dbConnection;
      tableName = "Calendar";
      identityColumnName = "Id";
      sqlColumns = string.Join(",",  sqlCols);
    }

		public string TableName { get { return tableName; } set { tableName = value; } }

    public bool GetById(int Id, out DdCalendar buffer)
    {
      DsCalendar dsCalendar = new DsCalendar();
      dsCalendar.Buffer.Id = Id;
      if (!GetById(ref dsCalendar)) 
      {
        buffer = new DdCalendar();
        return false;
      }
      buffer = dsCalendar.Buffer;
      return true;
    }

    public bool GetById(ref DsCalendar xStr)
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
        DateTime DayDate
      , out DdCalendar buffer)
    {
      DsCalendar dsCalendar = new DsCalendar();
      dsCalendar.Buffer.DayDate = DayDate;
      if (!GetByPK(ref dsCalendar))
      {
        buffer = new DdCalendar();
        return false;
      }
      buffer = dsCalendar.Buffer;
      return true;
    }

    public bool GetByPK(ref DsCalendar xStr)
    {
      string sql = "SELECT " + sqlColumns
      + " FROM " + tableName + NOLOCKSQL
      + " WHERE DayDate = " + TXT.q1(xStr.Buffer.DayDate.ToShortDateString());
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

    public bool UpdateById(ref DsCalendar xStr)
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

    public bool UpdateByPK(ref DsCalendar xStr)
    {
      int rowsUpdated = 0;
      if (xStr.Modified())
      {
        string sql = "UPDATE " + tableName + " SET " + BuildUpdateSQL(xStr) + " WHERE"
      + " DayDate = " + TXT.q1(xStr.Buffer.DayDate.ToShortDateString());
        if(!UpdateSQL(sql)) return false;
        rowsUpdated = _rowsAffected;
      }
      bool ok = GetByPK(ref xStr);
      _rowsAffected = rowsUpdated;
      return ok;
    }

    public bool DeleteByPK(
        DateTime DayDate)
    {
      string sql = "DELETE FROM " + tableName + " WHERE"
      + " DayDate = " + TXT.q1(DayDate.ToShortDateString());
      return DeleteSQL(sql);
    }

    public bool DeleteByPK(ref DsCalendar xStr)
    {
      string sql = "DELETE FROM " + tableName + " WHERE"
      + " DayDate = " + TXT.q1(xStr.Buffer.DayDate.ToShortDateString());
      return DeleteSQL(sql);
    }
    public bool Insert(ref DsCalendar xStr)
    {
      int Id;
      string sql = BuildInsertSQL(xStr);
      if (!InsertIdSQL(sql, out Id)) return false;
      xStr.Buffer.Id = Id;
      return GetById(ref xStr);
    }

    public bool GetBySql(string sqlWhere, ref DsCalendar xStr)
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


    public DnCalendar Fill(string xWhere, string xOrder, int xTop, bool xNoLock)
    {
      System.Data.DataTable dt = FillDataTable(xWhere, xOrder, xTop, xNoLock);
      DnCalendar CalendarList = new DnCalendar(dt.Rows.Count);
      foreach(System.Data.DataRow adr in dt.Rows)
      {
        CalendarList.Add(Load(adr).Buffer);
      }
      return CalendarList;
    }

    static public DsCalendar Load(System.Data.DataRow dr)
    {
      DsCalendar tStr = new DsCalendar();
      tStr.ClearBuffer();
      if (dr[idxCreated] != System.DBNull.Value) tStr.Buffer.Created = (DateTime)dr[idxCreated];
      if (dr[idxDayDate] != System.DBNull.Value) tStr.Buffer.DayDate = (DateTime)dr[idxDayDate];
      if (dr[idxDayNumber] != System.DBNull.Value) tStr.Buffer.DayNumber = (int)dr[idxDayNumber];
      if (dr[idxEndOfPeriod] != System.DBNull.Value) tStr.Buffer.EndOfPeriod = (bool)dr[idxEndOfPeriod];
      if (dr[idxId] != System.DBNull.Value) tStr.Buffer.Id = (int)dr[idxId];
      if (dr[idxInvoiceDue] != System.DBNull.Value) tStr.Buffer.InvoiceDue = (bool)dr[idxInvoiceDue];
      if (dr[idxModified] != System.DBNull.Value) tStr.Buffer.Modified = (DateTime)dr[idxModified];
      if (dr[idxModifiedBy] != System.DBNull.Value) tStr.Buffer.ModifiedBy = (string)dr[idxModifiedBy];
      if (dr[idxPeriodNumber] != System.DBNull.Value) tStr.Buffer.PeriodNumber = (int)dr[idxPeriodNumber];
      if (dr[idxTimestamp] != System.DBNull.Value) tStr.Buffer.Timestamp = (byte[])dr[idxTimestamp];
      return tStr;
    }

    public string BuildInsertSQL(DsCalendar xStr)
    {
      SQL.SqlCommandBuilder sc = new SQL.SqlCommandBuilder(
        SQL.sqlVerb.Insert, tableName);
      if (xStr.modDayDate)
        sc.AddColumn(sqlCols[idxDayDate], xStr.Buffer.DayDate);
      if (xStr.modDayNumber)
        sc.AddColumn(sqlCols[idxDayNumber], xStr.Buffer.DayNumber);
      if (xStr.modEndOfPeriod)
        sc.AddColumn(sqlCols[idxEndOfPeriod], xStr.Buffer.EndOfPeriod);
      if (xStr.modInvoiceDue)
        sc.AddColumn(sqlCols[idxInvoiceDue], xStr.Buffer.InvoiceDue);
      if (xStr.modModified)
        sc.AddColumn(sqlCols[idxModified], xStr.Buffer.Modified);
      if (xStr.modModifiedBy)
        sc.AddColumn(sqlCols[idxModifiedBy], xStr.Buffer.ModifiedBy);
      if (xStr.modPeriodNumber)
        sc.AddColumn(sqlCols[idxPeriodNumber], xStr.Buffer.PeriodNumber);
      return sc.CommandText;
    }

    public string BuildUpdateSQL(DsCalendar xStr)
    {
      SQL.SqlCommandBuilder sc = new SQL.SqlCommandBuilder(SQL.sqlVerb.Update);
      if (xStr.modDayDate)
        sc.AddColumn(sqlCols[idxDayDate], xStr.Buffer.DayDate);
      if (xStr.modDayNumber)
        sc.AddColumn(sqlCols[idxDayNumber], xStr.Buffer.DayNumber);
      if (xStr.modEndOfPeriod)
        sc.AddColumn(sqlCols[idxEndOfPeriod], xStr.Buffer.EndOfPeriod);
      if (xStr.modInvoiceDue)
        sc.AddColumn(sqlCols[idxInvoiceDue], xStr.Buffer.InvoiceDue);
      if (xStr.modModified)
        sc.AddColumn(sqlCols[idxModified], xStr.Buffer.Modified);
      if (xStr.modModifiedBy)
        sc.AddColumn(sqlCols[idxModifiedBy], xStr.Buffer.ModifiedBy);
      if (xStr.modPeriodNumber)
        sc.AddColumn(sqlCols[idxPeriodNumber], xStr.Buffer.PeriodNumber);
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
		
		static public DdCalendar LoadRow(System.Data.SqlClient.SqlDataReader reader)
		{
			DdCalendar rowBuffer = new DdCalendar();
			rowBuffer.Clear();
			if (!reader.IsDBNull(idxCreated)) rowBuffer.Created = reader.GetDateTime(idxCreated);
			if (!reader.IsDBNull(idxDayDate)) rowBuffer.DayDate = reader.GetDateTime(idxDayDate);
			if (!reader.IsDBNull(idxDayNumber)) rowBuffer.DayNumber = reader.GetInt32(idxDayNumber);
			if (!reader.IsDBNull(idxEndOfPeriod)) rowBuffer.EndOfPeriod = reader.GetBoolean(idxEndOfPeriod);
			if (!reader.IsDBNull(idxId)) rowBuffer.Id = reader.GetInt32(idxId);
			if (!reader.IsDBNull(idxInvoiceDue)) rowBuffer.InvoiceDue = reader.GetBoolean(idxInvoiceDue);
			if (!reader.IsDBNull(idxModified)) rowBuffer.Modified = reader.GetDateTime(idxModified);
			if (!reader.IsDBNull(idxModifiedBy)) rowBuffer.ModifiedBy = reader.GetString(idxModifiedBy);
			if (!reader.IsDBNull(idxPeriodNumber)) rowBuffer.PeriodNumber = reader.GetInt32(idxPeriodNumber);
			if (!reader.IsDBNull(idxTimestamp)) rowBuffer.Timestamp = GetTimestamp(idxTimestamp, reader);
			return rowBuffer;
		}
  }
  [Serializable]
  public class DsCalendar
  {
    public DdCalendar Buffer = new DdCalendar();

    public bool IsNew;
    public bool IsDeleted;

    public bool modDayDate;
    public bool modDayNumber;
    public bool modEndOfPeriod;
    public bool modInvoiceDue;
    public bool modModified;
    public bool modModifiedBy;
    public bool modPeriodNumber;

    public object Tag;
    public int RowsAffected;
    public string ResultCode;
    public string ResultMessage;

    public bool Modified()
    {
      return
        modDayDate
     || modDayNumber
     || modEndOfPeriod
     || modInvoiceDue
     || modModified
     || modModifiedBy
     || modPeriodNumber;
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
      modDayDate = false;
      modDayNumber = false;
      modEndOfPeriod = false;
      modInvoiceDue = false;
      modModified = false;
      modModifiedBy = false;
      modPeriodNumber = false;
    }

    public void SetModFlags()
    {
      modDayDate = true;
      modDayNumber = true;
      modEndOfPeriod = true;
      modInvoiceDue = true;
      modModified = true;
      modModifiedBy = true;
      modPeriodNumber = true;
    }
  }

  [Serializable]
  public class DdCalendar : ASL.Forms.DdBase
  {
    public DateTime DayDate { get; set; }
    public int DayNumber { get; set; }
    public bool EndOfPeriod { get; set; }
    public bool InvoiceDue { get; set; }
    public int PeriodNumber { get; set; }

    public const string DayDate_N = "DayDate";
    public const string DayNumber_N = "DayNumber";
    public const string EndOfPeriod_N = "EndOfPeriod";
    public const string InvoiceDue_N = "InvoiceDue";
    public const string PeriodNumber_N = "PeriodNumber";


    public DdCalendar()
	  : base()
    {
      Clear();
    }

    public DdCalendar(DdCalendar original)
	  : base(original)
    {
      DayDate = original.DayDate;
      DayNumber = original.DayNumber;
      EndOfPeriod = original.EndOfPeriod;
      InvoiceDue = original.InvoiceDue;
      PeriodNumber = original.PeriodNumber;
    }

    public override void Clear()
    {
      base.Clear();
      DayDate = DateTime.MinValue;
      DayNumber = 0;
      EndOfPeriod = false;
      InvoiceDue = false;
      PeriodNumber = 0;
    }

    public override void SetDefaults()
    {
      base.SetDefaults();
      DayDate = DateTime.MinValue;
      DayNumber = (-1);
      EndOfPeriod = false;
      InvoiceDue = false;
      PeriodNumber = (-1);
    }
  }

  [Serializable]
  public class DnCalendar : System.Collections.Generic.List<DdCalendar>
  {
    public DnCalendar() : base() {}
    public DnCalendar(int xCapacity) : base(xCapacity) {}

    public new DdCalendar this[int xIndex]
    {
      get { return (DdCalendar) base[xIndex]; }
      set { base[xIndex] = value; }
    }
  }


}
