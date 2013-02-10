// Generated: Sun Jan 27, 2013 10:54:27
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
  public class DaTaskHeadingRole : DbTaskHeadingRole, ASL.ApplicatFieldType.IDaForm_I
#else
  public class DaTaskHeadingRole : DbTaskHeadingRole
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
      public int PersonREF;
      public int TaskHeadingREF;
      public int TaskRoleREF;
		}
		public class FetchEntry
		{
			public int hitCount = 1;
			public DdTaskHeadingRole ddTaskHeadingRole;
			public FetchEntry(DdTaskHeadingRole ddTaskHeadingRole) { this.ddTaskHeadingRole = ddTaskHeadingRole; }
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
        if (value.Length > 50) InvalidateField("Too long", "TaskHeadingRole.ModifiedBy");
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
    public int TaskHeadingREF
    {
      get { return store.Buffer.TaskHeadingREF; }

      set 
      { 
#if __REALCHANGE__
        if (store.Buffer.TaskHeadingREF != value)
        {
          store.Buffer.TaskHeadingREF = value; 
          store.modTaskHeadingREF = true;
        }
#else
        store.Buffer.TaskHeadingREF = value; 
        store.modTaskHeadingREF = true;
#endif
      }
    }
    public int TaskRoleREF
    {
      get { return store.Buffer.TaskRoleREF; }

      set 
      { 
#if __REALCHANGE__
        if (store.Buffer.TaskRoleREF != value)
        {
          store.Buffer.TaskRoleREF = value; 
          store.modTaskRoleREF = true;
        }
#else
        store.Buffer.TaskRoleREF = value; 
        store.modTaskRoleREF = true;
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
      items["Id"] = Id;
      items["Modified"] = Modified;
      items["ModifiedBy"] = ModifiedBy;
      items["PersonREF"] = PersonREF;
      items["TaskHeadingREF"] = TaskHeadingREF;
      items["TaskRoleREF"] = TaskRoleREF;
      return items;
    }

    public void SetFromList(SortedList<string, object> items)
    {
      if (items.ContainsKey("Modified")) Modified= (DateTime)items["Modified"];
      if (items.ContainsKey("ModifiedBy")) ModifiedBy= (string)items["ModifiedBy"];
      if (items.ContainsKey("PersonREF")) PersonREF= (int)items["PersonREF"];
      if (items.ContainsKey("TaskHeadingREF")) TaskHeadingREF= (int)items["TaskHeadingREF"];
      if (items.ContainsKey("TaskRoleREF")) TaskRoleREF= (int)items["TaskRoleREF"];
    }
#endif
//??EndExpand 1/27/2013 10:54:27 AM
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
			DnTaskHeadingRole dnTaskHeadingRole = FillByParent(parentREF);
			ArrayList choices = new ArrayList();
			IEnumerator en = dnTaskHeadingRole.GetEnumerator();
			DdTaskHeadingRole ddTaskHeadingRole;
			while (en.MoveNext())
			{
				ddTaskHeadingRole = (DdTaskHeadingRole)en.Current;
				choices.Add(ddTaskHeadingRole.Id.ToString() + "," + ddTaskHeadingRole.Description);
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

    private DsTaskHeadingRole store = new DsTaskHeadingRole();

    public DaTaskHeadingRole(SQL.DBConnection dbConnection) : base(dbConnection)
    {
      store.ClearAll();
    }

    public void Clear()
    {
      store.ClearAll();
    }

    public bool GetByPK(int PersonREF, int TaskHeadingREF, int TaskRoleREF)
    {
      store.Buffer.PersonREF = PersonREF;
      store.Buffer.TaskHeadingREF = TaskHeadingREF;
      store.Buffer.TaskRoleREF = TaskRoleREF;
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

    public void SetBuffer(DdTaskHeadingRole buffer)
    {
      store.Buffer = buffer;
    }

    public bool _IsModified
    {
      get { return store.Modified(); }
    }

    public DdTaskHeadingRole GetBuffer()
    {
      return store.Buffer; 
    }

    public void SetModFlags() { store.SetModFlags(); }
    public void ClearModFlags() { store.ClearModFlags(); }
    public void SetDefaults() { store.Buffer.SetDefaults(); }

    #region fetch cache
#if __FETCHCACHE__
		public bool FetchByPK(int PersonREF, int TaskHeadingREF, int TaskRoleREF)
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
      key.PersonREF = PersonREF;
      key.TaskHeadingREF = TaskHeadingREF;
      key.TaskRoleREF = TaskRoleREF;
			if (fetchTable.Contains(key))
			{
				_hitCount++;
				ent = (FetchEntry)fetchTable[key];
				SetBuffer(ent.ddTaskHeadingRole);
				if (ent.hitCount < int.MaxValue) ent.hitCount++;
				return true;
			}
			if (missTable.Contains(key)) return false;
			
			_ioCount++;
      store.Buffer.PersonREF = PersonREF;
      store.Buffer.TaskHeadingREF = TaskHeadingREF;
      store.Buffer.TaskRoleREF = TaskRoleREF;
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
		public DnTaskHeadingRole Fill()
		{
			string sqlWhere = "Id >= 100";
			return Fill(sqlWhere, "Id", 0, true);
		}
		public DnTaskHeadingRole FillByTaskHeading(int parentREF)
		{
			string sqlWhere = string.Format("TaskHeadingREF={0}", parentREF);
			return Fill(sqlWhere, "Id", 0, true);
		}
		#endregion extend
  }


  public class DbTaskHeadingRole : ASL.SQL.TableDataObject
  {
    private const int idxCreated = 0;
    private const int idxId = 1;
    private const int idxModified = 2;
    private const int idxModifiedBy = 3;
    private const int idxPersonREF = 4;
    private const int idxTaskHeadingREF = 5;
    private const int idxTaskRoleREF = 6;
    private const int idxTimestamp = 7;
    private const int idxNUMCOLS = 8;
    // Column names
    static readonly protected string[] sqlCols =
    {
     "[Created]", "[Id]", "[Modified]", "[ModifiedBy]", "[PersonREF]"
     , "[TaskHeadingREF]", "[TaskRoleREF]", "[Timestamp]"
    };
    static public string SqlColumnList { get { return string.Join(",", sqlCols); } }
    static public string[] SqlCols { get { return sqlCols; } }

    // set database connection and other initial values
    public DbTaskHeadingRole(SQL.DBConnection dbConnection)
    {
      base.dbConnection = dbConnection;
      tableName = "TaskHeadingRole";
      identityColumnName = "Id";
      sqlColumns = string.Join(",",  sqlCols);
    }

		public string TableName { get { return tableName; } set { tableName = value; } }

    public bool GetById(int Id, out DdTaskHeadingRole buffer)
    {
      DsTaskHeadingRole dsTaskHeadingRole = new DsTaskHeadingRole();
      dsTaskHeadingRole.Buffer.Id = Id;
      if (!GetById(ref dsTaskHeadingRole)) 
      {
        buffer = new DdTaskHeadingRole();
        return false;
      }
      buffer = dsTaskHeadingRole.Buffer;
      return true;
    }

    public bool GetById(ref DsTaskHeadingRole xStr)
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
        int PersonREF
      , int TaskHeadingREF
      , int TaskRoleREF
      , out DdTaskHeadingRole buffer)
    {
      DsTaskHeadingRole dsTaskHeadingRole = new DsTaskHeadingRole();
      dsTaskHeadingRole.Buffer.PersonREF = PersonREF;
      dsTaskHeadingRole.Buffer.TaskHeadingREF = TaskHeadingREF;
      dsTaskHeadingRole.Buffer.TaskRoleREF = TaskRoleREF;
      if (!GetByPK(ref dsTaskHeadingRole))
      {
        buffer = new DdTaskHeadingRole();
        return false;
      }
      buffer = dsTaskHeadingRole.Buffer;
      return true;
    }

    public bool GetByPK(ref DsTaskHeadingRole xStr)
    {
      string sql = "SELECT " + sqlColumns
      + " FROM " + tableName + NOLOCKSQL
      + " WHERE PersonREF = " + xStr.Buffer.PersonREF.ToString()
      + " AND TaskHeadingREF = " + xStr.Buffer.TaskHeadingREF.ToString()
      + " AND TaskRoleREF = " + xStr.Buffer.TaskRoleREF.ToString();
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

    public bool UpdateById(ref DsTaskHeadingRole xStr)
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

    public bool UpdateByPK(ref DsTaskHeadingRole xStr)
    {
      int rowsUpdated = 0;
      if (xStr.Modified())
      {
        string sql = "UPDATE " + tableName + " SET " + BuildUpdateSQL(xStr) + " WHERE"
      + " PersonREF = " + xStr.Buffer.PersonREF.ToString()
      + " AND TaskHeadingREF = " + xStr.Buffer.TaskHeadingREF.ToString()
      + " AND TaskRoleREF = " + xStr.Buffer.TaskRoleREF.ToString();
        if(!UpdateSQL(sql)) return false;
        rowsUpdated = _rowsAffected;
      }
      bool ok = GetByPK(ref xStr);
      _rowsAffected = rowsUpdated;
      return ok;
    }

    public bool DeleteByPK(
        int PersonREF
      , int TaskHeadingREF
      , int TaskRoleREF)
    {
      string sql = "DELETE FROM " + tableName + " WHERE"
      + " PersonREF = " + PersonREF.ToString()
      + " AND TaskHeadingREF = " + TaskHeadingREF.ToString()
      + " AND TaskRoleREF = " + TaskRoleREF.ToString();
      return DeleteSQL(sql);
    }

    public bool DeleteByPK(ref DsTaskHeadingRole xStr)
    {
      string sql = "DELETE FROM " + tableName + " WHERE"
      + " PersonREF = " + xStr.Buffer.PersonREF.ToString()
      + " AND TaskHeadingREF = " + xStr.Buffer.TaskHeadingREF.ToString()
      + " AND TaskRoleREF = " + xStr.Buffer.TaskRoleREF.ToString();
      return DeleteSQL(sql);
    }
    public bool Insert(ref DsTaskHeadingRole xStr)
    {
      int Id;
      string sql = BuildInsertSQL(xStr);
      if (!InsertIdSQL(sql, out Id)) return false;
      xStr.Buffer.Id = Id;
      return GetById(ref xStr);
    }

    public bool GetBySql(string sqlWhere, ref DsTaskHeadingRole xStr)
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


    public DnTaskHeadingRole Fill(string xWhere, string xOrder, int xTop, bool xNoLock)
    {
      System.Data.DataTable dt = FillDataTable(xWhere, xOrder, xTop, xNoLock);
      DnTaskHeadingRole TaskHeadingRoleList = new DnTaskHeadingRole(dt.Rows.Count);
      foreach(System.Data.DataRow adr in dt.Rows)
      {
        TaskHeadingRoleList.Add(Load(adr).Buffer);
      }
      return TaskHeadingRoleList;
    }

    static public DsTaskHeadingRole Load(System.Data.DataRow dr)
    {
      DsTaskHeadingRole tStr = new DsTaskHeadingRole();
      tStr.ClearBuffer();
      if (dr[idxCreated] != System.DBNull.Value) tStr.Buffer.Created = (DateTime)dr[idxCreated];
      if (dr[idxId] != System.DBNull.Value) tStr.Buffer.Id = (int)dr[idxId];
      if (dr[idxModified] != System.DBNull.Value) tStr.Buffer.Modified = (DateTime)dr[idxModified];
      if (dr[idxModifiedBy] != System.DBNull.Value) tStr.Buffer.ModifiedBy = (string)dr[idxModifiedBy];
      if (dr[idxPersonREF] != System.DBNull.Value) tStr.Buffer.PersonREF = (int)dr[idxPersonREF];
      if (dr[idxTaskHeadingREF] != System.DBNull.Value) tStr.Buffer.TaskHeadingREF = (int)dr[idxTaskHeadingREF];
      if (dr[idxTaskRoleREF] != System.DBNull.Value) tStr.Buffer.TaskRoleREF = (int)dr[idxTaskRoleREF];
      if (dr[idxTimestamp] != System.DBNull.Value) tStr.Buffer.Timestamp = (byte[])dr[idxTimestamp];
      return tStr;
    }

    public string BuildInsertSQL(DsTaskHeadingRole xStr)
    {
      SQL.SqlCommandBuilder sc = new SQL.SqlCommandBuilder(
        SQL.sqlVerb.Insert, tableName);
      if (xStr.modModified)
        sc.AddColumn(sqlCols[idxModified], xStr.Buffer.Modified);
      if (xStr.modModifiedBy)
        sc.AddColumn(sqlCols[idxModifiedBy], xStr.Buffer.ModifiedBy);
      if (xStr.modPersonREF)
        sc.AddColumn(sqlCols[idxPersonREF], xStr.Buffer.PersonREF);
      if (xStr.modTaskHeadingREF)
        sc.AddColumn(sqlCols[idxTaskHeadingREF], xStr.Buffer.TaskHeadingREF);
      if (xStr.modTaskRoleREF)
        sc.AddColumn(sqlCols[idxTaskRoleREF], xStr.Buffer.TaskRoleREF);
      return sc.CommandText;
    }

    public string BuildUpdateSQL(DsTaskHeadingRole xStr)
    {
      SQL.SqlCommandBuilder sc = new SQL.SqlCommandBuilder(SQL.sqlVerb.Update);
      if (xStr.modModified)
        sc.AddColumn(sqlCols[idxModified], xStr.Buffer.Modified);
      if (xStr.modModifiedBy)
        sc.AddColumn(sqlCols[idxModifiedBy], xStr.Buffer.ModifiedBy);
      if (xStr.modPersonREF)
        sc.AddColumn(sqlCols[idxPersonREF], xStr.Buffer.PersonREF);
      if (xStr.modTaskHeadingREF)
        sc.AddColumn(sqlCols[idxTaskHeadingREF], xStr.Buffer.TaskHeadingREF);
      if (xStr.modTaskRoleREF)
        sc.AddColumn(sqlCols[idxTaskRoleREF], xStr.Buffer.TaskRoleREF);
      return sc.ColumnList;
    }

    //  Index = IX_TaskHeadingRole
    public bool GetBy_IX_TaskHeadingRole(
      int PersonREF
    , int TaskHeadingREF
    , int TaskRoleREF
    , out DdTaskHeadingRole buffer)
  {
    string sql = "SELECT " + sqlColumns
    + " FROM " + tableName + NOLOCKSQL
    + " WHERE PersonREF = " + PersonREF.ToString()
    + " AND TaskHeadingREF = " + TaskHeadingREF.ToString()
    + " AND TaskRoleREF = " + TaskRoleREF.ToString();
    System.Data.DataRow dr;
    if (GetSQL(sql, out dr))
    {
      DsTaskHeadingRole dsTaskHeadingRole = Load(dr);
      buffer = dsTaskHeadingRole.Buffer;
      return true;
    }
    else
    {
      buffer = new DdTaskHeadingRole();
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
		
		static public DdTaskHeadingRole LoadRow(System.Data.SqlClient.SqlDataReader reader)
		{
			DdTaskHeadingRole rowBuffer = new DdTaskHeadingRole();
			rowBuffer.Clear();
			if (!reader.IsDBNull(idxCreated)) rowBuffer.Created = reader.GetDateTime(idxCreated);
			if (!reader.IsDBNull(idxId)) rowBuffer.Id = reader.GetInt32(idxId);
			if (!reader.IsDBNull(idxModified)) rowBuffer.Modified = reader.GetDateTime(idxModified);
			if (!reader.IsDBNull(idxModifiedBy)) rowBuffer.ModifiedBy = reader.GetString(idxModifiedBy);
			if (!reader.IsDBNull(idxPersonREF)) rowBuffer.PersonREF = reader.GetInt32(idxPersonREF);
			if (!reader.IsDBNull(idxTaskHeadingREF)) rowBuffer.TaskHeadingREF = reader.GetInt32(idxTaskHeadingREF);
			if (!reader.IsDBNull(idxTaskRoleREF)) rowBuffer.TaskRoleREF = reader.GetInt32(idxTaskRoleREF);
			if (!reader.IsDBNull(idxTimestamp)) rowBuffer.Timestamp = GetTimestamp(idxTimestamp, reader);
			return rowBuffer;
		}
  }
  [Serializable]
  public class DsTaskHeadingRole
  {
    public DdTaskHeadingRole Buffer = new DdTaskHeadingRole();

    public bool IsNew;
    public bool IsDeleted;

    public bool modModified;
    public bool modModifiedBy;
    public bool modPersonREF;
    public bool modTaskHeadingREF;
    public bool modTaskRoleREF;

    public object Tag;
    public int RowsAffected;
    public string ResultCode;
    public string ResultMessage;

    public bool Modified()
    {
      return
        modModified
     || modModifiedBy
     || modPersonREF
     || modTaskHeadingREF
     || modTaskRoleREF;
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
      modModified = false;
      modModifiedBy = false;
      modPersonREF = false;
      modTaskHeadingREF = false;
      modTaskRoleREF = false;
    }

    public void SetModFlags()
    {
      modModified = true;
      modModifiedBy = true;
      modPersonREF = true;
      modTaskHeadingREF = true;
      modTaskRoleREF = true;
    }
  }

  [Serializable]
  public class DdTaskHeadingRole : ASL.Forms.DdBase
  {
    public int PersonREF { get; set; }
    public int TaskHeadingREF { get; set; }
    public int TaskRoleREF { get; set; }

    public const string PersonREF_N = "PersonREF";
    public const string TaskHeadingREF_N = "TaskHeadingREF";
    public const string TaskRoleREF_N = "TaskRoleREF";


    public DdTaskHeadingRole()
	  : base()
    {
      Clear();
    }

    public DdTaskHeadingRole(DdTaskHeadingRole original)
	  : base(original)
    {
      PersonREF = original.PersonREF;
      TaskHeadingREF = original.TaskHeadingREF;
      TaskRoleREF = original.TaskRoleREF;
    }

    public override void Clear()
    {
      base.Clear();
      PersonREF = 0;
      TaskHeadingREF = 0;
      TaskRoleREF = 0;
    }

    public override void SetDefaults()
    {
      base.SetDefaults();
      PersonREF = (1);
      TaskHeadingREF = (1);
      TaskRoleREF = (1);
    }
  }

  [Serializable]
  public class DnTaskHeadingRole : System.Collections.Generic.List<DdTaskHeadingRole>
  {
    public DnTaskHeadingRole() : base() {}
    public DnTaskHeadingRole(int xCapacity) : base(xCapacity) {}

    public new DdTaskHeadingRole this[int xIndex]
    {
      get { return (DdTaskHeadingRole) base[xIndex]; }
      set { base[xIndex] = value; }
    }
  }


}
