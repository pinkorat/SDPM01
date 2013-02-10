// Generated: Sun Jan 27, 2013 10:54:20
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
  public class DaStep : DbStep, ASL.ApplicatFieldType.IDaForm_I
#else
  public class DaStep : DbStep
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
      public string StepID;
      public int TaskREF;
		}
		public class FetchEntry
		{
			public int hitCount = 1;
			public DdStep ddStep;
			public FetchEntry(DdStep ddStep) { this.ddStep = ddStep; }
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
    public DateTime DueDate
    {
      get { return store.Buffer.DueDate; }

      set 
      { 
#if __REALCHANGE__
        if (store.Buffer.DueDate != value)
        {
          store.Buffer.DueDate = value; 
          store.modDueDate = true;
        }
#else
        store.Buffer.DueDate = value; 
        store.modDueDate = true;
#endif
      }
    }
    public double EstHours
    {
      get { return store.Buffer.EstHours; }

      set 
      { 
#if __REALCHANGE__
        if (store.Buffer.EstHours != value)
        {
          store.Buffer.EstHours = value; 
          store.modEstHours = true;
        }
#else
        store.Buffer.EstHours = value; 
        store.modEstHours = true;
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
        if (value.Length > 50) InvalidateField("Too long", "Step.ModifiedBy");
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
    public string StepID
    {
      get { return store.Buffer.StepID; }

      set 
      { 
        if (value.Length > 200) InvalidateField("Too long", "Step.StepID");
#if __REALCHANGE__
        if (store.Buffer.StepID != value)
        {
          store.Buffer.StepID = value; 
          store.modStepID = true;
        }
#else
        store.Buffer.StepID = value; 
        store.modStepID = true;
#endif
      }
    }
    public int TaskREF
    {
      get { return store.Buffer.TaskREF; }

      set 
      { 
#if __REALCHANGE__
        if (store.Buffer.TaskREF != value)
        {
          store.Buffer.TaskREF = value; 
          store.modTaskREF = true;
        }
#else
        store.Buffer.TaskREF = value; 
        store.modTaskREF = true;
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
        if (value.Length > 200) InvalidateField("Too long", "Step.Title");
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
      items["DueDate"] = DueDate;
      items["EstHours"] = EstHours;
      items["Id"] = Id;
      items["Modified"] = Modified;
      items["ModifiedBy"] = ModifiedBy;
      items["StepID"] = StepID;
      items["TaskREF"] = TaskREF;
      items["Title"] = Title;
      return items;
    }

    public void SetFromList(SortedList<string, object> items)
    {
      if (items.ContainsKey("Description")) Description= (string)items["Description"];
      if (items.ContainsKey("DueDate")) DueDate= (DateTime)items["DueDate"];
      if (items.ContainsKey("EstHours")) EstHours= (double)items["EstHours"];
      if (items.ContainsKey("Modified")) Modified= (DateTime)items["Modified"];
      if (items.ContainsKey("ModifiedBy")) ModifiedBy= (string)items["ModifiedBy"];
      if (items.ContainsKey("StepID")) StepID= (string)items["StepID"];
      if (items.ContainsKey("TaskREF")) TaskREF= (int)items["TaskREF"];
      if (items.ContainsKey("Title")) Title= (string)items["Title"];
    }
#endif
//??EndExpand 1/27/2013 10:54:20 AM
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
			DnStep dnStep = FillByParent(parentREF);
			ArrayList choices = new ArrayList();
			IEnumerator en = dnStep.GetEnumerator();
			DdStep ddStep;
			while (en.MoveNext())
			{
				ddStep = (DdStep)en.Current;
				choices.Add(ddStep.Id.ToString() + "," + ddStep.Description);
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

    private DsStep store = new DsStep();

    public DaStep(SQL.DBConnection dbConnection) : base(dbConnection)
    {
      store.ClearAll();
    }

    public void Clear()
    {
      store.ClearAll();
    }

    public bool GetByPK(string StepID, int TaskREF)
    {
      store.Buffer.StepID = StepID;
      store.Buffer.TaskREF = TaskREF;
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

    public void SetBuffer(DdStep buffer)
    {
      store.Buffer = buffer;
    }

    public bool _IsModified
    {
      get { return store.Modified(); }
    }

    public DdStep GetBuffer()
    {
      return store.Buffer; 
    }

    public void SetModFlags() { store.SetModFlags(); }
    public void ClearModFlags() { store.ClearModFlags(); }
    public void SetDefaults() { store.Buffer.SetDefaults(); }

    #region fetch cache
#if __FETCHCACHE__
		public bool FetchByPK(string StepID, int TaskREF)
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
      key.StepID = StepID;
      key.TaskREF = TaskREF;
			if (fetchTable.Contains(key))
			{
				_hitCount++;
				ent = (FetchEntry)fetchTable[key];
				SetBuffer(ent.ddStep);
				if (ent.hitCount < int.MaxValue) ent.hitCount++;
				return true;
			}
			if (missTable.Contains(key)) return false;
			
			_ioCount++;
      store.Buffer.StepID = StepID;
      store.Buffer.TaskREF = TaskREF;
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
		public DnStep Fill()
		{
			string sqlWhere = "Id >= 100";
			return Fill(sqlWhere, "StepID", 0, true);
		}
		public DnStep FillByTask(int parentREF)
		{
			string sqlWhere = string.Format("TaskREF={0}", parentREF);
			return Fill(sqlWhere, "StepID", 0, true);
		}
		#endregion extend
  }


  public class DbStep : ASL.SQL.TableDataObject
  {
    private const int idxCreated = 0;
    private const int idxDescription = 1;
    private const int idxDueDate = 2;
    private const int idxEstHours = 3;
    private const int idxId = 4;
    private const int idxModified = 5;
    private const int idxModifiedBy = 6;
    private const int idxStepID = 7;
    private const int idxTaskREF = 8;
    private const int idxTimestamp = 9;
    private const int idxTitle = 10;
    private const int idxNUMCOLS = 11;
    // Column names
    static readonly protected string[] sqlCols =
    {
     "[Created]", "[Description]", "[DueDate]", "[EstHours]", "[Id]", "[Modified]"
     , "[ModifiedBy]", "[StepID]", "[TaskREF]", "[Timestamp]", "[Title]"
    };
    static public string SqlColumnList { get { return string.Join(",", sqlCols); } }
    static public string[] SqlCols { get { return sqlCols; } }

    // set database connection and other initial values
    public DbStep(SQL.DBConnection dbConnection)
    {
      base.dbConnection = dbConnection;
      tableName = "Step";
      identityColumnName = "Id";
      sqlColumns = string.Join(",",  sqlCols);
    }

		public string TableName { get { return tableName; } set { tableName = value; } }

    public bool GetById(int Id, out DdStep buffer)
    {
      DsStep dsStep = new DsStep();
      dsStep.Buffer.Id = Id;
      if (!GetById(ref dsStep)) 
      {
        buffer = new DdStep();
        return false;
      }
      buffer = dsStep.Buffer;
      return true;
    }

    public bool GetById(ref DsStep xStr)
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
        string StepID
      , int TaskREF
      , out DdStep buffer)
    {
      DsStep dsStep = new DsStep();
      dsStep.Buffer.StepID = StepID;
      dsStep.Buffer.TaskREF = TaskREF;
      if (!GetByPK(ref dsStep))
      {
        buffer = new DdStep();
        return false;
      }
      buffer = dsStep.Buffer;
      return true;
    }

    public bool GetByPK(ref DsStep xStr)
    {
      string sql = "SELECT " + sqlColumns
      + " FROM " + tableName + NOLOCKSQL
      + " WHERE StepID = " + TXT.q1(xStr.Buffer.StepID)
      + " AND TaskREF = " + xStr.Buffer.TaskREF.ToString();
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

    public bool UpdateById(ref DsStep xStr)
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

    public bool UpdateByPK(ref DsStep xStr)
    {
      int rowsUpdated = 0;
      if (xStr.Modified())
      {
        string sql = "UPDATE " + tableName + " SET " + BuildUpdateSQL(xStr) + " WHERE"
      + " StepID = " + TXT.q1(xStr.Buffer.StepID)
      + " AND TaskREF = " + xStr.Buffer.TaskREF.ToString();
        if(!UpdateSQL(sql)) return false;
        rowsUpdated = _rowsAffected;
      }
      bool ok = GetByPK(ref xStr);
      _rowsAffected = rowsUpdated;
      return ok;
    }

    public bool DeleteByPK(
        string StepID
      , int TaskREF)
    {
      string sql = "DELETE FROM " + tableName + " WHERE"
      + " StepID = " + TXT.q1(StepID)
      + " AND TaskREF = " + TaskREF.ToString();
      return DeleteSQL(sql);
    }

    public bool DeleteByPK(ref DsStep xStr)
    {
      string sql = "DELETE FROM " + tableName + " WHERE"
      + " StepID = " + TXT.q1(xStr.Buffer.StepID)
      + " AND TaskREF = " + xStr.Buffer.TaskREF.ToString();
      return DeleteSQL(sql);
    }
    public bool Insert(ref DsStep xStr)
    {
      int Id;
      string sql = BuildInsertSQL(xStr);
      if (!InsertIdSQL(sql, out Id)) return false;
      xStr.Buffer.Id = Id;
      return GetById(ref xStr);
    }

    public bool GetBySql(string sqlWhere, ref DsStep xStr)
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


    public DnStep Fill(string xWhere, string xOrder, int xTop, bool xNoLock)
    {
      System.Data.DataTable dt = FillDataTable(xWhere, xOrder, xTop, xNoLock);
      DnStep StepList = new DnStep(dt.Rows.Count);
      foreach(System.Data.DataRow adr in dt.Rows)
      {
        StepList.Add(Load(adr).Buffer);
      }
      return StepList;
    }

    static public DsStep Load(System.Data.DataRow dr)
    {
      DsStep tStr = new DsStep();
      tStr.ClearBuffer();
      if (dr[idxCreated] != System.DBNull.Value) tStr.Buffer.Created = (DateTime)dr[idxCreated];
      if (dr[idxDescription] != System.DBNull.Value) tStr.Buffer.Description = (string)dr[idxDescription];
      if (dr[idxDueDate] != System.DBNull.Value) tStr.Buffer.DueDate = (DateTime)dr[idxDueDate];
      if (dr[idxEstHours] != System.DBNull.Value) tStr.Buffer.EstHours = (double)dr[idxEstHours];
      if (dr[idxId] != System.DBNull.Value) tStr.Buffer.Id = (int)dr[idxId];
      if (dr[idxModified] != System.DBNull.Value) tStr.Buffer.Modified = (DateTime)dr[idxModified];
      if (dr[idxModifiedBy] != System.DBNull.Value) tStr.Buffer.ModifiedBy = (string)dr[idxModifiedBy];
      if (dr[idxStepID] != System.DBNull.Value) tStr.Buffer.StepID = (string)dr[idxStepID];
      if (dr[idxTaskREF] != System.DBNull.Value) tStr.Buffer.TaskREF = (int)dr[idxTaskREF];
      if (dr[idxTimestamp] != System.DBNull.Value) tStr.Buffer.Timestamp = (byte[])dr[idxTimestamp];
      if (dr[idxTitle] != System.DBNull.Value) tStr.Buffer.Title = (string)dr[idxTitle];
      return tStr;
    }

    public string BuildInsertSQL(DsStep xStr)
    {
      SQL.SqlCommandBuilder sc = new SQL.SqlCommandBuilder(
        SQL.sqlVerb.Insert, tableName);
      if (xStr.modDescription)
        sc.AddColumn(sqlCols[idxDescription], xStr.Buffer.Description);
      if (xStr.modDueDate)
        sc.AddColumn(sqlCols[idxDueDate], xStr.Buffer.DueDate);
      if (xStr.modEstHours)
        sc.AddColumn(sqlCols[idxEstHours], xStr.Buffer.EstHours);
      if (xStr.modModified)
        sc.AddColumn(sqlCols[idxModified], xStr.Buffer.Modified);
      if (xStr.modModifiedBy)
        sc.AddColumn(sqlCols[idxModifiedBy], xStr.Buffer.ModifiedBy);
      if (xStr.modStepID)
        sc.AddColumn(sqlCols[idxStepID], xStr.Buffer.StepID);
      if (xStr.modTaskREF)
        sc.AddColumn(sqlCols[idxTaskREF], xStr.Buffer.TaskREF);
      if (xStr.modTitle)
        sc.AddColumn(sqlCols[idxTitle], xStr.Buffer.Title);
      return sc.CommandText;
    }

    public string BuildUpdateSQL(DsStep xStr)
    {
      SQL.SqlCommandBuilder sc = new SQL.SqlCommandBuilder(SQL.sqlVerb.Update);
      if (xStr.modDescription)
        sc.AddColumn(sqlCols[idxDescription], xStr.Buffer.Description);
      if (xStr.modDueDate)
        sc.AddColumn(sqlCols[idxDueDate], xStr.Buffer.DueDate);
      if (xStr.modEstHours)
        sc.AddColumn(sqlCols[idxEstHours], xStr.Buffer.EstHours);
      if (xStr.modModified)
        sc.AddColumn(sqlCols[idxModified], xStr.Buffer.Modified);
      if (xStr.modModifiedBy)
        sc.AddColumn(sqlCols[idxModifiedBy], xStr.Buffer.ModifiedBy);
      if (xStr.modStepID)
        sc.AddColumn(sqlCols[idxStepID], xStr.Buffer.StepID);
      if (xStr.modTaskREF)
        sc.AddColumn(sqlCols[idxTaskREF], xStr.Buffer.TaskREF);
      if (xStr.modTitle)
        sc.AddColumn(sqlCols[idxTitle], xStr.Buffer.Title);
      return sc.ColumnList;
    }

    //  Index = IX_Step
    public bool GetBy_IX_Step(
      string StepID
    , int TaskREF
    , out DdStep buffer)
  {
    string sql = "SELECT " + sqlColumns
    + " FROM " + tableName + NOLOCKSQL
    + " WHERE StepID = " + TXT.q1(StepID)
    + " AND TaskREF = " + TaskREF.ToString();
    System.Data.DataRow dr;
    if (GetSQL(sql, out dr))
    {
      DsStep dsStep = Load(dr);
      buffer = dsStep.Buffer;
      return true;
    }
    else
    {
      buffer = new DdStep();
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
		
		static public DdStep LoadRow(System.Data.SqlClient.SqlDataReader reader)
		{
			DdStep rowBuffer = new DdStep();
			rowBuffer.Clear();
			if (!reader.IsDBNull(idxCreated)) rowBuffer.Created = reader.GetDateTime(idxCreated);
			if (!reader.IsDBNull(idxDescription)) rowBuffer.Description = reader.GetString(idxDescription);
			if (!reader.IsDBNull(idxDueDate)) rowBuffer.DueDate = reader.GetDateTime(idxDueDate);
			if (!reader.IsDBNull(idxEstHours)) rowBuffer.EstHours = reader.GetDouble(idxEstHours);
			if (!reader.IsDBNull(idxId)) rowBuffer.Id = reader.GetInt32(idxId);
			if (!reader.IsDBNull(idxModified)) rowBuffer.Modified = reader.GetDateTime(idxModified);
			if (!reader.IsDBNull(idxModifiedBy)) rowBuffer.ModifiedBy = reader.GetString(idxModifiedBy);
			if (!reader.IsDBNull(idxStepID)) rowBuffer.StepID = reader.GetString(idxStepID);
			if (!reader.IsDBNull(idxTaskREF)) rowBuffer.TaskREF = reader.GetInt32(idxTaskREF);
			if (!reader.IsDBNull(idxTimestamp)) rowBuffer.Timestamp = GetTimestamp(idxTimestamp, reader);
			if (!reader.IsDBNull(idxTitle)) rowBuffer.Title = reader.GetString(idxTitle);
			return rowBuffer;
		}
  }
  [Serializable]
  public class DsStep
  {
    public DdStep Buffer = new DdStep();

    public bool IsNew;
    public bool IsDeleted;

    public bool modDescription;
    public bool modDueDate;
    public bool modEstHours;
    public bool modModified;
    public bool modModifiedBy;
    public bool modStepID;
    public bool modTaskREF;
    public bool modTitle;

    public object Tag;
    public int RowsAffected;
    public string ResultCode;
    public string ResultMessage;

    public bool Modified()
    {
      return
        modDescription
     || modDueDate
     || modEstHours
     || modModified
     || modModifiedBy
     || modStepID
     || modTaskREF
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
      modDueDate = false;
      modEstHours = false;
      modModified = false;
      modModifiedBy = false;
      modStepID = false;
      modTaskREF = false;
      modTitle = false;
    }

    public void SetModFlags()
    {
      modDescription = true;
      modDueDate = true;
      modEstHours = true;
      modModified = true;
      modModifiedBy = true;
      modStepID = true;
      modTaskREF = true;
      modTitle = true;
    }
  }

  [Serializable]
  public class DdStep : ASL.Forms.DdBase
  {
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public double EstHours { get; set; }
    public string StepID { get; set; }
    public int TaskREF { get; set; }
    public string Title { get; set; }

    public const string Description_N = "Description";
    public const string DueDate_N = "DueDate";
    public const string EstHours_N = "EstHours";
    public const string StepID_N = "StepID";
    public const string TaskREF_N = "TaskREF";
    public const string Title_N = "Title";

    public const int Description_L = -1;
    public const int StepID_L = 200;
    public const int Title_L = 200;

    public DdStep()
	  : base()
    {
      Clear();
    }

    public DdStep(DdStep original)
	  : base(original)
    {
      Description = original.Description;
      DueDate = original.DueDate;
      EstHours = original.EstHours;
      StepID = original.StepID;
      TaskREF = original.TaskREF;
      Title = original.Title;
    }

    public override void Clear()
    {
      base.Clear();
      Description = "";
      DueDate = DateTime.MinValue;
      EstHours = 0;
      StepID = "";
      TaskREF = 0;
      Title = "";
    }

    public override void SetDefaults()
    {
      base.SetDefaults();
      Description = string.Empty;
      DueDate = ASL.Run.Config.EMPTYDATE;
      EstHours = (0);
      StepID = string.Empty;
      TaskREF = (1);
      Title = string.Empty;
    }
  }

  [Serializable]
  public class DnStep : System.Collections.Generic.List<DdStep>
  {
    public DnStep() : base() {}
    public DnStep(int xCapacity) : base(xCapacity) {}

    public new DdStep this[int xIndex]
    {
      get { return (DdStep) base[xIndex]; }
      set { base[xIndex] = value; }
    }
  }


}
