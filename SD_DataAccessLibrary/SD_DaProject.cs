// Generated: Sun Jan 27, 2013 10:54:15
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
  public class DaProject : DbProject, ASL.ApplicatFieldType.IDaForm_I
#else
  public class DaProject : DbProject
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
      public int TaskHeadingREF;
		}
		public class FetchEntry
		{
			public int hitCount = 1;
			public DdProject ddProject;
			public FetchEntry(DdProject ddProject) { this.ddProject = ddProject; }
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

    public int ClientREF
    {
      get { return store.Buffer.ClientREF; }

      set 
      { 
#if __REALCHANGE__
        if (store.Buffer.ClientREF != value)
        {
          store.Buffer.ClientREF = value; 
          store.modClientREF = true;
        }
#else
        store.Buffer.ClientREF = value; 
        store.modClientREF = true;
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
        if (value.Length > 50) InvalidateField("Too long", "Project.ModifiedBy");
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
    public string ProjectID
    {
      get { return store.Buffer.ProjectID; }

      set 
      { 
        if (value.Length > 200) InvalidateField("Too long", "Project.ProjectID");
#if __REALCHANGE__
        if (store.Buffer.ProjectID != value)
        {
          store.Buffer.ProjectID = value; 
          store.modProjectID = true;
        }
#else
        store.Buffer.ProjectID = value; 
        store.modProjectID = true;
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
    public byte[] Timestamp
    {
      get { return store.Buffer.Timestamp; }

    }
    public string Title
    {
      get { return store.Buffer.Title; }

      set 
      { 
        if (value.Length > 200) InvalidateField("Too long", "Project.Title");
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
      items["ClientREF"] = ClientREF;
      items["Created"] = Created;
      items["Description"] = Description;
      items["Id"] = Id;
      items["Modified"] = Modified;
      items["ModifiedBy"] = ModifiedBy;
      items["ProjectID"] = ProjectID;
      items["TaskHeadingREF"] = TaskHeadingREF;
      items["Title"] = Title;
      return items;
    }

    public void SetFromList(SortedList<string, object> items)
    {
      if (items.ContainsKey("ClientREF")) ClientREF= (int)items["ClientREF"];
      if (items.ContainsKey("Description")) Description= (string)items["Description"];
      if (items.ContainsKey("Modified")) Modified= (DateTime)items["Modified"];
      if (items.ContainsKey("ModifiedBy")) ModifiedBy= (string)items["ModifiedBy"];
      if (items.ContainsKey("ProjectID")) ProjectID= (string)items["ProjectID"];
      if (items.ContainsKey("TaskHeadingREF")) TaskHeadingREF= (int)items["TaskHeadingREF"];
      if (items.ContainsKey("Title")) Title= (string)items["Title"];
    }
#endif
//??EndExpand 1/27/2013 10:54:15 AM
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
			DnProject dnProject = FillByParent(parentREF);
			ArrayList choices = new ArrayList();
			IEnumerator en = dnProject.GetEnumerator();
			DdProject ddProject;
			while (en.MoveNext())
			{
				ddProject = (DdProject)en.Current;
				choices.Add(ddProject.Id.ToString() + "," + ddProject.Description);
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

    private DsProject store = new DsProject();

    public DaProject(SQL.DBConnection dbConnection) : base(dbConnection)
    {
      store.ClearAll();
    }

    public void Clear()
    {
      store.ClearAll();
    }

    public bool GetByPK(int TaskHeadingREF)
    {
      store.Buffer.TaskHeadingREF = TaskHeadingREF;
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

    public void SetBuffer(DdProject buffer)
    {
      store.Buffer = buffer;
    }

    public bool _IsModified
    {
      get { return store.Modified(); }
    }

    public DdProject GetBuffer()
    {
      return store.Buffer; 
    }

    public void SetModFlags() { store.SetModFlags(); }
    public void ClearModFlags() { store.ClearModFlags(); }
    public void SetDefaults() { store.Buffer.SetDefaults(); }

    #region fetch cache
#if __FETCHCACHE__
		public bool FetchByPK(int TaskHeadingREF)
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
      key.TaskHeadingREF = TaskHeadingREF;
			if (fetchTable.Contains(key))
			{
				_hitCount++;
				ent = (FetchEntry)fetchTable[key];
				SetBuffer(ent.ddProject);
				if (ent.hitCount < int.MaxValue) ent.hitCount++;
				return true;
			}
			if (missTable.Contains(key)) return false;
			
			_ioCount++;
      store.Buffer.TaskHeadingREF = TaskHeadingREF;
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
		public DnProject Fill()
		{
			string sqlWhere = "Id >= 100";
			return Fill(sqlWhere, "ProjectID", 0, true);
		}
		public DnProject FillByClient(int parentREF)
		{
			string sqlWhere = string.Format("ClientREF={0}", parentREF);
			return Fill(sqlWhere, "ProjectID", 0, true);
		}
		#endregion extend
  }


  public class DbProject : ASL.SQL.TableDataObject
  {
    private const int idxClientREF = 0;
    private const int idxCreated = 1;
    private const int idxDescription = 2;
    private const int idxId = 3;
    private const int idxModified = 4;
    private const int idxModifiedBy = 5;
    private const int idxProjectID = 6;
    private const int idxTaskHeadingREF = 7;
    private const int idxTimestamp = 8;
    private const int idxTitle = 9;
    private const int idxNUMCOLS = 10;
    // Column names
    static readonly protected string[] sqlCols =
    {
     "[ClientREF]", "[Created]", "[Description]", "[Id]", "[Modified]"
     , "[ModifiedBy]", "[ProjectID]", "[TaskHeadingREF]", "[Timestamp]", "[Title]"
    };
    static public string SqlColumnList { get { return string.Join(",", sqlCols); } }
    static public string[] SqlCols { get { return sqlCols; } }

    // set database connection and other initial values
    public DbProject(SQL.DBConnection dbConnection)
    {
      base.dbConnection = dbConnection;
      tableName = "Project";
      identityColumnName = "Id";
      sqlColumns = string.Join(",",  sqlCols);
    }

		public string TableName { get { return tableName; } set { tableName = value; } }

    public bool GetById(int Id, out DdProject buffer)
    {
      DsProject dsProject = new DsProject();
      dsProject.Buffer.Id = Id;
      if (!GetById(ref dsProject)) 
      {
        buffer = new DdProject();
        return false;
      }
      buffer = dsProject.Buffer;
      return true;
    }

    public bool GetById(ref DsProject xStr)
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
        int TaskHeadingREF
      , out DdProject buffer)
    {
      DsProject dsProject = new DsProject();
      dsProject.Buffer.TaskHeadingREF = TaskHeadingREF;
      if (!GetByPK(ref dsProject))
      {
        buffer = new DdProject();
        return false;
      }
      buffer = dsProject.Buffer;
      return true;
    }

    public bool GetByPK(ref DsProject xStr)
    {
      string sql = "SELECT " + sqlColumns
      + " FROM " + tableName + NOLOCKSQL
      + " WHERE TaskHeadingREF = " + xStr.Buffer.TaskHeadingREF.ToString();
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

    public bool UpdateById(ref DsProject xStr)
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

    public bool UpdateByPK(ref DsProject xStr)
    {
      int rowsUpdated = 0;
      if (xStr.Modified())
      {
        string sql = "UPDATE " + tableName + " SET " + BuildUpdateSQL(xStr) + " WHERE"
      + " TaskHeadingREF = " + xStr.Buffer.TaskHeadingREF.ToString();
        if(!UpdateSQL(sql)) return false;
        rowsUpdated = _rowsAffected;
      }
      bool ok = GetByPK(ref xStr);
      _rowsAffected = rowsUpdated;
      return ok;
    }

    public bool DeleteByPK(
        int TaskHeadingREF)
    {
      string sql = "DELETE FROM " + tableName + " WHERE"
      + " TaskHeadingREF = " + TaskHeadingREF.ToString();
      return DeleteSQL(sql);
    }

    public bool DeleteByPK(ref DsProject xStr)
    {
      string sql = "DELETE FROM " + tableName + " WHERE"
      + " TaskHeadingREF = " + xStr.Buffer.TaskHeadingREF.ToString();
      return DeleteSQL(sql);
    }
    public bool Insert(ref DsProject xStr)
    {
      int Id;
      string sql = BuildInsertSQL(xStr);
      if (!InsertIdSQL(sql, out Id)) return false;
      xStr.Buffer.Id = Id;
      return GetById(ref xStr);
    }

    public bool GetBySql(string sqlWhere, ref DsProject xStr)
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


    public DnProject Fill(string xWhere, string xOrder, int xTop, bool xNoLock)
    {
      System.Data.DataTable dt = FillDataTable(xWhere, xOrder, xTop, xNoLock);
      DnProject ProjectList = new DnProject(dt.Rows.Count);
      foreach(System.Data.DataRow adr in dt.Rows)
      {
        ProjectList.Add(Load(adr).Buffer);
      }
      return ProjectList;
    }

    static public DsProject Load(System.Data.DataRow dr)
    {
      DsProject tStr = new DsProject();
      tStr.ClearBuffer();
      if (dr[idxClientREF] != System.DBNull.Value) tStr.Buffer.ClientREF = (int)dr[idxClientREF];
      if (dr[idxCreated] != System.DBNull.Value) tStr.Buffer.Created = (DateTime)dr[idxCreated];
      if (dr[idxDescription] != System.DBNull.Value) tStr.Buffer.Description = (string)dr[idxDescription];
      if (dr[idxId] != System.DBNull.Value) tStr.Buffer.Id = (int)dr[idxId];
      if (dr[idxModified] != System.DBNull.Value) tStr.Buffer.Modified = (DateTime)dr[idxModified];
      if (dr[idxModifiedBy] != System.DBNull.Value) tStr.Buffer.ModifiedBy = (string)dr[idxModifiedBy];
      if (dr[idxProjectID] != System.DBNull.Value) tStr.Buffer.ProjectID = (string)dr[idxProjectID];
      if (dr[idxTaskHeadingREF] != System.DBNull.Value) tStr.Buffer.TaskHeadingREF = (int)dr[idxTaskHeadingREF];
      if (dr[idxTimestamp] != System.DBNull.Value) tStr.Buffer.Timestamp = (byte[])dr[idxTimestamp];
      if (dr[idxTitle] != System.DBNull.Value) tStr.Buffer.Title = (string)dr[idxTitle];
      return tStr;
    }

    public string BuildInsertSQL(DsProject xStr)
    {
      SQL.SqlCommandBuilder sc = new SQL.SqlCommandBuilder(
        SQL.sqlVerb.Insert, tableName);
      if (xStr.modClientREF)
        sc.AddColumn(sqlCols[idxClientREF], xStr.Buffer.ClientREF);
      if (xStr.modDescription)
        sc.AddColumn(sqlCols[idxDescription], xStr.Buffer.Description);
      if (xStr.modModified)
        sc.AddColumn(sqlCols[idxModified], xStr.Buffer.Modified);
      if (xStr.modModifiedBy)
        sc.AddColumn(sqlCols[idxModifiedBy], xStr.Buffer.ModifiedBy);
      if (xStr.modProjectID)
        sc.AddColumn(sqlCols[idxProjectID], xStr.Buffer.ProjectID);
      if (xStr.modTaskHeadingREF)
        sc.AddColumn(sqlCols[idxTaskHeadingREF], xStr.Buffer.TaskHeadingREF);
      if (xStr.modTitle)
        sc.AddColumn(sqlCols[idxTitle], xStr.Buffer.Title);
      return sc.CommandText;
    }

    public string BuildUpdateSQL(DsProject xStr)
    {
      SQL.SqlCommandBuilder sc = new SQL.SqlCommandBuilder(SQL.sqlVerb.Update);
      if (xStr.modClientREF)
        sc.AddColumn(sqlCols[idxClientREF], xStr.Buffer.ClientREF);
      if (xStr.modDescription)
        sc.AddColumn(sqlCols[idxDescription], xStr.Buffer.Description);
      if (xStr.modModified)
        sc.AddColumn(sqlCols[idxModified], xStr.Buffer.Modified);
      if (xStr.modModifiedBy)
        sc.AddColumn(sqlCols[idxModifiedBy], xStr.Buffer.ModifiedBy);
      if (xStr.modProjectID)
        sc.AddColumn(sqlCols[idxProjectID], xStr.Buffer.ProjectID);
      if (xStr.modTaskHeadingREF)
        sc.AddColumn(sqlCols[idxTaskHeadingREF], xStr.Buffer.TaskHeadingREF);
      if (xStr.modTitle)
        sc.AddColumn(sqlCols[idxTitle], xStr.Buffer.Title);
      return sc.ColumnList;
    }

    //  Index = IX_Project
    public bool GetBy_IX_Project(
      int TaskHeadingREF
    , out DdProject buffer)
  {
    string sql = "SELECT " + sqlColumns
    + " FROM " + tableName + NOLOCKSQL
    + " WHERE TaskHeadingREF = " + TaskHeadingREF.ToString();
    System.Data.DataRow dr;
    if (GetSQL(sql, out dr))
    {
      DsProject dsProject = Load(dr);
      buffer = dsProject.Buffer;
      return true;
    }
    else
    {
      buffer = new DdProject();
      return false;
    }
  }

    //  Index = IX_Project_1
    public bool GetBy_IX_Project_1(
      string ProjectID
    , out DdProject buffer)
  {
    string sql = "SELECT " + sqlColumns
    + " FROM " + tableName + NOLOCKSQL
    + " WHERE ProjectID = " + TXT.q1(ProjectID);
    System.Data.DataRow dr;
    if (GetSQL(sql, out dr))
    {
      DsProject dsProject = Load(dr);
      buffer = dsProject.Buffer;
      return true;
    }
    else
    {
      buffer = new DdProject();
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
		
		static public DdProject LoadRow(System.Data.SqlClient.SqlDataReader reader)
		{
			DdProject rowBuffer = new DdProject();
			rowBuffer.Clear();
			if (!reader.IsDBNull(idxClientREF)) rowBuffer.ClientREF = reader.GetInt32(idxClientREF);
			if (!reader.IsDBNull(idxCreated)) rowBuffer.Created = reader.GetDateTime(idxCreated);
			if (!reader.IsDBNull(idxDescription)) rowBuffer.Description = reader.GetString(idxDescription);
			if (!reader.IsDBNull(idxId)) rowBuffer.Id = reader.GetInt32(idxId);
			if (!reader.IsDBNull(idxModified)) rowBuffer.Modified = reader.GetDateTime(idxModified);
			if (!reader.IsDBNull(idxModifiedBy)) rowBuffer.ModifiedBy = reader.GetString(idxModifiedBy);
			if (!reader.IsDBNull(idxProjectID)) rowBuffer.ProjectID = reader.GetString(idxProjectID);
			if (!reader.IsDBNull(idxTaskHeadingREF)) rowBuffer.TaskHeadingREF = reader.GetInt32(idxTaskHeadingREF);
			if (!reader.IsDBNull(idxTimestamp)) rowBuffer.Timestamp = GetTimestamp(idxTimestamp, reader);
			if (!reader.IsDBNull(idxTitle)) rowBuffer.Title = reader.GetString(idxTitle);
			return rowBuffer;
		}
  }
  [Serializable]
  public class DsProject
  {
    public DdProject Buffer = new DdProject();

    public bool IsNew;
    public bool IsDeleted;

    public bool modClientREF;
    public bool modDescription;
    public bool modModified;
    public bool modModifiedBy;
    public bool modProjectID;
    public bool modTaskHeadingREF;
    public bool modTitle;

    public object Tag;
    public int RowsAffected;
    public string ResultCode;
    public string ResultMessage;

    public bool Modified()
    {
      return
        modClientREF
     || modDescription
     || modModified
     || modModifiedBy
     || modProjectID
     || modTaskHeadingREF
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
      modClientREF = false;
      modDescription = false;
      modModified = false;
      modModifiedBy = false;
      modProjectID = false;
      modTaskHeadingREF = false;
      modTitle = false;
    }

    public void SetModFlags()
    {
      modClientREF = true;
      modDescription = true;
      modModified = true;
      modModifiedBy = true;
      modProjectID = true;
      modTaskHeadingREF = true;
      modTitle = true;
    }
  }

  [Serializable]
  public class DdProject : ASL.Forms.DdBase
  {
    public int ClientREF { get; set; }
    public string Description { get; set; }
    public string ProjectID { get; set; }
    public int TaskHeadingREF { get; set; }
    public string Title { get; set; }

    public const string ClientREF_N = "ClientREF";
    public const string Description_N = "Description";
    public const string ProjectID_N = "ProjectID";
    public const string TaskHeadingREF_N = "TaskHeadingREF";
    public const string Title_N = "Title";

    public const int Description_L = -1;
    public const int ProjectID_L = 200;
    public const int Title_L = 200;

    public DdProject()
	  : base()
    {
      Clear();
    }

    public DdProject(DdProject original)
	  : base(original)
    {
      ClientREF = original.ClientREF;
      Description = original.Description;
      ProjectID = original.ProjectID;
      TaskHeadingREF = original.TaskHeadingREF;
      Title = original.Title;
    }

    public override void Clear()
    {
      base.Clear();
      ClientREF = 0;
      Description = "";
      ProjectID = "";
      TaskHeadingREF = 0;
      Title = "";
    }

    public override void SetDefaults()
    {
      base.SetDefaults();
      ClientREF = (1);
      Description = string.Empty;
      ProjectID = string.Empty;
      TaskHeadingREF = (1);
      Title = string.Empty;
    }
  }

  [Serializable]
  public class DnProject : System.Collections.Generic.List<DdProject>
  {
    public DnProject() : base() {}
    public DnProject(int xCapacity) : base(xCapacity) {}

    public new DdProject this[int xIndex]
    {
      get { return (DdProject) base[xIndex]; }
      set { base[xIndex] = value; }
    }
  }


}
