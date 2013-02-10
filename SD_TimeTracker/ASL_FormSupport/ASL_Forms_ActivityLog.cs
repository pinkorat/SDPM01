using System;
using System.Data;
using System.Data.SqlClient;
using ASL;

namespace ASL.Forms
{
  public class ActivityLog
  {
    static public void AddLogEntry(string state, string content = null)
    {
      return;
      try
      {
        using (ASL.SQL.DBConnection cxconn = DataStore.CloneCxConnection())
        using (SqlCommand sqc
          = new SqlCommand("select * from [ActivityLog] where Id = 1", cxconn.Connection))
        {
          SqlDataAdapter da = new SqlDataAdapter(sqc);
          SqlCommandBuilder scb = new SqlCommandBuilder(da);
          DataTable dt = new DataTable();
          da.Fill(dt);
          DataRow dr = dt.Rows.Add();
          dr["State"] = state;
          if (content != null) dr["Content"] = content;
          dr["AppVersion"] = DataStore.AssemblyName + "#" + DataStore.AssemblyVersion;
          dr["MachineName"] = Environment.MachineName;
          dr["UserDomainName"] = Environment.UserDomainName;
          dr["UserName"] = Environment.UserName;
          if (state == "connect")
          {
            dr["CurrentDirectory"] = Environment.CurrentDirectory;
            dr["CommandLine"] = Environment.CommandLine;
            dr["ConfigConnectionString"] = DataStore.CxConnection.Connection.ConnectionString;
            if (DataStore.DbConnection != null)
              dr["PlantConnectionString"] = DataStore.DbConnection.Connection.ConnectionString;
            dr["OSVersion"] = Environment.OSVersion.ToString();
          }
          scb.GetInsertCommand();
          da.Update(dt);
        }
      }
      catch (Exception exc)
      {
        throw new AppEx(exc, state); ;
      }
    }
  }
}
