// Generated: Sun Jan 27, 2013 10:54:13
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
  public class DaPerson : DbPerson, ASL.ApplicatFieldType.IDaForm_I
#else
  public class DaPerson : DbPerson
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
      public string PersonID;
		}
		public class FetchEntry
		{
			public int hitCount = 1;
			public DdPerson ddPerson;
			public FetchEntry(DdPerson ddPerson) { this.ddPerson = ddPerson; }
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
    public string Credentials
    {
      get { return store.Buffer.Credentials; }

      set 
      { 
        if (value.Length > 200) InvalidateField("Too long", "Person.Credentials");
#if __REALCHANGE__
        if (store.Buffer.Credentials != value)
        {
          store.Buffer.Credentials = value; 
          store.modCredentials = true;
        }
#else
        store.Buffer.Credentials = value; 
        store.modCredentials = true;
#endif
      }
    }
    public string FullName
    {
      get { return store.Buffer.FullName; }

      set 
      { 
        if (value.Length > 200) InvalidateField("Too long", "Person.FullName");
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
    public bool Inactive
    {
      get { return store.Buffer.Inactive; }

      set 
      { 
#if __REALCHANGE__
        if (store.Buffer.Inactive != value)
        {
          store.Buffer.Inactive = value; 
          store.modInactive = true;
        }
#else
        store.Buffer.Inactive = value; 
        store.modInactive = true;
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
        if (value.Length > 50) InvalidateField("Too long", "Person.ModifiedBy");
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
    public string PersonID
    {
      get { return store.Buffer.PersonID; }

      set 
      { 
        if (value.Length > 200) InvalidateField("Too long", "Person.PersonID");
#if __REALCHANGE__
        if (store.Buffer.PersonID != value)
        {
          store.Buffer.PersonID = value; 
          store.modPersonID = true;
        }
#else
        store.Buffer.PersonID = value; 
        store.modPersonID = true;
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
        if (value.Length > 200) InvalidateField("Too long", "Person.Title");
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
      items["Comment"] = Comment;
      items["Created"] = Created;
      items["Credentials"] = Credentials;
      items["FullName"] = FullName;
      items["Id"] = Id;
      items["Inactive"] = Inactive;
      items["Modified"] = Modified;
      items["ModifiedBy"] = ModifiedBy;
      items["PersonID"] = PersonID;
      items["Title"] = Title;
      return items;
    }

    public void SetFromList(SortedList<string, object> items)
    {
      if (items.ContainsKey("Comment")) Comment= (string)items["Comment"];
      if (items.ContainsKey("Credentials")) Credentials= (string)items["Credentials"];
      if (items.ContainsKey("FullName")) FullName= (string)items["FullName"];
      if (items.ContainsKey("Inactive")) Inactive= (bool)items["Inactive"];
      if (items.ContainsKey("Modified")) Modified= (DateTime)items["Modified"];
      if (items.ContainsKey("ModifiedBy")) ModifiedBy= (string)items["ModifiedBy"];
      if (items.ContainsKey("PersonID")) PersonID= (string)items["PersonID"];
      if (items.ContainsKey("Title")) Title= (string)items["Title"];
    }
#endif
//??EndExpand 1/27/2013 10:54:13 AM
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
			DnPerson dnPerson = FillByParent(parentREF);
			ArrayList choices = new ArrayList();
			IEnumerator en = dnPerson.GetEnumerator();
			DdPerson ddPerson;
			while (en.MoveNext())
			{
				ddPerson = (DdPerson)en.Current;
				choices.Add(ddPerson.Id.ToString() + "," + ddPerson.Description);
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

    private DsPerson store = new DsPerson();

    public DaPerson(SQL.DBConnection dbConnection) : base(dbConnection)
    {
      store.ClearAll();
    }

    public void Clear()
    {
      store.ClearAll();
    }

    public bool GetByPK(string PersonID)
    {
      store.Buffer.PersonID = PersonID;
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

    public void SetBuffer(DdPerson buffer)
    {
      store.Buffer = buffer;
    }

    public bool _IsModified
    {
      get { return store.Modified(); }
    }

    public DdPerson GetBuffer()
    {
      return store.Buffer; 
    }

    public void SetModFlags() { store.SetModFlags(); }
    public void ClearModFlags() { store.ClearModFlags(); }
    public void SetDefaults() { store.Buffer.SetDefaults(); }

    #region fetch cache
#if __FETCHCACHE__
		public bool FetchByPK(string PersonID)
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
      key.PersonID = PersonID;
			if (fetchTable.Contains(key))
			{
				_hitCount++;
				ent = (FetchEntry)fetchTable[key];
				SetBuffer(ent.ddPerson);
				if (ent.hitCount < int.MaxValue) ent.hitCount++;
				return true;
			}
			if (missTable.Contains(key)) return false;
			
			_ioCount++;
      store.Buffer.PersonID = PersonID;
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
		public DnPerson Fill()
		{
			string sqlWhere = "Id >= 100";
			return Fill(sqlWhere, "PersonID", 0, true);
		}
		#endregion extend
  }


  public class DbPerson : ASL.SQL.TableDataObject
  {
    private const int idxComment = 0;
    private const int idxCreated = 1;
    private const int idxCredentials = 2;
    private const int idxFullName = 3;
    private const int idxId = 4;
    private const int idxInactive = 5;
    private const int idxModified = 6;
    private const int idxModifiedBy = 7;
    private const int idxPersonID = 8;
    private const int idxTimestamp = 9;
    private const int idxTitle = 10;
    private const int idxNUMCOLS = 11;
    // Column names
    static readonly protected string[] sqlCols =
    {
     "[Comment]", "[Created]", "[Credentials]", "[FullName]", "[Id]", "[Inactive]"
     , "[Modified]", "[ModifiedBy]", "[PersonID]", "[Timestamp]", "[Title]"
    };
    static public string SqlColumnList { get { return string.Join(",", sqlCols); } }
    static public string[] SqlCols { get { return sqlCols; } }

    // set database connection and other initial values
    public DbPerson(SQL.DBConnection dbConnection)
    {
      base.dbConnection = dbConnection;
      tableName = "Person";
      identityColumnName = "Id";
      sqlColumns = string.Join(",",  sqlCols);
    }

		public string TableName { get { return tableName; } set { tableName = value; } }

    public bool GetById(int Id, out DdPerson buffer)
    {
      DsPerson dsPerson = new DsPerson();
      dsPerson.Buffer.Id = Id;
      if (!GetById(ref dsPerson)) 
      {
        buffer = new DdPerson();
        return false;
      }
      buffer = dsPerson.Buffer;
      return true;
    }

    public bool GetById(ref DsPerson xStr)
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
        string PersonID
      , out DdPerson buffer)
    {
      DsPerson dsPerson = new DsPerson();
      dsPerson.Buffer.PersonID = PersonID;
      if (!GetByPK(ref dsPerson))
      {
        buffer = new DdPerson();
        return false;
      }
      buffer = dsPerson.Buffer;
      return true;
    }

    public bool GetByPK(ref DsPerson xStr)
    {
      string sql = "SELECT " + sqlColumns
      + " FROM " + tableName + NOLOCKSQL
      + " WHERE PersonID = " + TXT.q1(xStr.Buffer.PersonID);
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

    public bool UpdateById(ref DsPerson xStr)
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

    public bool UpdateByPK(ref DsPerson xStr)
    {
      int rowsUpdated = 0;
      if (xStr.Modified())
      {
        string sql = "UPDATE " + tableName + " SET " + BuildUpdateSQL(xStr) + " WHERE"
      + " PersonID = " + TXT.q1(xStr.Buffer.PersonID);
        if(!UpdateSQL(sql)) return false;
        rowsUpdated = _rowsAffected;
      }
      bool ok = GetByPK(ref xStr);
      _rowsAffected = rowsUpdated;
      return ok;
    }

    public bool DeleteByPK(
        string PersonID)
    {
      string sql = "DELETE FROM " + tableName + " WHERE"
      + " PersonID = " + TXT.q1(PersonID);
      return DeleteSQL(sql);
    }

    public bool DeleteByPK(ref DsPerson xStr)
    {
      string sql = "DELETE FROM " + tableName + " WHERE"
      + " PersonID = " + TXT.q1(xStr.Buffer.PersonID);
      return DeleteSQL(sql);
    }
    public bool Insert(ref DsPerson xStr)
    {
      int Id;
      string sql = BuildInsertSQL(xStr);
      if (!InsertIdSQL(sql, out Id)) return false;
      xStr.Buffer.Id = Id;
      return GetById(ref xStr);
    }

    public bool GetBySql(string sqlWhere, ref DsPerson xStr)
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


    public DnPerson Fill(string xWhere, string xOrder, int xTop, bool xNoLock)
    {
      System.Data.DataTable dt = FillDataTable(xWhere, xOrder, xTop, xNoLock);
      DnPerson PersonList = new DnPerson(dt.Rows.Count);
      foreach(System.Data.DataRow adr in dt.Rows)
      {
        PersonList.Add(Load(adr).Buffer);
      }
      return PersonList;
    }

    static public DsPerson Load(System.Data.DataRow dr)
    {
      DsPerson tStr = new DsPerson();
      tStr.ClearBuffer();
      if (dr[idxComment] != System.DBNull.Value) tStr.Buffer.Comment = (string)dr[idxComment];
      if (dr[idxCreated] != System.DBNull.Value) tStr.Buffer.Created = (DateTime)dr[idxCreated];
      if (dr[idxCredentials] != System.DBNull.Value) tStr.Buffer.Credentials = (string)dr[idxCredentials];
      if (dr[idxFullName] != System.DBNull.Value) tStr.Buffer.FullName = (string)dr[idxFullName];
      if (dr[idxId] != System.DBNull.Value) tStr.Buffer.Id = (int)dr[idxId];
      if (dr[idxInactive] != System.DBNull.Value) tStr.Buffer.Inactive = (bool)dr[idxInactive];
      if (dr[idxModified] != System.DBNull.Value) tStr.Buffer.Modified = (DateTime)dr[idxModified];
      if (dr[idxModifiedBy] != System.DBNull.Value) tStr.Buffer.ModifiedBy = (string)dr[idxModifiedBy];
      if (dr[idxPersonID] != System.DBNull.Value) tStr.Buffer.PersonID = (string)dr[idxPersonID];
      if (dr[idxTimestamp] != System.DBNull.Value) tStr.Buffer.Timestamp = (byte[])dr[idxTimestamp];
      if (dr[idxTitle] != System.DBNull.Value) tStr.Buffer.Title = (string)dr[idxTitle];
      return tStr;
    }

    public string BuildInsertSQL(DsPerson xStr)
    {
      SQL.SqlCommandBuilder sc = new SQL.SqlCommandBuilder(
        SQL.sqlVerb.Insert, tableName);
      if (xStr.modComment)
        sc.AddColumn(sqlCols[idxComment], xStr.Buffer.Comment);
      if (xStr.modCredentials)
        sc.AddColumn(sqlCols[idxCredentials], xStr.Buffer.Credentials);
      if (xStr.modFullName)
        sc.AddColumn(sqlCols[idxFullName], xStr.Buffer.FullName);
      if (xStr.modInactive)
        sc.AddColumn(sqlCols[idxInactive], xStr.Buffer.Inactive);
      if (xStr.modModified)
        sc.AddColumn(sqlCols[idxModified], xStr.Buffer.Modified);
      if (xStr.modModifiedBy)
        sc.AddColumn(sqlCols[idxModifiedBy], xStr.Buffer.ModifiedBy);
      if (xStr.modPersonID)
        sc.AddColumn(sqlCols[idxPersonID], xStr.Buffer.PersonID);
      if (xStr.modTitle)
        sc.AddColumn(sqlCols[idxTitle], xStr.Buffer.Title);
      return sc.CommandText;
    }

    public string BuildUpdateSQL(DsPerson xStr)
    {
      SQL.SqlCommandBuilder sc = new SQL.SqlCommandBuilder(SQL.sqlVerb.Update);
      if (xStr.modComment)
        sc.AddColumn(sqlCols[idxComment], xStr.Buffer.Comment);
      if (xStr.modCredentials)
        sc.AddColumn(sqlCols[idxCredentials], xStr.Buffer.Credentials);
      if (xStr.modFullName)
        sc.AddColumn(sqlCols[idxFullName], xStr.Buffer.FullName);
      if (xStr.modInactive)
        sc.AddColumn(sqlCols[idxInactive], xStr.Buffer.Inactive);
      if (xStr.modModified)
        sc.AddColumn(sqlCols[idxModified], xStr.Buffer.Modified);
      if (xStr.modModifiedBy)
        sc.AddColumn(sqlCols[idxModifiedBy], xStr.Buffer.ModifiedBy);
      if (xStr.modPersonID)
        sc.AddColumn(sqlCols[idxPersonID], xStr.Buffer.PersonID);
      if (xStr.modTitle)
        sc.AddColumn(sqlCols[idxTitle], xStr.Buffer.Title);
      return sc.ColumnList;
    }

    //  Index = IX_Person
    public bool GetBy_IX_Person(
      string PersonID
    , out DdPerson buffer)
  {
    string sql = "SELECT " + sqlColumns
    + " FROM " + tableName + NOLOCKSQL
    + " WHERE PersonID = " + TXT.q1(PersonID);
    System.Data.DataRow dr;
    if (GetSQL(sql, out dr))
    {
      DsPerson dsPerson = Load(dr);
      buffer = dsPerson.Buffer;
      return true;
    }
    else
    {
      buffer = new DdPerson();
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
		
		static public DdPerson LoadRow(System.Data.SqlClient.SqlDataReader reader)
		{
			DdPerson rowBuffer = new DdPerson();
			rowBuffer.Clear();
			if (!reader.IsDBNull(idxComment)) rowBuffer.Comment = reader.GetString(idxComment);
			if (!reader.IsDBNull(idxCreated)) rowBuffer.Created = reader.GetDateTime(idxCreated);
			if (!reader.IsDBNull(idxCredentials)) rowBuffer.Credentials = reader.GetString(idxCredentials);
			if (!reader.IsDBNull(idxFullName)) rowBuffer.FullName = reader.GetString(idxFullName);
			if (!reader.IsDBNull(idxId)) rowBuffer.Id = reader.GetInt32(idxId);
			if (!reader.IsDBNull(idxInactive)) rowBuffer.Inactive = reader.GetBoolean(idxInactive);
			if (!reader.IsDBNull(idxModified)) rowBuffer.Modified = reader.GetDateTime(idxModified);
			if (!reader.IsDBNull(idxModifiedBy)) rowBuffer.ModifiedBy = reader.GetString(idxModifiedBy);
			if (!reader.IsDBNull(idxPersonID)) rowBuffer.PersonID = reader.GetString(idxPersonID);
			if (!reader.IsDBNull(idxTimestamp)) rowBuffer.Timestamp = GetTimestamp(idxTimestamp, reader);
			if (!reader.IsDBNull(idxTitle)) rowBuffer.Title = reader.GetString(idxTitle);
			return rowBuffer;
		}
  }
  [Serializable]
  public class DsPerson
  {
    public DdPerson Buffer = new DdPerson();

    public bool IsNew;
    public bool IsDeleted;

    public bool modComment;
    public bool modCredentials;
    public bool modFullName;
    public bool modInactive;
    public bool modModified;
    public bool modModifiedBy;
    public bool modPersonID;
    public bool modTitle;

    public object Tag;
    public int RowsAffected;
    public string ResultCode;
    public string ResultMessage;

    public bool Modified()
    {
      return
        modComment
     || modCredentials
     || modFullName
     || modInactive
     || modModified
     || modModifiedBy
     || modPersonID
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
      modComment = false;
      modCredentials = false;
      modFullName = false;
      modInactive = false;
      modModified = false;
      modModifiedBy = false;
      modPersonID = false;
      modTitle = false;
    }

    public void SetModFlags()
    {
      modComment = true;
      modCredentials = true;
      modFullName = true;
      modInactive = true;
      modModified = true;
      modModifiedBy = true;
      modPersonID = true;
      modTitle = true;
    }
  }

  [Serializable]
  public class DdPerson : ASL.Forms.DdBase
  {
    public string Comment { get; set; }
    public string Credentials { get; set; }
    public string FullName { get; set; }
    public bool Inactive { get; set; }
    public string PersonID { get; set; }
    public string Title { get; set; }

    public const string Comment_N = "Comment";
    public const string Credentials_N = "Credentials";
    public const string FullName_N = "FullName";
    public const string Inactive_N = "Inactive";
    public const string PersonID_N = "PersonID";
    public const string Title_N = "Title";

    public const int Comment_L = -1;
    public const int Credentials_L = 200;
    public const int FullName_L = 200;
    public const int PersonID_L = 200;
    public const int Title_L = 200;

    public DdPerson()
	  : base()
    {
      Clear();
    }

    public DdPerson(DdPerson original)
	  : base(original)
    {
      Comment = original.Comment;
      Credentials = original.Credentials;
      FullName = original.FullName;
      Inactive = original.Inactive;
      PersonID = original.PersonID;
      Title = original.Title;
    }

    public override void Clear()
    {
      base.Clear();
      Comment = "";
      Credentials = "";
      FullName = "";
      Inactive = false;
      PersonID = "";
      Title = "";
    }

    public override void SetDefaults()
    {
      base.SetDefaults();
      Comment = string.Empty;
      Credentials = string.Empty;
      FullName = string.Empty;
      Inactive = false;
      PersonID = string.Empty;
      Title = string.Empty;
    }
  }

  [Serializable]
  public class DnPerson : System.Collections.Generic.List<DdPerson>
  {
    public DnPerson() : base() {}
    public DnPerson(int xCapacity) : base(xCapacity) {}

    public new DdPerson this[int xIndex]
    {
      get { return (DdPerson) base[xIndex]; }
      set { base[xIndex] = value; }
    }
  }


}
