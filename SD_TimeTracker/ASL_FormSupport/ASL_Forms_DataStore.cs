using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using Hap = HtmlAgilityPack;

namespace ASL.Forms
{
  public partial class DataStore
  {
    public const int NoParam = -1;

    static public string UserName { get; private set; }
    static public string ProductName
    {
      get
      {
        return "Project Manager (" + Release + ")";
      }
    }
    static public string ProductVersion { get; set; }

    static public DdUserExt UserInfo;

    static public DropDownItemList UserList;

    #region database

    public const int NullId = 1;

    static public ASL.SQL.DBConnection CxConnection { get; private set; }
    static private string lastCxConnectionString;
    static public ASL.SQL.DBConnection DbConnection { get; private set; }
    static private string lastDbConnectionString;

    static public void ConnectToConfig(string dataSource, bool readOnly = false)
    {
      UserName = Environment.UserName;
      ASL.Run.Log.UseExceptionLogger = false;

      // get configuration database parameters and connect to DB        
      XmlDocument xdoc = new XmlDocument();
      xdoc.Load(@"FSA042.params.xml");
      XmlElement xDatabase = (XmlElement)xdoc.DocumentElement.SelectSingleNode("Database");
      string userAtt = (readOnly) ? "roUsername" : "username";
      string dbUserID = DecryptPW(xDatabase.GetAttribute(userAtt), 29);
      string dbPassword = DecryptPW(xDatabase.GetAttribute("password"), 29);
      SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder();
      csb.DataSource = dataSource;
      csb.InitialCatalog = "FSA042_Configuration";
      csb.UserID = dbUserID;
      csb.Password = dbPassword;
      csb.IntegratedSecurity = false;
      lastCxConnectionString = csb.ConnectionString;
      CxConnection = new ASL.SQL.DBConnection(lastCxConnectionString);
    }

    static public ASL.SQL.DBConnection CloneCxConnection()
    {
      return new ASL.SQL.DBConnection(lastCxConnectionString);
    }

    static public void OpenDatabase(string dataSource, bool readOnly = false)
    {
      UserName = Environment.UserName;
      ASL.Run.Log.UseExceptionLogger = false;

      // get configuration database parameters and connect to DB        
      XmlDocument xdoc = new XmlDocument();
      xdoc.Load(@"FSA042.params.xml");
      XmlElement xDatabase = (XmlElement)xdoc.DocumentElement.SelectSingleNode("Database");
      string userAtt = (readOnly) ? "roUsername" : "username";
      string dbUserID = DecryptPW(xDatabase.GetAttribute(userAtt), 29);
      string dbPassword = DecryptPW(xDatabase.GetAttribute("password"), 29);
      SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder();
      csb.DataSource = dataSource;
      csb.InitialCatalog = "SDPM01_Master";
      csb.UserID = dbUserID;
      csb.Password = dbPassword;
      csb.IntegratedSecurity = false;
      lastDbConnectionString = csb.ConnectionString;
      DbConnection = new ASL.SQL.DBConnection(lastDbConnectionString);
    }

    static public void Close()
    {
      lastDbConnectionString = null;
      ProductVersion = null;
      if (DbConnection != null)
      {
        DbConnection.Connection.Close();
        DbConnection = null;
      }
    }

    static public void ReConnect()
    {// used only in FSA_ImportTxt...
      DbConnection = new ASL.SQL.DBConnection(lastDbConnectionString);
    }

    static public ASL.SQL.DBConnection CloneDbConnection()
    {
      return new ASL.SQL.DBConnection(lastDbConnectionString);
    }

    static public UInt64 ConvertTimestamp(byte[] timestamp)
    {
      if (timestamp == null) return 0;
      byte[] t1 = new byte[8];
      Array.Copy(timestamp, 0, t1, 8 - timestamp.Length, timestamp.Length);
      if (BitConverter.IsLittleEndian) Array.Reverse(t1);
      return BitConverter.ToUInt64(t1, 0);
    }

    static public string NotDbNull(object v)
    {
      return ((v == System.DBNull.Value) ? string.Empty : (string)v);
    }

    static public DataTable ExecuteQuery(string sql)
    {
      SqlConnection sqx = DbConnection.Connection;
      SqlCommand sqc = new SqlCommand(sql, sqx);
      SqlDataAdapter da = new SqlDataAdapter(sqc);
      DataTable dt = new DataTable();
      da.Fill(dt);
      return dt;
    }

    static public int ExecuteNonQuery(string sql)
    {
      using (SqlCommand sqc = new SqlCommand(sql, DataStore.DbConnection.Connection))
      {
        return sqc.ExecuteNonQuery();
      }
    }

    static public DaPickList OpenPickList()
    {
      return new DaPickList(DbConnection);
    }

    #endregion

    private string NE(object o)
    {
      return (o == null) ? string.Empty : (string)o;
    }

    static public bool IsHtml(string text)
    {
      return ((text != null) && (text.StartsWith("<!DOCTYPE HTML") || text.StartsWith("<HTML")));
    }

    static public string AsHtml(string text)
    {
      return "<HTML><HEAD/><BODY><P>" + text + "</P></BODY></HTML>";
    }

    static public string GetTextFromHtml(string html)
    {
      try
      {
        Hap.HtmlDocument hdoc = new Hap.HtmlDocument();
        hdoc.LoadHtml(html);
        Hap.HtmlNode hDocNode = hdoc.DocumentNode;
        Hap.HtmlNode hHtml = hDocNode.Element("html");
        Hap.HtmlNode hBody = hHtml.Element("body");
        return hBody.InnerText;
      }
      catch
      {
        return string.Empty;
      }
    }

    private const int maxTextLength = 70;
    static public string TruncateText(string text)
    {
      return TruncateText(text, maxTextLength);
    }
    static public string TruncateText(string text, int maxLength)
    {
      const string ellipsis = "...";
      char[] delimiters = new char[] { ' ', ',', '.', ';', ':', '?' };
      if (text == null) return string.Empty;
      if (text.Length <= maxLength) return text;
      int i0 = text.LastIndexOfAny(delimiters, maxLength - ellipsis.Length);
      if (i0 >= 0) return text.Substring(0, i0) + ellipsis;
      return text.Substring(0, maxLength - ellipsis.Length) + ellipsis;
    }

    static private long serialSecondKeyCounter = 0;
    static public string GetSerialSecondKey()
    {
      serialSecondKeyCounter += 1;
      TimeSpan t = DateTime.Now - new DateTime(2012, 11, 01);
      return string.Format(@"{0:#00'.'000'.'00}-{1}", t.TotalSeconds, serialSecondKeyCounter);
    }

    #region data dictionary

    //static public DefineAPI DDef;
    //static public string DataDictionaryFileName;
    //static private string dataDefNameDebugPath = @"Q:\EE\FSA\FSA_Runtime\";

    //static public void LoadDataDictionary()
    //{
    //  // load data dictionary for FSA
    //  string ddFileName = Path.ChangeExtension(ProductVersion, ".datadef.0.xml");
    //  DataDictionaryFileName = Path.Combine(dataDefNameDebugPath, ddFileName);
    //  if (!File.Exists(DataDictionaryFileName))
    //    DataDictionaryFileName = Path.Combine(ASL.Run.Config.ExecutablePath, ddFileName);
    //  DDef = new DefineAPI();
    //  DDef.Load(DataDictionaryFileName, "FSA");
    //}

    //static public void SaveDataDictionary()
    //{
    //  DDef.Save();
    //}
    #endregion

    #region security

    static public void LoadStaticLists()
    {
      LoadUserList();
    }

    static public void LoadUserList()
    {
      UserList = new DropDownItemList();
      DaUser daUser = new DaUser(DbConnection);
      DnUser list = daUser.Fill("Id>1", "UserID", 0, true);
      UserList = new DropDownItemList(list.Count);
      UserList.Add(1, string.Empty, string.Empty);
      foreach (DdUser dd in list)
        UserList.Add(dd.Id, dd.UserID, dd.UserID);
    }

    static public string GeneratePassword()
    {
      // generate password
      char[] vowels = new char[] { 'A', 'E', 'I', 'O', 'U', 'Y' };
      char[] consonants = new char[] 
				{ 
					'B', 'C', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 
					'N', 'P', 'Q', 'R', 'S', 'T', 'V', 'W', 'X', 'Z' 
				};
      System.Random rand1 = new Random();
      string password = string.Empty;
      for (int i = 0; i < 4; i++)
      {
        int v;
        v = rand1.Next(0, consonants.Length - 1);
        password += consonants[v];
        v = rand1.Next(0, vowels.Length - 1);
        password += vowels[v];
      }
      return password.ToLower();
    }

    static public long ComputePasswordHash(string password)
    {
      long passKey = 1;
      if (password.Length > 0)
      {
        int k = 5;//64 / password.Length + 1;
        int s = 0;
        foreach (char cc in password.ToCharArray())
        {
          long x = passKey;
          x ^= cc;
          x <<= s;
          s += k;
          passKey ^= x;
        }
      }
      return passKey;
    }

    static public int ComputeAccessKey(DateTime t0)
    {
      return (19 * int.Parse(t0.ToString("ssddHHmm")) + 13) & 0xFFFF;
    }

    #endregion

    #region password encryption/decryption

    public static string EncryptPW(string Xtext, int Xkey)
    {
      //string cx = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
      string cx = @"0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz#$_-";
      int nx = cx.Length;
      char[] cc = Xtext.ToCharArray();
      char[] cy = new char[cc.Length + 1];

      int x = (Xkey * 13) + 107;
      for (int ix = 0; ix < cc.Length - 1; ix++)
        x = (x + (int)cc[ix]) % nx;
      cy[cy.Length - 1] = cx[x];
      x += Xkey;

      int t;
      for (int ix = 0; ix < cc.Length; ix++)
      {
        t = cx.IndexOf(cc[ix]);
        if (t == -1) throw (new Exception(
@"Invalid character in password. Only a-z, A-Z, 0-9 and #$_- allowed"));
        t = (t + x) % nx;
        cy[ix] = (char)cx[t];
        x = ((x + 13) * 119) % 10000;
      }
      return new string(cy);
    }

    public static string DecryptPW(string Xtext, int Xkey)
    {
      //string cx = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
      string cx = @"0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz#$_-";
      int nx = cx.Length;
      char[] cy = Xtext.ToCharArray();
      char[] cc = new Char[cy.Length - 1];

      int x = cx.IndexOf(cy[cy.Length - 1]);
      x += Xkey;

      int t;
      for (int ix = 0; ix < cc.Length; ix++)
      {
        t = cx.IndexOf(cy[ix]);
        if (t == -1) throw (new Exception("Invalid character in string"));
        t -= (x % nx);
        if (t < 0) t += nx;
        cc[ix] = (char)cx[t];
        x = ((x + 13) * 119) % 10000;
      }
      return new string(cc);
    }

    #endregion password encryption/decryption

  }

  public class DbInfo
  {
    public int Id { get; set; }
    public string ServerName { get; set; }
    public string DatabaseName { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Description { get; set; }
    public string Comments { get; set; }
    public DateTime Created { get; set; }
    public DateTime Modified { get; set; }
    public string ModifiedBy { get; set; }
    public string Timestamp { get; set; }
  }

}
