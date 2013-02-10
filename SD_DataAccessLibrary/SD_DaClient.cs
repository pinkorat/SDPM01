// Generated: Sun Jan 27, 2013 10:54:11
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
  public class DaClient : DbClient, ASL.ApplicatFieldType.IDaForm_I
#else
  public class DaClient : DbClient
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
      public string ClientID;
		}
		public class FetchEntry
		{
			public int hitCount = 1;
			public DdClient ddClient;
			public FetchEntry(DdClient ddClient) { this.ddClient = ddClient; }
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

    public string ClientID
    {
      get { return store.Buffer.ClientID; }

      set 
      { 
        if (value.Length > 200) InvalidateField("Too long", "Client.ClientID");
#if __REALCHANGE__
        if (store.Buffer.ClientID != value)
        {
          store.Buffer.ClientID = value; 
          store.modClientID = true;
        }
#else
        store.Buffer.ClientID = value; 
        store.modClientID = true;
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
    public string FullName
    {
      get { return store.Buffer.FullName; }

      set 
      { 
        if (value.Length > 200) InvalidateField("Too long", "Client.FullName");
#if __REALCHANGE__
        if (store.Buffer.FullName != value)
        {
          store.Buffer.FullName = value; 
          store.modFullName = true;
        }
#else
        store.Buffer.FullName = value; 
        store.modFullName = true;
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
        if (value.Length > 50) InvalidateField("Too long", "Client.ModifiedBy");
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
      items["ClientID"] = ClientID;
      items["Comment"] = Comment;
      items["Created"] = Created;
      items["FullName"] = FullName;
      items["Id"] = Id;
      items["Modified"] = Modified;
      items["ModifiedBy"] = ModifiedBy;
      return items;
    }

    public void SetFromList(SortedList<string, object> items)
    {
      if (items.ContainsKey("ClientID")) ClientID= (string)items["ClientID"];
      if (items.ContainsKey("Comment")) Comment= (string)items["Comment"];
      if (items.ContainsKey("FullName")) FullName= (string)items["FullName"];
      if (items.ContainsKey("Modified")) Modified= (DateTime)items["Modified"];
      if (items.ContainsKey("ModifiedBy")) ModifiedBy= (string)items["ModifiedBy"];
    }
#endif
//??EndExpand 1/27/2013 10:54:11 AM
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
			DnClient dnClient = FillByParent(parentREF);
			ArrayList choices = new ArrayList();
			IEnumerator en = dnClient.GetEnumerator();
			DdClient ddClient;
			while (en.MoveNext())
			{
				ddClient = (DdClient)en.Current;
				choices.Add(ddClient.Id.ToString() + "," + ddClient.Description);
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

    private DsClient store = new DsClient();

    public DaClient(SQL.DBConnection dbConnection) : base(dbConnection)
    {
      store.ClearAll();
    }

    public void Clear()
    {
      store.ClearAll();
    }

    public bool GetByPK(string ClientID)
    {
      store.Buffer.ClientID = ClientID;
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

    public void SetBuffer(DdClient buffer)
    {
      store.Buffer = buffer;
    }

    public bool _IsModified
    {
      get { return store.Modified(); }
    }

    public DdClient GetBuffer()
    {
      return store.Buffer; 
    }

    public void SetModFlags() { store.SetModFlags(); }
    public void ClearModFlags() { store.ClearModFlags(); }
    public void SetDefaults() { store.Buffer.SetDefaults(); }

    #region fetch cache
#if __FETCHCACHE__
		public bool FetchByPK(string ClientID)
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
      key.ClientID = ClientID;
			if (fetchTable.Contains(key))
			{
				_hitCount++;
				ent = (FetchEntry)fetchTable[key];
				SetBuffer(ent.ddClient);
				if (ent.hitCount < int.MaxValue) ent.hitCount++;
				return true;
			}
			if (missTable.Contains(key)) return false;
			
			_ioCount++;
      store.Buffer.ClientID = ClientID;
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
		public DnClient Fill()
		{
			string sqlWhere = "Id >= 100";
			return Fill(sqlWhere, "ClientID", 0, true);
		}
		#endregion extend
  }


  public class DbClient : ASL.SQL.TableDataObject
  {
    private const int idxClientID = 0;
    private const int idxComment = 1;
    private const int idxCreated = 2;
    private const int idxFullName = 3;
    private const int idxId = 4;
    private const int idxModified = 5;
    private const int idxModifiedBy = 6;
    private const int idxTimestamp = 7;
    private const int idxNUMCOLS = 8;
    // Column names
    static readonly protected string[] sqlCols =
    {
     "[ClientID]", "[Comment]", "[Created]", "[FullName]", "[Id]", "[Modified]"
     , "[ModifiedBy]", "[Timestamp]"
    };
    static public string SqlColumnList { get { return string.Join(",", sqlCols); } }
    static public string[] SqlCols { get { return sqlCols; } }

    // set database connection and other initial values
    public DbClient(SQL.DBConnection dbConnection)
    {
      base.dbConnection = dbConnection;
      tableName = "Client";
      identityColumnName = "Id";
      sqlColumns = string.Join(",",  sqlCols);
    }

		public string TableName { get { return tableName; } set { tableName = value; } }

    public bool GetById(int Id, out DdClient buffer)
    {
      DsClient dsClient = new DsClient();
      dsClient.Buffer.Id = Id;
      if (!GetById(ref dsClient)) 
      {
        buffer = new DdClient();
        return false;
      }
      buffer = dsClient.Buffer;
      return true;
    }

    public bool GetById(ref DsClient xStr)
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
        string ClientID
      , out DdClient buffer)
    {
      DsClient dsClient = new DsClient();
      dsClient.Buffer.ClientID = ClientID;
      if (!GetByPK(ref dsClient))
      {
        buffer = new DdClient();
        return false;
      }
      buffer = dsClient.Buffer;
      return true;
    }

    public bool GetByPK(ref DsClient xStr)
    {
      string sql = "SELECT " + sqlColumns
      + " FROM " + tableName + NOLOCKSQL
      + " WHERE ClientID = " + TXT.q1(xStr.Buffer.ClientID);
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

    public bool UpdateById(ref DsClient xStr)
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

    public bool UpdateByPK(ref DsClient xStr)
    {
      int rowsUpdated = 0;
      if (xStr.Modified())
      {
        string sql = "UPDATE " + tableName + " SET " + BuildUpdateSQL(xStr) + " WHERE"
      + " ClientID = " + TXT.q1(xStr.Buffer.ClientID);
        if(!UpdateSQL(sql)) return false;
        rowsUpdated = _rowsAffected;
      }
      bool ok = GetByPK(ref xStr);
      _rowsAffected = rowsUpdated;
      return ok;
    }

    public bool DeleteByPK(
        string ClientID)
    {
      string sql = "DELETE FROM " + tableName + " WHERE"
      + " ClientID = " + TXT.q1(ClientID);
      return DeleteSQL(sql);
    }

    public bool DeleteByPK(ref DsClient xStr)
    {
      string sql = "DELETE FROM " + tableName + " WHERE"
      + " ClientID = " + TXT.q1(xStr.Buffer.ClientID);
      return DeleteSQL(sql);
    }
    public bool Insert(ref DsClient xStr)
    {
      int Id;
      string sql = BuildInsertSQL(xStr);
      if (!InsertIdSQL(sql, out Id)) return false;
      xStr.Buffer.Id = Id;
      return GetById(ref xStr);
    }

    public bool GetBySql(string sqlWhere, ref DsClient xStr)
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


    public DnClient Fill(string xWhere, string xOrder, int xTop, bool xNoLock)
    {
      System.Data.DataTable dt = FillDataTable(xWhere, xOrder, xTop, xNoLock);
      DnClient ClientList = new DnClient(dt.Rows.Count);
      foreach(System.Data.DataRow adr in dt.Rows)
      {
        ClientList.Add(Load(adr).Buffer);
      }
      return ClientList;
    }

    static public DsClient Load(System.Data.DataRow dr)
    {
      DsClient tStr = new DsClient();
      tStr.ClearBuffer();
      if (dr[idxClientID] != System.DBNull.Value) tStr.Buffer.ClientID = (string)dr[idxClientID];
      if (dr[idxComment] != System.DBNull.Value) tStr.Buffer.Comment = (string)dr[idxComment];
      if (dr[idxCreated] != System.DBNull.Value) tStr.Buffer.Created = (DateTime)dr[idxCreated];
      if (dr[idxFullName] != System.DBNull.Value) tStr.Buffer.FullName = (string)dr[idxFullName];
      if (dr[idxId] != System.DBNull.Value) tStr.Buffer.Id = (int)dr[idxId];
      if (dr[idxModified] != System.DBNull.Value) tStr.Buffer.Modified = (DateTime)dr[idxModified];
      if (dr[idxModifiedBy] != System.DBNull.Value) tStr.Buffer.ModifiedBy = (string)dr[idxModifiedBy];
      if (dr[idxTimestamp] != System.DBNull.Value) tStr.Buffer.Timestamp = (byte[])dr[idxTimestamp];
      return tStr;
    }

    public string BuildInsertSQL(DsClient xStr)
    {
      SQL.SqlCommandBuilder sc = new SQL.SqlCommandBuilder(
        SQL.sqlVerb.Insert, tableName);
      if (xStr.modClientID)
        sc.AddColumn(sqlCols[idxClientID], xStr.Buffer.ClientID);
      if (xStr.modComment)
        sc.AddColumn(sqlCols[idxComment], xStr.Buffer.Comment);
      if (xStr.modFullName)
        sc.AddColumn(sqlCols[idxFullName], xStr.Buffer.FullName);
      if (xStr.modModified)
        sc.AddColumn(sqlCols[idxModified], xStr.Buffer.Modified);
      if (xStr.modModifiedBy)
        sc.AddColumn(sqlCols[idxModifiedBy], xStr.Buffer.ModifiedBy);
      return sc.CommandText;
    }

    public string BuildUpdateSQL(DsClient xStr)
    {
      SQL.SqlCommandBuilder sc = new SQL.SqlCommandBuilder(SQL.sqlVerb.Update);
      if (xStr.modClientID)
        sc.AddColumn(sqlCols[idxClientID], xStr.Buffer.ClientID);
      if (xStr.modComment)
        sc.AddColumn(sqlCols[idxComment], xStr.Buffer.Comment);
      if (xStr.modFullName)
        sc.AddColumn(sqlCols[idxFullName], xStr.Buffer.FullName);
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
		
		static public DdClient LoadRow(System.Data.SqlClient.SqlDataReader reader)
		{
			DdClient rowBuffer = new DdClient();
			rowBuffer.Clear();
			if (!reader.IsDBNull(idxClientID)) rowBuffer.ClientID = reader.GetString(idxClientID);
			if (!reader.IsDBNull(idxComment)) rowBuffer.Comment = reader.GetString(idxComment);
			if (!reader.IsDBNull(idxCreated)) rowBuffer.Created = reader.GetDateTime(idxCreated);
			if (!reader.IsDBNull(idxFullName)) rowBuffer.FullName = reader.GetString(idxFullName);
			if (!reader.IsDBNull(idxId)) rowBuffer.Id = reader.GetInt32(idxId);
			if (!reader.IsDBNull(idxModified)) rowBuffer.Modified = reader.GetDateTime(idxModified);
			if (!reader.IsDBNull(idxModifiedBy)) rowBuffer.ModifiedBy = reader.GetString(idxModifiedBy);
			if (!reader.IsDBNull(idxTimestamp)) rowBuffer.Timestamp = GetTimestamp(idxTimestamp, reader);
			return rowBuffer;
		}
  }
  [Serializable]
  public class DsClient
  {
    public DdClient Buffer = new DdClient();

    public bool IsNew;
    public bool IsDeleted;

    public bool modClientID;
    public bool modComment;
    public bool modFullName;
    public bool modModified;
    public bool modModifiedBy;

    public object Tag;
    public int RowsAffected;
    public string ResultCode;
    public string ResultMessage;

    public bool Modified()
    {
      return
        modClientID
     || modComment
     || modFullName
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
      modClientID = false;
      modComment = false;
      modFullName = false;
      modModified = false;
      modModifiedBy = false;
    }

    public void SetModFlags()
    {
      modClientID = true;
      modComment = true;
      modFullName = true;
      modModified = true;
      modModifiedBy = true;
    }
  }

  [Serializable]
  public class DdClient : ASL.Forms.DdBase
  {
    public string ClientID { get; set; }
    public string Comment { get; set; }
    public string FullName { get; set; }

    public const string ClientID_N = "ClientID";
    public const string Comment_N = "Comment";
    public const string FullName_N = "FullName";

    public const int ClientID_L = 200;
    public const int Comment_L = -1;
    public const int FullName_L = 200;

    public DdClient()
	  : base()
    {
      Clear();
    }

    public DdClient(DdClient original)
	  : base(original)
    {
      ClientID = original.ClientID;
      Comment = original.Comment;
      FullName = original.FullName;
    }

    public override void Clear()
    {
      base.Clear();
      ClientID = "";
      Comment = "";
      FullName = "";
    }

    public override void SetDefaults()
    {
      base.SetDefaults();
      ClientID = string.Empty;
      Comment = string.Empty;
      FullName = string.Empty;
    }
  }

  [Serializable]
  public class DnClient : System.Collections.Generic.List<DdClient>
  {
    public DnClient() : base() {}
    public DnClient(int xCapacity) : base(xCapacity) {}

    public new DdClient this[int xIndex]
    {
      get { return (DdClient) base[xIndex]; }
      set { base[xIndex] = value; }
    }
  }


}
