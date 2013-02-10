// Generated: Sun Jan 27, 2013 10:54:24
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
  public class DaTaskChargeCode : DbTaskChargeCode, ASL.ApplicatFieldType.IDaForm_I
#else
  public class DaTaskChargeCode : DbTaskChargeCode
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
      public string TaskChargeCodeID;
      public int TaskHeadingRoleREF;
		}
		public class FetchEntry
		{
			public int hitCount = 1;
			public DdTaskChargeCode ddTaskChargeCode;
			public FetchEntry(DdTaskChargeCode ddTaskChargeCode) { this.ddTaskChargeCode = ddTaskChargeCode; }
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
        if (value.Length > 50) InvalidateField("Too long", "TaskChargeCode.ModifiedBy");
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
    public string TaskChargeCodeID
    {
      get { return store.Buffer.TaskChargeCodeID; }

      set 
      { 
        if (value.Length > 200) InvalidateField("Too long", "TaskChargeCode.TaskChargeCodeID");
#if __REALCHANGE__
        if (store.Buffer.TaskChargeCodeID != value)
        {
          store.Buffer.TaskChargeCodeID = value; 
          store.modTaskChargeCodeID = true;
        }
#else
        store.Buffer.TaskChargeCodeID = value; 
        store.modTaskChargeCodeID = true;
#endif
      }
    }
    public int TaskHeadingRoleREF
    {
      get { return store.Buffer.TaskHeadingRoleREF; }

      set 
      { 
#if __REALCHANGE__
        if (store.Buffer.TaskHeadingRoleREF != value)
        {
          store.Buffer.TaskHeadingRoleREF = value; 
          store.modTaskHeadingRoleREF = true;
        }
#else
        store.Buffer.TaskHeadingRoleREF = value; 
        store.modTaskHeadingRoleREF = true;
#endif
      }
    }
    public byte[] Timestamp
    {
      get { return store.Buffer.Timestamp; }

    }
    public string Title
    {
      get { return store.Buffer.Title; }

      set 
      { 
        if (value.Length > 200) InvalidateField("Too long", "TaskChargeCode.Title");
#if __REALCHANGE__
        if (store.Buffer.Title != value)
        {
          store.Buffer.Title = value; 
          store.modTitle = true;
        }
#else
        store.Buffer.Title = value; 
        store.modTitle = true;
#endif
      }
    }

#if __FIELDLIST__
    public SortedList<string, object> GetAsList()
    {
      SortedList<string, object> items = new SortedList<string, object>();
      items["Created"] = Created;
      items["Description"] = Description;
      items["Id"] = Id;
      items["Modified"] = Modified;
      items["ModifiedBy"] = ModifiedBy;
      items["TaskChargeCodeID"] = TaskChargeCodeID;
      items["TaskHeadingRoleREF"] = TaskHeadingRoleREF;
      items["Title"] = Title;
      return items;
    }

    public void SetFromList(SortedList<string, object> items)
    {
      if (items.ContainsKey("Description")) Description= (string)items["Description"];
      if (items.ContainsKey("Modified")) Modified= (DateTime)items["Modified"];
      if (items.ContainsKey("ModifiedBy")) ModifiedBy= (string)items["ModifiedBy"];
      if (items.ContainsKey("TaskChargeCodeID")) TaskChargeCodeID= (string)items["TaskChargeCodeID"];
      if (items.ContainsKey("TaskHeadingRoleREF")) TaskHeadingRoleREF= (int)items["TaskHeadingRoleREF"];
      if (items.ContainsKey("Title")) Title= (string)items["Title"];
    }
#endif
//??EndExpand 1/27/2013 10:54:24 AM
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
			DnTaskChargeCode dnTaskChargeCode = FillByParent(parentREF);
			ArrayList choices = new ArrayList();
			IEnumerator en = dnTaskChargeCode.GetEnumerator();
			DdTaskChargeCode ddTaskChargeCode;
			while (en.MoveNext())
			{
				ddTaskChargeCode = (DdTaskChargeCode)en.Current;
				choices.Add(ddTaskChargeCode.Id.ToString() + "," + ddTaskChargeCode.Description);
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

    private DsTaskChargeCode store = new DsTaskChargeCode();

    public DaTaskChargeCode(SQL.DBConnection dbConnection) : base(dbConnection)
    {
      store.ClearAll();
    }

    public void Clear()
    {
      store.ClearAll();
    }

    public bool GetByPK(string TaskChargeCodeID, int TaskHeadingRoleREF)
    {
      store.Buffer.TaskChargeCodeID = TaskChargeCodeID;
      store.Buffer.TaskHeadingRoleREF = TaskHeadingRoleREF;
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

    public void SetBuffer(DdTaskChargeCode buffer)
    {
      store.Buffer = buffer;
    }

    public bool _IsModified
    {
      get { return store.Modified(); }
    }

    public DdTaskChargeCode GetBuffer()
    {
      return store.Buffer; 
    }

    public void SetModFlags() { store.SetModFlags(); }
    public void ClearModFlags() { store.ClearModFlags(); }
    public void SetDefaults() { store.Buffer.SetDefaults(); }

    #region fetch cache
#if __FETCHCACHE__
		public bool FetchByPK(string TaskChargeCodeID, int TaskHeadingRoleREF)
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
      key.TaskChargeCodeID = TaskChargeCodeID;
      key.TaskHeadingRoleREF = TaskHeadingRoleREF;
			if (fetchTable.Contains(key))
			{
				_hitCount++;
				ent = (FetchEntry)fetchTable[key];
				SetBuffer(ent.ddTaskChargeCode);
				if (ent.hitCount < int.MaxValue) ent.hitCount++;
				return true;
			}
			if (missTable.Contains(key)) return false;
			
			_ioCount++;
      store.Buffer.TaskChargeCodeID = TaskChargeCodeID;
      store.Buffer.TaskHeadingRoleREF = TaskHeadingRoleREF;
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
		public DnTaskChargeCode Fill()
		{
			string sqlWhere = "Id >= 100";
			return Fill(sqlWhere, "Id", 0, true);
		}
		public DnTaskChargeCode FillByTaskHeadingRole(int parentREF)
		{
			string sqlWhere = string.Format("TaskHeadingRoleREF={0}", parentREF);
			return Fill(sqlWhere, "Id", 0, true);
		}
		#endregion extend
  }


  public class DbTaskChargeCode : ASL.SQL.TableDataObject
  {
    private const int idxCreated = 0;
    private const int idxDescription = 1;
    private const int idxId = 2;
    private const int idxModified = 3;
    private const int idxModifiedBy = 4;
    private const int idxTaskChargeCodeID = 5;
    private const int idxTaskHeadingRoleREF = 6;
    private const int idxTimestamp = 7;
    private const int idxTitle = 8;
    private const int idxNUMCOLS = 9;
    // Column names
    static readonly protected string[] sqlCols =
    {
     "[Created]", "[Description]", "[Id]", "[Modified]", "[ModifiedBy]"
     , "[TaskChargeCodeID]", "[TaskHeadingRoleREF]", "[Timestamp]", "[Title]"
    };
    static public string SqlColumnList { get { return string.Join(",", sqlCols); } }
    static public string[] SqlCols { get { return sqlCols; } }

    // set database connection and other initial values
    public DbTaskChargeCode(SQL.DBConnection dbConnection)
    {
      base.dbConnection = dbConnection;
      tableName = "TaskChargeCode";
      identityColumnName = "Id";
      sqlColumns = string.Join(",",  sqlCols);
    }

		public string TableName { get { return tableName; } set { tableName = value; } }

    public bool GetById(int Id, out DdTaskChargeCode buffer)
    {
      DsTaskChargeCode dsTaskChargeCode = new DsTaskChargeCode();
      dsTaskChargeCode.Buffer.Id = Id;
      if (!GetById(ref dsTaskChargeCode)) 
      {
        buffer = new DdTaskChargeCode();
        return false;
      }
      buffer = dsTaskChargeCode.Buffer;
      return true;
    }

    public bool GetById(ref DsTaskChargeCode xStr)
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
        string TaskChargeCodeID
      , int TaskHeadingRoleREF
      , out DdTaskChargeCode buffer)
    {
      DsTaskChargeCode dsTaskChargeCode = new DsTaskChargeCode();
      dsTaskChargeCode.Buffer.TaskChargeCodeID = TaskChargeCodeID;
      dsTaskChargeCode.Buffer.TaskHeadingRoleREF = TaskHeadingRoleREF;
      if (!GetByPK(ref dsTaskChargeCode))
      {
        buffer = new DdTaskChargeCode();
        return false;
      }
      buffer = dsTaskChargeCode.Buffer;
      return true;
    }

    public bool GetByPK(ref DsTaskChargeCode xStr)
    {
      string sql = "SELECT " + sqlColumns
      + " FROM " + tableName + NOLOCKSQL
      + " WHERE TaskChargeCodeID = " + TXT.q1(xStr.Buffer.TaskChargeCodeID)
      + " AND TaskHeadingRoleREF = " + xStr.Buffer.TaskHeadingRoleREF.ToString();
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

    public bool UpdateById(ref DsTaskChargeCode xStr)
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

    public bool UpdateByPK(ref DsTaskChargeCode xStr)
    {
      int rowsUpdated = 0;
      if (xStr.Modified())
      {
        string sql = "UPDATE " + tableName + " SET " + BuildUpdateSQL(xStr) + " WHERE"
      + " TaskChargeCodeID = " + TXT.q1(xStr.Buffer.TaskChargeCodeID)
      + " AND TaskHeadingRoleREF = " + xStr.Buffer.TaskHeadingRoleREF.ToString();
        if(!UpdateSQL(sql)) return false;
        rowsUpdated = _rowsAffected;
      }
      bool ok = GetByPK(ref xStr);
      _rowsAffected = rowsUpdated;
      return ok;
    }

    public bool DeleteByPK(
        string TaskChargeCodeID
      , int TaskHeadingRoleREF)
    {
      string sql = "DELETE FROM " + tableName + " WHERE"
      + " TaskChargeCodeID = " + TXT.q1(TaskChargeCodeID)
      + " AND TaskHeadingRoleREF = " + TaskHeadingRoleREF.ToString();
      return DeleteSQL(sql);
    }

    public bool DeleteByPK(ref DsTaskChargeCode xStr)
    {
      string sql = "DELETE FROM " + tableName + " WHERE"
      + " TaskChargeCodeID = " + TXT.q1(xStr.Buffer.TaskChargeCodeID)
      + " AND TaskHeadingRoleREF = " + xStr.Buffer.TaskHeadingRoleREF.ToString();
      return DeleteSQL(sql);
    }
    public bool Insert(ref DsTaskChargeCode xStr)
    {
      int Id;
      string sql = BuildInsertSQL(xStr);
      if (!InsertIdSQL(sql, out Id)) return false;
      xStr.Buffer.Id = Id;
      return GetById(ref xStr);
    }

    public bool GetBySql(string sqlWhere, ref DsTaskChargeCode xStr)
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


    public DnTaskChargeCode Fill(string xWhere, string xOrder, int xTop, bool xNoLock)
    {
      System.Data.DataTable dt = FillDataTable(xWhere, xOrder, xTop, xNoLock);
      DnTaskChargeCode TaskChargeCodeList = new DnTaskChargeCode(dt.Rows.Count);
      foreach(System.Data.DataRow adr in dt.Rows)
      {
        TaskChargeCodeList.Add(Load(adr).Buffer);
      }
      return TaskChargeCodeList;
    }

    static public DsTaskChargeCode Load(System.Data.DataRow dr)
    {
      DsTaskChargeCode tStr = new DsTaskChargeCode();
      tStr.ClearBuffer();
      if (dr[idxCreated] != System.DBNull.Value) tStr.Buffer.Created = (DateTime)dr[idxCreated];
      if (dr[idxDescription] != System.DBNull.Value) tStr.Buffer.Description = (string)dr[idxDescription];
      if (dr[idxId] != System.DBNull.Value) tStr.Buffer.Id = (int)dr[idxId];
      if (dr[idxModified] != System.DBNull.Value) tStr.Buffer.Modified = (DateTime)dr[idxModified];
      if (dr[idxModifiedBy] != System.DBNull.Value) tStr.Buffer.ModifiedBy = (string)dr[idxModifiedBy];
      if (dr[idxTaskChargeCodeID] != System.DBNull.Value) tStr.Buffer.TaskChargeCodeID = (string)dr[idxTaskChargeCodeID];
      if (dr[idxTaskHeadingRoleREF] != System.DBNull.Value) tStr.Buffer.TaskHeadingRoleREF = (int)dr[idxTaskHeadingRoleREF];
      if (dr[idxTimestamp] != System.DBNull.Value) tStr.Buffer.Timestamp = (byte[])dr[idxTimestamp];
      if (dr[idxTitle] != System.DBNull.Value) tStr.Buffer.Title = (string)dr[idxTitle];
      return tStr;
    }

    public string BuildInsertSQL(DsTaskChargeCode xStr)
    {
      SQL.SqlCommandBuilder sc = new SQL.SqlCommandBuilder(
        SQL.sqlVerb.Insert, tableName);
      if (xStr.modDescription)
        sc.AddColumn(sqlCols[idxDescription], xStr.Buffer.Description);
      if (xStr.modModified)
        sc.AddColumn(sqlCols[idxModified], xStr.Buffer.Modified);
      if (xStr.modModifiedBy)
        sc.AddColumn(sqlCols[idxModifiedBy], xStr.Buffer.ModifiedBy);
      if (xStr.modTaskChargeCodeID)
        sc.AddColumn(sqlCols[idxTaskChargeCodeID], xStr.Buffer.TaskChargeCodeID);
      if (xStr.modTaskHeadingRoleREF)
        sc.AddColumn(sqlCols[idxTaskHeadingRoleREF], xStr.Buffer.TaskHeadingRoleREF);
      if (xStr.modTitle)
        sc.AddColumn(sqlCols[idxTitle], xStr.Buffer.Title);
      return sc.CommandText;
    }

    public string BuildUpdateSQL(DsTaskChargeCode xStr)
    {
      SQL.SqlCommandBuilder sc = new SQL.SqlCommandBuilder(SQL.sqlVerb.Update);
      if (xStr.modDescription)
        sc.AddColumn(sqlCols[idxDescription], xStr.Buffer.Description);
      if (xStr.modModified)
        sc.AddColumn(sqlCols[idxModified], xStr.Buffer.Modified);
      if (xStr.modModifiedBy)
        sc.AddColumn(sqlCols[idxModifiedBy], xStr.Buffer.ModifiedBy);
      if (xStr.modTaskChargeCodeID)
        sc.AddColumn(sqlCols[idxTaskChargeCodeID], xStr.Buffer.TaskChargeCodeID);
      if (xStr.modTaskHeadingRoleREF)
        sc.AddColumn(sqlCols[idxTaskHeadingRoleREF], xStr.Buffer.TaskHeadingRoleREF);
      if (xStr.modTitle)
        sc.AddColumn(sqlCols[idxTitle], xStr.Buffer.Title);
      return sc.ColumnList;
    }

    //  Index = IX_TaskChargeCode
    public bool GetBy_IX_TaskChargeCode(
      string TaskChargeCodeID
    , int TaskHeadingRoleREF
    , out DdTaskChargeCode buffer)
  {
    string sql = "SELECT " + sqlColumns
    + " FROM " + tableName + NOLOCKSQL
    + " WHERE TaskChargeCodeID = " + TXT.q1(TaskChargeCodeID)
    + " AND TaskHeadingRoleREF = " + TaskHeadingRoleREF.ToString();
    System.Data.DataRow dr;
    if (GetSQL(sql, out dr))
    {
      DsTaskChargeCode dsTaskChargeCode = Load(dr);
      buffer = dsTaskChargeCode.Buffer;
      return true;
    }
    else
    {
      buffer = new DdTaskChargeCode();
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
		
		static public DdTaskChargeCode LoadRow(System.Data.SqlClient.SqlDataReader reader)
		{
			DdTaskChargeCode rowBuffer = new DdTaskChargeCode();
			rowBuffer.Clear();
			if (!reader.IsDBNull(idxCreated)) rowBuffer.Created = reader.GetDateTime(idxCreated);
			if (!reader.IsDBNull(idxDescription)) rowBuffer.Description = reader.GetString(idxDescription);
			if (!reader.IsDBNull(idxId)) rowBuffer.Id = reader.GetInt32(idxId);
			if (!reader.IsDBNull(idxModified)) rowBuffer.Modified = reader.GetDateTime(idxModified);
			if (!reader.IsDBNull(idxModifiedBy)) rowBuffer.ModifiedBy = reader.GetString(idxModifiedBy);
			if (!reader.IsDBNull(idxTaskChargeCodeID)) rowBuffer.TaskChargeCodeID = reader.GetString(idxTaskChargeCodeID);
			if (!reader.IsDBNull(idxTaskHeadingRoleREF)) rowBuffer.TaskHeadingRoleREF = reader.GetInt32(idxTaskHeadingRoleREF);
			if (!reader.IsDBNull(idxTimestamp)) rowBuffer.Timestamp = GetTimestamp(idxTimestamp, reader);
			if (!reader.IsDBNull(idxTitle)) rowBuffer.Title = reader.GetString(idxTitle);
			return rowBuffer;
		}
  }
  [Serializable]
  public class DsTaskChargeCode
  {
    public DdTaskChargeCode Buffer = new DdTaskChargeCode();

    public bool IsNew;
    public bool IsDeleted;

    public bool modDescription;
    public bool modModified;
    public bool modModifiedBy;
    public bool modTaskChargeCodeID;
    public bool modTaskHeadingRoleREF;
    public bool modTitle;

    public object Tag;
    public int RowsAffected;
    public string ResultCode;
    public string ResultMessage;

    public bool Modified()
    {
      return
        modDescription
     || modModified
     || modModifiedBy
     || modTaskChargeCodeID
     || modTaskHeadingRoleREF
     || modTitle;
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
      modDescription = false;
      modModified = false;
      modModifiedBy = false;
      modTaskChargeCodeID = false;
      modTaskHeadingRoleREF = false;
      modTitle = false;
    }

    public void SetModFlags()
    {
      modDescription = true;
      modModified = true;
      modModifiedBy = true;
      modTaskChargeCodeID = true;
      modTaskHeadingRoleREF = true;
      modTitle = true;
    }
  }

  [Serializable]
  public class DdTaskChargeCode : ASL.Forms.DdBase
  {
    public string Description { get; set; }
    public string TaskChargeCodeID { get; set; }
    public int TaskHeadingRoleREF { get; set; }
    public string Title { get; set; }

    public const string Description_N = "Description";
    public const string TaskChargeCodeID_N = "TaskChargeCodeID";
    public const string TaskHeadingRoleREF_N = "TaskHeadingRoleREF";
    public const string Title_N = "Title";

    public const int Description_L = -1;
    public const int TaskChargeCodeID_L = 200;
    public const int Title_L = 200;

    public DdTaskChargeCode()
	  : base()
    {
      Clear();
    }

    public DdTaskChargeCode(DdTaskChargeCode original)
	  : base(original)
    {
      Description = original.Description;
      TaskChargeCodeID = original.TaskChargeCodeID;
      TaskHeadingRoleREF = original.TaskHeadingRoleREF;
      Title = original.Title;
    }

    public override void Clear()
    {
      base.Clear();
      Description = "";
      TaskChargeCodeID = "";
      TaskHeadingRoleREF = 0;
      Title = "";
    }

    public override void SetDefaults()
    {
      base.SetDefaults();
      Description = string.Empty;
      TaskChargeCodeID = string.Empty;
      TaskHeadingRoleREF = (1);
      Title = string.Empty;
    }
  }

  [Serializable]
  public class DnTaskChargeCode : System.Collections.Generic.List<DdTaskChargeCode>
  {
    public DnTaskChargeCode() : base() {}
    public DnTaskChargeCode(int xCapacity) : base(xCapacity) {}

    public new DdTaskChargeCode this[int xIndex]
    {
      get { return (DdTaskChargeCode) base[xIndex]; }
      set { base[xIndex] = value; }
    }
  }


}
