// Generated: Sun Jan 27, 2013 10:54:16
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
  public class DaRequestItem : DbRequestItem, ASL.ApplicatFieldType.IDaForm_I
#else
  public class DaRequestItem : DbRequestItem
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
      public string ItemID;
		}
		public class FetchEntry
		{
			public int hitCount = 1;
			public DdRequestItem ddRequestItem;
			public FetchEntry(DdRequestItem ddRequestItem) { this.ddRequestItem = ddRequestItem; }
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
    public int Id
    {
      get { return store.Buffer.Id; }

    }
    public string ItemID
    {
      get { return store.Buffer.ItemID; }

      set 
      { 
        if (value.Length > 50) InvalidateField("Too long", "RequestItem.ItemID");
#if __REALCHANGE__
        if (store.Buffer.ItemID != value)
        {
          store.Buffer.ItemID = value; 
          store.modItemID = true;
        }
#else
        store.Buffer.ItemID = value; 
        store.modItemID = true;
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
        if (value.Length > 50) InvalidateField("Too long", "RequestItem.ModifiedBy");
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
      items["ChangeRequestREF"] = ChangeRequestREF;
      items["Comment"] = Comment;
      items["Created"] = Created;
      items["Description"] = Description;
      items["EffectiveDate"] = EffectiveDate;
      items["Id"] = Id;
      items["ItemID"] = ItemID;
      items["Modified"] = Modified;
      items["ModifiedBy"] = ModifiedBy;
      return items;
    }

    public void SetFromList(SortedList<string, object> items)
    {
      if (items.ContainsKey("ChangeRequestREF")) ChangeRequestREF= (int)items["ChangeRequestREF"];
      if (items.ContainsKey("Comment")) Comment= (string)items["Comment"];
      if (items.ContainsKey("Description")) Description= (string)items["Description"];
      if (items.ContainsKey("EffectiveDate")) EffectiveDate= (DateTime)items["EffectiveDate"];
      if (items.ContainsKey("ItemID")) ItemID= (string)items["ItemID"];
      if (items.ContainsKey("Modified")) Modified= (DateTime)items["Modified"];
      if (items.ContainsKey("ModifiedBy")) ModifiedBy= (string)items["ModifiedBy"];
    }
#endif
//??EndExpand 1/27/2013 10:54:16 AM
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
			DnRequestItem dnRequestItem = FillByParent(parentREF);
			ArrayList choices = new ArrayList();
			IEnumerator en = dnRequestItem.GetEnumerator();
			DdRequestItem ddRequestItem;
			while (en.MoveNext())
			{
				ddRequestItem = (DdRequestItem)en.Current;
				choices.Add(ddRequestItem.Id.ToString() + "," + ddRequestItem.Description);
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

    private DsRequestItem store = new DsRequestItem();

    public DaRequestItem(SQL.DBConnection dbConnection) : base(dbConnection)
    {
      store.ClearAll();
    }

    public void Clear()
    {
      store.ClearAll();
    }

    public bool GetByPK(int ChangeRequestREF, string ItemID)
    {
      store.Buffer.ChangeRequestREF = ChangeRequestREF;
      store.Buffer.ItemID = ItemID;
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

    public void SetBuffer(DdRequestItem buffer)
    {
      store.Buffer = buffer;
    }

    public bool _IsModified
    {
      get { return store.Modified(); }
    }

    public DdRequestItem GetBuffer()
    {
      return store.Buffer; 
    }

    public void SetModFlags() { store.SetModFlags(); }
    public void ClearModFlags() { store.ClearModFlags(); }
    public void SetDefaults() { store.Buffer.SetDefaults(); }

    #region fetch cache
#if __FETCHCACHE__
		public bool FetchByPK(int ChangeRequestREF, string ItemID)
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
      key.ItemID = ItemID;
			if (fetchTable.Contains(key))
			{
				_hitCount++;
				ent = (FetchEntry)fetchTable[key];
				SetBuffer(ent.ddRequestItem);
				if (ent.hitCount < int.MaxValue) ent.hitCount++;
				return true;
			}
			if (missTable.Contains(key)) return false;
			
			_ioCount++;
      store.Buffer.ChangeRequestREF = ChangeRequestREF;
      store.Buffer.ItemID = ItemID;
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
		public DnRequestItem Fill()
		{
			string sqlWhere = "Id >= 100";
			return Fill(sqlWhere, "RequestItemID", 0, true);
		}
		public DnRequestItem FillByChangeRequest(int parentREF)
		{
			string sqlWhere = string.Format("ChangeRequestREF={0}", parentREF);
			return Fill(sqlWhere, "RequestItemID", 0, true);
		}
		#endregion extend
  }


  public class DbRequestItem : ASL.SQL.TableDataObject
  {
    private const int idxChangeRequestREF = 0;
    private const int idxComment = 1;
    private const int idxCreated = 2;
    private const int idxDescription = 3;
    private const int idxEffectiveDate = 4;
    private const int idxId = 5;
    private const int idxItemID = 6;
    private const int idxModified = 7;
    private const int idxModifiedBy = 8;
    private const int idxTimestamp = 9;
    private const int idxNUMCOLS = 10;
    // Column names
    static readonly protected string[] sqlCols =
    {
     "[ChangeRequestREF]", "[Comment]", "[Created]", "[Description]"
     , "[EffectiveDate]", "[Id]", "[ItemID]", "[Modified]", "[ModifiedBy]"
     , "[Timestamp]"
    };
    static public string SqlColumnList { get { return string.Join(",", sqlCols); } }
    static public string[] SqlCols { get { return sqlCols; } }

    // set database connection and other initial values
    public DbRequestItem(SQL.DBConnection dbConnection)
    {
      base.dbConnection = dbConnection;
      tableName = "RequestItem";
      identityColumnName = "Id";
      sqlColumns = string.Join(",",  sqlCols);
    }

		public string TableName { get { return tableName; } set { tableName = value; } }

    public bool GetById(int Id, out DdRequestItem buffer)
    {
      DsRequestItem dsRequestItem = new DsRequestItem();
      dsRequestItem.Buffer.Id = Id;
      if (!GetById(ref dsRequestItem)) 
      {
        buffer = new DdRequestItem();
        return false;
      }
      buffer = dsRequestItem.Buffer;
      return true;
    }

    public bool GetById(ref DsRequestItem xStr)
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
      , string ItemID
      , out DdRequestItem buffer)
    {
      DsRequestItem dsRequestItem = new DsRequestItem();
      dsRequestItem.Buffer.ChangeRequestREF = ChangeRequestREF;
      dsRequestItem.Buffer.ItemID = ItemID;
      if (!GetByPK(ref dsRequestItem))
      {
        buffer = new DdRequestItem();
        return false;
      }
      buffer = dsRequestItem.Buffer;
      return true;
    }

    public bool GetByPK(ref DsRequestItem xStr)
    {
      string sql = "SELECT " + sqlColumns
      + " FROM " + tableName + NOLOCKSQL
      + " WHERE ChangeRequestREF = " + xStr.Buffer.ChangeRequestREF.ToString()
      + " AND ItemID = " + TXT.q1(xStr.Buffer.ItemID);
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

    public bool UpdateById(ref DsRequestItem xStr)
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

    public bool UpdateByPK(ref DsRequestItem xStr)
    {
      int rowsUpdated = 0;
      if (xStr.Modified())
      {
        string sql = "UPDATE " + tableName + " SET " + BuildUpdateSQL(xStr) + " WHERE"
      + " ChangeRequestREF = " + xStr.Buffer.ChangeRequestREF.ToString()
      + " AND ItemID = " + TXT.q1(xStr.Buffer.ItemID);
        if(!UpdateSQL(sql)) return false;
        rowsUpdated = _rowsAffected;
      }
      bool ok = GetByPK(ref xStr);
      _rowsAffected = rowsUpdated;
      return ok;
    }

    public bool DeleteByPK(
        int ChangeRequestREF
      , string ItemID)
    {
      string sql = "DELETE FROM " + tableName + " WHERE"
      + " ChangeRequestREF = " + ChangeRequestREF.ToString()
      + " AND ItemID = " + TXT.q1(ItemID);
      return DeleteSQL(sql);
    }

    public bool DeleteByPK(ref DsRequestItem xStr)
    {
      string sql = "DELETE FROM " + tableName + " WHERE"
      + " ChangeRequestREF = " + xStr.Buffer.ChangeRequestREF.ToString()
      + " AND ItemID = " + TXT.q1(xStr.Buffer.ItemID);
      return DeleteSQL(sql);
    }
    public bool Insert(ref DsRequestItem xStr)
    {
      int Id;
      string sql = BuildInsertSQL(xStr);
      if (!InsertIdSQL(sql, out Id)) return false;
      xStr.Buffer.Id = Id;
      return GetById(ref xStr);
    }

    public bool GetBySql(string sqlWhere, ref DsRequestItem xStr)
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


    public DnRequestItem Fill(string xWhere, string xOrder, int xTop, bool xNoLock)
    {
      System.Data.DataTable dt = FillDataTable(xWhere, xOrder, xTop, xNoLock);
      DnRequestItem RequestItemList = new DnRequestItem(dt.Rows.Count);
      foreach(System.Data.DataRow adr in dt.Rows)
      {
        RequestItemList.Add(Load(adr).Buffer);
      }
      return RequestItemList;
    }

    static public DsRequestItem Load(System.Data.DataRow dr)
    {
      DsRequestItem tStr = new DsRequestItem();
      tStr.ClearBuffer();
      if (dr[idxChangeRequestREF] != System.DBNull.Value) tStr.Buffer.ChangeRequestREF = (int)dr[idxChangeRequestREF];
      if (dr[idxComment] != System.DBNull.Value) tStr.Buffer.Comment = (string)dr[idxComment];
      if (dr[idxCreated] != System.DBNull.Value) tStr.Buffer.Created = (DateTime)dr[idxCreated];
      if (dr[idxDescription] != System.DBNull.Value) tStr.Buffer.Description = (string)dr[idxDescription];
      if (dr[idxEffectiveDate] != System.DBNull.Value) tStr.Buffer.EffectiveDate = (DateTime)dr[idxEffectiveDate];
      if (dr[idxId] != System.DBNull.Value) tStr.Buffer.Id = (int)dr[idxId];
      if (dr[idxItemID] != System.DBNull.Value) tStr.Buffer.ItemID = (string)dr[idxItemID];
      if (dr[idxModified] != System.DBNull.Value) tStr.Buffer.Modified = (DateTime)dr[idxModified];
      if (dr[idxModifiedBy] != System.DBNull.Value) tStr.Buffer.ModifiedBy = (string)dr[idxModifiedBy];
      if (dr[idxTimestamp] != System.DBNull.Value) tStr.Buffer.Timestamp = (byte[])dr[idxTimestamp];
      return tStr;
    }

    public string BuildInsertSQL(DsRequestItem xStr)
    {
      SQL.SqlCommandBuilder sc = new SQL.SqlCommandBuilder(
        SQL.sqlVerb.Insert, tableName);
      if (xStr.modChangeRequestREF)
        sc.AddColumn(sqlCols[idxChangeRequestREF], xStr.Buffer.ChangeRequestREF);
      if (xStr.modComment)
        sc.AddColumn(sqlCols[idxComment], xStr.Buffer.Comment);
      if (xStr.modDescription)
        sc.AddColumn(sqlCols[idxDescription], xStr.Buffer.Description);
      if (xStr.modEffectiveDate)
        sc.AddColumn(sqlCols[idxEffectiveDate], xStr.Buffer.EffectiveDate);
      if (xStr.modItemID)
        sc.AddColumn(sqlCols[idxItemID], xStr.Buffer.ItemID);
      if (xStr.modModified)
        sc.AddColumn(sqlCols[idxModified], xStr.Buffer.Modified);
      if (xStr.modModifiedBy)
        sc.AddColumn(sqlCols[idxModifiedBy], xStr.Buffer.ModifiedBy);
      return sc.CommandText;
    }

    public string BuildUpdateSQL(DsRequestItem xStr)
    {
      SQL.SqlCommandBuilder sc = new SQL.SqlCommandBuilder(SQL.sqlVerb.Update);
      if (xStr.modChangeRequestREF)
        sc.AddColumn(sqlCols[idxChangeRequestREF], xStr.Buffer.ChangeRequestREF);
      if (xStr.modComment)
        sc.AddColumn(sqlCols[idxComment], xStr.Buffer.Comment);
      if (xStr.modDescription)
        sc.AddColumn(sqlCols[idxDescription], xStr.Buffer.Description);
      if (xStr.modEffectiveDate)
        sc.AddColumn(sqlCols[idxEffectiveDate], xStr.Buffer.EffectiveDate);
      if (xStr.modItemID)
        sc.AddColumn(sqlCols[idxItemID], xStr.Buffer.ItemID);
      if (xStr.modModified)
        sc.AddColumn(sqlCols[idxModified], xStr.Buffer.Modified);
      if (xStr.modModifiedBy)
        sc.AddColumn(sqlCols[idxModifiedBy], xStr.Buffer.ModifiedBy);
      return sc.ColumnList;
    }

    //  Index = IX_RequestItem
    public bool GetBy_IX_RequestItem(
      int ChangeRequestREF
    , string ItemID
    , out DdRequestItem buffer)
  {
    string sql = "SELECT " + sqlColumns
    + " FROM " + tableName + NOLOCKSQL
    + " WHERE ChangeRequestREF = " + ChangeRequestREF.ToString()
    + " AND ItemID = " + TXT.q1(ItemID);
    System.Data.DataRow dr;
    if (GetSQL(sql, out dr))
    {
      DsRequestItem dsRequestItem = Load(dr);
      buffer = dsRequestItem.Buffer;
      return true;
    }
    else
    {
      buffer = new DdRequestItem();
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
		
		static public DdRequestItem LoadRow(System.Data.SqlClient.SqlDataReader reader)
		{
			DdRequestItem rowBuffer = new DdRequestItem();
			rowBuffer.Clear();
			if (!reader.IsDBNull(idxChangeRequestREF)) rowBuffer.ChangeRequestREF = reader.GetInt32(idxChangeRequestREF);
			if (!reader.IsDBNull(idxComment)) rowBuffer.Comment = reader.GetString(idxComment);
			if (!reader.IsDBNull(idxCreated)) rowBuffer.Created = reader.GetDateTime(idxCreated);
			if (!reader.IsDBNull(idxDescription)) rowBuffer.Description = reader.GetString(idxDescription);
			if (!reader.IsDBNull(idxEffectiveDate)) rowBuffer.EffectiveDate = reader.GetDateTime(idxEffectiveDate);
			if (!reader.IsDBNull(idxId)) rowBuffer.Id = reader.GetInt32(idxId);
			if (!reader.IsDBNull(idxItemID)) rowBuffer.ItemID = reader.GetString(idxItemID);
			if (!reader.IsDBNull(idxModified)) rowBuffer.Modified = reader.GetDateTime(idxModified);
			if (!reader.IsDBNull(idxModifiedBy)) rowBuffer.ModifiedBy = reader.GetString(idxModifiedBy);
			if (!reader.IsDBNull(idxTimestamp)) rowBuffer.Timestamp = GetTimestamp(idxTimestamp, reader);
			return rowBuffer;
		}
  }
  [Serializable]
  public class DsRequestItem
  {
    public DdRequestItem Buffer = new DdRequestItem();

    public bool IsNew;
    public bool IsDeleted;

    public bool modChangeRequestREF;
    public bool modComment;
    public bool modDescription;
    public bool modEffectiveDate;
    public bool modItemID;
    public bool modModified;
    public bool modModifiedBy;

    public object Tag;
    public int RowsAffected;
    public string ResultCode;
    public string ResultMessage;

    public bool Modified()
    {
      return
        modChangeRequestREF
     || modComment
     || modDescription
     || modEffectiveDate
     || modItemID
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
      modChangeRequestREF = false;
      modComment = false;
      modDescription = false;
      modEffectiveDate = false;
      modItemID = false;
      modModified = false;
      modModifiedBy = false;
    }

    public void SetModFlags()
    {
      modChangeRequestREF = true;
      modComment = true;
      modDescription = true;
      modEffectiveDate = true;
      modItemID = true;
      modModified = true;
      modModifiedBy = true;
    }
  }

  [Serializable]
  public class DdRequestItem : ASL.Forms.DdBase
  {
    public int ChangeRequestREF { get; set; }
    public string Comment { get; set; }
    public string Description { get; set; }
    public DateTime EffectiveDate { get; set; }
    public string ItemID { get; set; }

    public const string ChangeRequestREF_N = "ChangeRequestREF";
    public const string Comment_N = "Comment";
    public const string Description_N = "Description";
    public const string EffectiveDate_N = "EffectiveDate";
    public const string ItemID_N = "ItemID";

    public const int Comment_L = -1;
    public const int Description_L = -1;
    public const int ItemID_L = 50;

    public DdRequestItem()
	  : base()
    {
      Clear();
    }

    public DdRequestItem(DdRequestItem original)
	  : base(original)
    {
      ChangeRequestREF = original.ChangeRequestREF;
      Comment = original.Comment;
      Description = original.Description;
      EffectiveDate = original.EffectiveDate;
      ItemID = original.ItemID;
    }

    public override void Clear()
    {
      base.Clear();
      ChangeRequestREF = 0;
      Comment = "";
      Description = "";
      EffectiveDate = DateTime.MinValue;
      ItemID = "";
    }

    public override void SetDefaults()
    {
      base.SetDefaults();
      ChangeRequestREF = (1);
      Comment = string.Empty;
      Description = string.Empty;
      EffectiveDate = DateTime.Now;
      ItemID = string.Empty;
    }
  }

  [Serializable]
  public class DnRequestItem : System.Collections.Generic.List<DdRequestItem>
  {
    public DnRequestItem() : base() {}
    public DnRequestItem(int xCapacity) : base(xCapacity) {}

    public new DdRequestItem this[int xIndex]
    {
      get { return (DdRequestItem) base[xIndex]; }
      set { base[xIndex] = value; }
    }
  }


}
