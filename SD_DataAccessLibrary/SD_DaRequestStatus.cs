// Generated: Sun Jan 27, 2013 10:54:18
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
  public class DaRequestStatus : DbRequestStatus, ASL.ApplicatFieldType.IDaForm_I
#else
  public class DaRequestStatus : DbRequestStatus
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
      public int ChangeRequestREF;
      public string StatusID;
		}
		public class FetchEntry
		{
			public int hitCount = 1;
			public DdRequestStatus ddRequestStatus;
			public FetchEntry(DdRequestStatus ddRequestStatus) { this.ddRequestStatus = ddRequestStatus; }
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

    public int ChangeRequestREF
    {
      get { return store.Buffer.ChangeRequestREF; }

      set 
      { 
#if __REALCHANGE__
        if (store.Buffer.ChangeRequestREF != value)
        {
          store.Buffer.ChangeRequestREF = value; 
          store.modChangeRequestREF = true;
        }
#else
        store.Buffer.ChangeRequestREF = value; 
        store.modChangeRequestREF = true;
#endif
      }
    }
    public string Comment
    {
      get { return store.Buffer.Comment; }

      set 
      { 
#if __REALCHANGE__
        if (store.Buffer.Comment != value)
        {
          store.Buffer.Comment = value; 
          store.modComment = true;
        }
#else
        store.Buffer.Comment = value; 
        store.modComment = true;
#endif
      }
    }
    public DateTime Created
    {
      get { return store.Buffer.Created; }

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
    public double Hours
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
        if (value.Length > 50) InvalidateField("Too long", "RequestStatus.ModifiedBy");
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
    public string StatusID
    {
      get { return store.Buffer.StatusID; }

      set 
      { 
        if (value.Length > 50) InvalidateField("Too long", "RequestStatus.StatusID");
#if __REALCHANGE__
        if (store.Buffer.StatusID != value)
        {
          store.Buffer.StatusID = value; 
          store.modStatusID = true;
        }
#else
        store.Buffer.StatusID = value; 
        store.modStatusID = true;
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
      items["ChangeRequestREF"] = ChangeRequestREF;
      items["Comment"] = Comment;
      items["Created"] = Created;
      items["EffectiveDate"] = EffectiveDate;
      items["Hours"] = Hours;
      items["Id"] = Id;
      items["Modified"] = Modified;
      items["ModifiedBy"] = ModifiedBy;
      items["PersonREF"] = PersonREF;
      items["StatusID"] = StatusID;
      return items;
    }

    public void SetFromList(SortedList<string, object> items)
    {
      if (items.ContainsKey("ChangeRequestREF")) ChangeRequestREF= (int)items["ChangeRequestREF"];
      if (items.ContainsKey("Comment")) Comment= (string)items["Comment"];
      if (items.ContainsKey("EffectiveDate")) EffectiveDate= (DateTime)items["EffectiveDate"];
      if (items.ContainsKey("Hours")) Hours= (double)items["Hours"];
      if (items.ContainsKey("Modified")) Modified= (DateTime)items["Modified"];
      if (items.ContainsKey("ModifiedBy")) ModifiedBy= (string)items["ModifiedBy"];
      if (items.ContainsKey("PersonREF")) PersonREF= (int)items["PersonREF"];
      if (items.ContainsKey("StatusID")) StatusID= (string)items["StatusID"];
    }
#endif
//??EndExpand 1/27/2013 10:54:18 AM
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
			DnRequestStatus dnRequestStatus = FillByParent(parentREF);
			ArrayList choices = new ArrayList();
			IEnumerator en = dnRequestStatus.GetEnumerator();
			DdRequestStatus ddRequestStatus;
			while (en.MoveNext())
			{
				ddRequestStatus = (DdRequestStatus)en.Current;
				choices.Add(ddRequestStatus.Id.ToString() + "," + ddRequestStatus.Description);
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

    private DsRequestStatus store = new DsRequestStatus();

    public DaRequestStatus(SQL.DBConnection dbConnection) : base(dbConnection)
    {
      store.ClearAll();
    }

    public void Clear()
    {
      store.ClearAll();
    }

    public bool GetByPK(int ChangeRequestREF, string StatusID)
    {
      store.Buffer.ChangeRequestREF = ChangeRequestREF;
      store.Buffer.StatusID = StatusID;
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

    public void SetBuffer(DdRequestStatus buffer)
    {
      store.Buffer = buffer;
    }

    public bool _IsModified
    {
      get { return store.Modified(); }
    }

    public DdRequestStatus GetBuffer()
    {
      return store.Buffer; 
    }

    public void SetModFlags() { store.SetModFlags(); }
    public void ClearModFlags() { store.ClearModFlags(); }
    public void SetDefaults() { store.Buffer.SetDefaults(); }

    #region fetch cache
#if __FETCHCACHE__
		public bool FetchByPK(int ChangeRequestREF, string StatusID)
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
      key.ChangeRequestREF = ChangeRequestREF;
      key.StatusID = StatusID;
			if (fetchTable.Contains(key))
			{
				_hitCount++;
				ent = (FetchEntry)fetchTable[key];
				SetBuffer(ent.ddRequestStatus);
				if (ent.hitCount < int.MaxValue) ent.hitCount++;
				return true;
			}
			if (missTable.Contains(key)) return false;
			
			_ioCount++;
      store.Buffer.ChangeRequestREF = ChangeRequestREF;
      store.Buffer.StatusID = StatusID;
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
		public DnRequestStatus Fill()
		{
			string sqlWhere = "Id >= 100";
			return Fill(sqlWhere, "RequestStatusID", 0, true);
		}
		public DnRequestStatus FillByChangeRequest(int parentREF)
		{
			string sqlWhere = string.Format("ChangeRequestREF={0}", parentREF);
			return Fill(sqlWhere, "RequestStatusID", 0, true);
		}
		#endregion extend
  }


  public class DbRequestStatus : ASL.SQL.TableDataObject
  {
    private const int idxChangeRequestREF = 0;
    private const int idxComment = 1;
    private const int idxCreated = 2;
    private const int idxEffectiveDate = 3;
    private const int idxHours = 4;
    private const int idxId = 5;
    private const int idxModified = 6;
    private const int idxModifiedBy = 7;
    private const int idxPersonREF = 8;
    private const int idxStatusID = 9;
    private const int idxTimestamp = 10;
    private const int idxNUMCOLS = 11;
    // Column names
    static readonly protected string[] sqlCols =
    {
     "[ChangeRequestREF]", "[Comment]", "[Created]", "[EffectiveDate]", "[Hours]"
     , "[Id]", "[Modified]", "[ModifiedBy]", "[PersonREF]", "[StatusID]"
     , "[Timestamp]"
    };
    static public string SqlColumnList { get { return string.Join(",", sqlCols); } }
    static public string[] SqlCols { get { return sqlCols; } }

    // set database connection and other initial values
    public DbRequestStatus(SQL.DBConnection dbConnection)
    {
      base.dbConnection = dbConnection;
      tableName = "RequestStatus";
      identityColumnName = "Id";
      sqlColumns = string.Join(",",  sqlCols);
    }

		public string TableName { get { return tableName; } set { tableName = value; } }

    public bool GetById(int Id, out DdRequestStatus buffer)
    {
      DsRequestStatus dsRequestStatus = new DsRequestStatus();
      dsRequestStatus.Buffer.Id = Id;
      if (!GetById(ref dsRequestStatus)) 
      {
        buffer = new DdRequestStatus();
        return false;
      }
      buffer = dsRequestStatus.Buffer;
      return true;
    }

    public bool GetById(ref DsRequestStatus xStr)
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
        int ChangeRequestREF
      , string StatusID
      , out DdRequestStatus buffer)
    {
      DsRequestStatus dsRequestStatus = new DsRequestStatus();
      dsRequestStatus.Buffer.ChangeRequestREF = ChangeRequestREF;
      dsRequestStatus.Buffer.StatusID = StatusID;
      if (!GetByPK(ref dsRequestStatus))
      {
        buffer = new DdRequestStatus();
        return false;
      }
      buffer = dsRequestStatus.Buffer;
      return true;
    }

    public bool GetByPK(ref DsRequestStatus xStr)
    {
      string sql = "SELECT " + sqlColumns
      + " FROM " + tableName + NOLOCKSQL
      + " WHERE ChangeRequestREF = " + xStr.Buffer.ChangeRequestREF.ToString()
      + " AND StatusID = " + TXT.q1(xStr.Buffer.StatusID);
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

    public bool UpdateById(ref DsRequestStatus xStr)
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

    public bool UpdateByPK(ref DsRequestStatus xStr)
    {
      int rowsUpdated = 0;
      if (xStr.Modified())
      {
        string sql = "UPDATE " + tableName + " SET " + BuildUpdateSQL(xStr) + " WHERE"
      + " ChangeRequestREF = " + xStr.Buffer.ChangeRequestREF.ToString()
      + " AND StatusID = " + TXT.q1(xStr.Buffer.StatusID);
        if(!UpdateSQL(sql)) return false;
        rowsUpdated = _rowsAffected;
      }
      bool ok = GetByPK(ref xStr);
      _rowsAffected = rowsUpdated;
      return ok;
    }

    public bool DeleteByPK(
        int ChangeRequestREF
      , string StatusID)
    {
      string sql = "DELETE FROM " + tableName + " WHERE"
      + " ChangeRequestREF = " + ChangeRequestREF.ToString()
      + " AND StatusID = " + TXT.q1(StatusID);
      return DeleteSQL(sql);
    }

    public bool DeleteByPK(ref DsRequestStatus xStr)
    {
      string sql = "DELETE FROM " + tableName + " WHERE"
      + " ChangeRequestREF = " + xStr.Buffer.ChangeRequestREF.ToString()
      + " AND StatusID = " + TXT.q1(xStr.Buffer.StatusID);
      return DeleteSQL(sql);
    }
    public bool Insert(ref DsRequestStatus xStr)
    {
      int Id;
      string sql = BuildInsertSQL(xStr);
      if (!InsertIdSQL(sql, out Id)) return false;
      xStr.Buffer.Id = Id;
      return GetById(ref xStr);
    }

    public bool GetBySql(string sqlWhere, ref DsRequestStatus xStr)
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


    public DnRequestStatus Fill(string xWhere, string xOrder, int xTop, bool xNoLock)
    {
      System.Data.DataTable dt = FillDataTable(xWhere, xOrder, xTop, xNoLock);
      DnRequestStatus RequestStatusList = new DnRequestStatus(dt.Rows.Count);
      foreach(System.Data.DataRow adr in dt.Rows)
      {
        RequestStatusList.Add(Load(adr).Buffer);
      }
      return RequestStatusList;
    }

    static public DsRequestStatus Load(System.Data.DataRow dr)
    {
      DsRequestStatus tStr = new DsRequestStatus();
      tStr.ClearBuffer();
      if (dr[idxChangeRequestREF] != System.DBNull.Value) tStr.Buffer.ChangeRequestREF = (int)dr[idxChangeRequestREF];
      if (dr[idxComment] != System.DBNull.Value) tStr.Buffer.Comment = (string)dr[idxComment];
      if (dr[idxCreated] != System.DBNull.Value) tStr.Buffer.Created = (DateTime)dr[idxCreated];
      if (dr[idxEffectiveDate] != System.DBNull.Value) tStr.Buffer.EffectiveDate = (DateTime)dr[idxEffectiveDate];
      if (dr[idxHours] != System.DBNull.Value) tStr.Buffer.Hours = (double)dr[idxHours];
      if (dr[idxId] != System.DBNull.Value) tStr.Buffer.Id = (int)dr[idxId];
      if (dr[idxModified] != System.DBNull.Value) tStr.Buffer.Modified = (DateTime)dr[idxModified];
      if (dr[idxModifiedBy] != System.DBNull.Value) tStr.Buffer.ModifiedBy = (string)dr[idxModifiedBy];
      if (dr[idxPersonREF] != System.DBNull.Value) tStr.Buffer.PersonREF = (int)dr[idxPersonREF];
      if (dr[idxStatusID] != System.DBNull.Value) tStr.Buffer.StatusID = (string)dr[idxStatusID];
      if (dr[idxTimestamp] != System.DBNull.Value) tStr.Buffer.Timestamp = (byte[])dr[idxTimestamp];
      return tStr;
    }

    public string BuildInsertSQL(DsRequestStatus xStr)
    {
      SQL.SqlCommandBuilder sc = new SQL.SqlCommandBuilder(
        SQL.sqlVerb.Insert, tableName);
      if (xStr.modChangeRequestREF)
        sc.AddColumn(sqlCols[idxChangeRequestREF], xStr.Buffer.ChangeRequestREF);
      if (xStr.modComment)
        sc.AddColumn(sqlCols[idxComment], xStr.Buffer.Comment);
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
      if (xStr.modStatusID)
        sc.AddColumn(sqlCols[idxStatusID], xStr.Buffer.StatusID);
      return sc.CommandText;
    }

    public string BuildUpdateSQL(DsRequestStatus xStr)
    {
      SQL.SqlCommandBuilder sc = new SQL.SqlCommandBuilder(SQL.sqlVerb.Update);
      if (xStr.modChangeRequestREF)
        sc.AddColumn(sqlCols[idxChangeRequestREF], xStr.Buffer.ChangeRequestREF);
      if (xStr.modComment)
        sc.AddColumn(sqlCols[idxComment], xStr.Buffer.Comment);
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
      if (xStr.modStatusID)
        sc.AddColumn(sqlCols[idxStatusID], xStr.Buffer.StatusID);
      return sc.ColumnList;
    }

    //  Index = IX_RequestStatus
    public bool GetBy_IX_RequestStatus(
      int ChangeRequestREF
    , string StatusID
    , out DdRequestStatus buffer)
  {
    string sql = "SELECT " + sqlColumns
    + " FROM " + tableName + NOLOCKSQL
    + " WHERE ChangeRequestREF = " + ChangeRequestREF.ToString()
    + " AND StatusID = " + TXT.q1(StatusID);
    System.Data.DataRow dr;
    if (GetSQL(sql, out dr))
    {
      DsRequestStatus dsRequestStatus = Load(dr);
      buffer = dsRequestStatus.Buffer;
      return true;
    }
    else
    {
      buffer = new DdRequestStatus();
      return false;
    }
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
		
		static public DdRequestStatus LoadRow(System.Data.SqlClient.SqlDataReader reader)
		{
			DdRequestStatus rowBuffer = new DdRequestStatus();
			rowBuffer.Clear();
			if (!reader.IsDBNull(idxChangeRequestREF)) rowBuffer.ChangeRequestREF = reader.GetInt32(idxChangeRequestREF);
			if (!reader.IsDBNull(idxComment)) rowBuffer.Comment = reader.GetString(idxComment);
			if (!reader.IsDBNull(idxCreated)) rowBuffer.Created = reader.GetDateTime(idxCreated);
			if (!reader.IsDBNull(idxEffectiveDate)) rowBuffer.EffectiveDate = reader.GetDateTime(idxEffectiveDate);
			if (!reader.IsDBNull(idxHours)) rowBuffer.Hours = reader.GetDouble(idxHours);
			if (!reader.IsDBNull(idxId)) rowBuffer.Id = reader.GetInt32(idxId);
			if (!reader.IsDBNull(idxModified)) rowBuffer.Modified = reader.GetDateTime(idxModified);
			if (!reader.IsDBNull(idxModifiedBy)) rowBuffer.ModifiedBy = reader.GetString(idxModifiedBy);
			if (!reader.IsDBNull(idxPersonREF)) rowBuffer.PersonREF = reader.GetInt32(idxPersonREF);
			if (!reader.IsDBNull(idxStatusID)) rowBuffer.StatusID = reader.GetString(idxStatusID);
			if (!reader.IsDBNull(idxTimestamp)) rowBuffer.Timestamp = GetTimestamp(idxTimestamp, reader);
			return rowBuffer;
		}
  }
  [Serializable]
  public class DsRequestStatus
  {
    public DdRequestStatus Buffer = new DdRequestStatus();

    public bool IsNew;
    public bool IsDeleted;

    public bool modChangeRequestREF;
    public bool modComment;
    public bool modEffectiveDate;
    public bool modHours;
    public bool modModified;
    public bool modModifiedBy;
    public bool modPersonREF;
    public bool modStatusID;

    public object Tag;
    public int RowsAffected;
    public string ResultCode;
    public string ResultMessage;

    public bool Modified()
    {
      return
        modChangeRequestREF
     || modComment
     || modEffectiveDate
     || modHours
     || modModified
     || modModifiedBy
     || modPersonREF
     || modStatusID;
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
      modChangeRequestREF = false;
      modComment = false;
      modEffectiveDate = false;
      modHours = false;
      modModified = false;
      modModifiedBy = false;
      modPersonREF = false;
      modStatusID = false;
    }

    public void SetModFlags()
    {
      modChangeRequestREF = true;
      modComment = true;
      modEffectiveDate = true;
      modHours = true;
      modModified = true;
      modModifiedBy = true;
      modPersonREF = true;
      modStatusID = true;
    }
  }

  [Serializable]
  public class DdRequestStatus : ASL.Forms.DdBase
  {
    public int ChangeRequestREF { get; set; }
    public string Comment { get; set; }
    public DateTime EffectiveDate { get; set; }
    public double Hours { get; set; }
    public int PersonREF { get; set; }
    public string StatusID { get; set; }

    public const string ChangeRequestREF_N = "ChangeRequestREF";
    public const string Comment_N = "Comment";
    public const string EffectiveDate_N = "EffectiveDate";
    public const string Hours_N = "Hours";
    public const string PersonREF_N = "PersonREF";
    public const string StatusID_N = "StatusID";

    public const int Comment_L = -1;
    public const int StatusID_L = 50;

    public DdRequestStatus()
	  : base()
    {
      Clear();
    }

    public DdRequestStatus(DdRequestStatus original)
	  : base(original)
    {
      ChangeRequestREF = original.ChangeRequestREF;
      Comment = original.Comment;
      EffectiveDate = original.EffectiveDate;
      Hours = original.Hours;
      PersonREF = original.PersonREF;
      StatusID = original.StatusID;
    }

    public override void Clear()
    {
      base.Clear();
      ChangeRequestREF = 0;
      Comment = "";
      EffectiveDate = DateTime.MinValue;
      Hours = 0;
      PersonREF = 0;
      StatusID = "";
    }

    public override void SetDefaults()
    {
      base.SetDefaults();
      ChangeRequestREF = (1);
      Comment = string.Empty;
      EffectiveDate = DateTime.Now;
      Hours = (0);
      PersonREF = (1);
      StatusID = string.Empty;
    }
  }

  [Serializable]
  public class DnRequestStatus : System.Collections.Generic.List<DdRequestStatus>
  {
    public DnRequestStatus() : base() {}
    public DnRequestStatus(int xCapacity) : base(xCapacity) {}

    public new DdRequestStatus this[int xIndex]
    {
      get { return (DdRequestStatus) base[xIndex]; }
      set { base[xIndex] = value; }
    }
  }


}
