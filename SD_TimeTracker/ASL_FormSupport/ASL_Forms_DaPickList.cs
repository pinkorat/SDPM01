// Generated: Sun Jan 27, 2013 11:26:38
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

namespace ASL.Forms
{
#if __FORMINTERFACE__
  public class DaPickList : DbPickList, ASL.ApplicatFieldType.IDaForm_I
#else
  public class DaPickList : DbPickList
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
      public string ListID;
      public string TextValue;
		}
		public class FetchEntry
		{
			public int hitCount = 1;
			public DdPickList ddPickList;
			public FetchEntry(DdPickList ddPickList) { this.ddPickList = ddPickList; }
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

    public int Id
    {
      get { return store.Buffer.Id; }

    }
    public string ListID
    {
      get { return store.Buffer.ListID; }

      set 
      { 
        if (value.Length > 30) InvalidateField("Too long", "PickList.ListID");
#if __REALCHANGE__
        if (store.Buffer.ListID != value)
        {
          store.Buffer.ListID = value; 
          store.modListID = true;
        }
#else
        store.Buffer.ListID = value; 
        store.modListID = true;
#endif
      }
    }
    public string TextValue
    {
      get { return store.Buffer.TextValue; }

      set 
      { 
#if __REALCHANGE__
        if (store.Buffer.TextValue != value)
        {
          store.Buffer.TextValue = value; 
          store.modTextValue = true;
        }
#else
        store.Buffer.TextValue = value; 
        store.modTextValue = true;
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
      items["Id"] = Id;
      items["ListID"] = ListID;
      items["TextValue"] = TextValue;
      return items;
    }

    public void SetFromList(SortedList<string, object> items)
    {
      if (items.ContainsKey("ListID")) ListID= (string)items["ListID"];
      if (items.ContainsKey("TextValue")) TextValue= (string)items["TextValue"];
    }
#endif
//??EndExpand 1/27/2013 11:26:38 AM
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
			DnPickList dnPickList = FillByParent(parentREF);
			ArrayList choices = new ArrayList();
			IEnumerator en = dnPickList.GetEnumerator();
			DdPickList ddPickList;
			while (en.MoveNext())
			{
				ddPickList = (DdPickList)en.Current;
				choices.Add(ddPickList.Id.ToString() + "," + ddPickList.Description);
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

    private DsPickList store = new DsPickList();

    public DaPickList(SQL.DBConnection dbConnection) : base(dbConnection)
    {
      store.ClearAll();
    }

    public void Clear()
    {
      store.ClearAll();
    }

    public bool GetByPK(string ListID, string TextValue)
    {
      store.Buffer.ListID = ListID;
      store.Buffer.TextValue = TextValue;
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

    public void SetBuffer(DdPickList buffer)
    {
      store.Buffer = buffer;
    }

    public bool _IsModified
    {
      get { return store.Modified(); }
    }

    public DdPickList GetBuffer()
    {
      return store.Buffer; 
    }

    public void SetModFlags() { store.SetModFlags(); }
    public void ClearModFlags() { store.ClearModFlags(); }
    public void SetDefaults() { store.Buffer.SetDefaults(); }

    #region fetch cache
#if __FETCHCACHE__
		public bool FetchByPK(string ListID, string TextValue)
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
      key.ListID = ListID;
      key.TextValue = TextValue;
			if (fetchTable.Contains(key))
			{
				_hitCount++;
				ent = (FetchEntry)fetchTable[key];
				SetBuffer(ent.ddPickList);
				if (ent.hitCount < int.MaxValue) ent.hitCount++;
				return true;
			}
			if (missTable.Contains(key)) return false;
			
			_ioCount++;
      store.Buffer.ListID = ListID;
      store.Buffer.TextValue = TextValue;
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
		public DnPickList Fill()
		{
			string sqlWhere = "Id >= 100";
			return Fill(sqlWhere, "ListID", 0, true);
		}
    
    public DnPickList FillByListID(string listID)
    {
      string sqlWhere = string.Format("ListID='{0}'", listID);
      return Fill(sqlWhere, "TextValue,Id", 0, true);
    }
    #endregion extend
  }


  public class DbPickList : ASL.SQL.TableDataObject
  {
    private const int idxId = 0;
    private const int idxListID = 1;
    private const int idxTextValue = 2;
    private const int idxTimestamp = 3;
    private const int idxNUMCOLS = 4;
    // Column names
    static readonly protected string[] sqlCols =
    {
     "[Id]", "[ListID]", "[TextValue]", "[Timestamp]"
    };
    static public string SqlColumnList { get { return string.Join(",", sqlCols); } }
    static public string[] SqlCols { get { return sqlCols; } }

    // set database connection and other initial values
    public DbPickList(SQL.DBConnection dbConnection)
    {
      base.dbConnection = dbConnection;
      tableName = "PickList";
      identityColumnName = "Id";
      sqlColumns = string.Join(",",  sqlCols);
    }

		public string TableName { get { return tableName; } set { tableName = value; } }

    public bool GetById(int Id, out DdPickList buffer)
    {
      DsPickList dsPickList = new DsPickList();
      dsPickList.Buffer.Id = Id;
      if (!GetById(ref dsPickList)) 
      {
        buffer = new DdPickList();
        return false;
      }
      buffer = dsPickList.Buffer;
      return true;
    }

    public bool GetById(ref DsPickList xStr)
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
        string ListID
      , string TextValue
      , out DdPickList buffer)
    {
      DsPickList dsPickList = new DsPickList();
      dsPickList.Buffer.ListID = ListID;
      dsPickList.Buffer.TextValue = TextValue;
      if (!GetByPK(ref dsPickList))
      {
        buffer = new DdPickList();
        return false;
      }
      buffer = dsPickList.Buffer;
      return true;
    }

    public bool GetByPK(ref DsPickList xStr)
    {
      string sql = "SELECT " + sqlColumns
      + " FROM " + tableName + NOLOCKSQL
      + " WHERE ListID = " + TXT.q1(xStr.Buffer.ListID)
      + " AND TextValue = " + TXT.q1(xStr.Buffer.TextValue);
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

    public bool UpdateById(ref DsPickList xStr)
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

    public bool UpdateByPK(ref DsPickList xStr)
    {
      int rowsUpdated = 0;
      if (xStr.Modified())
      {
        string sql = "UPDATE " + tableName + " SET " + BuildUpdateSQL(xStr) + " WHERE"
      + " ListID = " + TXT.q1(xStr.Buffer.ListID)
      + " AND TextValue = " + TXT.q1(xStr.Buffer.TextValue);
        if(!UpdateSQL(sql)) return false;
        rowsUpdated = _rowsAffected;
      }
      bool ok = GetByPK(ref xStr);
      _rowsAffected = rowsUpdated;
      return ok;
    }

    public bool DeleteByPK(
        string ListID
      , string TextValue)
    {
      string sql = "DELETE FROM " + tableName + " WHERE"
      + " ListID = " + TXT.q1(ListID)
      + " AND TextValue = " + TXT.q1(TextValue);
      return DeleteSQL(sql);
    }

    public bool DeleteByPK(ref DsPickList xStr)
    {
      string sql = "DELETE FROM " + tableName + " WHERE"
      + " ListID = " + TXT.q1(xStr.Buffer.ListID)
      + " AND TextValue = " + TXT.q1(xStr.Buffer.TextValue);
      return DeleteSQL(sql);
    }
    public bool Insert(ref DsPickList xStr)
    {
      int Id;
      string sql = BuildInsertSQL(xStr);
      if (!InsertIdSQL(sql, out Id)) return false;
      xStr.Buffer.Id = Id;
      return GetById(ref xStr);
    }

    public bool GetBySql(string sqlWhere, ref DsPickList xStr)
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


    public DnPickList Fill(string xWhere, string xOrder, int xTop, bool xNoLock)
    {
      System.Data.DataTable dt = FillDataTable(xWhere, xOrder, xTop, xNoLock);
      DnPickList PickListList = new DnPickList(dt.Rows.Count);
      foreach(System.Data.DataRow adr in dt.Rows)
      {
        PickListList.Add(Load(adr).Buffer);
      }
      return PickListList;
    }

    static public DsPickList Load(System.Data.DataRow dr)
    {
      DsPickList tStr = new DsPickList();
      tStr.ClearBuffer();
      if (dr[idxId] != System.DBNull.Value) tStr.Buffer.Id = (int)dr[idxId];
      if (dr[idxListID] != System.DBNull.Value) tStr.Buffer.ListID = (string)dr[idxListID];
      if (dr[idxTextValue] != System.DBNull.Value) tStr.Buffer.TextValue = (string)dr[idxTextValue];
      if (dr[idxTimestamp] != System.DBNull.Value) tStr.Buffer.Timestamp = (byte[])dr[idxTimestamp];
      return tStr;
    }

    public string BuildInsertSQL(DsPickList xStr)
    {
      SQL.SqlCommandBuilder sc = new SQL.SqlCommandBuilder(
        SQL.sqlVerb.Insert, tableName);
      if (xStr.modListID)
        sc.AddColumn(sqlCols[idxListID], xStr.Buffer.ListID);
      if (xStr.modTextValue)
        sc.AddColumn(sqlCols[idxTextValue], xStr.Buffer.TextValue);
      return sc.CommandText;
    }

    public string BuildUpdateSQL(DsPickList xStr)
    {
      SQL.SqlCommandBuilder sc = new SQL.SqlCommandBuilder(SQL.sqlVerb.Update);
      if (xStr.modListID)
        sc.AddColumn(sqlCols[idxListID], xStr.Buffer.ListID);
      if (xStr.modTextValue)
        sc.AddColumn(sqlCols[idxTextValue], xStr.Buffer.TextValue);
      return sc.ColumnList;
    }

    //  Index = IX_PickList
    public bool GetBy_IX_PickList(
      string ListID
    , string TextValue
    , out DdPickList buffer)
  {
    string sql = "SELECT " + sqlColumns
    + " FROM " + tableName + NOLOCKSQL
    + " WHERE ListID = " + TXT.q1(ListID)
    + " AND TextValue = " + TXT.q1(TextValue);
    System.Data.DataRow dr;
    if (GetSQL(sql, out dr))
    {
      DsPickList dsPickList = Load(dr);
      buffer = dsPickList.Buffer;
      return true;
    }
    else
    {
      buffer = new DdPickList();
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
		
		static public DdPickList LoadRow(System.Data.SqlClient.SqlDataReader reader)
		{
			DdPickList rowBuffer = new DdPickList();
			rowBuffer.Clear();
			if (!reader.IsDBNull(idxId)) rowBuffer.Id = reader.GetInt32(idxId);
			if (!reader.IsDBNull(idxListID)) rowBuffer.ListID = reader.GetString(idxListID);
			if (!reader.IsDBNull(idxTextValue)) rowBuffer.TextValue = reader.GetString(idxTextValue);
			if (!reader.IsDBNull(idxTimestamp)) rowBuffer.Timestamp = GetTimestamp(idxTimestamp, reader);
			return rowBuffer;
		}
  }
  [Serializable]
  public class DsPickList
  {
    public DdPickList Buffer = new DdPickList();

    public bool IsNew;
    public bool IsDeleted;

    public bool modListID;
    public bool modTextValue;

    public object Tag;
    public int RowsAffected;
    public string ResultCode;
    public string ResultMessage;

    public bool Modified()
    {
      return
        modListID
     || modTextValue;
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
      modListID = false;
      modTextValue = false;
    }

    public void SetModFlags()
    {
      modListID = true;
      modTextValue = true;
    }
  }

  [Serializable]
  public class DdPickList : DdBase
  {
    public string ListID { get; set; }
    public string TextValue { get; set; }

    public const string ListID_N = "ListID";
    public const string TextValue_N = "TextValue";

    public const int ListID_L = 30;
    public const int TextValue_L = 255;

    public DdPickList()
	  : base()
    {
      Clear();
    }

    public DdPickList(DdPickList original)
	  : base(original)
    {
      ListID = original.ListID;
      TextValue = original.TextValue;
    }

    public override void Clear()
    {
      base.Clear();
      ListID = "";
      TextValue = "";
    }

    public override void SetDefaults()
    {
      base.SetDefaults();
      ListID = string.Empty;
      TextValue = string.Empty;
    }
  }

  [Serializable]
  public class DnPickList : System.Collections.Generic.List<DdPickList>
  {
    public DnPickList() : base() {}
    public DnPickList(int xCapacity) : base(xCapacity) {}

    public new DdPickList this[int xIndex]
    {
      get { return (DdPickList) base[xIndex]; }
      set { base[xIndex] = value; }
    }
  }


}
