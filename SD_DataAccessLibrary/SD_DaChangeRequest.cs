// Generated: Sun Jan 27, 2013 10:54:09
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
  public class DaChangeRequest : DbChangeRequest, ASL.ApplicatFieldType.IDaForm_I
#else
  public class DaChangeRequest : DbChangeRequest
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
      public string RequestID;
		}
		public class FetchEntry
		{
			public int hitCount = 1;
			public DdChangeRequest ddChangeRequest;
			public FetchEntry(DdChangeRequest ddChangeRequest) { this.ddChangeRequest = ddChangeRequest; }
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

    public int ApplicationREF
    {
      get { return store.Buffer.ApplicationREF; }

      set 
      { 
#if __REALCHANGE__
        if (store.Buffer.ApplicationREF != value)
        {
          store.Buffer.ApplicationREF = value; 
          store.modApplicationREF = true;
        }
#else
        store.Buffer.ApplicationREF = value; 
        store.modApplicationREF = true;
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
        if (value.Length > 50) InvalidateField("Too long", "ChangeRequest.ModifiedBy");
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
    public string RequestID
    {
      get { return store.Buffer.RequestID; }

      set 
      { 
        if (value.Length > 50) InvalidateField("Too long", "ChangeRequest.RequestID");
#if __REALCHANGE__
        if (store.Buffer.RequestID != value)
        {
          store.Buffer.RequestID = value; 
          store.modRequestID = true;
        }
#else
        store.Buffer.RequestID = value; 
        store.modRequestID = true;
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
      items["ApplicationREF"] = ApplicationREF;
      items["Comment"] = Comment;
      items["Created"] = Created;
      items["Id"] = Id;
      items["Modified"] = Modified;
      items["ModifiedBy"] = ModifiedBy;
      items["RequestID"] = RequestID;
      items["Title"] = Title;
      return items;
    }

    public void SetFromList(SortedList<string, object> items)
    {
      if (items.ContainsKey("ApplicationREF")) ApplicationREF= (int)items["ApplicationREF"];
      if (items.ContainsKey("Comment")) Comment= (string)items["Comment"];
      if (items.ContainsKey("Modified")) Modified= (DateTime)items["Modified"];
      if (items.ContainsKey("ModifiedBy")) ModifiedBy= (string)items["ModifiedBy"];
      if (items.ContainsKey("RequestID")) RequestID= (string)items["RequestID"];
      if (items.ContainsKey("Title")) Title= (string)items["Title"];
    }
#endif
//??EndExpand 1/27/2013 10:54:09 AM
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
			DnChangeRequest dnChangeRequest = FillByParent(parentREF);
			ArrayList choices = new ArrayList();
			IEnumerator en = dnChangeRequest.GetEnumerator();
			DdChangeRequest ddChangeRequest;
			while (en.MoveNext())
			{
				ddChangeRequest = (DdChangeRequest)en.Current;
				choices.Add(ddChangeRequest.Id.ToString() + "," + ddChangeRequest.Description);
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

    private DsChangeRequest store = new DsChangeRequest();

    public DaChangeRequest(SQL.DBConnection dbConnection) : base(dbConnection)
    {
      store.ClearAll();
    }

    public void Clear()
    {
      store.ClearAll();
    }

    public bool GetByPK(string RequestID)
    {
      store.Buffer.RequestID = RequestID;
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

    public void SetBuffer(DdChangeRequest buffer)
    {
      store.Buffer = buffer;
    }

    public bool _IsModified
    {
      get { return store.Modified(); }
    }

    public DdChangeRequest GetBuffer()
    {
      return store.Buffer; 
    }

    public void SetModFlags() { store.SetModFlags(); }
    public void ClearModFlags() { store.ClearModFlags(); }
    public void SetDefaults() { store.Buffer.SetDefaults(); }

    #region fetch cache
#if __FETCHCACHE__
		public bool FetchByPK(string RequestID)
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
      key.RequestID = RequestID;
			if (fetchTable.Contains(key))
			{
				_hitCount++;
				ent = (FetchEntry)fetchTable[key];
				SetBuffer(ent.ddChangeRequest);
				if (ent.hitCount < int.MaxValue) ent.hitCount++;
				return true;
			}
			if (missTable.Contains(key)) return false;
			
			_ioCount++;
      store.Buffer.RequestID = RequestID;
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
		public DnChangeRequest Fill()
		{
			string sqlWhere = "Id >= 100";
			return Fill(sqlWhere, "ChangeRequestID", 0, true);
		}
		public DnChangeRequest FillByApplication(int parentREF)
		{
			string sqlWhere = string.Format("ApplicationREF={0}", parentREF);
			return Fill(sqlWhere, "ChangeRequestID", 0, true);
		}
		#endregion extend
  }


  public class DbChangeRequest : ASL.SQL.TableDataObject
  {
    private const int idxApplicationREF = 0;
    private const int idxComment = 1;
    private const int idxCreated = 2;
    private const int idxId = 3;
    private const int idxModified = 4;
    private const int idxModifiedBy = 5;
    private const int idxRequestID = 6;
    private const int idxTimestamp = 7;
    private const int idxTitle = 8;
    private const int idxNUMCOLS = 9;
    // Column names
    static readonly protected string[] sqlCols =
    {
     "[ApplicationREF]", "[Comment]", "[Created]", "[Id]", "[Modified]"
     , "[ModifiedBy]", "[RequestID]", "[Timestamp]", "[Title]"
    };
    static public string SqlColumnList { get { return string.Join(",", sqlCols); } }
    static public string[] SqlCols { get { return sqlCols; } }

    // set database connection and other initial values
    public DbChangeRequest(SQL.DBConnection dbConnection)
    {
      base.dbConnection = dbConnection;
      tableName = "ChangeRequest";
      identityColumnName = "Id";
      sqlColumns = string.Join(",",  sqlCols);
    }

		public string TableName { get { return tableName; } set { tableName = value; } }

    public bool GetById(int Id, out DdChangeRequest buffer)
    {
      DsChangeRequest dsChangeRequest = new DsChangeRequest();
      dsChangeRequest.Buffer.Id = Id;
      if (!GetById(ref dsChangeRequest)) 
      {
        buffer = new DdChangeRequest();
        return false;
      }
      buffer = dsChangeRequest.Buffer;
      return true;
    }

    public bool GetById(ref DsChangeRequest xStr)
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
        string RequestID
      , out DdChangeRequest buffer)
    {
      DsChangeRequest dsChangeRequest = new DsChangeRequest();
      dsChangeRequest.Buffer.RequestID = RequestID;
      if (!GetByPK(ref dsChangeRequest))
      {
        buffer = new DdChangeRequest();
        return false;
      }
      buffer = dsChangeRequest.Buffer;
      return true;
    }

    public bool GetByPK(ref DsChangeRequest xStr)
    {
      string sql = "SELECT " + sqlColumns
      + " FROM " + tableName + NOLOCKSQL
      + " WHERE RequestID = " + TXT.q1(xStr.Buffer.RequestID);
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

    public bool UpdateById(ref DsChangeRequest xStr)
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

    public bool UpdateByPK(ref DsChangeRequest xStr)
    {
      int rowsUpdated = 0;
      if (xStr.Modified())
      {
        string sql = "UPDATE " + tableName + " SET " + BuildUpdateSQL(xStr) + " WHERE"
      + " RequestID = " + TXT.q1(xStr.Buffer.RequestID);
        if(!UpdateSQL(sql)) return false;
        rowsUpdated = _rowsAffected;
      }
      bool ok = GetByPK(ref xStr);
      _rowsAffected = rowsUpdated;
      return ok;
    }

    public bool DeleteByPK(
        string RequestID)
    {
      string sql = "DELETE FROM " + tableName + " WHERE"
      + " RequestID = " + TXT.q1(RequestID);
      return DeleteSQL(sql);
    }

    public bool DeleteByPK(ref DsChangeRequest xStr)
    {
      string sql = "DELETE FROM " + tableName + " WHERE"
      + " RequestID = " + TXT.q1(xStr.Buffer.RequestID);
      return DeleteSQL(sql);
    }
    public bool Insert(ref DsChangeRequest xStr)
    {
      int Id;
      string sql = BuildInsertSQL(xStr);
      if (!InsertIdSQL(sql, out Id)) return false;
      xStr.Buffer.Id = Id;
      return GetById(ref xStr);
    }

    public bool GetBySql(string sqlWhere, ref DsChangeRequest xStr)
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


    public DnChangeRequest Fill(string xWhere, string xOrder, int xTop, bool xNoLock)
    {
      System.Data.DataTable dt = FillDataTable(xWhere, xOrder, xTop, xNoLock);
      DnChangeRequest ChangeRequestList = new DnChangeRequest(dt.Rows.Count);
      foreach(System.Data.DataRow adr in dt.Rows)
      {
        ChangeRequestList.Add(Load(adr).Buffer);
      }
      return ChangeRequestList;
    }

    static public DsChangeRequest Load(System.Data.DataRow dr)
    {
      DsChangeRequest tStr = new DsChangeRequest();
      tStr.ClearBuffer();
      if (dr[idxApplicationREF] != System.DBNull.Value) tStr.Buffer.ApplicationREF = (int)dr[idxApplicationREF];
      if (dr[idxComment] != System.DBNull.Value) tStr.Buffer.Comment = (string)dr[idxComment];
      if (dr[idxCreated] != System.DBNull.Value) tStr.Buffer.Created = (DateTime)dr[idxCreated];
      if (dr[idxId] != System.DBNull.Value) tStr.Buffer.Id = (int)dr[idxId];
      if (dr[idxModified] != System.DBNull.Value) tStr.Buffer.Modified = (DateTime)dr[idxModified];
      if (dr[idxModifiedBy] != System.DBNull.Value) tStr.Buffer.ModifiedBy = (string)dr[idxModifiedBy];
      if (dr[idxRequestID] != System.DBNull.Value) tStr.Buffer.RequestID = (string)dr[idxRequestID];
      if (dr[idxTimestamp] != System.DBNull.Value) tStr.Buffer.Timestamp = (byte[])dr[idxTimestamp];
      if (dr[idxTitle] != System.DBNull.Value) tStr.Buffer.Title = (string)dr[idxTitle];
      return tStr;
    }

    public string BuildInsertSQL(DsChangeRequest xStr)
    {
      SQL.SqlCommandBuilder sc = new SQL.SqlCommandBuilder(
        SQL.sqlVerb.Insert, tableName);
      if (xStr.modApplicationREF)
        sc.AddColumn(sqlCols[idxApplicationREF], xStr.Buffer.ApplicationREF);
      if (xStr.modComment)
        sc.AddColumn(sqlCols[idxComment], xStr.Buffer.Comment);
      if (xStr.modModified)
        sc.AddColumn(sqlCols[idxModified], xStr.Buffer.Modified);
      if (xStr.modModifiedBy)
        sc.AddColumn(sqlCols[idxModifiedBy], xStr.Buffer.ModifiedBy);
      if (xStr.modRequestID)
        sc.AddColumn(sqlCols[idxRequestID], xStr.Buffer.RequestID);
      if (xStr.modTitle)
        sc.AddColumn(sqlCols[idxTitle], xStr.Buffer.Title);
      return sc.CommandText;
    }

    public string BuildUpdateSQL(DsChangeRequest xStr)
    {
      SQL.SqlCommandBuilder sc = new SQL.SqlCommandBuilder(SQL.sqlVerb.Update);
      if (xStr.modApplicationREF)
        sc.AddColumn(sqlCols[idxApplicationREF], xStr.Buffer.ApplicationREF);
      if (xStr.modComment)
        sc.AddColumn(sqlCols[idxComment], xStr.Buffer.Comment);
      if (xStr.modModified)
        sc.AddColumn(sqlCols[idxModified], xStr.Buffer.Modified);
      if (xStr.modModifiedBy)
        sc.AddColumn(sqlCols[idxModifiedBy], xStr.Buffer.ModifiedBy);
      if (xStr.modRequestID)
        sc.AddColumn(sqlCols[idxRequestID], xStr.Buffer.RequestID);
      if (xStr.modTitle)
        sc.AddColumn(sqlCols[idxTitle], xStr.Buffer.Title);
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
		
		static public DdChangeRequest LoadRow(System.Data.SqlClient.SqlDataReader reader)
		{
			DdChangeRequest rowBuffer = new DdChangeRequest();
			rowBuffer.Clear();
			if (!reader.IsDBNull(idxApplicationREF)) rowBuffer.ApplicationREF = reader.GetInt32(idxApplicationREF);
			if (!reader.IsDBNull(idxComment)) rowBuffer.Comment = reader.GetString(idxComment);
			if (!reader.IsDBNull(idxCreated)) rowBuffer.Created = reader.GetDateTime(idxCreated);
			if (!reader.IsDBNull(idxId)) rowBuffer.Id = reader.GetInt32(idxId);
			if (!reader.IsDBNull(idxModified)) rowBuffer.Modified = reader.GetDateTime(idxModified);
			if (!reader.IsDBNull(idxModifiedBy)) rowBuffer.ModifiedBy = reader.GetString(idxModifiedBy);
			if (!reader.IsDBNull(idxRequestID)) rowBuffer.RequestID = reader.GetString(idxRequestID);
			if (!reader.IsDBNull(idxTimestamp)) rowBuffer.Timestamp = GetTimestamp(idxTimestamp, reader);
			if (!reader.IsDBNull(idxTitle)) rowBuffer.Title = reader.GetString(idxTitle);
			return rowBuffer;
		}
  }
  [Serializable]
  public class DsChangeRequest
  {
    public DdChangeRequest Buffer = new DdChangeRequest();

    public bool IsNew;
    public bool IsDeleted;

    public bool modApplicationREF;
    public bool modComment;
    public bool modModified;
    public bool modModifiedBy;
    public bool modRequestID;
    public bool modTitle;

    public object Tag;
    public int RowsAffected;
    public string ResultCode;
    public string ResultMessage;

    public bool Modified()
    {
      return
        modApplicationREF
     || modComment
     || modModified
     || modModifiedBy
     || modRequestID
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
      modApplicationREF = false;
      modComment = false;
      modModified = false;
      modModifiedBy = false;
      modRequestID = false;
      modTitle = false;
    }

    public void SetModFlags()
    {
      modApplicationREF = true;
      modComment = true;
      modModified = true;
      modModifiedBy = true;
      modRequestID = true;
      modTitle = true;
    }
  }

  [Serializable]
  public class DdChangeRequest : ASL.Forms.DdBase
  {
    public int ApplicationREF { get; set; }
    public string Comment { get; set; }
    public string RequestID { get; set; }
    public string Title { get; set; }

    public const string ApplicationREF_N = "ApplicationREF";
    public const string Comment_N = "Comment";
    public const string RequestID_N = "RequestID";
    public const string Title_N = "Title";

    public const int Comment_L = -1;
    public const int RequestID_L = 50;
    public const int Title_L = -1;

    public DdChangeRequest()
	  : base()
    {
      Clear();
    }

    public DdChangeRequest(DdChangeRequest original)
	  : base(original)
    {
      ApplicationREF = original.ApplicationREF;
      Comment = original.Comment;
      RequestID = original.RequestID;
      Title = original.Title;
    }

    public override void Clear()
    {
      base.Clear();
      ApplicationREF = 0;
      Comment = "";
      RequestID = "";
      Title = "";
    }

    public override void SetDefaults()
    {
      base.SetDefaults();
      ApplicationREF = (1);
      Comment = string.Empty;
      RequestID = string.Empty;
      Title = string.Empty;
    }
  }

  [Serializable]
  public class DnChangeRequest : System.Collections.Generic.List<DdChangeRequest>
  {
    public DnChangeRequest() : base() {}
    public DnChangeRequest(int xCapacity) : base(xCapacity) {}

    public new DdChangeRequest this[int xIndex]
    {
      get { return (DdChangeRequest) base[xIndex]; }
      set { base[xIndex] = value; }
    }
  }


}
