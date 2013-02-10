// Generated: Sun Jan 27, 2013 10:54:05
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
  public class DaApplication : DbApplication, ASL.ApplicatFieldType.IDaForm_I
#else
  public class DaApplication : DbApplication
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
      public string ApplicationID;
		}
		public class FetchEntry
		{
			public int hitCount = 1;
			public DdApplication ddApplication;
			public FetchEntry(DdApplication ddApplication) { this.ddApplication = ddApplication; }
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

    public string ApplicationID
    {
      get { return store.Buffer.ApplicationID; }

      set 
      { 
        if (value.Length > 50) InvalidateField("Too long", "Application.ApplicationID");
#if __REALCHANGE__
        if (store.Buffer.ApplicationID != value)
        {
          store.Buffer.ApplicationID = value; 
          store.modApplicationID = true;
        }
#else
        store.Buffer.ApplicationID = value; 
        store.modApplicationID = true;
#endif
      }
    }
    public string ApplicationName
    {
      get { return store.Buffer.ApplicationName; }

      set 
      { 
#if __REALCHANGE__
        if (store.Buffer.ApplicationName != value)
        {
          store.Buffer.ApplicationName = value; 
          store.modApplicationName = true;
        }
#else
        store.Buffer.ApplicationName = value; 
        store.modApplicationName = true;
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
        if (value.Length > 50) InvalidateField("Too long", "Application.ModifiedBy");
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
    public byte[] Timestamp
    {
      get { return store.Buffer.Timestamp; }

    }

#if __FIELDLIST__
    public SortedList<string, object> GetAsList()
    {
      SortedList<string, object> items = new SortedList<string, object>();
      items["ApplicationID"] = ApplicationID;
      items["ApplicationName"] = ApplicationName;
      items["Comment"] = Comment;
      items["Created"] = Created;
      items["Id"] = Id;
      items["Modified"] = Modified;
      items["ModifiedBy"] = ModifiedBy;
      return items;
    }

    public void SetFromList(SortedList<string, object> items)
    {
      if (items.ContainsKey("ApplicationID")) ApplicationID= (string)items["ApplicationID"];
      if (items.ContainsKey("ApplicationName")) ApplicationName= (string)items["ApplicationName"];
      if (items.ContainsKey("Comment")) Comment= (string)items["Comment"];
      if (items.ContainsKey("Modified")) Modified= (DateTime)items["Modified"];
      if (items.ContainsKey("ModifiedBy")) ModifiedBy= (string)items["ModifiedBy"];
    }
#endif
//??EndExpand 1/27/2013 10:54:06 AM
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
			DnApplication dnApplication = FillByParent(parentREF);
			ArrayList choices = new ArrayList();
			IEnumerator en = dnApplication.GetEnumerator();
			DdApplication ddApplication;
			while (en.MoveNext())
			{
				ddApplication = (DdApplication)en.Current;
				choices.Add(ddApplication.Id.ToString() + "," + ddApplication.Description);
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

    private DsApplication store = new DsApplication();

    public DaApplication(SQL.DBConnection dbConnection) : base(dbConnection)
    {
      store.ClearAll();
    }

    public void Clear()
    {
      store.ClearAll();
    }

    public bool GetByPK(string ApplicationID)
    {
      store.Buffer.ApplicationID = ApplicationID;
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

    public void SetBuffer(DdApplication buffer)
    {
      store.Buffer = buffer;
    }

    public bool _IsModified
    {
      get { return store.Modified(); }
    }

    public DdApplication GetBuffer()
    {
      return store.Buffer; 
    }

    public void SetModFlags() { store.SetModFlags(); }
    public void ClearModFlags() { store.ClearModFlags(); }
    public void SetDefaults() { store.Buffer.SetDefaults(); }

    #region fetch cache
#if __FETCHCACHE__
		public bool FetchByPK(string ApplicationID)
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
      key.ApplicationID = ApplicationID;
			if (fetchTable.Contains(key))
			{
				_hitCount++;
				ent = (FetchEntry)fetchTable[key];
				SetBuffer(ent.ddApplication);
				if (ent.hitCount < int.MaxValue) ent.hitCount++;
				return true;
			}
			if (missTable.Contains(key)) return false;
			
			_ioCount++;
      store.Buffer.ApplicationID = ApplicationID;
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
		public DnApplication Fill()
		{
			string sqlWhere = "Id >= 100";
			return Fill(sqlWhere, "ApplicationID", 0, true);
		}
		#endregion extend
  }


  public class DbApplication : ASL.SQL.TableDataObject
  {
    private const int idxApplicationID = 0;
    private const int idxApplicationName = 1;
    private const int idxComment = 2;
    private const int idxCreated = 3;
    private const int idxId = 4;
    private const int idxModified = 5;
    private const int idxModifiedBy = 6;
    private const int idxTimestamp = 7;
    private const int idxNUMCOLS = 8;
    // Column names
    static readonly protected string[] sqlCols =
    {
     "[ApplicationID]", "[ApplicationName]", "[Comment]", "[Created]", "[Id]"
     , "[Modified]", "[ModifiedBy]", "[Timestamp]"
    };
    static public string SqlColumnList { get { return string.Join(",", sqlCols); } }
    static public string[] SqlCols { get { return sqlCols; } }

    // set database connection and other initial values
    public DbApplication(SQL.DBConnection dbConnection)
    {
      base.dbConnection = dbConnection;
      tableName = "Application";
      identityColumnName = "Id";
      sqlColumns = string.Join(",",  sqlCols);
    }

		public string TableName { get { return tableName; } set { tableName = value; } }

    public bool GetById(int Id, out DdApplication buffer)
    {
      DsApplication dsApplication = new DsApplication();
      dsApplication.Buffer.Id = Id;
      if (!GetById(ref dsApplication)) 
      {
        buffer = new DdApplication();
        return false;
      }
      buffer = dsApplication.Buffer;
      return true;
    }

    public bool GetById(ref DsApplication xStr)
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
        string ApplicationID
      , out DdApplication buffer)
    {
      DsApplication dsApplication = new DsApplication();
      dsApplication.Buffer.ApplicationID = ApplicationID;
      if (!GetByPK(ref dsApplication))
      {
        buffer = new DdApplication();
        return false;
      }
      buffer = dsApplication.Buffer;
      return true;
    }

    public bool GetByPK(ref DsApplication xStr)
    {
      string sql = "SELECT " + sqlColumns
      + " FROM " + tableName + NOLOCKSQL
      + " WHERE ApplicationID = " + TXT.q1(xStr.Buffer.ApplicationID);
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

    public bool UpdateById(ref DsApplication xStr)
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

    public bool UpdateByPK(ref DsApplication xStr)
    {
      int rowsUpdated = 0;
      if (xStr.Modified())
      {
        string sql = "UPDATE " + tableName + " SET " + BuildUpdateSQL(xStr) + " WHERE"
      + " ApplicationID = " + TXT.q1(xStr.Buffer.ApplicationID);
        if(!UpdateSQL(sql)) return false;
        rowsUpdated = _rowsAffected;
      }
      bool ok = GetByPK(ref xStr);
      _rowsAffected = rowsUpdated;
      return ok;
    }

    public bool DeleteByPK(
        string ApplicationID)
    {
      string sql = "DELETE FROM " + tableName + " WHERE"
      + " ApplicationID = " + TXT.q1(ApplicationID);
      return DeleteSQL(sql);
    }

    public bool DeleteByPK(ref DsApplication xStr)
    {
      string sql = "DELETE FROM " + tableName + " WHERE"
      + " ApplicationID = " + TXT.q1(xStr.Buffer.ApplicationID);
      return DeleteSQL(sql);
    }
    public bool Insert(ref DsApplication xStr)
    {
      int Id;
      string sql = BuildInsertSQL(xStr);
      if (!InsertIdSQL(sql, out Id)) return false;
      xStr.Buffer.Id = Id;
      return GetById(ref xStr);
    }

    public bool GetBySql(string sqlWhere, ref DsApplication xStr)
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


    public DnApplication Fill(string xWhere, string xOrder, int xTop, bool xNoLock)
    {
      System.Data.DataTable dt = FillDataTable(xWhere, xOrder, xTop, xNoLock);
      DnApplication ApplicationList = new DnApplication(dt.Rows.Count);
      foreach(System.Data.DataRow adr in dt.Rows)
      {
        ApplicationList.Add(Load(adr).Buffer);
      }
      return ApplicationList;
    }

    static public DsApplication Load(System.Data.DataRow dr)
    {
      DsApplication tStr = new DsApplication();
      tStr.ClearBuffer();
      if (dr[idxApplicationID] != System.DBNull.Value) tStr.Buffer.ApplicationID = (string)dr[idxApplicationID];
      if (dr[idxApplicationName] != System.DBNull.Value) tStr.Buffer.ApplicationName = (string)dr[idxApplicationName];
      if (dr[idxComment] != System.DBNull.Value) tStr.Buffer.Comment = (string)dr[idxComment];
      if (dr[idxCreated] != System.DBNull.Value) tStr.Buffer.Created = (DateTime)dr[idxCreated];
      if (dr[idxId] != System.DBNull.Value) tStr.Buffer.Id = (int)dr[idxId];
      if (dr[idxModified] != System.DBNull.Value) tStr.Buffer.Modified = (DateTime)dr[idxModified];
      if (dr[idxModifiedBy] != System.DBNull.Value) tStr.Buffer.ModifiedBy = (string)dr[idxModifiedBy];
      if (dr[idxTimestamp] != System.DBNull.Value) tStr.Buffer.Timestamp = (byte[])dr[idxTimestamp];
      return tStr;
    }

    public string BuildInsertSQL(DsApplication xStr)
    {
      SQL.SqlCommandBuilder sc = new SQL.SqlCommandBuilder(
        SQL.sqlVerb.Insert, tableName);
      if (xStr.modApplicationID)
        sc.AddColumn(sqlCols[idxApplicationID], xStr.Buffer.ApplicationID);
      if (xStr.modApplicationName)
        sc.AddColumn(sqlCols[idxApplicationName], xStr.Buffer.ApplicationName);
      if (xStr.modComment)
        sc.AddColumn(sqlCols[idxComment], xStr.Buffer.Comment);
      if (xStr.modModified)
        sc.AddColumn(sqlCols[idxModified], xStr.Buffer.Modified);
      if (xStr.modModifiedBy)
        sc.AddColumn(sqlCols[idxModifiedBy], xStr.Buffer.ModifiedBy);
      return sc.CommandText;
    }

    public string BuildUpdateSQL(DsApplication xStr)
    {
      SQL.SqlCommandBuilder sc = new SQL.SqlCommandBuilder(SQL.sqlVerb.Update);
      if (xStr.modApplicationID)
        sc.AddColumn(sqlCols[idxApplicationID], xStr.Buffer.ApplicationID);
      if (xStr.modApplicationName)
        sc.AddColumn(sqlCols[idxApplicationName], xStr.Buffer.ApplicationName);
      if (xStr.modComment)
        sc.AddColumn(sqlCols[idxComment], xStr.Buffer.Comment);
      if (xStr.modModified)
        sc.AddColumn(sqlCols[idxModified], xStr.Buffer.Modified);
      if (xStr.modModifiedBy)
        sc.AddColumn(sqlCols[idxModifiedBy], xStr.Buffer.ModifiedBy);
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
		
		static public DdApplication LoadRow(System.Data.SqlClient.SqlDataReader reader)
		{
			DdApplication rowBuffer = new DdApplication();
			rowBuffer.Clear();
			if (!reader.IsDBNull(idxApplicationID)) rowBuffer.ApplicationID = reader.GetString(idxApplicationID);
			if (!reader.IsDBNull(idxApplicationName)) rowBuffer.ApplicationName = reader.GetString(idxApplicationName);
			if (!reader.IsDBNull(idxComment)) rowBuffer.Comment = reader.GetString(idxComment);
			if (!reader.IsDBNull(idxCreated)) rowBuffer.Created = reader.GetDateTime(idxCreated);
			if (!reader.IsDBNull(idxId)) rowBuffer.Id = reader.GetInt32(idxId);
			if (!reader.IsDBNull(idxModified)) rowBuffer.Modified = reader.GetDateTime(idxModified);
			if (!reader.IsDBNull(idxModifiedBy)) rowBuffer.ModifiedBy = reader.GetString(idxModifiedBy);
			if (!reader.IsDBNull(idxTimestamp)) rowBuffer.Timestamp = GetTimestamp(idxTimestamp, reader);
			return rowBuffer;
		}
  }
  [Serializable]
  public class DsApplication
  {
    public DdApplication Buffer = new DdApplication();

    public bool IsNew;
    public bool IsDeleted;

    public bool modApplicationID;
    public bool modApplicationName;
    public bool modComment;
    public bool modModified;
    public bool modModifiedBy;

    public object Tag;
    public int RowsAffected;
    public string ResultCode;
    public string ResultMessage;

    public bool Modified()
    {
      return
        modApplicationID
     || modApplicationName
     || modComment
     || modModified
     || modModifiedBy;
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
      modApplicationID = false;
      modApplicationName = false;
      modComment = false;
      modModified = false;
      modModifiedBy = false;
    }

    public void SetModFlags()
    {
      modApplicationID = true;
      modApplicationName = true;
      modComment = true;
      modModified = true;
      modModifiedBy = true;
    }
  }

  [Serializable]
  public class DdApplication : ASL.Forms.DdBase
  {
    public string ApplicationID { get; set; }
    public string ApplicationName { get; set; }
    public string Comment { get; set; }

    public const string ApplicationID_N = "ApplicationID";
    public const string ApplicationName_N = "ApplicationName";
    public const string Comment_N = "Comment";

    public const int ApplicationID_L = 50;
    public const int ApplicationName_L = -1;
    public const int Comment_L = -1;

    public DdApplication()
	  : base()
    {
      Clear();
    }

    public DdApplication(DdApplication original)
	  : base(original)
    {
      ApplicationID = original.ApplicationID;
      ApplicationName = original.ApplicationName;
      Comment = original.Comment;
    }

    public override void Clear()
    {
      base.Clear();
      ApplicationID = "";
      ApplicationName = "";
      Comment = "";
    }

    public override void SetDefaults()
    {
      base.SetDefaults();
      ApplicationID = string.Empty;
      ApplicationName = string.Empty;
      Comment = string.Empty;
    }
  }

  [Serializable]
  public class DnApplication : System.Collections.Generic.List<DdApplication>
  {
    public DnApplication() : base() {}
    public DnApplication(int xCapacity) : base(xCapacity) {}

    public new DdApplication this[int xIndex]
    {
      get { return (DdApplication) base[xIndex]; }
      set { base[xIndex] = value; }
    }
  }


}
